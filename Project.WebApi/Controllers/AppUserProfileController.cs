using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Bll.Dtos;
using Project.Bll.Managers.Abstracts;
using Project.Bll.Managers.Concretes;
using Project.Concrats.Models.RequestModels.AppUserProfiles;
using Project.Concrats.Models.RequestModels.AppUsers;
using Project.Concrats.Models.ResponseModels.AppUserProfiles;

namespace Project.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserProfileController : ControllerBase
    {
        private readonly IAppUserProfileManager _appUserProfileManager;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateAppUserProfileRequestModel> _createAppUserProfileValidator;
        private readonly IValidator<UpdateAppUserProfileRequestModel> _updateAppUserProfileValidator;

        public AppUserProfileController(IAppUserProfileManager appUserProfileManager, IMapper mapper, IValidator<CreateAppUserProfileRequestModel> createAppUserProfileValidator, IValidator<UpdateAppUserProfileRequestModel> updateAppUserProfileValidator)
        {
            _appUserProfileManager = appUserProfileManager;
            _mapper = mapper;
            _createAppUserProfileValidator = createAppUserProfileValidator;
            _updateAppUserProfileValidator = updateAppUserProfileValidator;
        }

        [HttpGet]
        public async Task<IActionResult> GetProfiles()
        {
            //var profiles = await _manager.GetAllAsync();
            //return Ok(profiles);
            List<AppUserProfileDto> values = await _appUserProfileManager.GetAllAsync();

            List<AppUserProfileResponseModel> response =
                _mapper.Map<List<AppUserProfileResponseModel>>(values);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProfile(int id)
        {
            //var profile = await _manager.GetByIdAsync(id);
            //if (profile == null)
            //{
            //    return NotFound();
            //}
            //var response = _mapper.Map<AppUserProfileDto>(profile);
            //return Ok(response);

            AppUserProfileDto value = await _appUserProfileManager.GetByIdAsync(id);
            if (value == null) return NotFound();

            AppUserProfileResponseModel response =
                _mapper.Map<AppUserProfileResponseModel>(value);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProfile([FromBody] CreateAppUserProfileRequestModel model)
        {
            //await _manager.CreateAsync(profileDto);
            //return Ok("User Profil oluşturuldu");
            var validationResult = await _createAppUserProfileValidator.ValidateAsync(model);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            AppUserProfileDto dto = _mapper.Map<AppUserProfileDto>(model);
            await _appUserProfileManager.CreateAsync(dto);

            return Ok("User Profil oluşturuldu");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProfile(int id, [FromBody] UpdateAppUserProfileRequestModel model)
        {
            //profileDto.Id = id;
            //await _manager.UpdateAsync(profileDto);
            //return Ok("User Profil güncellendi");
            var validationResult = await _updateAppUserProfileValidator.ValidateAsync(model);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            AppUserProfileDto dto = _mapper.Map<AppUserProfileDto>(model);
            dto.Id = id; // id leri eşitlemek için. güncellerken id almıyoruz aynı id yi paylaştıkları için

            await _appUserProfileManager.UpdateAsync(dto);
            return Ok("User güncellendi");
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProfile(int id)
        {
            //var result = await _manager.SoftDeleteAsync(id);
            //return Ok(result);
            string mesaj = await _appUserProfileManager.HardDeleteAsync(id);
            return Ok(mesaj);
        }
    }
}
