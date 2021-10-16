using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Transfer.City.BusinessLayer;
using Transfer.City.Models.ViewModels;

namespace Transfer.City.Controllers
{
    public class BaseController : Controller
    {
        public CountriesFactory Countries = new CountriesFactory();
        public LocationsFactory Locations = new LocationsFactory();
        public CarsFactory Cars = new CarsFactory();
        public CurrenciesFactory Currencies = new CurrenciesFactory();
        public GeneralTransfersFactory Transfers = new GeneralTransfersFactory();
        public CompaniesFactory Companies = new CompaniesFactory();
        public Company_CarsFactory Company_Cars = new Company_CarsFactory();
        public Company_LocationsFactory Company_Locations = new Company_LocationsFactory();
        public UsersFactory Users = new UsersFactory();
        public ExtrasFactory Extras = new ExtrasFactory();
        public Extra_CarsFactory Extra_Cars = new Extra_CarsFactory();
        public CustomerPricesFactory CustomerPrices = new CustomerPricesFactory();
        public TripsFactory Trips = new TripsFactory();
        public Trip_ExtarsFactory TripsExtras = new Trip_ExtarsFactory();
        public TransferInvitationsFactory TripsInvitations = new TransferInvitationsFactory();
        public UserPermissionsFactory UserPermissions = new UserPermissionsFactory();
        public PermissionsFactory Permissions = new PermissionsFactory();
        public FindTransferFactory FindTransfers = new FindTransferFactory();
        public KpiFactory KpiFactory = new KpiFactory();
        public TripsKpiFactory TripsKpiFactory = new TripsKpiFactory();
        public ComplaintsFactory ComplaintsFactory = new ComplaintsFactory();


        public int UserId()
        {
            var userId = Convert.ToInt32(Session["UserId"]);
            return userId;
        }

        public string UserName()
        {
            var UserName = Convert.ToString(Session["UserName"]);
            return UserName;
        }



        public List<DropdownViewModel<int>> TripStatus = new List<DropdownViewModel<int>>()
        {
            new DropdownViewModel<int>{Value=1,Name="Reserved without payment"},
            new DropdownViewModel<int>{Value=2,Name="booking confirmed"},
            new DropdownViewModel<int>{Value=3,Name="Booking canceled"},
            new DropdownViewModel<int>{Value=4,Name="An invitation has been sent to the service provider"},
            new DropdownViewModel<int>{Value=5,Name="The invitation has been cancelled"},
            new DropdownViewModel<int>{Value=6,Name="Accepted by the service provider"},
            new DropdownViewModel<int>{Value=7,Name="Rejected by the service provider"},
            new DropdownViewModel<int>{Value=8,Name="The service is in progress"},
            new DropdownViewModel<int>{Value=9,Name="The service was carried out without problems"},
            new DropdownViewModel<int>{Value=10,Name="Service performed with problems"},
            new DropdownViewModel<int>{Value=11,Name="The service has not been performed"},
        };

    }

}