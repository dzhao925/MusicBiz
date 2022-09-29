using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using W2022A6DZ.Models;

namespace W2022A6DZ.Controllers
{
    [Authorize]
    public class AlbumController : Controller
    {
        private Manager m = new Manager();

        // GET: Album
        public ActionResult Index()
        {
            return View(m.AlbumGetAll());
        }

        public ActionResult Details(int? id)
        {
            var o = m.AlbumGetById(id.GetValueOrDefault());
            if (o == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(o);
            }
        }

        [Authorize(Roles = "Clerk")]
        [Route("album/{id}/addtrack")]
        public ActionResult AddTrack(int? id)
        {
            var a = m.AlbumGetById(id.GetValueOrDefault());
            if (a == null)
            {
                return HttpNotFound();
            }
            else
            {
                var form = new TrackAddFormViewModel();
                form.AlbumName = a.Name;
                form.AlbumId = a.Id;
                form.Genre = new SelectList(m.GenresGetAll(), "Name", "Name");
                return View(form);
            }
        }

        [Authorize(Roles = "Clerk")]
        [Route("album/{id}/addtrack")]
        [HttpPost]
        public ActionResult AddTrack(TrackAddViewModel newItem)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("addTrack", new { id = newItem.Id });
            }

            var addedItem = m.TrackAdd(newItem);

            if (addedItem == null)
            {
                return View(newItem);
            }
            else
            {
                return RedirectToAction("details", "track", new { id = addedItem.Id });
            }
        }
    }
}