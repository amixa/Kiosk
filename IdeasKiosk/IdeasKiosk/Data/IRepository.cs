using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IdeasKiosk.Data
{
    public interface IRepository<T> where T : class, new()
	{
		Task<List<T>> GetAllAsync();
		Task<int> InsertAsync(T entity);
		Task<int> UpdateAsync(T entity);
		Task<int> DeleteAsync(T entity);
	}
}
