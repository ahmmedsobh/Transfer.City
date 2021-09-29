using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Transfer.City.Helpers;
using Transfer.City.Models;
using Transfer.City.Models.ViewModels;
using System.Linq.Dynamic.Core;

namespace Transfer.City.Controllers
{
    
    public class CompaniesController : BaseController
    {
        // GET: Companies
        public ActionResult Index()
        {
            CompanyViewModel model = new CompanyViewModel();
            model.Countries = (from c in Countries.GetAll()
                               select new DropdownViewModel<int>
                               { Name = c.Name, Value = c.ID }).ToList();

            model.Currencies = (from c in Currencies.GetAll()
                                select new DropdownViewModel<int>
                                { Name = c.Name, Value = c.ID }).ToList();

            return View(model);
        }
        public ActionResult CompaniesList()
        {
            try
            {
                var CompaniesList = (from c in Companies.GetAll()
                                     select new Companies
                                     {
                                         ID = c.ID,
                                         Company_Name = c.Company_Name,
                                         Trading_Name = c.Trading_Name,
                                         CountryName = c.CountryName,
                                         Phone = c.Phone,
                                         CurrencyName = c.CurrencyName
                                     });

                var data = Json(CompaniesList, JsonRequestBehavior.AllowGet);
                data.MaxJsonLength = int.MaxValue;
                return data;
            }
            catch (Exception ex)
            {
                var CompaniesList = new List<Companies>();
                var data = Json(CompaniesList, JsonRequestBehavior.AllowGet);
                data.MaxJsonLength = int.MaxValue;
                return data;
            }

        }
        [HttpGet]
        public ActionResult Insert()
        {
            CompanyViewModel model = new CompanyViewModel();

            model.Countries = (from c in Countries.GetAll()
                              select new DropdownViewModel<int>
                              { Name = c.Name, Value = c.ID }).ToList();

            model.Currencies = (from c in Currencies.GetAll()
                                select new DropdownViewModel<int>
                                { Name = c.Name, Value = c.ID }).ToList();


            return View(model);
        }
        [HttpPost]
        public ActionResult Insert(Companies company)
        {
            var Message = new Message("Aadding process", "An error occurred, please try", MessageType.warning);
            company.RegisteredDate = DateTime.Now;
            if (company.IsValid)
            {
                if(company.Password != company.ConfirmPassword)
                {
                    Message = new Message("Aadding process", "Confirm password is not equal", MessageType.warning);
                    return Json(new
                    {
                        Message = Message,
                    }, JsonRequestBehavior.AllowGet);
                }

                var UserFromDB = Users.GetByUserNameOrEmail(new Users {UserName = company.Account_Administrator,EmailAddress = company.Account_Administrator_Email });
                if(UserFromDB != null)
                {
                    Message = new Message("Aadding process", "Username or login email already exists", MessageType.warning);
                    return Json(new
                    {
                        Message = Message,
                    }, JsonRequestBehavior.AllowGet);
                }

                var user = new Users()
                {
                    UserName = company.Account_Administrator,
                    Password = company.Password,
                    EmailAddress = company.Account_Administrator_Email,
                    DisplayName = company.Company_Name,
                    IsCompany = true,
                    CreatedDate = DateTime.Now,
                    IsActive = company.IsActive,
                    IsEnabled = company.IsEnabled
                };

                if (Users.Insert(user))
                {
                    company.UserID = user.ID;
                    if (company.IsApproved)
                        company.ApprovedDate = DateTime.Now;
                    else
                        company.ApprovedDate = null;


                    if (Companies.Insert(company))
                    {
                        Message = new Message("Aadding process", "Added successfully", MessageType.success);
                        return Json(new
                        {
                            Message = Message,
                        }, JsonRequestBehavior.AllowGet);

                    }
                }

                
            }
            else
            {
                var messageDescription = "An error occurred, please try";
                if (company.BrokenRulesList[0] != null)
                {
                    messageDescription = company.BrokenRulesList[0].Description;
                }
                Message = new Message("Aadding process", messageDescription, MessageType.warning);
            }

            return Json(new
            {
                Message = Message,
            }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Update(int Id = 0)
        {
            if(Id == 0)
            {
                return HttpNotFound();
            }
            CompanyViewModel model = new CompanyViewModel(); 

            var Company = new Companies() { ID = Id };
            Company = Companies.GetByID(Company);

            var Cars = Company_Cars.GetByCompanyID(new Company_Cars {Company = Id});
            var Locations = Company_Locations.GetCompanyEnabledLocationsByCompanyID(new Company_Locations { Company = Id });
            model.Countries = (from c in Countries.GetAll()
                               select new DropdownViewModel<int>
                               { Name = c.Name, Value = c.ID }).ToList();

            model.Currencies = (from c in Currencies.GetAll()
                                select new DropdownViewModel<int>
                                { Name = c.Name, Value = c.ID }).ToList();

            model.Company = Company;
            model.Locations = Locations;
            model.Cars = Cars;

            return View(model);
        }
        [HttpPost]
        public ActionResult Update(Companies company)
        {
            company.Account_Administrator_Email = "a@g.com";
            company.Password = "gggggggggg$F1";
            company.RegisteredDate = DateTime.Now;

            var Message = new Message("Updating process", "An error occurred, please try", MessageType.warning);

            if (company.IsValid)
            {
                if (company.IsApproved)
                    company.ApprovedDate = DateTime.Now;
                else
                    company.ApprovedDate = null;

                if (Companies.Update(company))
                {
                    Message = new Message("Updating process", "Edited successfully", MessageType.success);
                    return Json(new
                    {
                        Message = Message,
                    }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                var messageDescription = "An error occurred, please try";
                if (company.BrokenRulesList[0] != null)
                {
                    messageDescription = company.BrokenRulesList[0].Description;
                }
                Message = new Message("Updating process", messageDescription, MessageType.warning);
            }

            return Json(new
            {
                Message = Message,
            }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Details(int Id = 0)
        {
            if (Id == 0)
            {
                return HttpNotFound();
            }
            CompanyViewModel model = new CompanyViewModel();

            var Company = new Companies() { ID = Id };
            Company = Companies.GetByID(Company);

            var Cars = Company_Cars.GetByCompanyID(new Company_Cars { Company = Id });
            var Locations = Company_Locations.GetCompanyEnabledLocationsByCompanyID(new Company_Locations { Company = Id });

            model.Countries = (from c in Countries.GetAll()
                               select new DropdownViewModel<int>
                               { Name = c.Name, Value = c.ID }).ToList();

            model.Currencies = (from c in Currencies.GetAll()
                                select new DropdownViewModel<int>
                                { Name = c.Name, Value = c.ID }).ToList();

            model.Company = Company;
            model.Locations = Locations;
            model.Cars = Cars;

            return View(model);
        }
        [HttpPost]
        public ActionResult Delete(int Id = 0)
        {
            var Message = new Message("Deleting process", "An error occurred, please try", MessageType.warning);

            if (Id == 0)
            {
                return Json(new
                {
                    Message = Message,
                }, JsonRequestBehavior.AllowGet);
            }

            var company = Companies.GetByID(new Companies { ID = Id});
            
            if(company == null)
            {
                return Json(new
                {
                    Message = Message,
                }, JsonRequestBehavior.AllowGet);
            }

            Users.Delete(new Users { ID = company.UserID });
            var result = Companies.Delete(company);
            if (result)
            {
                Message = new Message("Deleting process", "Deleted successfully", MessageType.success);
                return Json(new
                {
                    Message = Message,
                }, JsonRequestBehavior.AllowGet);
            }

            return Json(new
            {
                Message = Message,
            }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult CompanyCars(int CompanyId = 0)
        {
            var companyCarsList = CompanyCarsList(CompanyId);

            var data = Json(companyCarsList, JsonRequestBehavior.AllowGet);
            data.MaxJsonLength = int.MaxValue;
            return data;
        }
        public ActionResult ApproveCompanyCars(int CompanyId = 0 , int CarId = 0)
        {

            var CompanyCar = Company_Cars.GetByID(new Company_Cars() { Company = CompanyId, Car = CarId });

            if(CompanyCar != null)
            {
                if(CompanyCar.Approved)
                {
                    CompanyCar.Approved = false;
                    CompanyCar.ApprovedDate = null;
                }
                else
                {
                    CompanyCar.Approved = true;
                    CompanyCar.ApprovedDate = DateTime.Now;
                }

                Company_Cars.Update(CompanyCar);
            }

            var data = Json(true, JsonRequestBehavior.AllowGet);
            return data;
        }
        public List<Company_Cars> CompanyCarsList(int CompanyId)
        {
           var CompanyCarsList = (from c in Company_Cars.GetByCompanyID(new Company_Cars { Company = CompanyId })
                               select new Company_Cars
                               {
                                   ID = c.ID,
                                   Company = c.Company,
                                   Car = c.Car,
                                   CarName = c.CarName,
                                   Approved = c.Approved,
                                   Max_Passengers = c.Max_Passengers,
                                   Max_Suitcases = c.Max_Suitcases
                               }).ToList();

            return CompanyCarsList;

        }
        public ActionResult LocationsList(int CompanyId = 0)
        {
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchValue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            string drow = Request["draw"];

            if (sortColumnName == "")
            {
                sortColumnName = "LocationName";
            }

            var LocationsList = Company_Locations.GetByCompanyID(new Company_Locations { Company = CompanyId });

            int totalrows = LocationsList.Count;

            if (!string.IsNullOrEmpty(searchValue))
            {
                LocationsList = (from t in LocationsList
                                 where t.LocationName.ToLower().Contains(searchValue.ToLower())
                                 || t.CountryName.ToLower().Contains(searchValue.ToLower())
                                 || t.LocationTypeName.Contains(searchValue)
                                 select t).ToList();
            }

            int totalrowsafterfiltering = LocationsList.Count;
            //sorting
            LocationsList = LocationsList.AsQueryable().OrderBy(sortColumnName + " " + sortDirection).ToList();


            //paging
            LocationsList = LocationsList.Skip(start).Take(length).ToList();

            var data = Json(new { LocationsList = LocationsList, draw = drow, recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
            data.MaxJsonLength = int.MaxValue;
            return data;
        }
        public ActionResult ApproveCompanyLocations(int CompanyId = 0, int LocationId = 0)
        {
            if (CompanyId == 0 || LocationId == 0)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }

            var CompanyLocation = Company_Locations.GetByID(new Company_Locations() { Company = CompanyId, Location = LocationId });

            if (CompanyLocation != null)
            {
                if (CompanyLocation.Enabled)
                {
                    CompanyLocation.Enabled = false;
                    CompanyLocation.EnabledDate = null;
                }
                else
                {
                    CompanyLocation.Enabled = true;
                    CompanyLocation.EnabledDate = DateTime.Now;
                }

                Company_Locations.Update(CompanyLocation);
            }
            else
            {
                CompanyLocation = new Company_Locations()
                {
                    Company = CompanyId,
                    Location = LocationId,
                    Enabled = true,
                    EnabledDate = DateTime.Now
                };

                Company_Locations.Insert(CompanyLocation);
            }

            var data = Json(true, JsonRequestBehavior.AllowGet);
            return data;
        }
        public ActionResult TransfersList(int CompanyId = 0, int CarId = 0)
        {
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchValue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            string drow = Request["draw"];

            if (sortColumnName == "")
            {
                sortColumnName = "LocationName";
            }

            var TransfersList = CustomerPrices.GetTransferList(new Customer_Prices { CompanyID = CompanyId,CarID = CarId });

            int totalrows = TransfersList.Count;

            if (!string.IsNullOrEmpty(searchValue))
            {
                TransfersList = (from t in TransfersList
                                 where t.FromLocation.ToLower().Contains(searchValue.ToLower())
                                 || t.ToLocation.ToLower().Contains(searchValue.ToLower())
                                 select t).ToList();
            }

            int totalrowsafterfiltering = TransfersList.Count;
            //sorting
            TransfersList = TransfersList.AsQueryable().OrderBy(sortColumnName + " " + sortDirection).ToList();


            //paging
            TransfersList = TransfersList.Skip(start).Take(length).ToList();

            

            var data = Json(new { TransfersList = TransfersList, draw = drow, recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering  }, JsonRequestBehavior.AllowGet);
            data.MaxJsonLength = int.MaxValue;
            return data;
        }
        public ActionResult ApprovedTransfersList(int CompanyId = 0, int CarId = 0)
        {
            var TransfersList = CustomerPrices.GetApprovedTransferList(new Customer_Prices { CompanyID = CompanyId, CarID = CarId });
            var data = Json(new { TransfersList = TransfersList }, JsonRequestBehavior.AllowGet);
            data.MaxJsonLength = int.MaxValue;
            return data;
        }
        public ActionResult ApproveCompanyPrices(CustomerPricesViewModel model)
        {
            if (model.CompanyID == 0 || model.CarID == 0)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }

            var company = Companies.GetByID(new Models.Companies {ID= model.CompanyID });
            var car = Company_Cars.GetByID(new Company_Cars { Car = model.CarID , Company=model.CompanyID});

            if(company == null || car == null)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }

            var Customer_Prices = model.Customer_Prices;

            foreach (var item in Customer_Prices)
            {

                if(item.GeneralTransferID == 0)
                {
                    return Json(false, JsonRequestBehavior.AllowGet);
                }

                var GeneralTransfer = Transfers.GetByID(new GeneralTransfers {ID = item.GeneralTransferID });

                if (GeneralTransfer == null)
                {
                    return Json(false, JsonRequestBehavior.AllowGet);
                }

                var CustomerPrice = CustomerPrices.GetSingle(new Customer_Prices() { CompanyID = model.CompanyID, CarID = model.CarID,GeneralTransferID = item.GeneralTransferID });

                if (CustomerPrice != null)
                {
                    if(item.Price > 0 || item.SellingPrice > 0)
                    {
                        CustomerPrice.Price = item.Price;
                        CustomerPrice.SellingPrice = item.SellingPrice;
                        CustomerPrices.Update(CustomerPrice);
                    }
                    else
                    {
                        CustomerPrices.Delete(CustomerPrice);
                    }


                }
                else
                {
                    if (item.Price > 0 && item.SellingPrice > 0)
                    {
                        CustomerPrice = new Customer_Prices()
                        {
                            CompanyID = model.CompanyID,
                            CarID = model.CarID,
                            GeneralTransferID = item.GeneralTransferID,
                            Price = item.Price,
                            SellingPrice= item.SellingPrice
                        };

                        CustomerPrices.Insert(CustomerPrice);
                    }
                }
            }

            

            var data = Json(true, JsonRequestBehavior.AllowGet);
            return data;
        }
        public ActionResult FillCarsDropdown(int CompanyId = 0)
        {
            var AprovedCars = Company_Cars.GetByCompanyID(new Company_Cars { Company = CompanyId });
            var Cars = (from c in AprovedCars
                        where c.Approved
                        select new DropdownViewModel<int>
                        {
                            Value = c.Car,
                            Name = c.CarName
                        }).ToList();
            
            var data = Json(new { Cars=Cars }, JsonRequestBehavior.AllowGet);
            return data;
        }
        public ActionResult FilterCompanies(int CountryId = 0 , int CurrencyId = 0)
        {
            var CompaniesList = Companies.FilterCompanies(CountryId,CurrencyId);

            var data = Json(CompaniesList, JsonRequestBehavior.AllowGet);
            data.MaxJsonLength = int.MaxValue;
            return data;
        }
    }
}