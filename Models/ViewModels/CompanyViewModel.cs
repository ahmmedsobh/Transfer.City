using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Transfer.City.Models.ViewModels
{
    public class CompanyViewModel
    {
        public Companies Company { get; set; } = new Companies();
        public List<Company_Cars> Cars { get; set; } = new List<Company_Cars>();
        public List<Company_Locations> Locations { get; set; } = new List<Company_Locations>();
        public List<DropdownViewModel<int>> Countries { get; set; } = new List<DropdownViewModel<int>>();
        public List<DropdownViewModel<int>> Currencies { get; set; } = new List<DropdownViewModel<int>>();
        public List<Customer_Prices>  Customer_Prices { get; set; } = new List<Customer_Prices>();


    }
}