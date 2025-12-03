using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Bll.Dtos;
using Project.Bll.Managers.Abstracts;
using Project.Concrats.Models.RequestModels.AppUsers;

namespace Project.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserController : ControllerBase
    {
        private readonly IAppUserManager _appUserManager;
        private readonly IMapper _mapper;

        private readonly IValidator<CreateAppUserRequestModel> _createAppUserValidator;
        private readonly IValidator<UpdateAppUserRequestModel> _updateAppUserValidator;
        public AppUserController(IAppUserManager appUserManager, IMapper mapper, IValidator<CreateAppUserRequestModel> createAppUserValidator, IValidator<UpdateAppUserRequestModel> updateAppUserValidator)
        {
            _appUserManager = appUserManager;
            _mapper = mapper;
            _createAppUserValidator = createAppUserValidator;
            _updateAppUserValidator = updateAppUserValidator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAppUsers()
        {
            List<AppUserDto> values = await _appUserManager.GetAllAsync();

            // var response = _mapper.Map<List<AppUserResponseModel>>(values);
            // return Ok(response);

            return Ok(values); 
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAppUser(int id)
        {
            AppUserDto value = await _appUserManager.GetByIdAsync(id);
            if (value == null) return NotFound();

            // varsa response model:
            // var response = _mapper.Map<AppUserResponseModel>(value);
            // return Ok(response);

            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAppUser(CreateAppUserRequestModel model)
        {
            var validationResult = await _createAppUserValidator.ValidateAsync(model);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            AppUserDto dto = _mapper.Map<AppUserDto>(model);
            await _appUserManager.CreateAsync(dto);

            return Ok("User oluşturuldu");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAppUser(UpdateAppUserRequestModel model)
        {
            var validationResult = await _updateAppUserValidator.ValidateAsync(model);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            AppUserDto dto = _mapper.Map<AppUserDto>(model);
            await _appUserManager.UpdateAsync(dto);

            return Ok("User güncellendi");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PacifyAppUser(int id)
        {
            string mesaj = await _appUserManager.SoftDeleteAsync(id);
            return Ok(mesaj);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAppUser(int id)
        {
            string mesaj = await _appUserManager.HardDeleteAsync(id);
            return Ok(mesaj);
        }
    }
}
