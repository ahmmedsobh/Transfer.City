using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Transfer.City.Areas.Company.Models.ViewModel;
using cn = Transfer.City.Areas.Company.Models.ViewModel;
using Transfer.City.Areas.Customer.Models.ViewModels;
using Transfer.City.Controllers;
using Transfer.City.Helpers;
using Transfer.City.Models;
using Transfer.City.Models.ViewModels;

namespace Transfer.City.Areas.Customer.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Customer/Home
        public ActionResult Index()
        {
            var Email = UserName();
            var User = Users.GetByUserNameOrEmail(new Users { EmailAddress = "", UserName = Email });
            MyBookingViewModels model = new MyBookingViewModels();

            if(User == null)
            {
                var trips = Trips.GetByReferenceAndEmail(new Trips { EmailAddress = Email,BookingReference="" });
                if(trips != null)
                {
                    if(trips.Count > 0)
                    {
                        User = new Users
                        {
                            EmailAddress = Email,
                            DisplayName = $"{trips[0].ContactName} {trips[0].ContactSurname}" 
                        };

                        model.User = User;
                        model.Trips.AddRange(trips);
                        foreach(var item in trips)
                        {
                            var extras = TripsExtras.GetByTripId(new Trip_Extars {Trip= item.ID });
                            if(extras != null)
                            {
                                model.TripsExtras.AddRange(extras);
                            }
                        }
                    }
                }
            }
            else
            {
                model.User = User;
                var trips = Trips.GetByReferenceAndEmail(new Trips { EmailAddress = User.EmailAddress, BookingReference = "" });
                if (trips != null)
                {
                    if (trips.Count > 0)
                    {
                        model.Trips.AddRange(trips);
                        foreach (var item in trips)
                        {
                            var extras = TripsExtras.GetByTripId(new Trip_Extars { Trip = item.ID });
                            if (extras != null)
                            {
                                model.TripsExtras.AddRange(extras);
                            }
                        }
                    }
                }
            }

            return View(model);
        }
        [HttpPost]
        public ActionResult AccountSettings(Users user)
        {
            var Message = new Message("Account settings", "An error occurred, please try", MessageType.warning);
            user.CreatedDate = DateTime.Now;
            if (user.IsValid)
            {
                var Email = UserName();
                
                var UserToUpdate = Users.GetByUserNameOrEmail(new Users { EmailAddress = Email , UserName = "" });
                if (UserToUpdate == null)
                {
                    var trips = Trips.GetByReferenceAndEmail(new Trips {EmailAddress = Email,BookingReference=""});
                    if(trips != null)
                    {
                        if(trips.Count > 0)
                        {
                            if(user.Password != user.ConfirmPassword)
                            {
                                Message = new Message("Account settings", "Confirm password is not equal", MessageType.warning);
                                return Json(new
                                {
                                    Message = Message,
                                }, JsonRequestBehavior.AllowGet);
                            }

                            var UserToAdd = new Users()
                            {
                                EmailAddress = Email,
                                UserName = user.UserName,
                                Password = user.Password,
                                IsCustomer = true,
                                DisplayName = user.DisplayName,
                                CreatedDate = DateTime.Now
                            };

                            Users.Insert(UserToAdd);
                            //The data has been saved
                            Message = new Message("Account settings", "", MessageType.success);
                            return Json(new
                            {
                                Message = Message,
                            }, JsonRequestBehavior.AllowGet);
                        }
                    }
                }
            }
            else
            {
                var messageDescription = "An error occurred, please try";
                if (user.BrokenRulesList[0] != null)
                {
                    messageDescription = user.BrokenRulesList[0].Description;
                }
                Message = new Message("Updating process", messageDescription, MessageType.warning);
            }

            return Json(new
            {
                Message = Message,
            }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult ChangePassword(cn.ChangePasswordViewModel model)
        {
            var Message = new Message("Change password", "An error occurred, please try", MessageType.warning);
            model.UserName = UserName();
            
            if (model.IsValid)
            {
                var user = Users.GetByUserNameAndPassword(new Users { UserName = model.UserName, Password = model.OldPassword });
                if (user == null)
                {
                    return Json(new
                    {
                        Message = Message,
                    }, JsonRequestBehavior.AllowGet);
                }

                if (model.NewPassword != model.ConfirmPassword)
                {
                    Message = new Message("Change password", "Confirm password is not equal", MessageType.warning);
                    return Json(new
                    {
                        Message = Message,
                    }, JsonRequestBehavior.AllowGet);
                }

                user.Password = model.NewPassword;

                if (Users.ChangePassword(user))
                {
                    //Password changed successfully
                    Message = new Message("Change password", "", MessageType.success);
                    return Json(new
                    {
                        Message = Message,
                    }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                var messageDescription = "An error occurred, please try";
                if (model.BrokenRulesList[0] != null)
                {
                    messageDescription = model.BrokenRulesList[0].Description;
                }
                Message = new Message("Updating process", messageDescription, MessageType.warning);
            }

            return Json(new
            {
                Message = Message,
            }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult SearchResult(string id = "")
        {


            var email = UserName();
            var user = Users.GetByUserNameOrEmail(new City.Models.Users { UserName = UserName(),EmailAddress = "" });
            if(user != null)
            {
                email = user.EmailAddress;
            }

            FindResultViewModel model = new FindResultViewModel();
            model.DateAndLocations = new List<SelectDataAndTransferViewModel>();
            
            var trips = Trips.GetByReferenceAndEmail(new City.Models.Trips { BookingReference = id, EmailAddress = "" });
            
            trips = trips.Where(t => t.EmailAddress == email).ToList();

            if(trips != null)
            {
                if(trips.Count > 0)
                {
                    
                    var m = new SelectDataAndTransferViewModel
                    {
                        LocationFrom = trips[0].LocationFromId,
                        LocationTo = trips[0].LocationToId,
                        LocationFromName = trips[0].LocationFrom,
                        LocationToName = trips[0].LocationTo,
                        DateTime = Convert.ToDateTime(trips[0].FromFlightArrivalTime)
                    };
                    model.DateAndLocations.Add(m);

                    var car = Cars.GetByID(new City.Models.Cars {ID =trips[0].Car });
                    if(car != null)
                    {
                        model.PassngersCount = car.Max_Passengers;
                    }
                    
                }

                if (trips.Count > 1)
                {
                    var m = new SelectDataAndTransferViewModel
                    {
                        LocationFrom = trips[1].LocationFromId,
                        LocationTo = trips[1].LocationToId,
                        LocationFromName = trips[1].LocationFrom,
                        LocationToName = trips[1].LocationTo,
                        DateTime = Convert.ToDateTime(trips[1].FromFlightArrivalTime)
                    };
                    model.DateAndLocations.Add(m);
                }
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }


            if (model.DateAndLocations != null)
            {
                if (model.DateAndLocations.Count > 0)
                {
                    SearchResultViewModel SearchModel = new SearchResultViewModel();
                    SearchModel.BookingReference.Add(id);

                    foreach (var item in model.DateAndLocations)
                    {
                        if (item.IsValid)
                        {
                            if (item.LocationFrom > 0 && item.LocationTo > 0)
                            {
                                var searchReslt = FindTransfers.SearchResult(new FindTransfer { LocationFrom = item.LocationFrom, LocationTo = item.LocationTo, PassngersCount = model.PassngersCount });
                                var LocationFrom = Locations.GetByID(new Locations { ID = item.LocationFrom });
                                var LocationTo = Locations.GetByID(new Locations { ID = item.LocationTo });
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
                                    SearchModel.SearchResultList.Add(searchReslt);
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
        [HttpPost]
        public ActionResult SearchResult(FindResultViewModel model)
        {
            if (model.DateAndLocations != null)
            {
                if (model.DateAndLocations.Count > 0)
                {

                    SearchResultViewModel SearchModel = new SearchResultViewModel();
                    SearchModel.BookingReference.Add(model.BookingReference);
                    foreach (var item in model.DateAndLocations)
                    {
                        if (item.IsValid)
                        {
                            if (item.LocationFrom > 0 && item.LocationTo > 0)
                            {
                                var searchReslt = FindTransfers.SearchResult(new FindTransfer { LocationFrom = item.LocationFrom, LocationTo = item.LocationTo, PassngersCount = model.PassngersCount });
                                var LocationFrom = Locations.GetByID(new Locations { ID = item.LocationFrom });
                                var LocationTo = Locations.GetByID(new Locations { ID = item.LocationTo });
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
                                    SearchModel.SearchResultList.Add(searchReslt);
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
        public ActionResult ChooseExtras(FindResultViewModel model)
        {
            if (model.DateAndLocations != null)
            {
                if (model.DateAndLocations.Count > 0)
                {

                    SearchResultViewModel SearchModel = new SearchResultViewModel();
                    SearchModel.BookingReference.Add(model.BookingReference);

                    foreach (var item in model.DateAndLocations)
                    {
                        if (item.IsValid)
                        {
                            if (item.LocationFrom > 0 && item.LocationTo > 0)
                            {
                                var searchReslt = FindTransfers.SearchResult(new FindTransfer { LocationFrom = item.LocationFrom, LocationTo = item.LocationTo, PassngersCount = model.PassngersCount });
                                var LocationFrom = Locations.GetByID(new Locations { ID = item.LocationFrom });
                                var LocationTo = Locations.GetByID(new Locations { ID = item.LocationTo });
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
                                        var extras = Extras.Booking_ExtrasList(new Extras { ID = SelectedCar.ID });

                                        searchReslt = new List<FindTransfer>();
                                        searchReslt.Add(SelectedCar);
                                        SearchModel.SearchResultList.Add(searchReslt);
                                        if (extras != null)
                                        {
                                            if (extras.Count > 0)
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
            if (model.DateAndLocations != null)
            {
                if (model.DateAndLocations.Count > 0)
                {
                    SearchResultViewModel SearchModel = new SearchResultViewModel();
                    SearchModel.BookingReference.Add(model.BookingReference);

                    //return passengers and transfers data
                    var email = UserName();
                    var user = Users.GetByUserNameOrEmail(new City.Models.Users { UserName = UserName(), EmailAddress = "" });
                    if (user != null)
                    {
                        email = user.EmailAddress;
                    }

                    var trips = Trips.GetByReferenceAndEmail(new City.Models.Trips { BookingReference = model.BookingReference, EmailAddress = "" });

                    trips = trips.Where(t => t.EmailAddress == email).ToList();
                    SearchModel.PassengersAndTransfers = new List<PassengersAndTransferViewModel>();
                    if(trips.Count > 0)
                    {
                        var m = new PassengersAndTransferViewModel()
                        {
                            ContactName = trips[0].ContactName,
                            ContactSurname = trips[0].ContactSurname,
                            EmailAddress = trips[0].EmailAddress,
                            LeadPassengerMobile = trips[0].LeadPassengerMobile,
                            SaveQuota = trips[0].SaveQuota,
                            SMS = trips[0].SMS,
                            FromAirline = trips[0].FromAirline,
                            FromFlightNumber = trips[0].FromFlightNumber,
                            FromOriginatingAirport = trips[0].FromOriginatingAirport,
                            FromFlightArrivalTime = trips[0].FromFlightArrivalTime,
                            ToDropOfPoint = trips[0].ToDropOfPoint
                        };

                        SearchModel.PassengersAndTransfers.Add(m);
                    }

                    if (trips.Count > 1)
                    {
                        var m = new PassengersAndTransferViewModel()
                        {
                            ContactName = trips[0].ContactName,
                            ContactSurname = trips[0].ContactSurname,
                            EmailAddress = trips[0].EmailAddress,
                            LeadPassengerMobile = trips[0].LeadPassengerMobile,
                            SaveQuota = trips[0].SaveQuota,
                            SMS = trips[0].SMS,
                            FromAirline = trips[0].FromAirline,
                            FromFlightNumber = trips[0].FromFlightNumber,
                            FromOriginatingAirport = trips[1].FromOriginatingAirport,
                            FromFlightArrivalTime = trips[1].FromFlightArrivalTime,
                            ToDropOfPoint = trips[0].ToDropOfPoint
                        };

                        SearchModel.PassengersAndTransfers.Add(m);
                    }
                    // end return passengers and transfers data
                    foreach (var item in model.DateAndLocations)
                    {
                        if (item.IsValid)
                        {
                            if (item.LocationFrom > 0 && item.LocationTo > 0)
                            {
                                var searchReslt = FindTransfers.SearchResult(new FindTransfer { LocationFrom = item.LocationFrom, LocationTo = item.LocationTo, PassngersCount = model.PassngersCount });
                                var LocationFrom = Locations.GetByID(new Locations { ID = item.LocationFrom });
                                var LocationTo = Locations.GetByID(new Locations { ID = item.LocationTo });
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
                                        var extras = Extras.Booking_ExtrasList(new Extras { ID = SelectedCar.ID });

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
                    SearchModel.BookingReference.Add(model.BookingReference);

                    //return confirmation data
                    var email = UserName();
                    var user = Users.GetByUserNameOrEmail(new City.Models.Users { UserName = UserName(), EmailAddress = "" });
                    if (user != null)
                    {
                        email = user.EmailAddress;
                    }

                    var trips = Trips.GetByReferenceAndEmail(new City.Models.Trips { BookingReference = model.BookingReference, EmailAddress = "" });

                    trips = trips.Where(t => t.EmailAddress == email).ToList();
                    SearchModel.Confirmations = new List<ConfirmationViewModel>();
                    if (trips.Count > 0)
                    {
                        var m = new ConfirmationViewModel()
                        {
                            CustomerFirstName = trips[0].CustomerFirstName,
                            CustomerLastName = trips[0].CustomerLastName,
                            CustomerPhone = trips[0].CustomerPhone,
                            CancellationProtection = trips[0].CancellationProtection > 0?true:false,
                            Subscribed = trips[0].Subscribed
                        };

                        SearchModel.Confirmations.Add(m);
                    }

                    // end return confirmation data

                    var index = 0;
                    foreach (var item in model.DateAndLocations)
                    {
                        if (item.IsValid)
                        {
                            if (item.LocationFrom > 0 && item.LocationTo > 0)
                            {
                                var searchReslt = FindTransfers.SearchResult(new FindTransfer { LocationFrom = item.LocationFrom, LocationTo = item.LocationTo, PassngersCount = model.PassngersCount });
                                var LocationFrom = Locations.GetByID(new Locations { ID = item.LocationFrom });
                                var LocationTo = Locations.GetByID(new Locations { ID = item.LocationTo });
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
                                        var extras = Extras.Booking_ExtrasList(new Extras { ID = SelectedCar.ID });

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
                    }

                    if (SearchModel.SearchResultList.Count > 0)
                    {
                        return View(SearchModel);
                    }
                }
            }

            return RedirectToAction(nameof(Index));
        }
        public ActionResult SaveData(FindResultViewModel model)
        {
            if (model.DateAndLocations != null)
            {
                if (model.DateAndLocations.Count > 0)
                {
                    SearchResultViewModel SearchModel = new SearchResultViewModel();
                    SearchModel.BookingReference.Add(model.BookingReference);

                    var index = 0;
                    foreach (var item in model.DateAndLocations)
                    {
                        if (item.IsValid)
                        {
                            if (item.LocationFrom > 0 && item.LocationTo > 0)
                            {
                                var searchReslt = FindTransfers.SearchResult(new FindTransfer { LocationFrom = item.LocationFrom, LocationTo = item.LocationTo, PassngersCount = model.PassngersCount });
                                var LocationFrom = Locations.GetByID(new Locations { ID = item.LocationFrom });
                                var LocationTo = Locations.GetByID(new Locations { ID = item.LocationTo });
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
                                        var extras = Extras.Booking_ExtrasList(new Extras { ID = SelectedCar.ID });

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
                        if (item.Confirmation != null)
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

            //return trips data
            var email = UserName();
            var user = Users.GetByUserNameOrEmail(new City.Models.Users { UserName = UserName(), EmailAddress = "" });
            if (user != null)
            {
                email = user.EmailAddress;
            }

            var trips = Trips.GetByReferenceAndEmail(new City.Models.Trips { BookingReference = model.BookingReference[0], EmailAddress = "" });

            trips = trips.Where(t => t.EmailAddress == email).ToList();

            if (trips == null)
            {
                model.Status.Add(false);
                return model;
            }

            if (trips.Count == 0)
            {
                model.Status.Add(false);
                return model;
            }

            if(trips.Count > 0)
            {
                if(trips[0].TripStatus > 2)
                {
                    model.Status.Add(false);
                    return model;
                }
            }

            if (trips.Count > 1)
            {
                if (trips[1].TripStatus > 2)
                {
                    model.Status.Add(false);
                    return model;
                }
            }

            if (model.SearchResultList.Count > 0)
            {
                var LocationTo = model.SearchResultList[0][0].LocationTo;
                var LocationFrom = model.SearchResultList[0][0].LocationFrom;
                var Transfer = Transfers.GetByLocationToAndLocationFrom(new GeneralTransfers { LocationTo = LocationTo, LocationFrom = LocationFrom });
                if (Transfer != null)
                {
                    TransferId = Transfer.ID;
                }

                if (TransferId == 0)
                {
                    return model;
                }

                if (model.SearchResultList[0][0].ID == 0)
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

                

                if(trips.Count > 0)
                {
                    trips[0].Transfer = TransferId;
                    trips[0].Car = CarId;
                    trips[0].ContactName = model.PassengersAndTransfers[0].ContactName;
                    trips[0].ContactSurname = model.PassengersAndTransfers[0].ContactSurname;
                    trips[0].SaveQuota = model.PassengersAndTransfers[0].SaveQuota;
                    //trips[0].EmailAddress = model.PassengersAndTransfers[0].EmailAddress;
                    trips[0].LeadPassengerMobile = model.PassengersAndTransfers[0].LeadPassengerMobile;
                    trips[0].SMS = model.PassengersAndTransfers[0].SMS;
                    trips[0].FromAirline = model.PassengersAndTransfers[0].FromAirline;
                    trips[0].FromFlightNumber = model.PassengersAndTransfers[0].FromFlightNumber;
                    trips[0].FromOriginatingAirport = model.PassengersAndTransfers[0].FromOriginatingAirport;
                    trips[0].FromFlightArrivalTime = model.PassengersAndTransfers[0].FromFlightArrivalTime;
                    trips[0].ToDropOfPoint = model.PassengersAndTransfers[0].ToDropOfPoint;
                    trips[0].CustomerFirstName = model.Confirmations[0].CustomerFirstName;
                    trips[0].CustomerLastName = model.Confirmations[0].CustomerLastName;
                    trips[0].CustomerPhone = model.Confirmations[0].CustomerPhone;
                    trips[0].Subscribed = model.Confirmations[0].Subscribed;
                    trips[0].CancellationProtection = model.Confirmations[0].CancellationProtection == true ? 3 : 0;
                    //trips[0].CardHolder = model.Payment.CardHolder;
                    //trips[0].CardNumber = model.Payment.CardNumber;
                    //trips[0].ExpiryMonth = model.Payment.ExpiryMonth;
                    //trips[0].ExpireYear = model.Payment.ExpireYear;
                    //trips[0].CCV = model.Payment.CCV;
                    //trips[0].RegisteredDate = DateTime.Now;
                    //trips[0].IsPayed = true;
                    trips[0].Fees = TotalAmount;
                }
                // end return trips data


                

                var result = false;
                if (trips[0].IsValid)
                {
                    result = Trips.Update(trips[0]);
                }

                if (result)
                {
                    if (model.Extras.Count > 0)
                    {
                        //delete old extras 
                        var OldExtras = TripsExtras.GetByTripId(new Trip_Extars {Trip=trips[0].ID});
                        if(OldExtras != null)
                        {
                            foreach(var e in OldExtras)
                            {
                                TripsExtras.Delete(new Trip_Extars {ID = e.ID});
                            }
                        }

                        foreach (var item in model.Extras[0])
                        {
                            if(item.RequiredInfoValue == null)
                            {
                                item.RequiredInfoValue = "";
                            }

                            var TripExtras = new Trip_Extars()
                            {
                                Trip = trips[0].ID,
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

                    if (model.SearchResultList.Count != 2)
                    {
                        model.Status.Add(true);
                        model.BookingReference.Add(trips[0].BookingReference);
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

                if (trips.Count > 1)
                {
                    trips[1].Transfer = TransferId;
                    trips[1].Car = CarId;
                    trips[1].ContactName = model.PassengersAndTransfers[1].ContactName;
                    trips[1].ContactSurname = model.PassengersAndTransfers[1].ContactSurname;
                    trips[1].SaveQuota = model.PassengersAndTransfers[1].SaveQuota;
                    //trips[0].EmailAddress = model.PassengersAndTransfers[0].EmailAddress;
                    trips[1].LeadPassengerMobile = model.PassengersAndTransfers[1].LeadPassengerMobile;
                    trips[1].SMS = model.PassengersAndTransfers[1].SMS;
                    trips[1].FromAirline = model.PassengersAndTransfers[1].FromAirline;
                    trips[1].FromFlightNumber = model.PassengersAndTransfers[1].FromFlightNumber;
                    trips[1].FromOriginatingAirport = model.PassengersAndTransfers[1].FromOriginatingAirport;
                    trips[1].FromFlightArrivalTime = model.PassengersAndTransfers[1].FromFlightArrivalTime;
                    trips[1].ToDropOfPoint = model.PassengersAndTransfers[1].ToDropOfPoint;
                    trips[1].CustomerFirstName = model.Confirmations[0].CustomerFirstName;
                    trips[1].CustomerLastName = model.Confirmations[0].CustomerLastName;
                    trips[1].CustomerPhone = model.Confirmations[0].CustomerPhone;
                    trips[1].Subscribed = model.Confirmations[0].Subscribed;
                    trips[1].CancellationProtection = model.Confirmations[0].CancellationProtection == true ? 3 : 0;
                    //trips[0].CardHolder = model.Payment.CardHolder;
                    //trips[0].CardNumber = model.Payment.CardNumber;
                    //trips[0].ExpiryMonth = model.Payment.ExpiryMonth;
                    //trips[0].ExpireYear = model.Payment.ExpireYear;
                    //trips[0].CCV = model.Payment.CCV;
                    //trips[0].RegisteredDate = DateTime.Now;
                    //trips[0].IsPayed = true;
                    trips[1].Fees = TotalAmount;

                    var result = false;
                    if (trips[1].IsValid)
                    {
                        result = Trips.Update(trips[1]);
                    }

                    if (result)
                    {
                        if (model.Extras.Count > 1)
                        {
                            //delete old extras 
                            var OldExtras = TripsExtras.GetByTripId(new Trip_Extars { Trip = trips[1].ID });
                            if (OldExtras != null)
                            {
                                foreach (var e in OldExtras)
                                {
                                    TripsExtras.Delete(new Trip_Extars { ID = e.ID });
                                }
                            }

                            foreach (var item in model.Extras[1])
                            {

                                if (item.RequiredInfoValue == null)
                                {
                                    item.RequiredInfoValue = "";
                                }
                                var TripExtras = new Trip_Extars()
                                {
                                    Trip = trips[1].ID,
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

                        model.Status.Add(true);
                        model.BookingReference.Add(trips[1].BookingReference);
                        return model;
                    }
                }
                else{

                    TransferId = 0;
                    LocationTo = model.SearchResultList[1][0].LocationTo;
                    LocationFrom = model.SearchResultList[1][0].LocationFrom;
                    Transfer = Transfers.GetByLocationToAndLocationFrom(new GeneralTransfers { LocationTo = LocationTo, LocationFrom = LocationFrom });
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

                    CarId = model.SearchResultList[1][0].ID;

                    //calc fees
                    VehicleBasePrice = 0;
                    VehicleBasePrice = model.SearchResultList[1][0].SellingPrice;
                    Extras = 0;
                    Discount = 0;
                    SmsMessage = 0;
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

                     CancellationProtection = 0;
                    if (model.Confirmations[0].CancellationProtection)
                    {
                        CancellationProtection = 3;
                    }

                     SubTotal = VehicleBasePrice - Discount;
                     TotalAmount = SubTotal + Extras + SmsMessage + CancellationProtection;

                    var trip = new Trips()
                    {
                        Transfer = TransferId,
                        Car = CarId,
                        ContactName = model.PassengersAndTransfers[1].ContactName,
                        ContactSurname = model.PassengersAndTransfers[1].ContactSurname,
                        SaveQuota = model.PassengersAndTransfers[1].SaveQuota,
                        EmailAddress = trips[0].EmailAddress,
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
                        CardHolder = trips[0].CardHolder,
                        CardNumber = trips[0].CardNumber,
                        ExpiryMonth = trips[0].ExpiryMonth,
                        ExpireYear = trips[0].ExpireYear,
                        CCV = trips[0].CCV,
                        RegisteredDate = DateTime.Now,
                        IsPayed = true,
                        Fees = TotalAmount,
                        BookingReference = trips[0].BookingReference,
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

                                if (TripExtras.IsValid)
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
            

                
            }
            else
            {
                if(trips.Count > 1)
                {
                    var TripId = trips[1].ID;
                    Trips.Delete(trips[1]);
                    var extras = TripsExtras.GetByTripId(new Trip_Extars { Trip = TripId});
                    if(extras != null)
                    {
                        foreach(var item in extras)
                        {
                            TripsExtras.Delete(item);
                        }
                    }
                }
            }

            return model;


        }
        public ActionResult CancelTrip(string id = "")
        {
            var email = UserName();
            var user = Users.GetByUserNameOrEmail(new City.Models.Users { UserName = UserName(), EmailAddress = "" });
            if (user != null)
            {
                email = user.EmailAddress;
            }

            var trips = Trips.GetByReferenceAndEmail(new City.Models.Trips { BookingReference = id, EmailAddress = "" });

            trips = trips.Where(t => t.EmailAddress == email).ToList();

            if(trips != null)
            {
                if(trips.Count > 0)
                {
                    trips[0].TripStatus = 3;
                    Trips.Update(trips[0]);
                }

                if(trips.Count > 1)
                {
                    trips[1].TripStatus = 3;
                    Trips.Update(trips[1]);
                }
            }

            return RedirectToAction(nameof(Index));
        }
        public ActionResult TripSurvey(int id = 0)
        {
           

            var email = UserName();
            var user = Users.GetByUserNameOrEmail(new City.Models.Users { UserName = UserName(), EmailAddress = "" });
            if (user != null)
            {
                email = user.EmailAddress;
            }

            var trip = Trips.GetByID(new City.Models.Trips { ID = id});

            if(trip != null)
            {
                if(trip.EmailAddress == email)
                {
                    var Survey = TripsKpiFactory.GetByTripId(new TripsKpi { TripId = trip.ID });
                    if(Survey != null)
                    {
                        if (Survey.Count > 0)
                        {
                            return RedirectToAction(nameof(SurveyDetails), new { id = trip.ID });
                        }
                    }
                    var kpis = (from k in KpiFactory.GetAll()
                               select new TripsKpi
                               {
                                   ReferenceId = trip.BookingReference,
                                   TripId = trip.ID,
                                   KpiId = k.ID,
                                   Name = k.Name
                               }).ToList();

                    return View(kpis);
                }
            }

            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public ActionResult TripSurvey(List<TripsKpi> model)
        {
            
            if(model.Count > 0)
            {
                var email = UserName();
                var user = Users.GetByUserNameOrEmail(new City.Models.Users { UserName = UserName(), EmailAddress = "" });
                if (user != null)
                {
                    email = user.EmailAddress;
                }

                var trip = Trips.GetByID(new City.Models.Trips { ID = model[0].TripId});
                if(trip != null)
                {
                    if(trip.EmailAddress == email)
                    {
                        decimal TotalWeight = 0;
                        decimal TotalPercentOfWeight = 0;
                        foreach (var item in model)
                        {
                            var kpi = KpiFactory.GetByID(new Kpi { ID = item.KpiId });

                            if (item.Details == null)
                            {
                                item.Details = "";
                            }

                            if (item.Decription == null)
                            {
                                item.Decription = "";
                            }

                            if (kpi != null)
                            {
                                decimal Percent = item.Value / 5;
                                int PercentFromWeight = Convert.ToInt32(Percent * kpi.Weight);
                                TotalWeight += kpi.Weight;
                                TotalPercentOfWeight += PercentFromWeight;
                                var tripKpi = new TripsKpi
                                {
                                    TripId = trip.ID,
                                    KpiId = kpi.ID,
                                    PercentValue = PercentFromWeight,
                                    Decription = item.Decription,
                                    Details = item.Details
                                };

                                TripsKpiFactory.Insert(tripKpi);
                            }
                        }

                        decimal TripQOS = TotalPercentOfWeight / TotalWeight*100;
                        var Invitations = TripsInvitations.GetSentInvitations(new TransferInvitations { Trip = trip.ID });
                        if (Invitations != null)
                        {
                            if (Invitations.Count > 0)
                            {
                                var Invitation = Invitations.FirstOrDefault(i => i.AcceptionStatus > 8);
                                Invitation.QOS = Convert.ToInt32(TripQOS);
                                TripsInvitations.Update(Invitation);
                                var Company = Companies.GetByID(new City.Models.Companies { ID = Invitation.Company });
                                if (Company != null)
                                {
                                    var CompanyTrips = Trips.GetByCompanyId(new City.Models.Trips { CompanyId = Company.ID });
                                    if (CompanyTrips != null)
                                    {
                                        if (CompanyTrips.Count > 0)
                                        {
                                            var CompanyDoneTrips = CompanyTrips.Where(i => i.TripStatus > 8).ToList();
                                            if (CompanyDoneTrips != null)
                                            {
                                                if (CompanyDoneTrips.Count > 0)
                                                {
                                                    decimal CompanyTotalQOS = Company.QOS * (CompanyTrips.Count - 1);
                                                    Company.QOS = Convert.ToInt32((CompanyTotalQOS + TripQOS) / CompanyDoneTrips.Count);
                                                    Companies.Update(Company);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                    

                }
            }

            return RedirectToAction(nameof(Index));
        }
        public ActionResult SurveyDetails(int id = 0)
        {
            if(id == 0)
            {
                return RedirectToAction(nameof(Index));
            }

            var Survey = TripsKpiFactory.GetByTripId(new TripsKpi {TripId = id});
            if(Survey != null)
            {
                if(Survey.Count > 0)
                {
                    return View(Survey);
                }
            }

            return RedirectToAction(nameof(Index));

        }
        public ActionResult Complaints(int id = 0)
        {
            var email = UserName();
            var user = Users.GetByUserNameOrEmail(new City.Models.Users { UserName = UserName(), EmailAddress = "" });
            if (user != null)
            {
                email = user.EmailAddress;
            }

            var trip = Trips.GetByID(new City.Models.Trips { ID = id});

            if (trip != null)
            {
                if(trip.EmailAddress == email)
                {
                    return View(trip.ID);
                }
            }

            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public ActionResult Complaints(Complaints model)
        {
            if(model.IsValid)
            {
                var email = UserName();
                var user = Users.GetByUserNameOrEmail(new City.Models.Users { UserName = UserName(), EmailAddress = "" });
                if (user != null)
                {
                    email = user.EmailAddress;
                }

                var trip = Trips.GetByID(new City.Models.Trips { ID = model.TripId });

                if (trip != null)
                {
                    if (trip.EmailAddress != email)
                    {
                        return RedirectToAction(nameof(Index));
                    }

                    ComplaintsFactory.Insert(model);
                }
            }
            return RedirectToAction(nameof(Index));

        }
    }
}