using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Transfer.City.Models.ViewModels
{
    public class SearchResultViewModel
    {
        public List<List<FindTransfer>> SearchResultList { get; set; } = new List<List<FindTransfer>>();
        public FindTransfer SearchData { get; set; } = new FindTransfer();
    }
}