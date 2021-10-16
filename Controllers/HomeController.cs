using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Transfer.City.Filter;
using Transfer.City.Helpers;
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
                                var SearchData = new FindTransfer();
                                SearchData.DateAndTransfer = new SelectDataAndTransferViewModel();
                                if (LocationFrom != null)
                                {
                                    SearchData.DateAndTransfer.LocationFrom = LocationFrom.ID;
                                    SearchData.DateAndTransfer.LocationFromName = LocationFrom.Name;
                                }

                                if(LocationTo != null)
                                {
                                    SearchData.DateAndTransfer.LocationTo = LocationTo.ID;
                                    SearchData.DateAndTransfer.LocationToName = LocationTo.Name;
                                }

                                SearchData.DateAndTransfer.DateTime = item.DateTime;
                                SearchData.PassngersCount = model.PassngersCount;

                                SearchModel.SearchData.Add(SearchData);


                                if (searchReslt != null)
                                {
                                    SearchModel.SearchResultList.Add(searchReslt);
                                }
                            }
                        }
                    }

                    if(SearchModel.SearchResultList.Count > 0)
                    {
                        return View(SearchModel);
                    }
                }
            }

            return RedirectToAction(nameof(Index));
        }
        public ActionResult ChooseExtras(FindResultViewModel model)
        {
            if (model.DateAndLocations != null)
            {
                if (model.DateAndLocations.Count > 0)
                {
                    SearchResultViewModel SearchModel = new SearchResultViewModel();
                    foreach (var item in model.DateAndLocations)
                    {
                        if (item.IsValid)
                        {
                            if (item.LocationFrom > 0 && item.LocationTo > 0)
                            {
                                var searchReslt = FindTransfers.SearchResult(new FindTransfer { LocationFrom = item.LocationFrom, LocationTo = item.LocationTo, PassngersCount = model.PassngersCount });
                                var LocationFrom = Locations.GetByID(new Models.Locations { ID = item.LocationFrom });
                                var LocationTo = Locations.GetByID(new Models.Locations { ID = item.LocationTo });
                                var SearchData = new FindTransfer();
                                SearchData.DateAndTransfer = new SelectDataAndTransferViewModel();
                                if (LocationFrom != null)
                                {
                                    SearchData.DateAndTransfer.LocationFrom = LocationFrom.ID;
                                    SearchData.DateAndTransfer.LocationFromName = LocationFrom.Name;
                                }

                                if (LocationTo != null)
                                {
                                    SearchData.DateAndTransfer.LocationTo = LocationTo.ID;
                                    SearchData.DateAndTransfer.LocationToName = LocationTo.Name;
                                }

                                SearchData.DateAndTransfer.DateTime = item.DateTime;
                                SearchData.PassngersCount = model.PassngersCount;
                                
                                SearchModel.SearchData.Add(SearchData);


                                if (searchReslt != null)
                                {
                                    var SelectedCar = searchReslt.FirstOrDefault(s=>s.ID == item.CarId);
                                    if(SelectedCar != null)
                                    {
                                        var extras = Extras.Booking_ExtrasList(new Models.Extras {ID = SelectedCar.ID });

                                        searchReslt = new List<FindTransfer>();
                                        searchReslt.Add(SelectedCar);
                                        SearchModel.SearchResultList.Add(searchReslt);
                                        if(extras != null)
                                        {
                                            if(extras.Count > 0)
                                            {
                                                SearchModel.Extras.Add(extras);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        return RedirectToAction(nameof(Index));
                                    }
                                }
                            }
                        }
                    }

                    if (SearchModel.SearchResultList.Count > 0)
                    {
                        return View(SearchModel);
                    }
                }
            }

            return RedirectToAction(nameof(Index));
        }
        public ActionResult PassngersAndTransfers(FindResultViewModel model)
        {

            //return passengers and transfers data
            var email = UserName();
            var user = Users.GetByUserNameOrEmail(new City.Models.Users { UserName = UserName(), EmailAddress = "" });
            if (user != null)
            {
                email = user.EmailAddress;
            }


            if (model.DateAndLocations != null)
            {
                if (model.DateAndLocations.Count > 0)
                {
                    SearchResultViewModel SearchModel = new SearchResultViewModel();
                    SearchModel.PassengersAndTransfers = new List<PassengersAndTransferViewModel>();
                    SearchModel.PassengersAndTransfers.Add(new PassengersAndTransferViewModel { EmailAddress = email });

                    foreach (var item in model.DateAndLocations)
                    {
                        if (item.IsValid)
                        {
                            if (item.LocationFrom > 0 && item.LocationTo > 0)
                            {
                                var searchReslt = FindTransfers.SearchResult(new FindTransfer { LocationFrom = item.LocationFrom, LocationTo = item.LocationTo, PassngersCount = model.PassngersCount });
                                var LocationFrom = Locations.GetByID(new Models.Locations { ID = item.LocationFrom });
                                var LocationTo = Locations.GetByID(new Models.Locations { ID = item.LocationTo });
                                var SearchData = new FindTransfer();
                                SearchData.DateAndTransfer = new SelectDataAndTransferViewModel();
                                if (LocationFrom != null)
                                {
                                    SearchData.DateAndTransfer.LocationFrom = LocationFrom.ID;
                                    SearchData.DateAndTransfer.LocationFromName = LocationFrom.Name;
                                }

                                if (LocationTo != null)
                                {
                                    SearchData.DateAndTransfer.LocationTo = LocationTo.ID;
                                    SearchData.DateAndTransfer.LocationToName = LocationTo.Name;
                                }

                                SearchData.DateAndTransfer.DateTime = item.DateTime;
                                SearchData.PassngersCount = model.PassngersCount;

                                SearchModel.SearchData.Add(SearchData);


                                if (searchReslt != null)
                                {
                                    var SelectedCar = searchReslt.FirstOrDefault(s => s.ID == item.CarId);
                                    if (SelectedCar != null)
                                    {
                                        var extras = Extras.Booking_ExtrasList(new Models.Extras { ID = SelectedCar.ID });

                                        searchReslt = new List<FindTransfer>();
                                        searchReslt.Add(SelectedCar);
                                        SearchModel.SearchResultList.Add(searchReslt);
                                        if (extras != null)
                                        {
                                            if (extras.Count > 0)
                                            {
                                                if(item.Extras != null)
                                                {
                                                    if (item.Extras.Count > 0)
                                                    {
                                                        var ChoosedExtras = new List<Extras>();
                                                        foreach (var extra in item.Extras)
                                                        {
                                                            if (extra.Count > 0)
                                                            {
                                                                var CheckExtra = extras.FirstOrDefault(e => e.ID == extra.ID);
                                                                if (CheckExtra != null)
                                                                {
                                                                    CheckExtra.Count = extra.Count;
                                                                    CheckExtra.RequiredInfoValue = extra.RequiredInfoValue;
                                                                    ChoosedExtras.Add(CheckExtra);
                                                                }
                                                            }
                                                        }

                                                        SearchModel.Extras.Add(ChoosedExtras);
                                                    }
                                                }
                                                
                                                
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                    if (SearchModel.SearchResultList.Count > 0)
                    {
                        return View(SearchModel);
                    }
                }
            }

            return RedirectToAction(nameof(Index));
        }
        public ActionResult Confirmation(FindResultViewModel model)
        {
            if (model.DateAndLocations != null)
            {
                if (model.DateAndLocations.Count > 0)
                {
                    SearchResultViewModel SearchModel = new SearchResultViewModel();
                    var index = 0;
                    foreach (var item in model.DateAndLocations)
                    {
                        if (item.IsValid)
                        {
                            if (item.LocationFrom > 0 && item.LocationTo > 0)
                            {
                                var searchReslt = FindTransfers.SearchResult(new FindTransfer { LocationFrom = item.LocationFrom, LocationTo = item.LocationTo, PassngersCount = model.PassngersCount });
                                var LocationFrom = Locations.GetByID(new Models.Locations { ID = item.LocationFrom });
                                var LocationTo = Locations.GetByID(new Models.Locations { ID = item.LocationTo });
                                var SearchData = new FindTransfer();
                                SearchData.DateAndTransfer = new SelectDataAndTransferViewModel();
                                if (LocationFrom != null)
                                {
                                    SearchData.DateAndTransfer.LocationFrom = LocationFrom.ID;
                                    SearchData.DateAndTransfer.LocationFromName = LocationFrom.Name;
                                }

                                if (LocationTo != null)
                                {
                                    SearchData.DateAndTransfer.LocationTo = LocationTo.ID;
                                    SearchData.DateAndTransfer.LocationToName = LocationTo.Name;
                                }

                                SearchData.DateAndTransfer.DateTime = item.DateTime;
                                SearchData.PassngersCount = model.PassngersCount;

                                SearchModel.SearchData.Add(SearchData);


                                if (searchReslt != null)
                                {
                                    var SelectedCar = searchReslt.FirstOrDefault(s => s.ID == item.CarId);
                                    if (SelectedCar != null)
                                    {
                                        var extras = Extras.Booking_ExtrasList(new Models.Extras { ID = SelectedCar.ID });

                                        searchReslt = new List<FindTransfer>();
                                        searchReslt.Add(SelectedCar);
                                        SearchModel.SearchResultList.Add(searchReslt);
                                        if (extras != null)
                                        {
                                            if (extras.Count > 0)
                                            {
                                                if(item.Extras != null)
                                                {
                                                    if (item.Extras.Count > 0)
                                                    {
                                                        var ChoosedExtras = new List<Extras>();
                                                        foreach (var extra in item.Extras)
                                                        {
                                                            if (extra.Count > 0)
                                                            {
                                                                var CheckExtra = extras.FirstOrDefault(e => e.ID == extra.ID);
                                                                if (CheckExtra != null)
                                                                {
                                                                    CheckExtra.Count = extra.Count;
                                                                    CheckExtra.RequiredInfoValue = extra.RequiredInfoValue;
                                                                    ChoosedExtras.Add(CheckExtra);
                                                                }
                                                            }
                                                        }

                                                        SearchModel.Extras.Add(ChoosedExtras);
                                                    }
                                                }
                                                
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        index = index + 1;
                        if(index > 1)
                        {
                            if(item.PassengersAndTransfers != null)
                            {
                                item.PassengersAndTransfers.ContactName = model.DateAndLocations[0].PassengersAndTransfers.ContactName;
                                item.PassengersAndTransfers.ContactSurname = model.DateAndLocations[0].PassengersAndTransfers.ContactSurname;
                                item.PassengersAndTransfers.EmailAddress = model.DateAndLocations[0].PassengersAndTransfers.EmailAddress;
                                item.PassengersAndTransfers.SaveQuota = model.DateAndLocations[0].PassengersAndTransfers.SaveQuota;
                                item.PassengersAndTransfers.LeadPassengerMobile = model.DateAndLocations[0].PassengersAndTransfers.LeadPassengerMobile;
                                item.PassengersAndTransfers.SMS = model.DateAndLocations[0].PassengersAndTransfers.SMS;
                            }
                        }

                        if(!item.PassengersAndTransfers.IsValid)
                        {
                            return RedirectToAction(nameof(Index));
                        }
                        else
                        {
                            SearchModel.PassengersAndTransfers.Add(item.PassengersAndTransfers);
                        }
                    }

                    if (SearchModel.SearchResultList.Count > 0)
                    {
                        return View(SearchModel);
                    }
                }
            }

            return RedirectToAction(nameof(Index));
        }
        public ActionResult Payment(FindResultViewModel model)
        {
            if (model.DateAndLocations != null)
            {
                if (model.DateAndLocations.Count > 0)
                {
                    SearchResultViewModel SearchModel = new SearchResultViewModel();
                    var index = 0;
                    foreach (var item in model.DateAndLocations)
                    {
                        if (item.IsValid)
                        {
                            if (item.LocationFrom > 0 && item.LocationTo > 0)
                            {
                                var searchReslt = FindTransfers.SearchResult(new FindTransfer { LocationFrom = item.LocationFrom, LocationTo = item.LocationTo, PassngersCount = model.PassngersCount });
                                var LocationFrom = Locations.GetByID(new Models.Locations { ID = item.LocationFrom });
                                var LocationTo = Locations.GetByID(new Models.Locations { ID = item.LocationTo });
                                var SearchData = new FindTransfer();
                                SearchData.DateAndTransfer = new SelectDataAndTransferViewModel();
                                if (LocationFrom != null)
                                {
                                    SearchData.DateAndTransfer.LocationFrom = LocationFrom.ID;
                                    SearchData.DateAndTransfer.LocationFromName = LocationFrom.Name;
                                }

                                if (LocationTo != null)
                                {
                                    SearchData.DateAndTransfer.LocationTo = LocationTo.ID;
                                    SearchData.DateAndTransfer.LocationToName = LocationTo.Name;
                                }

                                SearchData.DateAndTransfer.DateTime = item.DateTime;
                                SearchData.PassngersCount = model.PassngersCount;

                                SearchModel.SearchData.Add(SearchData);


                                if (searchReslt != null)
                                {
                                    var SelectedCar = searchReslt.FirstOrDefault(s => s.ID == item.CarId);
                                    if (SelectedCar != null)
                                    {
                                        var extras = Extras.Booking_ExtrasList(new Models.Extras { ID = SelectedCar.ID });

                                        searchReslt = new List<FindTransfer>();
                                        searchReslt.Add(SelectedCar);
                                        SearchModel.SearchResultList.Add(searchReslt);
                                        if (extras != null)
                                        {
                                            if (extras.Count > 0)
                                            {
                                                if(item.Extras != null)
                                                {
                                                    if (item.Extras.Count > 0)
                                                    {
                                                        var ChoosedExtras = new List<Extras>();
                                                        foreach (var extra in item.Extras)
                                                        {
                                                            if (extra.Count > 0)
                                                            {
                                                                var CheckExtra = extras.FirstOrDefault(e => e.ID == extra.ID);
                                                                if (CheckExtra != null)
                                                                {
                                                                    CheckExtra.Count = extra.Count;
                                                                    CheckExtra.RequiredInfoValue = extra.RequiredInfoValue;
                                                                    ChoosedExtras.Add(CheckExtra);
                                                                }
                                                            }
                                                        }

                                                        SearchModel.Extras.Add(ChoosedExtras);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        index = index + 1;
                        if (index > 1)
                        {
                            if (item.PassengersAndTransfers != null)
                            {
                                item.PassengersAndTransfers.ContactName = model.DateAndLocations[0].PassengersAndTransfers.ContactName;
                                item.PassengersAndTransfers.ContactSurname = model.DateAndLocations[0].PassengersAndTransfers.ContactSurname;
                                item.PassengersAndTransfers.EmailAddress = model.DateAndLocations[0].PassengersAndTransfers.EmailAddress;
                                item.PassengersAndTransfers.SaveQuota = model.DateAndLocations[0].PassengersAndTransfers.SaveQuota;
                                item.PassengersAndTransfers.LeadPassengerMobile = model.DateAndLocations[0].PassengersAndTransfers.LeadPassengerMobile;
                                item.PassengersAndTransfers.SMS = model.DateAndLocations[0].PassengersAndTransfers.SMS;
                            }
                        }

                        if (!item.PassengersAndTransfers.IsValid)
                        {
                            return RedirectToAction(nameof(Index));
                        }
                        else
                        {
                            SearchModel.PassengersAndTransfers.Add(item.PassengersAndTransfers);
                        }

                        if(item.Confirmation != null)
                        {
                            if (!item.Confirmation.IsValid)
                            {
                                return RedirectToAction(nameof(Index));
                            }
                            else
                            {
                                if (string.IsNullOrEmpty(item.Confirmation.CustomerFirstName))
                                {
                                    item.Confirmation.CustomerFirstName = item.PassengersAndTransfers.ContactName;
                                }

                                if (string.IsNullOrEmpty(item.Confirmation.CustomerLastName))
                                {
                                    item.Confirmation.CustomerLastName = item.PassengersAndTransfers.ContactSurname;
                                }

                                if (string.IsNullOrEmpty(item.Confirmation.CustomerPhone))
                                {
                                    item.Confirmation.CustomerPhone = item.PassengersAndTransfers.LeadPassengerMobile;
                                }

                                SearchModel.Confirmations.Add(item.Confirmation);
                            }
                        }
                        
                    }

                    if (SearchModel.SearchResultList.Count > 0)
                    {
                        return View(SearchModel);
                    }
                }
            }

            return RedirectToAction(nameof(Index));
        }
        public ActionResult SaveDate(FindResultViewModel model)
        {
            if (model.DateAndLocations != null)
            {
                if (model.DateAndLocations.Count > 0)
                {
                    SearchResultViewModel SearchModel = new SearchResultViewModel();
                    var index = 0;
                    foreach (var item in model.DateAndLocations)
                    {
                        if (item.IsValid)
                        {
                            if (item.LocationFrom > 0 && item.LocationTo > 0)
                            {
                                var searchReslt = FindTransfers.SearchResult(new FindTransfer { LocationFrom = item.LocationFrom, LocationTo = item.LocationTo, PassngersCount = model.PassngersCount });
                                var LocationFrom = Locations.GetByID(new Models.Locations { ID = item.LocationFrom });
                                var LocationTo = Locations.GetByID(new Models.Locations { ID = item.LocationTo });
                                var SearchData = new FindTransfer();
                                SearchData.DateAndTransfer = new SelectDataAndTransferViewModel();
                                if (LocationFrom != null)
                                {
                                    SearchData.DateAndTransfer.LocationFrom = LocationFrom.ID;
                                    SearchData.DateAndTransfer.LocationFromName = LocationFrom.Name;
                                }

                                if (LocationTo != null)
                                {
                                    SearchData.DateAndTransfer.LocationTo = LocationTo.ID;
                                    SearchData.DateAndTransfer.LocationToName = LocationTo.Name;
                                }

                                SearchData.DateAndTransfer.DateTime = item.DateTime;
                                SearchData.PassngersCount = model.PassngersCount;

                                SearchModel.SearchData.Add(SearchData);


                                if (searchReslt != null)
                                {
                                    var SelectedCar = searchReslt.FirstOrDefault(s => s.ID == item.CarId);
                                    if (SelectedCar != null)
                                    {
                                        var extras = Extras.Booking_ExtrasList(new Models.Extras { ID = SelectedCar.ID });

                                        searchReslt = new List<FindTransfer>();
                                        searchReslt.Add(SelectedCar);
                                        SearchModel.SearchResultList.Add(searchReslt);
                                        if (extras != null)
                                        {
                                            if (extras.Count > 0)
                                            {
                                                if (item.Extras != null)
                                                {
                                                    if (item.Extras.Count > 0)
                                                    {
                                                        var ChoosedExtras = new List<Extras>();
                                                        foreach (var extra in item.Extras)
                                                        {
                                                            if (extra.Count > 0)
                                                            {
                                                                var CheckExtra = extras.FirstOrDefault(e => e.ID == extra.ID);
                                                                if (CheckExtra != null)
                                                                {
                                                                    CheckExtra.Count = extra.Count;
                                                                    CheckExtra.RequiredInfoValue = extra.RequiredInfoValue;
                                                                    ChoosedExtras.Add(CheckExtra);
                                                                }
                                                            }
                                                        }

                                                        SearchModel.Extras.Add(ChoosedExtras);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        index = index + 1;
                        if (index > 1)
                        {
                            if (item.PassengersAndTransfers != null)
                            {
                                item.PassengersAndTransfers.ContactName = model.DateAndLocations[0].PassengersAndTransfers.ContactName;
                                item.PassengersAndTransfers.ContactSurname = model.DateAndLocations[0].PassengersAndTransfers.ContactSurname;
                                item.PassengersAndTransfers.EmailAddress = model.DateAndLocations[0].PassengersAndTransfers.EmailAddress;
                                item.PassengersAndTransfers.SaveQuota = model.DateAndLocations[0].PassengersAndTransfers.SaveQuota;
                                item.PassengersAndTransfers.LeadPassengerMobile = model.DateAndLocations[0].PassengersAndTransfers.LeadPassengerMobile;
                                item.PassengersAndTransfers.SMS = model.DateAndLocations[0].PassengersAndTransfers.SMS;
                            }
                        }

                        if (!item.PassengersAndTransfers.IsValid)
                        {
                            return RedirectToAction(nameof(Index));
                        }
                        else
                        {
                            SearchModel.PassengersAndTransfers.Add(item.PassengersAndTransfers);
                        }
                        if(item.Confirmation != null)
                        {
                            if (!item.Confirmation.IsValid)
                            {
                                return RedirectToAction(nameof(Index));
                            }
                            else
                            {
                                if (string.IsNullOrEmpty(item.Confirmation.CustomerFirstName))
                                {
                                    item.Confirmation.CustomerFirstName = item.PassengersAndTransfers.ContactName;
                                }

                                if (string.IsNullOrEmpty(item.Confirmation.CustomerLastName))
                                {
                                    item.Confirmation.CustomerLastName = item.PassengersAndTransfers.ContactSurname;
                                }

                                if (string.IsNullOrEmpty(item.Confirmation.CustomerPhone))
                                {
                                    item.Confirmation.CustomerPhone = item.PassengersAndTransfers.LeadPassengerMobile;
                                }

                                SearchModel.Confirmations.Add(item.Confirmation);
                            }
                        }
                    }

                    if(!model.Payment.IsValid)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        SearchModel.Payment = model.Payment;
                    }

                    if (SearchModel.SearchResultList.Count > 0)
                    {
                        var sm = AddTrips(SearchModel);
                        if (sm.Status[0])
                        {
                            return View(sm);
                        }
                    }
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
        public SearchResultViewModel AddTrips(SearchResultViewModel model)
        {
            //add trip 1
            var TransferId = 0;
            var BookingRefernce = Guid.NewGuid().ToString();

            var email = UserName();
            var user = Users.GetByUserNameOrEmail(new City.Models.Users { UserName = UserName(), EmailAddress = "" });
            if (user != null)
            {
                email = user.EmailAddress;
            }

            if (model.SearchResultList.Count > 0)
            {
                var LocationTo = model.SearchResultList[0][0].LocationTo;
                var LocationFrom = model.SearchResultList[0][0].LocationFrom;
                var Transfer = Transfers.GetByLocationToAndLocationFrom(new GeneralTransfers { LocationTo = LocationTo, LocationFrom = LocationFrom });
                if(Transfer != null)
                {
                    TransferId = Transfer.ID;
                }

                if (TransferId == 0)
                {
                    return model;
                }

                if(model.SearchResultList[0][0].ID == 0)
                {
                    return model;
                }

                var CarId = model.SearchResultList[0][0].ID;

                //calc fees
                decimal VehicleBasePrice = 0;
                VehicleBasePrice = model.SearchResultList[0][0].SellingPrice;
                decimal Extras = 0;
                decimal Discount = 0;
                decimal SmsMessage = 0;
                if (model.Extras.Count > 0)
                {
                    foreach (var item in model.Extras[0])
                    {
                        Extras = Extras + (item.Count * item.Fees);
                    }
                }

                if (Convert.ToBoolean(model.PassengersAndTransfers[0].SMS))
                {
                    SmsMessage = 1.75M;
                }

                decimal CancellationProtection = 0;
                if (model.Confirmations[0].CancellationProtection)
                {
                    CancellationProtection = 3;
                }

                var SubTotal = VehicleBasePrice - Discount;
                var TotalAmount = SubTotal + Extras + SmsMessage + CancellationProtection;
                var trip = new Trips()
                {
                    Transfer = TransferId,
                    Car = CarId,
                    ContactName = model.PassengersAndTransfers[0].ContactName,
                    ContactSurname = model.PassengersAndTransfers[0].ContactSurname,
                    SaveQuota = model.PassengersAndTransfers[0].SaveQuota,
                    EmailAddress = email == ""? model.PassengersAndTransfers[0].EmailAddress:email,
                    LeadPassengerMobile = model.PassengersAndTransfers[0].LeadPassengerMobile,
                    SMS = model.PassengersAndTransfers[0].SMS,
                    FromAirline = model.PassengersAndTransfers[0].FromAirline,
                    FromFlightNumber = model.PassengersAndTransfers[0].FromFlightNumber,
                    FromOriginatingAirport = model.PassengersAndTransfers[0].FromOriginatingAirport,
                    FromFlightArrivalTime = model.PassengersAndTransfers[0].FromFlightArrivalTime,
                    ToDropOfPoint = model.PassengersAndTransfers[0].ToDropOfPoint,
                    CustomerFirstName = model.Confirmations[0].CustomerFirstName,
                    CustomerLastName = model.Confirmations[0].CustomerLastName,
                    CustomerPhone = model.Confirmations[0].CustomerPhone,
                    Subscribed = model.Confirmations[0].Subscribed,
                    CancellationProtection = model.Confirmations[0].CancellationProtection == true ? 3 : 0,
                    CardHolder = model.Payment.CardHolder,
                    CardNumber = model.Payment.CardNumber,
                    ExpiryMonth = model.Payment.ExpiryMonth,
                    ExpireYear = model.Payment.ExpireYear,
                    CCV = model.Payment.CCV,
                    RegisteredDate = DateTime.Now,
                    IsPayed = true,
                    PayementDate = DateTime.Now,
                    TransactionID = 0,
                    Fees = TotalAmount,
                    BookingReference = BookingRefernce
                };

                var result = false;
                if(trip.IsValid)
                {
                    result = Trips.Insert(trip);
                }

                if(result)
                {
                    if (model.Extras.Count > 0)
                    {
                        foreach (var item in model.Extras[0])
                        {
                            if (item.RequiredInfoValue == null)
                            {
                                item.RequiredInfoValue = "";
                            }

                            var TripExtras = new Trip_Extars()
                            {
                                Trip = trip.ID,
                                Extra = item.ID,
                                Info = item.Count,
                                RequiredInfoValue = item.RequiredInfoValue
                            };

                            if (TripExtras.IsValid)
                            {
                                TripsExtras.Insert(TripExtras);
                            }
                        }
                    }

                    if(model.SearchResultList.Count != 2)
                    {
                        model.Status.Add(true);
                        model.BookingReference.Add(trip.BookingReference);
                        return model;
                    }

                }
            }

            if (model.SearchResultList.Count > 1)
            {
                TransferId = 0;
                var LocationTo = model.SearchResultList[1][0].LocationTo;
                var LocationFrom = model.SearchResultList[1][0].LocationFrom;
                var Transfer = Transfers.GetByLocationToAndLocationFrom(new GeneralTransfers { LocationTo = LocationTo, LocationFrom = LocationFrom });
                if (Transfer != null)
                {
                    TransferId = Transfer.ID;
                }

                if (TransferId == 0)
                {
                    return model;
                }

                if (model.SearchResultList[1][0].ID == 0)
                {
                    return model;
                }

                var CarId = model.SearchResultList[1][0].ID;

                //calc fees
                decimal VehicleBasePrice = 0;
                VehicleBasePrice = model.SearchResultList[1][0].SellingPrice;
                decimal Extras = 0;
                decimal Discount = 0;
                decimal SmsMessage = 0;
                if (model.Extras.Count > 1)
                {
                    foreach (var item in model.Extras[1])
                    {
                        Extras = Extras + (item.Count * item.Fees);
                    }
                }

                if (Convert.ToBoolean(model.PassengersAndTransfers[1].SMS))
                {
                    SmsMessage = 1.75M;
                }

                decimal CancellationProtection = 0;
                if (model.Confirmations[0].CancellationProtection)
                {
                    CancellationProtection = 3;
                }

                var SubTotal = VehicleBasePrice - Discount;
                var TotalAmount = SubTotal + Extras + SmsMessage + CancellationProtection;

                var trip = new Trips()
                {
                    Transfer = TransferId,
                    Car = CarId,
                    ContactName = model.PassengersAndTransfers[1].ContactName,
                    ContactSurname = model.PassengersAndTransfers[1].ContactSurname,
                    SaveQuota = model.PassengersAndTransfers[1].SaveQuota,
                    EmailAddress = email == "" ? model.PassengersAndTransfers[0].EmailAddress : email,
                    LeadPassengerMobile = model.PassengersAndTransfers[1].LeadPassengerMobile,
                    SMS = model.PassengersAndTransfers[1].SMS,
                    FromAirline = model.PassengersAndTransfers[1].FromAirline,
                    FromFlightNumber = model.PassengersAndTransfers[1].FromFlightNumber,
                    FromOriginatingAirport = model.PassengersAndTransfers[1].FromOriginatingAirport,
                    FromFlightArrivalTime = model.PassengersAndTransfers[1].FromFlightArrivalTime,
                    ToDropOfPoint = model.PassengersAndTransfers[1].ToDropOfPoint,
                    CustomerFirstName = model.Confirmations[0].CustomerFirstName,
                    CustomerLastName = model.Confirmations[0].CustomerLastName,
                    CustomerPhone = model.Confirmations[0].CustomerPhone,
                    Subscribed = model.Confirmations[0].Subscribed,
                    CancellationProtection = model.Confirmations[0].CancellationProtection == true ? 3 : 0,
                    CardHolder = model.Payment.CardHolder,
                    CardNumber = model.Payment.CardNumber,
                    ExpiryMonth = model.Payment.ExpiryMonth,
                    ExpireYear = model.Payment.ExpireYear,
                    CCV = model.Payment.CCV,
                    RegisteredDate = DateTime.Now,
                    IsPayed = true,
                    Fees = TotalAmount,
                    BookingReference = BookingRefernce,
                    PayementDate = DateTime.Now,
                    TransactionID = 0,
                };

                var result = false;
                if (trip.IsValid)
                {
                    result = Trips.Insert(trip);
                }

                if (result)
                {
                    if (model.Extras.Count > 1)
                    {
                        foreach (var item in model.Extras[1])
                        {

                            if (item.RequiredInfoValue == null)
                            {
                                item.RequiredInfoValue = "";
                            }

                            var TripExtras = new Trip_Extars()
                            {
                                Trip = trip.ID,
                                Extra = item.ID,
                                Info = item.Count,
                                RequiredInfoValue = item.RequiredInfoValue
                            };

                            if(TripExtras.IsValid)
                            {
                                TripsExtras.Insert(TripExtras);
                            }
                        }
                    }

                    model.Status.Add(true);
                    model.BookingReference.Add(trip.BookingReference);
                    return model;
                }
            }

            return model;


        }


    }
}