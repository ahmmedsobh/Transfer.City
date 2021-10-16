using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Transfer.City.Models.ViewModels
{
    public class SearchResultViewModel
    {
        public List<List<FindTransfer>> SearchResultList { get; set; } = new List<List<FindTransfer>>();
        public List<FindTransfer> SearchData { get; set; } = new List<FindTransfer>();
        public List<List<Extras>> Extras { get; set; } = new List<List<Extras>>();
        public List<PassengersAndTransferViewModel> PassengersAndTransfers { get; set; } = new List<PassengersAndTransferViewModel>();
        public List<ConfirmationViewModel> Confirmations { get; set; } = new List<ConfirmationViewModel>();
        public PaymentViewModel Payment { get; set; } = new PaymentViewModel();
        public List<bool> Status { get; set; } = new List<bool>();
        public List<string> BookingReference { get; set; } = new List<string>();
    }
}