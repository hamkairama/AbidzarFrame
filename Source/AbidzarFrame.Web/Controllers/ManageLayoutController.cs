using AutoMapper;
using System;
using System.Linq;
using System.Web.Mvc;
using AbidzarFrame.Web.WebApiLocal;
using System.Collections;
using AbidzarFrame.Web.Models;
using System.Collections.Generic;
using System.Web;
using AbidzarFrame.Security.Interface.Dto;
using Newtonsoft.Json;
using System.Threading.Tasks;
using AbidzarFrame.Web.Helpers;

namespace AbidzarFrame.Web.Controllers
{
    public class ManageLayoutController : Controller
    {
        public ManageLayoutController()
        {
            Mapper.CreateMap<MenuRequest, MenuViewModel>();
            Mapper.CreateMap<MenuViewModel, MenuRequest>();
            Mapper.CreateMap<MenuResult, MenuViewModel>();
            Mapper.CreateMap<MenuResult, MenuRequest>();
        }

        //[AllowAnonymous]
        // GET: ManageLayout
        public ActionResult Index()
        {
            MenuGenerator();
            return PartialView("_AsideMenus");
        }

        protected void MenuGenerator()
        {
            GlobalVariableUser userVariable = (GlobalVariableUser)Session["GlobalUserVariable"];

            if (CurrentUser.GetCurrentUserId() != null)
            {
                try
                {
                    // check current context requestnya lagi di posisi menu yang mana
                    var currentContext = System.Web.HttpContext.Current;
                    var routeData = currentContext.Request.RequestContext.RouteData;
                    string getAction = routeData.Values.ContainsKey("Action") ? (string)routeData.Values["Action"] : null;
                    string getController = routeData.Values.ContainsKey("Controller") ? (string)routeData.Values["Controller"] : null;
                    string getArea = routeData.DataTokens.ContainsKey("Area") ? (string)routeData.DataTokens["Area"] : null;

                    if (userVariable.MenuResponse == null)
                    {
                        MenuRequest request = new MenuRequest()
                        {
                            DieditOleh = CurrentUser.GetCurrentUserId(),
                        };
                        request.AuthenticationToken = AuthenticationConfiguration.GetInstance().WebServiceAuthenticationToken;

                        //call api
                        string apiUrl = "api/Menu/GetMenuAccessRight";
                        request.Nik = CurrentUser.GetCurrentUserId();
                        var doProcess = JsonConvert.DeserializeObject<MenuResponse>(JasonMapper.ConvertHttpResponseToJson(apiUrl, request));
                                               

                        if (doProcess.Errors.HasError)
                        {
                            throw new InvalidOperationException(exceptionWcf(doProcess));
                        }
                        userVariable.MenuResponse = doProcess;
                        Session["GlobalUserVariable"] = userVariable;
                    }

                    var data =
                           from q in userVariable.MenuResponse.MenuResultList
                           select new MenuViewModel
                           {
                               Id = q.Id,
                               NamaMenu = q.NamaMenu,
                               ParentId = q.ParentId,
                               NamaParent = q.NamaParent,
                               NamaIcon = q.NamaIcon,
                               MenuArea = q.MenuArea,
                               MenuController = q.MenuController,
                               MenuAction = q.MenuAction,
                               MenuLink = !string.IsNullOrWhiteSpace(q.MenuController) ? Url.Action(q.MenuAction, q.MenuController, new { area = q.MenuArea }) : "#",
                               ActiveClass = q.MenuArea == getArea && q.MenuController == getController ? "active" : "",
                               DieditTanggal = q.DieditTanggal
                           };
                    ViewBag.MenuList = BuildTree(data.ToList(), getArea, getController, getAction);
                }
                catch (Exception ex)
                {

                }
            }
        }

        static List<MenuViewModel> BuildTree(List<MenuViewModel> items, string area, string controller, string action)
        {
            items.ForEach(i =>
            {
                i.ChildMenu = items.Where(ch => ch.ParentId == i.Id).ToList();
                i.ActiveClass = items.Where(ch => ch.ParentId == i.Id && ch.ActiveClass == "active").Any() ? "active open" : i.ActiveClass;
            });
            items.ForEach(i => i.ActiveClass = items.Where(ch => ch.ParentId == i.Id && ch.ActiveClass == "active open").Any() ? "active open" : i.ActiveClass);
            return items.Where(i => i.ParentId == null).ToList();
        }

        protected string exceptionWcf(MenuResponse response)
        {
            var result = "";
            if (response != null)
            {
                foreach (var row in response.Errors.ErrorList)
                {
                    if (!string.IsNullOrWhiteSpace(row.ErrorMessage))
                    {
                        result += row.ErrorMessage + "<br/>";
                    }
                }
            }
            return result;
        }

        public JsonResult GetQuickSearchMenus(string search)
        {
            GlobalVariableUser userVariable = (GlobalVariableUser)Session["GlobalUserVariable"];

            if (userVariable != null)
            {
                var queryMenus = from q in userVariable.MenuResponse.MenuResultList
                                 select new MenuViewModel
                                 {
                                     Id = q.Id,
                                     NamaMenu = q.NamaMenu,
                                     ParentId = q.ParentId,
                                     NamaParent = q.NamaParent,
                                     NamaIcon = q.NamaIcon,
                                     MenuArea = q.MenuArea,
                                     MenuController = q.MenuController,
                                     MenuAction = q.MenuAction,
                                     MenuLink = !string.IsNullOrWhiteSpace(q.MenuController) ? Url.Action(q.MenuAction, q.MenuController, new { area = q.MenuArea }) : "#",
                                 };
                // tampilkan hanya yang memiliki hyperlink
                queryMenus = queryMenus.Where(w => w.MenuLink != "#");

                // check kondisi berdasarkan search key
                if (!string.IsNullOrWhiteSpace(search))
                {
                    queryMenus = queryMenus.Where(w => w.NamaMenu.ToLower().Contains(search.ToLower()));
                    //queryMenus = queryMenus.Where(w => search.ToLower().Contains(w.MENU_NAME.ToLower()));
                }

                // tampung resultnya
                var result = queryMenus.Select(s => new { Value = s.MenuLink, Text = s.NamaMenu + " (" + s.NamaParent + ")", s.Id }).OrderBy(ob => ob.Id).ToList();

                return Json(result, JsonRequestBehavior.AllowGet);
            }
            else
            {
                IQueryable<MenuViewModel> queryNull =
                    Enumerable.Empty<MenuViewModel>().AsQueryable();
                var returnNull = queryNull.Select(s => new { Value = "", Text = "" }).ToList();
                return Json(returnNull, JsonRequestBehavior.AllowGet);
            }
        }
    }
}