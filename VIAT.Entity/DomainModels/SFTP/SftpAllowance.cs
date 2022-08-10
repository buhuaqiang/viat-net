using System;
using System.Collections.Generic;
using System.Text;

namespace VIAT.Entity.DomainModels.SFTP
{
    public class SftpAllowance
    {
        public string start_date { get; set; }
        public string created_date { get; set; }
        public string cust_id { get; set; }
        public string cust_name { get; set; }
        public string prod_id { get; set; }
        public string prod_ename { get; set; }
        public string trx_date_e { get; set; }
        public string trx_date { get; set; }
        public string old_net_price { get; set; }
        public string new_net_price { get; set; }
        public string adj_qty { get; set; }
        public string act_allw_amt { get; set; }
        public string adj_date { get; set; }
        public string payment_type { get; set; }
        public string adj_seq { get; set; }
    }
}
