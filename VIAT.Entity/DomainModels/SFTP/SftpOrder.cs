using System;
using System.Collections.Generic;
using System.Text;

namespace VIAT.Entity.DomainModels.SFTP
{
    public class SftpOrder
    {
        public string order_no { get; set; }
        public string cust_id { get; set; }
        public string cust_name { get; set; }
        public string prod_id { get; set; }
        public string prod_cname { get; set; }
        public string qty { get; set; }
        public string order_date { get; set; }
        public string remarks { get; set; }
    }
}
