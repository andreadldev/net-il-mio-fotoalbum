using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using net_il_mio_fotoalbum.Models;

namespace net_il_mio_fotoalbum.Controllers
{
	public class CategoryController : Controller
	{
		public IActionResult Index()
		{
			ViewData["Title"] = "Homepage";
			using var ctx = new PhotoContext();

			var categoryList = ctx.Categories.ToArray();
			if (!ctx.Categories.Any())
			{
				ViewData["Message"] = "Nessuna categoria trovato";
			}
			return View("Index", categoryList);
		}

        [HttpGet]
        public IActionResult Create()
		{
			return View("Create");
        }

		[HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category data)
		{
            using var ctx = new PhotoContext();
            if (!ModelState.IsValid)
            {
                return View("Create", data);
            }

            Category newCategory = new Category();
            newCategory.Name = data.Name;

            ctx.Categories.Add(newCategory);
            ctx.SaveChanges();

			return RedirectToAction("Index");
        }

		[HttpGet]
		public IActionResult Edit (long id)
		{
            using var ctx = new PhotoContext();
            Category edit_category = ctx.Categories.Where(category  => category.Id == id).FirstOrDefault();

            if (edit_category == null) 
            { 
                return NotFound();
            }
            else
            {
                return View(edit_category);
            }
        }

		[HttpPost]
        [ValidateAntiForgeryToken]
		public IActionResult Update(long id, Category data)
		{
            using var ctx = new PhotoContext();

            if (!ModelState.IsValid)
            {
                return View("Edit", data);
            }

            Category edit_category = ctx.Categories.Where(category => category.Id == id).FirstOrDefault();
            if (edit_category == null)
            {
                return NotFound();
            }
            edit_category .Name = data.Name;
            ctx.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(long id)
        {
            using var ctx = new PhotoContext();
            Photo photo = ctx.Photos.Where(photo => photo.Id == id).FirstOrDefault();

            if (photo == null)
            {
                return NotFound();
            }

            ctx.Photos.Remove(photo);
            ctx.SaveChanges();
            return RedirectToAction("Index");
            
        }
    }
}
