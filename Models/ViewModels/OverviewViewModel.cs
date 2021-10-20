using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Transfer.City.Models.ViewModels
{
    public class OverviewViewModel
    {
        public int CarsCount { get; set; }
        public int CountriesCount { get; set; }
        public int LocationsCount { get; set; }
        public int TransfersCount { get; set; }
        public int CurrenciesCount { get; set; }
        public int kpiCount { get; set; }
        public int CompanyTotalCount { get; set; }
        public int CompanyApprovedCount { get; set; }
        public int CompanyNotApprovedCount { get; set; }
        public int TripsWaitCount { get; set; }
        public int TripsInProgressCount { get; set; }
        public int TripsDoneCount { get; set; }
        public int InvitationsSentCount { get; set; }
        public int InvitationsAcceptedCount { get; set; }
        public int InvitationsRefusedCount { get; set; }
        public int UsersTotalCount { get; set; }
        public int UsersEnabledCount { get; set; }
        public int UsersNotEnabledCount { get; set; }
    }
}