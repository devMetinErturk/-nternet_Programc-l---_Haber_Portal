using IntProg_Vize.Models;

namespace İntProg_Vize.Models
{
	public interface INewsRepository : IRepository<News>
	{
		void Update(News news);
		void Save();
	}
}
