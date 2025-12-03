using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Bll.Dtos;
using Project.Bll.Managers.Abstracts;
using Project.Concrats.Models.RequestModels.OrderDetails;
using Project.Concrats.Models.RequestModels.Orders;
using Project.Concrats.Models.ResponseModels.OrderDetails;

namespace Project.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        private readonly IOrderDetailManager _orderDetailManager;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateOrderDetailRequestModel> _createOrderDetailValidator;
        private readonly IValidator<UpdateOrderDetailRequestModel> _updateOrderDetailValidator;

        public OrderDetailController(IOrderDetailManager orderDetailManager, IMapper mapper, IValidator<CreateOrderDetailRequestModel> createOrderDetailValidator, IValidator<UpdateOrderDetailRequestModel> updateOrderDetailValidator)
        {
            _orderDetailManager = orderDetailManager;
            _mapper = mapper;
            _createOrderDetailValidator = createOrderDetailValidator;
            _updateOrderDetailValidator = updateOrderDetailValidator;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrderDetails()
        {
            //var orderDetails = await _orderDetailManager.GetAllAsync();
            //return Ok(orderDetails);

            List<OrderDetailDto> details = await _orderDetailManager.GetAllAsync();
            List<OrderDetailResponseModel> response =
                _mapper.Map<List<OrderDetailResponseModel>>(details);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderDetail(int id)
        {
            //var orderDetail = await _orderDetailManager.GetByIdAsync(id);
            //if (orderDetail == null)
            //{
            //    return NotFound();
            //}
            //var response = _mapper.Map<OrderDetailDto>(orderDetail);
            //return Ok(response);

            OrderDetailDto detail = await _orderDetailManager.GetByIdAsync(id);
            if (detail == null)
                return NotFound("Sipariş detayı bulunamadı");

            OrderDetailResponseModel response =
                _mapper.Map<OrderDetailResponseModel>(detail);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrderDetail([FromBody] CreateOrderDetailRequestModel model)
        {
            var validationResult = await _createOrderDetailValidator.ValidateAsync(model);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            OrderDetailDto dto = _mapper.Map<OrderDetailDto>(model);
            await _orderDetailManager.CreateAsync(dto);

            return Ok("Sipariş detayı oluşturuldu");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrderDetail(int id, [FromBody] UpdateOrderDetailRequestModel model)
        {
            var validationResult = await _updateOrderDetailValidator.ValidateAsync(model);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            OrderDetailDto dto = _mapper.Map<OrderDetailDto>(model);
            dto.Id = id; // Id URL’den geliyor, body’den değil

            await _orderDetailManager.UpdateAsync(dto);

            return Ok("Sipariş detayı güncellendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderDetail(int id)
        {
            string result = await _orderDetailManager.SoftDeleteAsync(id);
            return Ok(result);
        }
    }
}
