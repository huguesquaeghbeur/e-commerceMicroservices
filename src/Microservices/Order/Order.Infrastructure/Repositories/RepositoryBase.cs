

namespace Order.Infrastructure.Repositories
{
    public class RepositoryBase<T> : IAsyncRepository<T> where T : ModelBase
    {
        protected readonly OrderContext _orderContext;

        public RepositoryBase(OrderContext orderContext)
        {
            this._orderContext = orderContext;
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _orderContext.Set<T>().ToListAsync();
        }

        public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await _orderContext.Set<T>().Where(predicate).ToListAsync();
        }

        public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeString = null, bool disableTracking = true)
        {
            IQueryable<T> query = _orderContext.Set<T>();
            if (predicate != null) query = query.Where(predicate);
            if (disableTracking) query = query.AsNoTracking();
            if (includeString != null) query = query.Include(includeString);
            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }
            return await query.ToListAsync();
        }
        public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, List<Expression<Func<T, object>>> includes = null, bool disableTracking = true)
        {
            IQueryable<T> query = _orderContext.Set<T>();
            if (predicate != null) query = query.Where(predicate);
            if (disableTracking) query = query.AsNoTracking();
            if (includes != null) query = includes.Aggregate(query, (current, include) => current.Include(include));
            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }
            return await query.ToListAsync();
        }
        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _orderContext.Set<T>().FindAsync(id);
        }
        public async Task<T> AddAsync(T ordered)
        {
            _orderContext.Set<T>().Add(ordered);
            await _orderContext.SaveChangesAsync();
            return ordered;
        }
        public async Task UpdateAsync(T ordered)
        {
            _orderContext.Entry(ordered).State = EntityState.Modified;
            await _orderContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(T ordered)
        {
            _orderContext.Set<T>().Remove(ordered);
            await _orderContext.SaveChangesAsync();
        }
    }
}
