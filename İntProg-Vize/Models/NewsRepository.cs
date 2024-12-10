using System.Linq.Expressions;
using IntProg_Vize.Models;
using Microsoft.EntityFrameworkCore;

namespace İntProg_Vize.Models
{
	public class NewsRepository : Repository<News>, INewsRepository
	{
		private AppDbContext _appDbContext;
		public NewsRepository(AppDbContext appDbContext) : base(appDbContext)
		{
			_appDbContext = appDbContext;
		}
		public void Save()
		{
			_appDbContext.SaveChanges();
		}

		public void Update(News news)
		{
			_appDbContext.Update(news);
		}
	}
}
