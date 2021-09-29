using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Transfer.City.Models.ViewModels
{
    public class CustomerPricesViewModel
    {
        public int CompanyID { get; set; }
        public int CarID { get; set; }
        public List<Customer_Prices> Customer_Prices { get; set; } = new List<Customer_Prices>();
    }
}