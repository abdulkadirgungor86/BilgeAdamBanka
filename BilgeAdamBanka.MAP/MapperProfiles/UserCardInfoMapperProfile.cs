using BilgeAdamBanka.APIMODEL.ApiModels.CreditCard;
using BilgeAdamBanka.DTO.DTOs.UserCardInfoDTOs;
using BilgeAdamBanka.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgeAdamBanka.MAP.MapperProfiles
{
    public class UserCardInfoMapperProfile : BaseMapperProfile
    {
        public UserCardInfoMapperProfile()
        {
            CreateMap<UserCardInfo, UserCardInfoDTO>().ReverseMap();
            CreateMap<UserCardInfoDTO, GetActiveCreditCardsResponseModel>().ReverseMap();
            CreateMap<UserCardInfoDTO, GetActiveCreditCardResponseModel>().ReverseMap();
            CreateMap<CheckCreditCardRequestModel, UserCardInfoDTO>().ReverseMap();
            CreateMap<AddCreditCardRequestModel, UserCardInfoDTO>().ReverseMap();
            CreateMap<UpdateCreditCardRequestModel, UserCardInfoDTO>().ReverseMap();
        }
    }
}
