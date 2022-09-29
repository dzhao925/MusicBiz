using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using W2022A6DZ.Models;

namespace W2022A6DZ.Controllers
{
    [Authorize]
    public class TrackController : Controller
    {
        private Manager m = new Manager();
        // GET: Track
        public ActionResult Index()
        {
            return View(m.TrackGetAll());
        }
        public ActionResult Details(int? id)
        {
            var o = m.TrackGetById(id.GetValueOrDefault());
            if (o == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(o);
            }
        }
        [Route("clip/{id}")]
        public ActionResult GetClip(int? id)
        {
            var o = m.TrackAudioGetById(id.GetValueOrDefault());
            if (o == null)
            {
                return HttpNotFound();
            }
            else
            {
                return File(o.Audio, o.AudioContentType);
            }
        }

        [Authorize(Roles = "Clerk")]
        public ActionResult Edit(int? id)
        {
            var t = m.TrackGetById(id.GetValueOrDefault());
            if (t == null)
            {
                return HttpNotFound();
            }
            else
            {
                var form = m.mapper.Map<TrackEditFormViewModel>(t);
                return View(form);
            }
        }

        [Authorize(Roles = "Clerk")]
        [HttpPost]
        public ActionResult Edit(TrackEditViewModel newItem)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("edit", new { id = newItem.Id });
            }

            var editItem = m.TrackEdit(newItem);

            if (editItem == null)
            {
                return RedirectToAction("index");
            }
            else
            {
                return RedirectToAction("details", "track", new { id = newItem.Id });
            }
        }

        [Authorize(Roles = "Clerk")]
        public ActionResult Delete(int? id)
        {
            var deleteItem = m.TrackGetById(id.GetValueOrDefault());
            if(deleteItem == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(deleteItem);
            }
        }

        [Authorize(Roles = "Clerk")]
        [HttpPost]
        public ActionResult Delete(int? id, FormCollection collection)
        {
            var result = m.TrackDelete(id.GetValueOrDefault());
            return RedirectToAction("Index");
        }
    }


}