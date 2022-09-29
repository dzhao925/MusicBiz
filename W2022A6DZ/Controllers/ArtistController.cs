using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using W2022A6DZ.Models;

namespace W2022A6DZ.Controllers
{
    [Authorize]
    public class ArtistController : Controller
    {
        private Manager m = new Manager();

        // GET: Artist
        public ActionResult Index()
        {
            return View(m.ArtistGetAll());
        }

        public ActionResult Details(int? id)
        {
           
            var o = m.ArtistGetByIdWithMediaInfo(id.GetValueOrDefault());
            if( o == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(o);
            }
        }

        [Authorize(Roles = "Executive")]
        public ActionResult Create()
        {
            var form = new ArtistAddFormViewModel();
            form.Genre = new SelectList(m.GenresGetAll(), "Name", "Name");
            return View(form);
        }

        [Authorize(Roles = "Executive")]
        [HttpPost, ValidateInput(false)]
        public ActionResult Create(ArtistAddViewModel newItem)
        {
            if (!ModelState.IsValid)
            {
                return View(newItem);
            }

            var addedItem = m.ArtistAdd(newItem);

            if (addedItem == null)
            {
                return View(newItem);
            }
            else
            {
                return RedirectToAction("details", new { id = addedItem.Id });
            }
        }

        [Authorize(Roles = "Coordinator")]
        [Route("artist/{id}/addalbum")]
        public ActionResult AddAlbum(int? id)
        {
            var a = m.ArtistGetById(id.GetValueOrDefault());
            if (a == null)
            {
                return HttpNotFound();
            }
            else
            {
                var form = new AlbumAddFormViewModel();
                form.ArtistName = a.Name;
                form.ArtistId = a.Id;
                form.Genre = new SelectList(m.GenresGetAll(), "Name", "Name");
                return View(form);
            }
        }

        [Authorize(Roles = "Coordinator")]
        [Route("artist/{id}/addalbum")]
        [HttpPost, ValidateInput(false)]
        public ActionResult AddAlbum(AlbumAddViewModel newItem)
        {
            if (!ModelState.IsValid)
            {
                return View(newItem);
            }

            var addedItem = m.AlbumAdd(newItem);

            if (addedItem == null)
            {
                return View(newItem);
            }
            else
            {
                return RedirectToAction("details", "album", new { id = addedItem.Id });
            }
        }

        [Authorize(Roles = "Coordinator")]
        [Route("artist/{id}/addmediaitem")]
        public ActionResult AddMediaItem(int? id)
        {
            var a = m.ArtistGetById(id.GetValueOrDefault());
            if (a == null)
            {
                return HttpNotFound();
            }
            else
            {
                var form = new ArtistMediaItemAddFormViewModel();
                form.ArtistName = a.Name;
                form.ArtistId = a.Id;
                return View(form);
            }
        }

        [Authorize(Roles = "Coordinator")]
        [Route("artist/{id}/addmediaitem")]
        [HttpPost, ValidateInput(false)]
        public ActionResult AddMediaItem(ArtistMediaItemAddViewModel newItem)
        {
            if (!ModelState.IsValid)
            {
                return View(newItem);
            }

            var addedItem = m.ArtistMediaItemAdd(newItem);

            if (addedItem == null)
            {
                return View(newItem);
            }
            else
            {
                return RedirectToAction("details", "artist", new { id = newItem.ArtistId });
            }
        }
    }
}