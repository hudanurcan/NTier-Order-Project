using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Bll.Dtos;
using Project.Bll.Managers.Abstracts;
using Project.Concrats.Models.RequestModels.Orders;
using Project.Concrats.Models.ResponseModels.Orders;

namespace Project.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderManager _orderManager;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateOrderRequestModel> _createOrderValidator;
        private readonly IValidator<UpdateOrderRequestModel> _updateOrderValidator;
        public OrderController(IOrderManager orderManager, IMapper mapper, IValidator<CreateOrderRequestModel> createOrderValidator, IValidator<UpdateOrderRequestModel> updateOrderValidator)
        {
            _orderManager = orderManager;
            _mapper = mapper;
            _createOrderValidator = createOrderValidator;
            _updateOrderValidator = updateOrderValidator;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            //var orders = await _orderManager.GetAllAsync();
            //return Ok(orders);
            List<OrderDto> orders = await _orderManager.GetAllAsync();
            List<OrderResponseModel> response = _mapper.Map<List<OrderResponseModel>>(orders);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrder(int id)
        {
            //var order = await _orderManager.GetByIdAsync(id);
            //if (order == null)
            //{
            //    return NotFound();
            //}
            //var response = _mapper.Map<OrderDto>(order);
            //return Ok(response);
            OrderDto order = await _orderManager.GetByIdAsync(id);
            if (order == null) 
                return NotFound("Sipariş bulunamadı");

            OrderResponseModel response = _mapper.Map<OrderResponseModel>(order);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderRequestModel model)
        {
            var validationResult = await _createOrderValidator.ValidateAsync(model);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            OrderDto dto = _mapper.Map<OrderDto>(model);

            await _orderManager.CreateAsync(dto);
            return Ok("Sipariş eklendi");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(int id, [FromBody] UpdateOrderRequestModel model)
        {
            var validationResult = await _updateOrderValidator.ValidateAsync(model);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            OrderDto dto = _mapper.Map<OrderDto>(model);

            dto.Id = id;

            await _orderManager.UpdateAsync(dto);
            return Ok("Order updated successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            string result = await _orderManager.SoftDeleteAsync(id);
            return Ok(result);
        }
    }
}
