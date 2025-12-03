using AutoMapper;
using Project.Bll.Dtos;
using Project.Concrats.Models.RequestModels.AppUserProfiles;
using Project.Concrats.Models.RequestModels.AppUsers;
using Project.Concrats.Models.RequestModels.Categories;
using Project.Concrats.Models.RequestModels.OrderDetails;
using Project.Concrats.Models.RequestModels.Orders;
using Project.Concrats.Models.RequestModels.Products;
using Project.Concrats.Models.ResponseModels.AppUserProfiles;
using Project.Concrats.Models.ResponseModels.AppUsers;
using Project.Concrats.Models.ResponseModels.Categories;
using Project.Concrats.Models.ResponseModels.OrderDetails;
using Project.Concrats.Models.ResponseModels.Orders;
using Project.Concrats.Models.ResponseModels.Products;


namespace Project.WebApi.MappingProfiles
{
    public class VmMappingProfile : Profile
    {
        public VmMappingProfile()
        {
            CreateMap<CreateCategoryRequestModel, CategoryDto>();
            CreateMap<UpdateCategoryRequestModel, CategoryDto>();
            CreateMap<CategoryDto, CategoryResponseModel>();

            CreateMap<CreateAppUserRequestModel, AppUserDto>();
            CreateMap<UpdateAppUserRequestModel, AppUserDto>();
            CreateMap<AppUserDto, AppUserResponseModel>();

            CreateMap<CreateAppUserProfileRequestModel, AppUserProfileDto>();
            CreateMap<UpdateAppUserProfileRequestModel, AppUserProfileDto>();
            CreateMap<AppUserProfileDto, AppUserProfileResponseModel>();

            CreateMap<CreateProductRequestModel, ProductDto>();
            CreateMap<UpdateProductRequestModel, ProductDto>();
            CreateMap<ProductDto, ProductResponseModel>();

            CreateMap<CreateOrderRequestModel, OrderDto>();
            CreateMap<UpdateOrderRequestModel, OrderDto>();
            CreateMap<OrderDto, OrderResponseModel>();

            CreateMap<CreateOrderDetailRequestModel, OrderDetailDto>();
            CreateMap<UpdateOrderDetailRequestModel, OrderDetailDto>();
            CreateMap<OrderDetailDto, OrderDetailResponseModel>();

            CreateMap<CreateAppUserProfileRequestModel, AppUserProfileDto>()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.AppUserId)); // app user profile de ekleme yaparken id leri aynı yapmak için
        }
    }
}
