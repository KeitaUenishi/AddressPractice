using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AddressPractice.Models;
using System.Web.Mvc;

namespace AddressPractice.Controllers
{

    public class TestController : Controller
    {
        private EfPracticeEntities db = new EfPracticeEntities();
        // GET: Test
        public ActionResult Index()
        {
            return View(db.ADDRESS_MASTER.ToList());
        }
    }
}