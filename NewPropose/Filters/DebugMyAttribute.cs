using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NewPropose.DataAccess.IRepository;
using NewPropose.DataAccess.Repository;
using NewPropose.Controllers;
using NewPropose.Models;
using NewPropose.Models.Authorization;

namespace NewPropose.Filters
{
    //public class DebugMyAttribute : ActionFilterAttribute
    //{
    //    IRoleRepository rolerepository;
    //    IActionRepository ActReposi;
    //    public DebugMyAttribute()
    //    {
    //        rolerepository = new RoleRepository();
    //        ActReposi = new ActionRepository();
    //    }
    //    public override void OnActionExecuting(ActionExecutingContext filterContext)
    //    {
    //        UrlHelper Url = null;
    //        if (!(filterContext.Controller is AccountController))
    //        {

    //            Url = new UrlHelper(filterContext.RequestContext);


    //            if (filterContext.Controller is AccountController)
    //            {
    //                // filterContext.Result = new EmptyResult();
    //                //  base.OnActionExecuting(filterContext);
    //                filterContext.HttpContext.Response.Redirect(Url.Action("Error", "Account", new { Message = string.Format("شما دسترسی  ندارید") }));

    //            }
    //            string ActionName = filterContext.ActionDescriptor.ActionName;
    //            string ControlName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
    //            int roleId = 0;
    //            if (HttpContext.Current.Session["RoleId"] != null)
    //            {
    //                Url = new UrlHelper(filterContext.RequestContext);

    //                roleId = int.Parse(HttpContext.Current.Session["RoleId"].ToString());
    //                Role role = rolerepository.Load(roleId);
    //                if (role.Controls.Any(x => x.OrgName == ControlName))
    //                {
    //                    Controls cont = role.Controls.First(x => x.OrgName == ControlName);
    //                    if (cont.FullControl != true)
    //                    {
    //                        if (cont.Actions.Any(x => x.OrgName == ActionName))
    //                        {
    //                            base.OnActionExecuting(filterContext);
    //                        }
    //                        else
    //                        {
    //                            filterContext.Result = new EmptyResult();
    //                            filterContext.HttpContext.Response.Redirect(Url.Action("Error", "Home", new { Message = string.Format("شما دسترسی  ندارید") }));
    //                            return;
    //                        }
    //                    }
    //                    else
    //                    {
    //                        // it full control in control
    //                        base.OnActionExecuting(filterContext);
    //                    }

    //                }
    //                else
    //                {
    //                    filterContext.Result = new EmptyResult();
    //                    filterContext.HttpContext.Response.Redirect(Url.Action("Error", "Home", new { Message = string.Format("شما دسترسی  ندارید") }));
    //                    return;
    //                }
    //            }
    //            else
    //            {
    //                filterContext.Result = new EmptyResult();
    //                // RedirectToAction("Error", "Account", new { Message = string.Format("شما دسترسی ندارید") });
    //                filterContext.HttpContext.Response.Redirect(Url.Action("LogOn", "Account"));
    //                return;
    //            }
    //        }
    //    }
    //}
}