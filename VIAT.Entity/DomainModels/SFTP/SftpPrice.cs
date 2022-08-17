using System;
using System.Collections.Generic;
using System.Text;

namespace VIAT.Entity.DomainModels.SFTP
{
    public class SftpPrice
    {
        public string seq_no { get; set; }
        public string cust_id { get; set; }
        public string prod_id { get; set; }
        public string start_date { get; set; }
        public string end_date { get; set; }
        public string invoice_price { get; set; }
        public string net_price { get; set; }
        public string min_qty { get; set; }
        public string modified_date { get; set; }
        public string modified_time { get; set; }
        public string nhi_price { get; set; }
        public string group_name { get; set; }
        public string group_join_date { get; set; }
        public string status { get; set; }
    }
}
