using BilgeAdamBanka.DTO.DTOs.UserCardInfoDTOs;
using BilgeAdamBanka.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgeAdamBanka.BLL.Managers.Abstracts
{
    public interface IUserCardInfoManager : IManager<UserCardInfo, UserCardInfoDTO>
    {
        (bool result, UserCardInfoDTO? userCardInfoDTO) GetActiveCreditCard(int id);
        bool CheckCreditCard(UserCardInfoDTO userCardInfoDTO);
        bool AddCreditCard(UserCardInfoDTO userCardInfoDTO);
        Task<bool> UpdateCreditCardAsync(UserCardInfoDTO userCardInfoDTO);
        Task<(bool result, string msg)> DeleteCreditCardAsync(string CreditCardNumber);
        (bool result, string msg) DestroyCreditCard(string CreditCardNumber);
    }

}
