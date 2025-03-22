using AutoMapper;
using BilgeAdamBanka.BLL.Managers.Abstracts;
using BilgeAdamBanka.DAL.Repositories.Abstracts;
using BilgeAdamBanka.DTO.DTOs.UserCardInfoDTOs;
using BilgeAdamBanka.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgeAdamBanka.BLL.Managers.Concretes
{
    public class UserCardInfoManager : BaseManager<UserCardInfo, UserCardInfoDTO>, IUserCardInfoManager
    {
        readonly IMapper _mapper;
        readonly IRepository<UserCardInfo> _iRep;

        public UserCardInfoManager(IMapper mapper, IRepository<UserCardInfo> iRep) : base(mapper, iRep)
        {
            _iRep = iRep;
            _mapper = mapper;
        }

        public (bool result, UserCardInfoDTO? userCardInfoDTO) GetActiveCreditCard(int id)
        {
            UserCardInfo userCardInfo = _iRep.FirstOrDefault(e => e.Id == id && e.Status != ENTITIES.Enums.DataStatus.Deleted);
            UserCardInfoDTO userCardInfoDTO = _mapper.Map<UserCardInfoDTO>(userCardInfo);
            if(userCardInfoDTO != null) return (true, userCardInfoDTO);
            return (false, null);
        }

        public bool CheckCreditCard(UserCardInfoDTO userCardInfoDTO)
        {
            UserCardInfo userCardInfo = _mapper.Map<UserCardInfo>(userCardInfoDTO);
            UserCardInfo userCardInfoFromDb = _iRep.FirstOrDefault(e => e.CardNumber == userCardInfo.CardNumber && e.CVC == userCardInfo.CVC && e.ExpiryYear == userCardInfo.ExpiryYear && e.ExpiryMonth == userCardInfo.ExpiryMonth && e.CardUserName == userCardInfo.CardUserName);
            if (userCardInfoFromDb != null) return true;
            return false;
        }

        public bool AddCreditCard(UserCardInfoDTO userCardInfoDTO)
        {
            UserCardInfo userCardInfo = _mapper.Map<UserCardInfo>(userCardInfoDTO);
            if (_iRep.Any(x => x.CardNumber == userCardInfo.CardNumber)) return false;
            _iRep.Add(userCardInfo);
            return true;
        }

        public async Task<bool> UpdateCreditCardAsync(UserCardInfoDTO userCardInfoDTO)
        {
            UserCardInfo userCardInfo = _mapper.Map<UserCardInfo>(userCardInfoDTO);
            UserCardInfo userCardInfoFromDb = _iRep.FirstOrDefault(e => e.CardNumber == userCardInfo.CardNumber);
            if (userCardInfoFromDb == null) return false;

            userCardInfo.Id = userCardInfoFromDb.Id;
            userCardInfo.Status = ENTITIES.Enums.DataStatus.Updated;
            userCardInfo.UpdatedDate = DateTime.Now;
            userCardInfo.CVC = !string.IsNullOrEmpty(userCardInfo.CVC) ? userCardInfo.CVC : userCardInfoFromDb.CVC;
            userCardInfo.CardUserName = !string.IsNullOrEmpty(userCardInfo.CardUserName) ? userCardInfo.CardUserName : userCardInfoFromDb.CardUserName;

            UserCardInfo originalEntity = await _iRep.FindAsync(userCardInfo.Id);
            _iRep.Entry(originalEntity, userCardInfo);

            return true;
        }

        public async Task<(bool result, string msg)> DeleteCreditCardAsync(string CreditCardNumber)
        {
            if (string.IsNullOrEmpty(CreditCardNumber)) return (false, "Kredi kartı numarası boş olamaz.");
            UserCardInfo userCardInfoFromDb = _iRep.FirstOrDefault(e => e.CardNumber == CreditCardNumber);
            if (userCardInfoFromDb == null) return (false, "Kredi kartı bulunamadı.");
            
            userCardInfoFromDb.Status = ENTITIES.Enums.DataStatus.Deleted;
            userCardInfoFromDb.DeletedDate = DateTime.Now;

            UserCardInfo originalEntity = await _iRep.FindAsync(userCardInfoFromDb.Id);
            _iRep.Entry(originalEntity, userCardInfoFromDb);
            return (true, "Kredi kartı bilgileri silindi.");
        }

        public (bool result, string msg) DestroyCreditCard(string CreditCardNumber)
        {
            if (string.IsNullOrEmpty(CreditCardNumber)) return (false, "Kredi kartı numarası boş olamaz.");
            UserCardInfo userCardInfoFromDb = _iRep.FirstOrDefault(e => e.CardNumber == CreditCardNumber);
            if (userCardInfoFromDb == null) return (false, "Kredi kartı bulunamadı.");
            if (userCardInfoFromDb.Status != ENTITIES.Enums.DataStatus.Deleted) return (false, "Kredi kartını destroy için önce silmeniz lazım.");

            string msg =base.Destroy( _mapper.Map<UserCardInfoDTO>(userCardInfoFromDb) );
            if (msg == "Destroy işlemi başarılı") return (true, "Kredi kartı bilgileri yok edildi.");
            return (false, msg);
        }   



    }
}
