using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Transfer.City.Models.ViewModels
{
    public class InvitationsViewModel
    {
        public List<DropdownViewModel<int>> TripStatus { get; set; }
        public List<DropdownViewModel<int>> Companies { get; set; }

    }
}