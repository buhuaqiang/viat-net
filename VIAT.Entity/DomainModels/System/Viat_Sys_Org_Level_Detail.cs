﻿using System;
using System.Collections.Generic;
using System.Text;

namespace VIAT.Entity.DomainModels.System
{
    public class Viat_Sys_Org_Level_Detail
    {
        public Guid Sysorgdetail_Dbid { get; set; }
        public int Dbid { get; set; }
        public string Entity { get; set; }
        public string Division { get; set; }
        public Guid Sysorg_dbid { get; set; }
        public Guid Emp_Dbid { get; set; }
        public string Org_Type { get; set; }
        public string Org_Id { get; set; }
        public int Org_Level { get; set; }
        public string Director_Org_Id { get; set; }
    }
}
