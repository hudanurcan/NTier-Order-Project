using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Bll.Dtos;
using Project.Bll.Managers.Abstracts;
using Project.Concrats.Models.RequestModels.Products;
using Project.Concrats.Models.ResponseModels.Products;

namespace Project.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductManager _productManager;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateProductRequestModel> _createProductValidator;
        private readonly IValidator<UpdateProductRequestModel> _updateProductValidator;

        public ProductController(IProductManager productManager, IMapper mapper, IValidator<CreateProductRequestModel> createProductValidator, IValidator<UpdateProductRequestModel> updateProductValidator)
        {
            _productManager = productManager;
            _mapper = mapper;
            _createProductValidator = createProductValidator;
            _updateProductValidator = updateProductValidator;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            //var products = await _productManager.GetAllAsync();
            //return Ok(products);
            List<ProductDto> products = await _productManager.GetAllAsync();
            List<ProductResponseModel> response = _mapper.Map<List<ProductResponseModel>>(products);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            //var product = await _productManager.GetByIdAsync(id);
            //if (product == null)
            //{
            //    return NotFound();
            //}
            //var response = _mapper.Map<ProductDto>(product);
            //return Ok(response);
            ProductDto product = await _productManager.GetByIdAsync(id);
            if (product == null) return NotFound("Ürün bulunamadı");

            ProductResponseModel response = _mapper.Map<ProductResponseModel>(product);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductRequestModel model)
        {
            var validationResult = await _createProductValidator.ValidateAsync(model);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            ProductDto dto = _mapper.Map<ProductDto>(model);

            await _productManager.CreateAsync(dto);
            return Ok("Ürün eklendi");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] UpdateProductRequestModel model)
        {
            var validationResult = await _updateProductValidator.ValidateAsync(model);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            ProductDto dto = _mapper.Map<ProductDto>(model);

            dto.Id = id;

            await _productManager.UpdateAsync(dto);
            return Ok("Ürün güncellendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            string result = await _productManager.SoftDeleteAsync(id);
            return Ok(result);
        }
    }
}
