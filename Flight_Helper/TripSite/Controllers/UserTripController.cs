using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TripSite.ViewModel;

namespace TripSite.Controllers
{
    public class UserTripController : Controller
    {
        //// GET: UserTripController1cs
        //public ActionResult Index()
        //{
        //    return View();
        //}

        //// GET: UserTripController1cs/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        // GET: UserTripController1cs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserTripController1cs/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateTrip collection)
        {
            try
            {
                return RedirectToAction(nameof(Create));
            }
            catch
            {
                return View();
            }
        }

        //// GET: UserTripController1cs/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: UserTripController1cs/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: UserTripController1cs/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: UserTripController1cs/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
