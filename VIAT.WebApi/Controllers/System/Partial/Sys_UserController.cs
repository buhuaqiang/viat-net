﻿
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using VIAT.Core.CacheManager;
using VIAT.Core.Configuration;
using VIAT.Core.Controllers.Basic;
using VIAT.Core.DBManager;
using VIAT.Core.EFDbContext;
using VIAT.Core.Enums;
using VIAT.Core.Extensions;
using VIAT.Core.Filters;
using VIAT.Core.Infrastructure;
using VIAT.Core.ManageUser;
using VIAT.Core.ObjectActionValidator;
using VIAT.Core.Services;
using VIAT.Core.Utilities;
using VIAT.Entity.AttributeManager;
using VIAT.Entity.DomainModels;
using VIAT.System.IRepositories;
using VIAT.System.IServices;
using VIAT.System.Repositories;

namespace VIAT.System.Controllers
{
    [Route("api/User")]
    public partial class Sys_UserController
    {
        private ISys_UserRepository _userRepository;
        private ICacheService _cache;
        [ActivatorUtilitiesConstructor]
        public Sys_UserController(
               ISys_UserService userService,
               ISys_UserRepository userRepository,
               ICacheService cahce
              )
          : base(userService)
        {
            _userRepository = userRepository;
            _cache = cahce;
        }

        [HttpPost, HttpGet, Route("login"), AllowAnonymous]
        [ObjectModelValidatorFilter(ValidatorModel.Login)]
        public async Task<IActionResult> Login([FromBody] LoginInfo loginInfo, bool bverificationCode)
        {
            return Json(await Service.Login(loginInfo, bverificationCode));
        }


        [HttpPost, HttpGet, Route("getChangeUserImformation"), AllowAnonymous]
        public async Task<IActionResult> getChangeUserImformation(string sChangeUserNo)
        {
            //模拟登录
            return Json(await Service.getChangeUserImformation(sChangeUserNo));
        }

        private readonly ConcurrentDictionary<int, object> _lockCurrent = new ConcurrentDictionary<int, object>();
        [HttpPost, Route("replaceToken")]
        public IActionResult ReplaceToken()
        {
            WebResponseContent responseContent = new WebResponseContent();
            string error = "";
            string key = $"rp:Token:{UserContext.Current.UserId}";
            UserInfo userInfo = null;
            try
            {
                //如果5秒内替换过token,直接使用最新的token(防止一个页面多个并发请求同时替换token导致token错位)
                if (_cache.Exists(key))
                {
                    return Json(responseContent.OK(null, _cache.Get(key)));
                }
                var _obj = _lockCurrent.GetOrAdd(UserContext.Current.UserId, new object() { });
                lock (_obj)
                {
                    if (_cache.Exists(key))
                    {
                        return Json(responseContent.OK(null, _cache.Get(key)));
                    }
                    string requestToken = HttpContext.Request.Headers[AppSetting.TokenHeaderName];
                    requestToken = requestToken?.Replace("Bearer ", "");

                    if (JwtHelper.IsExp(requestToken)) return Json(responseContent.Error("Token已过期!"));

                    int userId = UserContext.Current.UserId;

                    userInfo = _userRepository.FindAsIQueryable(x => x.User_Id == userId).Select(
                             s => new UserInfo()
                             {
                                 User_Id = userId,
                                 UserName = s.UserName,
                                 UserTrueName = s.UserTrueName,
                                 Role_Id = s.Role_Id,
                                 RoleName = s.RoleName,
                                 ClientID = UserContext.Current.ClientID,
                                 ClientUserName = UserContext.Current.ClientUserName??"",
                                 ClientTrueUserName = UserContext.Current.ClientTrueUserName??"",
                                 TerritoryId = UserContext.Current.TerritoryId??""
                             }).FirstOrDefault();

                    if (userInfo == null) return Json(responseContent.Error("未查到用户信息!"));

                    string token = JwtHelper.IssueJwt(userInfo);
                    //移除当前缓存
                    _cache.Remove(userId.GetUserIdKey());
                    //只更新的token字段
                    _userRepository.Update(new Sys_User() { User_Id = userId, Token = token }, x => x.Token, true);
                    //添加一个5秒缓存
                    _cache.Add(key, token, 5);
                    responseContent.OK(null, token);
                }
            }
            catch (Exception ex)
            {
                error = ex.Message + ex.StackTrace;
                responseContent.Error("token替换异常");
            }
            finally
            {
                _lockCurrent.TryRemove(UserContext.Current.UserId, out object val);
                string _message = $"用户{userInfo?.User_Id}_{userInfo?.UserTrueName},({(responseContent.Status ? "token替换成功": "token替换失败")})";
                Logger.Info(LoggerType.ReplaceToeken, _message, null, error);
            }
            return Json(responseContent);
        }


        [HttpPost, Route("modifyPwd")]
        [ApiActionPermission]
        //通过ObjectGeneralValidatorFilter校验参数，不再需要if esle判断OldPwd与NewPwd参数
        [ObjectGeneralValidatorFilter(ValidatorGeneral.OldPwd, ValidatorGeneral.NewPwd)]
        public async Task<IActionResult> ModifyPwd(string oldPwd, string newPwd)
        {
            return Json(await Service.ModifyPwd(oldPwd, newPwd));
        }

        [HttpPost, Route("getCurrentUserInfo")]
        public async Task<IActionResult> GetCurrentUserInfo()
        {
            return Json(await Service.GetCurrentUserInfo());
        }

        //只能超级管理员才能修改密码
        //2020.08.01增加修改密码功能
        [HttpPost, Route("modifyUserPwd"), ApiActionPermission(ActionRolePermission.SuperAdmin)]
        public IActionResult ModifyUserPwd(string password, string userName)
        {
            WebResponseContent webResponse = new WebResponseContent();
            if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(userName))
            {
                return Json(webResponse.Error("参数不完整"));
            }
            if (password.Length < 6) return Json(webResponse.Error("密码长度不能少于6位"));

            ISys_UserRepository repository = Sys_UserRepository.Instance;
            Sys_User user = repository.FindFirst(x => x.UserName == userName);
            if (user == null)
            {
                return Json(webResponse.Error("用户不存在"));
            }
            user.UserPwd = password.EncryptDES(AppSetting.Secret.User);
            repository.Update(user, x => new { x.UserPwd }, true);
            //如果用户在线，强制下线
            UserContext.Current.LogOut(user.User_Id);
            return Json(webResponse.OK("密码修改成功"));
        }

        /// <summary>
        /// 2020.06.15增加登陆验证码
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("getVierificationCode"), AllowAnonymous]
        public IActionResult GetVierificationCode()
        {
            string code = VierificationCode.RandomText();
            var data = new
            {
                img = VierificationCode.CreateBase64Imgage(code),
                uuid = Guid.NewGuid(),
                code = code
            };
            HttpContext.GetService<IMemoryCache>().Set(data.uuid.ToString(), code, new TimeSpan(0, 5, 0));
            return Json(data);
        }

        //[ApiActionPermission]
        [HttpGet, Route("GetLevelDetail")]
        public IActionResult GetLevelDetail(string emp_dbid)
        {
            return Json(Service.GetLevelDetail(emp_dbid));
        }
    }
}
