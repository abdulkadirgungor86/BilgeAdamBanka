using AutoMapper;
using BilgeAdamBanka.BLL.Managers.Abstracts;
using BilgeAdamBanka.DAL.Repositories.Abstracts;
using BilgeAdamBanka.DTO.DTOs.BaseEntityDTOs;
using BilgeAdamBanka.ENTITIES.Enums;
using BilgeAdamBanka.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BilgeAdamBanka.BLL.Managers.Concretes
{
    public abstract class BaseManager<T,U> : IManager<T,U> where T : BaseEntity where U : BaseEntityDTO
    {
        protected readonly IMapper _mapper;
        protected readonly IRepository<T> _iRep;

        public BaseManager(IMapper mapper, IRepository<T> iRep)
        {
            _iRep = iRep;
            _mapper = mapper;
        }

        public virtual void Delete(U item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item), "Öğe boş olamaz.");
            T entity = _mapper.Map<T>(item);
            entity.Status = DataStatus.Deleted;
            entity.DeletedDate = DateTime.Now;
            T originalEntity = _iRep.Find(entity.Id);
            _iRep.Entry(originalEntity, entity);
        }

        public void DeleteRange(List<U> list)
        {
            if (list == null || list.Count == 0) throw new ArgumentNullException(nameof(list), "Liste null değere sahip ya da boş.");
            foreach (U item in list) Delete(item);
        }

        public virtual async Task UpdateAsync(U item)
        {
            T entity = _mapper.Map<T>(item);
            entity.UpdatedDate = DateTime.Now;
            entity.Status = DataStatus.Updated;
            T originalEntity = await _iRep.FindAsync(entity.Id);
            _iRep.Entry(originalEntity, entity);
        }

        public async Task UpdateRangeAsync(List<U> list)
        {
            foreach (U item in list) await UpdateAsync(item);
        }

        public List<U> GetActives()
        {
            return _mapper.Map<List<U>>(_iRep.Where(x => x.Status != ENTITIES.Enums.DataStatus.Deleted));
        }

        public List<U> GetModifieds()
        {
            return _mapper.Map<List<U>>(_iRep.Where(x => x.Status == ENTITIES.Enums.DataStatus.Updated));
        }

        public List<U> GetPassives()
        {
            return _mapper.Map<List<U>>(_iRep.Where(x => x.Status == ENTITIES.Enums.DataStatus.Deleted));
        }

        public List<U> GetAll()
        {
            return _mapper.Map<List<U>>(_iRep.GetAll());
        }

        public async Task<U> AddAndGetAsync(U item)
        {
            try
            {
                T entity = _mapper.Map<T>(item);
                await _iRep.AddAsync(entity);
                U addedItem = _mapper.Map<U>(entity);
                return addedItem;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ekleme yaparken hata oluştu : {ex.Message}");
            }
        }

        public virtual string Add(U item)
        {
            try
            {
                T entity = _mapper.Map<T>(item);
                T existingEntity = _iRep.Find(entity.Id);
                if (existingEntity != null) _iRep.Entry(existingEntity, entity);
                else _iRep.Add(entity);
                return "Başarıyla eklendi.";
            }
            catch (Exception ex)
            {
                return $"Ekleme yaparken hata oluştu : {ex.Message}";
            }
        }

        public virtual async Task<string> AddAsync(U item)
        {
            try
            {
                T entity = _mapper.Map<T>(item);
                await _iRep.AddAsync(entity);
                return "Başarıyla eklendi";
            }
            catch (Exception ex)
            {
                return $"Ekleme yaparken hata oluştu : {ex.Message}";
            }
        }

        public async Task<string> AddRangeAsync(List<U> list)
        {
            try
            {
                List<T> entities = _mapper.Map<List<T>>(list);
                await _iRep.AddRangeAsync(entities);
                return "Başarıyla eklendi.";
            }
            catch (Exception ex)
            {
                return $"Ekleme yaparken hata oluştu: {ex.Message}";

            }
        }

        public string AddRange(List<U> list)
        {
            try
            {
                List<T> entities = _mapper.Map<List<T>>(list);
                _iRep.AddRange(entities);
                return "Başarıyla eklendi.";
            }
            catch (Exception ex)
            {
                return $"Eklerken bir hata oluştu : {ex.Message}";
            }
        }

        public virtual string Destroy(U item)
        {
            T entity = _mapper.Map<T>(item);
            if (entity.Status == DataStatus.Deleted)
            {
                try
                {
                    T existingItem = _iRep.FirstOrDefault(e => e.Id == entity.Id);
                    if (existingItem != null) _iRep.Destroy(existingItem);
                    else throw new ArgumentException("Hata : existingItem nesnesi değeri null. Veritabanında bulunamadı. BaseManager/Destroy/existingItem");
                    return "Destroy işlemi başarılı";
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
            return "Veriyi yok etmek için önce silmeniz lazım";
        }

        public virtual string DestroyRange(List<U> list)
        {
            if (list == null || list.Count == 0) throw new ArgumentNullException(nameof(list), "Liste boş ya da null değere sahip");
            List<U> notDestroyed = new List<U>();

            foreach (U item in list)
            {
                T entity = _mapper.Map<T>(item);
                if (entity.Status != DataStatus.Deleted) notDestroyed.Add(item);
                else
                {
                    try
                    {
                        _iRep.Destroy(entity);
                    }
                    catch (Exception ex)
                    {
                        notDestroyed.Add(item);
                    }
                }
            }
            if (notDestroyed.Any()) return "Hata : listedeki bir veya birden fazla eleman yok edilemedi.";

            return "Başarıyla yok edildi";
        }

        public IQueryable<X> Select<X>(Expression<Func<T, X>> exp)
        {
            return _iRep.Select(exp);
        }

        public bool Any(Expression<Func<T, bool>> exp)
        {
            return _iRep.Any(exp);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> exp)
        {
            return await _iRep.AnyAsync(exp);
        }

        public U FirstOrDefault(Expression<Func<T, bool>> exp)
        {
            T entity = _iRep.FirstOrDefault(exp);
            return _mapper.Map<U>(entity);
        }

        public async Task<U> FirstOrDefaultAsync(Expression<Func<T, bool>> exp)
        {
            T entity = await _iRep.FirstOrDefaultAsync(exp);
            return _mapper.Map<U>(entity);
        }

        public object Select(Expression<Func<T, object>> exp)
        {
            return _iRep.Select(exp);
        }

        public List<U> Where(Expression<Func<T, bool>> exp)
        {
            return _mapper.Map<List<U>>(_iRep.Where(exp));
        }

        public List<U> GetLastDatas(int count)
        {
            return _mapper.Map<List<U>>(_iRep.GetLastDatas(count));
        }

        public List<U> GetFirstDatas(int count)
        {
            return _mapper.Map<List<U>>(_iRep.GetFirstDatas(count));
        }

        public U Find(params object[] values)
        {
            T foundEntity = _iRep.Find(values);
            return _mapper.Map<U>(foundEntity);
        }

        public async Task<U> FindAsync(params object[] values)
        {
            T foundEntity = await _iRep.FindAsync(values);
            return _mapper.Map<U>(foundEntity);
        }
    }
}
