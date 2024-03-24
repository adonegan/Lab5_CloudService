using Lab5CloudServices.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Lab5CloudServices.Controllers
{
    public class CloudServiceController : Controller
    {
        // GET: CloudServiceController
        public ActionResult Calculate()
        {
            ViewBag.InstanceSize = new SelectList(CloudService.InstanceSizePrices.Keys);
            return View(new CloudService());
        }

        // GET: CloudServiceController/Details/5
        [HttpPost]
        public ActionResult Calculate(CloudService svc)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Confirm", svc);
            } 
            else
            {
                ViewBag.InstanceSize = new SelectList(CloudService.InstanceSizePrices);
                return View();
            }
            
        }

        // GET: CloudServiceController/Create
        public ActionResult Confirm(CloudService service)
        {
            return View(service);
        }

    }
}
