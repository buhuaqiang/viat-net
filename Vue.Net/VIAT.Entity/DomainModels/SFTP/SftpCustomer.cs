using System;
using System.Collections.Generic;
using System.Text;

namespace VIAT.Entity.DomainModels.SFTP
{
    public class SftpCustomer
    {
        public string cust_id { get; set; }
        public string cust_name { get; set; }
        public string invoice_name { get; set; }
        public string cust_address { get; set; }
        public string tax_id { get; set; }
        public string tel_no { get; set; }
        public string owner { get; set; }
        public string contact { get; set; }
        public string datey { get; set; }
        public string dateh { get; set; }
        public string invoice_zip_id { get; set; }
        public string ctrl_drug_no { get; set; }
        public string ctrl_drug_contact { get; set; }
        public string doh_type { get; set; }
        public string margin_type { get; set; }
        public string status { get; set; }
        public string remarks { get; set; }
    }
}
