using IntProg_Vize.Models;
using İntProg_Vize.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace IntProg_Vize.Controllers
{
    public class NewsController : Controller
    {
		private readonly INewsRepository _newsRepository;
		private readonly INewsTypeRepository _newsTypeRepository;
		public readonly IWebHostEnvironment _webHostEnvironment;

		public NewsController(INewsRepository newsRepository, INewsTypeRepository newsTypeRepository, IWebHostEnvironment webHostEnvironment)
        {
            _newsRepository = newsRepository;
			_newsTypeRepository = newsTypeRepository;
			_webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            List<News> objNewsList = _newsRepository.GetAll(includeProps: "NewsTypeCategory").ToList();
            return View(objNewsList);
        }

        public IActionResult NewsAddUpdate(int? Id) 
        {
			IEnumerable<SelectListItem> NewsTypeCategory = _newsTypeRepository.GetAll()
				.Select(k => new SelectListItem
				{	
					Text = k.Name,
					Value = k.Id.ToString()
				});

			ViewBag.NewsTypeCategory = NewsTypeCategory;

			if (Id == null || Id == 0) 
			{
				//ekle
				return View();
			}
			else 
			{
				//guncelleme
				News? newsVt = _newsRepository.Get(u => u.Id == Id);
				if (newsVt == null)
				{
					return NotFound();
				}
				return View(newsVt);
			}
        }

        [HttpPost]
        public IActionResult NewsAddUpdate(News news, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
				string wwwRootPath = _webHostEnvironment.WebRootPath;
				string newsPath = Path.Combine(wwwRootPath, @"img");

				if (file != null)
				{
					using (var fileStream = new FileStream(Path.Combine(newsPath, file.FileName), FileMode.Create))
					{
						file.CopyTo(fileStream);
					}
					news.ImageUrl = @"\img\" + file.FileName;
				}
				
				if (news.Id == 0)
				{
					_newsRepository.Add(news);
					TempData["success"] = "Yeni Haber Başarıyla Eklendi !";
				}
				else
				{
					_newsRepository.Update(news);
					TempData["success"] = "Haber Başarıyla Güncellendi !";
				}

				_newsRepository.Save(); // saveChanges yapılmadığında bilgiler veritabanına eklenmez.
				TempData["success"] = "Yeni Haber Başarıyla Eklendi !";
                return RedirectToAction("Index", "News");
            }
            return View();
        }

		/*
		public IActionResult NewsUpdate(int? Id)
		{
			if(Id == null || Id==0)
			{
				return NotFound();
			}
			News? newsVt = _newsRepository.Get(u=>u.Id==Id);
			if(newsVt==null)
			{
				return NotFound();
			}
			return View(newsVt);
		}

		[HttpPost]
		public IActionResult NewsUpdate(News news)
		{
			if (ModelState.IsValid)
			{
				_newsRepository.Update(news);
				_newsRepository.Save(); // saveChanges yapılmadığında bilgiler veritabanına eklenmez.
				TempData["success"] = "Haber Başarıyla Güncellendi !";
				return RedirectToAction("Index", "News");
			}
			return View();
		}
		*/

		public IActionResult NewsDelete(int? Id)
		{
			if (Id == null || Id == 0)
			{
				return NotFound();
			}
			News? newsVt = _newsRepository.Get(u => u.Id == Id);
			if (newsVt == null)
			{
				return NotFound();
			}
			return View(newsVt);
		}

		[HttpPost, ActionName("NewsDelete")]
		public IActionResult NewsDeletePOST(int? Id)
		{
			News? news= _newsRepository.Get(u => u.Id == Id);
			if (news == null)
			{
				return NotFound();
			}
			_newsRepository.Remove(news);
			_newsRepository.Save();
			TempData["success"] = "Haber Başarıyla Silindi !";
			return RedirectToAction("Index", "News");
		}
	}
}