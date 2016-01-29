using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProductStore.Filters;

namespace Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AdminBaseController : Controller
    {

    }
}