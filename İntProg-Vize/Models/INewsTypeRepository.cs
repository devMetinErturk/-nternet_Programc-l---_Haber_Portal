using IntProg_Vize.Models;

namespace İntProg_Vize.Models
{
	public interface INewsTypeRepository : IRepository<NewsType>
	{
		void Update(NewsType newsType);
		void Save();
	}
}
