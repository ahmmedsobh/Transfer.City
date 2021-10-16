using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Transfer.City.Models;

namespace Transfer.City.Areas.Customer.Models.ViewModels
{
    public class MyBookingViewModels
    {
        public Users User { get; set; } = new Users();
        public List<Trips> Trips { get; set; } = new List<Trips>();
        public List<Trip_Extars> TripsExtras { get; set; } = new List<Trip_Extars>();
    }
}