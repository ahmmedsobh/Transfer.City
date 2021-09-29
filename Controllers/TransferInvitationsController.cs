using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Linq.Dynamic.Core;
using Transfer.City.Models;
using Transfer.City.Models.ViewModels;

namespace Transfer.City.Controllers
{
    public class TransferInvitationsController : BaseController
    {
        // GET: TransferInvitations
        public ActionResult Index()
        {
            InvitationsViewModel model = new InvitationsViewModel();

            var companies = (from c in Companies.GetAll()
                             select new DropdownViewModel<int>
                             {
                                 Value = c.ID,
                                 Name = c.Company_Name
                             }).ToList();

            model.Companies = companies;
            model.TripStatus = TripStatus;

            return View(model);
        }

        public ActionResult InvitationsList()
        {
            try
            {

                int start = Convert.ToInt32(Request["start"]);
                int length = Convert.ToInt32(Request["length"]);
                string searchValue = Request["search[value]"];
                string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
                string sortDirection = Request["order[0][dir]"];
                string drow = Request["draw"];

                if (sortColumnName == "")
                {
                    sortColumnName = "CompanyName";
                }

                var InvitationsList = TripsInvitations.GetAll();

                int totalrows = InvitationsList.Count;

                if (!string.IsNullOrEmpty(searchValue))
                {
                    InvitationsList = (from t in InvitationsList
                                       where t.CompanyName.ToLower().Contains(searchValue.ToLower())
                                     || t.Price.ToString().Contains(searchValue.ToLower())
                                     || t.AcceptionStatusTitle.ToLower().Contains(searchValue.ToLower())
                                     || t.CompanyQOS.ToString().Contains(searchValue)
                                 select t).ToList();
                }

                int totalrowsafterfiltering = InvitationsList.Count;
                //sorting
                InvitationsList = InvitationsList.AsQueryable().OrderBy(sortColumnName + " " + sortDirection).ToList();

                //paging
                InvitationsList = InvitationsList.Skip(start).Take(length).ToList();

                var data = Json(new { InvitationsList = InvitationsList, draw = drow, recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
                data.MaxJsonLength = int.MaxValue;
                return data;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public ActionResult FilterInvitations(TransferInvitations invitations)
        {
            try
            {

                int start = Convert.ToInt32(Request["start"]);
                int length = Convert.ToInt32(Request["length"]);
                string searchValue = Request["search[value]"];
                string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
                string sortDirection = Request["order[0][dir]"];
                string drow = Request["draw"];

                if (sortColumnName == "")
                {
                    sortColumnName = "CompanyName";
                }

                var InvitationsList = TripsInvitations.FilterInvitations(invitations);

                int totalrows = InvitationsList.Count;

                if (!string.IsNullOrEmpty(searchValue))
                {
                    InvitationsList = (from t in InvitationsList
                                       where t.CompanyName.ToLower().Contains(searchValue.ToLower())
                                     || t.Price.ToString().Contains(searchValue.ToLower())
                                     || t.AcceptionStatusTitle.ToLower().Contains(searchValue.ToLower())
                                     || t.CompanyQOS.ToString().Contains(searchValue)
                                       select t).ToList();
                }

                int totalrowsafterfiltering = InvitationsList.Count;
                //sorting
                InvitationsList = InvitationsList.AsQueryable().OrderBy(sortColumnName + " " + sortDirection).ToList();

                //paging
                InvitationsList = InvitationsList.Skip(start).Take(length).ToList();

                var data = Json(new { InvitationsList = InvitationsList, draw = drow, recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
                data.MaxJsonLength = int.MaxValue;
                return data;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}