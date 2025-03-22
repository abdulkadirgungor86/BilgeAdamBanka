using BilgeAdamBanka.DTO.DTOs.BaseEntityDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgeAdamBanka.DTO.DTOs.UserCardInfoDTOs
{
    public class UserCardInfoDTO : BaseEntityDTO
    {
        public string CardUserName { get; set; }
        public string CardNumber { get; set; }
        public string CVC { get; set; }
        public int ExpiryYear { get; set; }
        public int ExpiryMonth { get; set; }
        public decimal CardLimit { get; set; }
        public decimal Balance { get; set; }
    }
}
