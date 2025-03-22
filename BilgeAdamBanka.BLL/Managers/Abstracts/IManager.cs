using BilgeAdamBanka.DTO.DTOs.BaseEntityDTOs;
using BilgeAdamBanka.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BilgeAdamBanka.BLL.Managers.Abstracts
{
    public interface IManager<T, U> where T : BaseEntity where U : BaseEntityDTO
    {
        List<U> GetActives();
        List<U> GetPassives();
        List<U> GetModifieds();
        List<U> GetAll();
        Task UpdateAsync(U item);
        Task UpdateRangeAsync(List<U> list);
        Task<U> AddAndGetAsync(U item);
        string Add(U item);
        Task<string> AddAsync(U item);
        Task<string> AddRangeAsync(List<U> list);
        string AddRange(List<U> list);
        void Delete(U item);
        void DeleteRange(List<U> list);
        string Destroy(U item);
        string DestroyRange(List<U> list);
        IQueryable<X> Select<X>(Expression<Func<T, X>> exp);
        bool Any(Expression<Func<T, bool>> exp);
        Task<bool> AnyAsync(Expression<Func<T, bool>> exp);
        U FirstOrDefault(Expression<Func<T, bool>> exp);
        Task<U> FirstOrDefaultAsync(Expression<Func<T, bool>> exp);
        object Select(Expression<Func<T, object>> exp);
        List<U> Where(Expression<Func<T, bool>> exp);
        List<U> GetLastDatas(int count);
        List<U> GetFirstDatas(int count);
        U Find(params object[] values);
        Task<U> FindAsync(params object[] values);
    }
}
