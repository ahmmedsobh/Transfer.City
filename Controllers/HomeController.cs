using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Transfer.City.Filter;
using Transfer.City.Models;
using Transfer.City.Models.ViewModels;

namespace Transfer.City.Controllers
{
    //[CustomAuthenticationFilter]
    public class HomeController : BaseController
    {

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            var countries = Countries.GetAll();
            return View(countries);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult SearchResult(FindResultViewModel model)
        {
            if(model.DateAndLocations != null)
            {
                if(model.DateAndLocations.Count > 0)
                {

                    SearchResultViewModel SearchModel = new SearchResultViewModel();
                    foreach (var item in model.DateAndLocations)
                    {
                        if (item.IsValid)
                        {
                            if(item.LocationFrom > 0 && item.LocationTo > 0)
                            {
                                var searchReslt = FindTransfers.SearchResult(new FindTransfer { LocationFrom = item.LocationFrom, LocationTo = item.LocationTo, PassngersCount = model.PassngersCount });
                                var LocationFrom = Locations.GetByID(new Models.Locations { ID = item.LocationFrom });
                                var LocationTo = Locations.GetByID(new Models.Locations { ID = item.LocationTo });
                                var SearchData = new SelectDataAndTransferViewModel();
                                
                                if (LocationFrom != null)
                                {
                                    SearchData.LocationFrom = LocationFrom.ID;
                                    SearchData.LocationFromName = LocationFrom.Name;
                                }

                                if(LocationTo != null)
                                {
                                    SearchData.LocationTo = LocationTo.ID;
                                    SearchData.LocationToName = LocationTo.Name;
                                }

                                SearchData.DateTime = item.DateTime;



                                if (searchReslt != null)
                                {
                                    SearchModel.SearchResultList.Add(searchReslt);
                                }
                            }
                        }
                    }

                    return View(SearchModel);
                }
            }

            return RedirectToAction(nameof(Index));
        }

        public ActionResult LocationsList(string term)
        {
            //.Where(l => l.Name.Contains(term.ToString())).ToList()
            var locations = (from l in Locations.GetAll()
                             where l.Name.Contains(term)
                             select new
                             {
                                 id = l.ID,
                                 text = l.Name
                             }).ToList();

            var data = Json(new
            {
                Locations = locations
            }, JsonRequestBehavior.AllowGet);

            data.MaxJsonLength = int.MaxValue;
            return data;
        }
    }
}