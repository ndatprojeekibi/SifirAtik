using AutoMapper;
using SifirAtik.Domain.Dtos;
using SifirAtik.Domain.Entities;

namespace SifirAtik.Services.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, CreateUserDto>();

            CreateMap<RegisterUserDto, User>().ForSourceMember(s => s.Password, opt => opt.DoNotValidate());

            CreateMap<User, GetUserDto>();

            CreateMap<UpdateUserProfileDto, User>()
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedById, opt => opt.Ignore());

            CreateMap<UpdateEmailDto, User>()
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedById, opt => opt.Ignore());

            CreateMap<UpdatePasswordDto, User>()
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedById, opt => opt.Ignore());

            CreateMap<UpdateItemDto, Item>()
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedById, opt => opt.Ignore());

            CreateMap<AcceptDonatedItemDto, Item>()
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedById, opt => opt.Ignore());

            CreateMap<Item, GetItemDto>();

            CreateMap<Item, MarketItemDto>()
                .ForMember(s=> s.CreatedById, opt => opt.Ignore())
                .ForMember(s=> s.UpdatedById , opt => opt.Ignore());

            CreateMap<CreateItemDto, Item>();

            CreateMap<CreateRequestDto, Request>();

            CreateMap<Request, GetDonationRequestDto>()
                .ForMember(dest => dest.CreatedByName, opt => opt.Ignore())
                .ForMember(dest => dest.Item, opt => opt.MapFrom(src => src.Item));

            CreateMap<Request, GetAdoptionRequestDto>()
                .ForMember(dest => dest.Item, opt => opt.MapFrom(src => src.Item));

            CreateMap<UpdateRequestDto, Request>()
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedById, opt => opt.Ignore());
            

            CreateMap<Warehouse, GetWarehouseDto>();

            CreateMap<Warehouse, GetWarehouseNamesDto>()
                .ForMember(dest => dest.CreatedById, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedById, opt => opt.Ignore());

            CreateMap<CreateWarehouseDto, Warehouse>();

            CreateMap<UpdateWarehouseDto, Warehouse>()
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedById, opt => opt.Ignore());
        }
    }
}
