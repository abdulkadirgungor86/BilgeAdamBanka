using AutoMapper;
using BilgeAdamBanka.APIMODEL.ApiModels.CreditCard;
using BilgeAdamBanka.BLL.Managers.Abstracts;
using BilgeAdamBanka.BLL.Managers.Concretes;
using BilgeAdamBanka.DTO.DTOs.UserCardInfoDTOs;
using BilgeAdamBanka.ENTITIES.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BilgeAdamBanka.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditCardController : ControllerBase
    {
        readonly IUserCardInfoManager _userCardInfoManager;
        readonly IMapper _mapper;

        public CreditCardController(IUserCardInfoManager userCardInfoManager, IMapper mapper)
        {
            _userCardInfoManager = userCardInfoManager;
            _mapper = mapper;
        }

        [HttpGet("GetActiveCreditCards")]
        public IActionResult GetActiveCreditCards()
        {
            List<UserCardInfoDTO> userCardInfos = _userCardInfoManager.GetActives();
            List<GetActiveCreditCardsResponseModel> responseModels = _mapper.Map<List<GetActiveCreditCardsResponseModel>>(userCardInfos);

            if ((responseModels != null) && (responseModels.Count > 0))
                return Ok(responseModels);
            else return StatusCode(StatusCodes.Status404NotFound, "İçerik bulunamadı.");
        }

        [HttpGet("GetActiveCreditCard")]
        public IActionResult GetActiveCreditCart(int id)
        {
            if (id <= 0) return BadRequest("Geçersiz id değeri.");
            (bool result, UserCardInfoDTO? userCardInfoDTO) = _userCardInfoManager.GetActiveCreditCard(id);
            if (result) 
            {
                GetActiveCreditCardResponseModel getActiveCreditCardResponseModel = _mapper.Map<GetActiveCreditCardResponseModel>(userCardInfoDTO);
                return Ok(getActiveCreditCardResponseModel);
            }
            else return StatusCode(StatusCodes.Status404NotFound, "İçerik bulunamadı.");
        }

        [HttpPost("CheckCreditCard")]
        public IActionResult CheckCreditCard(CheckCreditCardRequestModel requestModel)
        {
            if(!ModelState.IsValid) return BadRequest();
            UserCardInfoDTO userCardInfoDTO = _mapper.Map<UserCardInfoDTO>(requestModel);
            bool result = _userCardInfoManager.CheckCreditCard(userCardInfoDTO);
            if(result) return Ok("Kredi kartı bilgileri doğrulandı.");
            else return StatusCode(StatusCodes.Status404NotFound, "Kredi kartı bilgileri doğrulanamadı.");
        }

        [HttpPost("AddCreditCard")]
        public IActionResult AddCreditCard(AddCreditCardRequestModel requestModel)
        {
            if (!ModelState.IsValid) return BadRequest();
            UserCardInfoDTO userCardInfoDTO = _mapper.Map<UserCardInfoDTO>(requestModel);
            bool result = _userCardInfoManager.AddCreditCard(userCardInfoDTO);
            if (result) return Ok("Kredi kartı bilgileri eklendi.");
            else return StatusCode(StatusCodes.Status400BadRequest, "Kredi kartı bilgileri eklenemedi. Kart numarası daha önce eklenmiş olabilir.");

        }

        [HttpPut("UpdateCreditCard")]
        public async Task<IActionResult> UpdateCreditCardAsync(UpdateCreditCardRequestModel requestModel)
        {
            if (!ModelState.IsValid) return BadRequest();
            UserCardInfoDTO userCardInfoDTO = _mapper.Map<UserCardInfoDTO>(requestModel);
            bool result = await _userCardInfoManager.UpdateCreditCardAsync(userCardInfoDTO);
            if (result) return Ok("Kredi kartı bilgileri güncellendi.");
            else return StatusCode(StatusCodes.Status400BadRequest, "Kredi kartı bilgileri güncellenemedi.");
        }

        [HttpDelete("DeleteCreditCard")]
        public async Task<IActionResult> DeleteCreditCardAsync(string CreditCardNumber)
        {
            (bool result, string msg) = await _userCardInfoManager.DeleteCreditCardAsync(CreditCardNumber);
            if (result) return Ok(msg);
            else return StatusCode(StatusCodes.Status400BadRequest, msg);
        }


        [HttpDelete("DestroyCreditCard")]
        public IActionResult DestroyCreditCard(string CreditCardNumber)
        {
            (bool result, string msg) = _userCardInfoManager.DestroyCreditCard(CreditCardNumber);
            if (result) return Ok(msg);
            else return StatusCode(StatusCodes.Status400BadRequest, msg);
        }


    }
}
