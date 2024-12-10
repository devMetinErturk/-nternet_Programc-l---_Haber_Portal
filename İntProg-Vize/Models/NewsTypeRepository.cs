using IntProg_Vize.Models;

namespace İntProg_Vize.Models
{
	public class NewsTypeRepository : Repository<NewsType>, INewsTypeRepository
	{
		private AppDbContext _appDbContext;
		public NewsTypeRepository(AppDbContext appDbContext) : base(appDbContext)
		{
			_appDbContext = appDbContext;
		}

		public void Save()
		{
			_appDbContext.SaveChanges();
		}

		public void Update(NewsType newsType)
		{
			_appDbContext.Update(newsType);
		}
	}
}
