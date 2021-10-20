using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Transfer.City.Models.ViewModels
{
    public class TripsViewModel
    {
        public Trips Trip { get; set; }

        public decimal? VehiclePrice { get; set; }
        public decimal ExtrasTotal { get; set; }
        public decimal TotalAmount { get; set; }

        public Cars Car { get; set; }
        public List<Trip_Extars> Trip_Extars { get; set; } = new List<Trip_Extars>();
        public List<TransferInvitations> TransferInvitations { get; set; } = new List<TransferInvitations>();
        public List<DropdownViewModel<int>> Cars { get; set; } = new List<DropdownViewModel<int>>();
        public List<DropdownViewModel<int>> TripStatus { get; set; }
        public List<TripsKpi> TripsKpis { get; set; } = new List<TripsKpi>();
        public List<Complaints> Complaints { get; set; } = new List<Complaints>();

    }
}