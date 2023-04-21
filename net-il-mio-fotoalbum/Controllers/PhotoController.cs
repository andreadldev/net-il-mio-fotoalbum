using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using net_il_mio_fotoalbum.Models;

namespace net_il_mio_fotoalbum.Controllers
{
	public class PhotoController : Controller
	{
		public IActionResult Index()
		{
			ViewData["Title"] = "Homepage";
			using var ctx = new PhotoContext();

			var photoGallery = ctx.Photos.ToArray();
			if (!ctx.Photos.Any())
			{
				ViewData["Message"] = "Nessun risultato trovato";
			}
			return View("Index", photoGallery);
		}

        [HttpGet]
        public IActionResult Create()
		{
			using var ctx = new PhotoContext();

			PhotoFormModel model = new PhotoFormModel();
			model.Photo = new Photo();

			List<Category> categories = ctx.Categories.ToList();
			List<SelectListItem> listCategories = new List<SelectListItem>();
			foreach (Category category in categories)
			{
				listCategories.Add(new SelectListItem()
				{
					Text = category.Name, 
					Value = category.Id.ToString()
				});
			}
			model.Categories = listCategories;

			return View("Create", model);
        }

		[HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PhotoFormModel data)
		{
            using var ctx = new PhotoContext();
			if (!ModelState.IsValid)
			{

                List<Category> categories = ctx.Categories.ToList();
				List<SelectListItem> listCategories = new List<SelectListItem>();
				foreach (Category category in categories)
				{
					listCategories.Add(new SelectListItem()
					{
						Text = category.Name,
						Value = category.Id.ToString()
					});
				}
				data.Categories = listCategories;
				return View("Create", data);
            }

			Photo newPhoto = new Photo();
			newPhoto.Title = data.Photo.Title;
			newPhoto.Description = data.Photo.Description;
			newPhoto.Url = data.Photo.Url;
			newPhoto.Visible = data.Photo.Visible;
			newPhoto.Categories = new List<Category>();

			if (data.SelectedCategories != null)
			{
				foreach (string selectedCategoryId in data.SelectedCategories)
				{
					int selectedIntCategoryId = int.Parse(selectedCategoryId);
					Category category = ctx.Categories.Where(x => x.Id == selectedIntCategoryId).FirstOrDefault();
					newPhoto.Categories.Add(category);
                }
			}
			ctx.Photos.Add(newPhoto);
			ctx.SaveChanges();

			return RedirectToAction("Index");
        }
	}
}
