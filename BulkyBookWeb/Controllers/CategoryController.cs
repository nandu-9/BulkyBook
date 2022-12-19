using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using BulkyBookWeb.DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Controllers
{
    public class CategoryController : Controller
    {

        private readonly ICategoryRepository _appDbContext;

        public CategoryController(ICategoryRepository appDbContext)
        {
            _appDbContext= appDbContext;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> catList = _appDbContext.GetAll();
            return View(catList);
        }

		#region Category Creation
		public IActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (ModelState.IsValid)
            {
                if (obj.Name == obj.DisplayOrder.ToString())
                {
                    // For putting up the error in the summary
//                  ModelState.AddModelError("CustomError", "Display order and name, should not match");

                    // For putting up the error beside the input fields
                    ModelState.AddModelError("name", "Display order and name, should not match");
                }
                _appDbContext.Add(obj);
                _appDbContext.Save();
                TempData["success"] = "Task successful";
                return RedirectToAction("Index");
            }
            else
            { 
                return View(obj);
            }
        }
		#endregion

		#region Edit Category
		public IActionResult Edit(int? id)
        {
            if ((id == null) || (id == 0))
                return NotFound();

            var categoryFromDb = _appDbContext.GetFirstOrDefault(u => u.Id == id);

            if (categoryFromDb == null)
                return NotFound();
            else
                return View(categoryFromDb);
        }

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(Category obj)
		{
			if (ModelState.IsValid)
			{
				if (obj.Name == obj.DisplayOrder.ToString())
				{
					// For putting up the error in the summary
					//                  ModelState.AddModelError("CustomError", "Display order and name, should not match");

					// For putting up the error beside the input fields
					ModelState.AddModelError("name", "Display order and name, should not match");
				}
				_appDbContext.Update(obj);
				_appDbContext.Save();
                TempData["success"] = "Task successful";
                return RedirectToAction("Index");
			}
			else
			{
				return View(obj);
			}
		}
        #endregion

        #region Delete Category
        public IActionResult Delete(int? id)
        {
            if ((id == null) || (id == 0))
                return NotFound();

            var categoryFromDb = _appDbContext.GetFirstOrDefault(u => u.Id == id);

            if (categoryFromDb == null)
                return NotFound();
            else
                return View(categoryFromDb);
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Category obj)
        {
            _appDbContext.Remove(obj);
            _appDbContext.Save();
            TempData["success"] = "Task successful";
            return RedirectToAction("Index");
        }
        #endregion
    }
}
