using Microsoft.EntityFrameworkCore;
using IntProg_Vize.Models;
using System.Linq.Expressions;


namespace IntProg_Vize.Models
{
	public class Repository<T> : IRepository<T> where T : class
	{
		private readonly AppDbContext _appDbContext;
		internal DbSet<T> dbSet; // dbset = _appDbContext.NewsTypes
		private Func<object, object> k;
		private string? includeProps;

		public Repository(AppDbContext appDbContext) 
		{
			_appDbContext = appDbContext;
			this.dbSet = _appDbContext.Set<T>();
			_appDbContext.Haberler.Include(k => k.NewsTypeCategory).Include(k => k.NewsTypeId);
		}

		public void Add(T entity)
		{
			dbSet.Add(entity);
		}

		public void DeleteRange(IEnumerable<T> entities)
		{
			dbSet.RemoveRange(entities);
		}

		public T Get(Expression<Func<T, bool>> filtre, string? includeProps = null)
		{
			IQueryable<T> query = dbSet;
			query = query.Where(filtre);
			if (!string.IsNullOrEmpty(includeProps))
			{
				foreach (var includeProp in includeProps.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
				{
					query = query.Include(includeProp);
				}
			}
			return query.FirstOrDefault();
		}

		public IEnumerable<T> GetAll(string? includeProps = null)
		{
			IQueryable<T> query = dbSet;

			if (!string.IsNullOrEmpty(includeProps))
			{
				foreach (var includeProp in includeProps.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
				{
					query = query.Include(includeProp);
				}
			}
			return query.ToList();
		}

		public void Remove(T entity)
		{
			dbSet.Remove(entity);
		}
	}
}
