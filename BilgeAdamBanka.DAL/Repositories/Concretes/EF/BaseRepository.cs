using BilgeAdamBanka.DAL.ContextClasses;
using BilgeAdamBanka.DAL.Repositories.Abstracts;
using BilgeAdamBanka.ENTITIES.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BilgeAdamBanka.DAL.Repositories.Concretes.EF
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected MyContext _db;
        public BaseRepository(MyContext db)
        {
            _db = db;
        }

        public void Add(T item)
        {
            _db.Set<T>().Add(item);
            Save();
        }

        public async Task AddAsync(T item)
        {
            await _db.Set<T>().AddAsync(item);
            Save();
        }

        public void AddRange(List<T> list)
        {
            _db.Set<T>().AddRange(list);
            Save();
        }

        public async Task AddRangeAsync(List<T> list)
        {
            await _db.Set<T>().AddRangeAsync(list);
            Save();
        }

        public bool Any(Expression<Func<T, bool>> exp)
        {
            return _db.Set<T>().Any(exp);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> exp)
        {
            return await _db.Set<T>().AnyAsync(exp);
        }

        public virtual void Destroy(T item)
        {
            _db.Set<T>().Remove(item);
            Save();

        }

        public void DestroyRange(List<T> list)
        {
            _db.Set<T>().RemoveRange(list);
            Save();
        }

        public void Entry(T originalEntity, T newItem)
        {
            _db.Entry(originalEntity).CurrentValues.SetValues(newItem);
            Save();
        }

        public T Find(params object[] values)
        {
            return _db.Set<T>().Find(values);
        }

        public async Task<T> FindAsync(params object[] values)
        {
            return await _db.Set<T>().FindAsync(values);
        }

        public T FirstOrDefault(Expression<Func<T, bool>> exp)
        {
            return _db.Set<T>().FirstOrDefault(exp);
        }

        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> exp)
        {
            return await _db.Set<T>().FirstOrDefaultAsync(exp);
        }

        public List<T> GetAll()
        {
            return _db.Set<T>().ToList();
        }

        public List<T> GetFirstDatas(int count)
        {
            return _db.Set<T>().OrderBy(x => x.CreatedDate).Take(count).ToList();
        }

        public List<T> GetLastDatas(int count)
        {
            return _db.Set<T>().OrderByDescending(x => x.CreatedDate).Take(count).ToList();
        }

        protected void Save()
        {
            _db.SaveChanges();
        }

        public object Select(Expression<Func<T, object>> exp)
        {
            return _db.Set<T>().Select(exp);
        }

        public IQueryable<X> Select<X>(Expression<Func<T, X>> exp)
        {
            return _db.Set<T>().Select(exp);
        }

        public List<T> Where(Expression<Func<T, bool>> exp)
        {
            return _db.Set<T>().Where(exp).ToList();
        }
    }
}
