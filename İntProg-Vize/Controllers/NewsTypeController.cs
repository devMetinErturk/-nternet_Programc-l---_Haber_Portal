using IntProg_Vize.Models;
using İntProg_Vize.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IntProg_Vize.Controllers
{
    public class NewsTypeController : Controller
    {
		private readonly INewsTypeRepository _newsTypeRepository;

        public NewsTypeController(INewsTypeRepository context)
        {
            _newsTypeRepository = context;
        }
        public IActionResult Index()
        {
            List<NewsType> objNewsTypeList = _newsTypeRepository.GetAll().ToList();   
            return View(objNewsTypeList);
        }

        public IActionResult NewsTypeAdd() 
        { 
            return View(); 
        }

        [HttpPost]
        public IActionResult NewsTypeAdd(NewsType newsType)
        {
            if (ModelState.IsValid)
            {
				_newsTypeRepository.Add(newsType);
				_newsTypeRepository.Save(); // saveChanges yapılmadığında bilgiler veritabanına eklenmez.
				TempData["success"] = "Yeni Haber Türü Başarıyla Eklendi !";
                return RedirectToAction("Index", "NewsType");
            }
            return View();
        }
		public IActionResult NewsTypeUpdate(int? Id)
		{
			if(Id == null || Id==0)
			{
				return NotFound();
			}
			NewsType? newsTypeVt = _newsTypeRepository.Get(u=>u.Id==Id);
			if(newsTypeVt==null)
			{
				return NotFound();
			}
			return View(newsTypeVt);
		}

		[HttpPost]
		public IActionResult NewsTypeUpdate(NewsType newsType)
		{
			if (ModelState.IsValid)
			{
				_newsTypeRepository.Update(newsType);
				_newsTypeRepository.Save(); // saveChanges yapılmadığında bilgiler veritabanına eklenmez.
				TempData["success"] = "Haber Türü Başarıyla Güncellendi !";
				return RedirectToAction("Index", "NewsType");
			}
			return View();
		}

		public IActionResult NewsTypeDelete(int? Id)
		{
			if (Id == null || Id == 0)
			{
				return NotFound();
			}
			NewsType? newsTypeVt = _newsTypeRepository.Get(u => u.Id == Id);
			if (newsTypeVt == null)
			{
				return NotFound();
			}
			return View(newsTypeVt);
		}

		[HttpPost, ActionName("NewsTypeDelete")]
		public IActionResult NewsTypeDeletePOST(int? Id)
		{
			NewsType? newsType = _newsTypeRepository.Get(u => u.Id == Id);
			if (newsType == null)
			{
				return NotFound();
			}
			_newsTypeRepository.Remove(newsType);
			_newsTypeRepository.Save();
			TempData["success"] = "Haber Türü Başarıyla Silindi !";
			return RedirectToAction("Index", "NewsType");
		}
	}
}