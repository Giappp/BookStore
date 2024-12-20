﻿using AutoMapper;
using BookStore.Application.DTOs;
using BookStore.Application.DTOs.Order;
using BookStore.Domain.Entities;

namespace BookStore.Application.Mappers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<RegisterDto, User>()
           .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
           .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
           .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
           .ForMember(dest => dest.Address, opt => opt.Ignore())
           .ForMember(dest => dest.Avatar, opt => opt.Ignore())
           .ForMember(dest => dest.Phone, opt => opt.Ignore())
           .ForMember(dest => dest.RoleId, opt => opt.Ignore())
           .ForMember(dest => dest.Carts, opt => opt.Ignore())
           .ForMember(dest => dest.Orders, opt => opt.Ignore())
           .ForMember(dest => dest.Role, opt => opt.Ignore());

            CreateMap<CartDetail, CartDetailDto>()
            .ForMember(dest => dest.BookName, opt => opt.MapFrom(src => src.Book.Name))
            .ForMember(dest => dest.BookPrice, opt => opt.MapFrom(src => src.Book.Price))
            .ForMember(dest => dest.BookImage, opt => opt.MapFrom(src => src.Book.Image))
            .ForMember(dest => dest.BookDiscount, opt => opt.MapFrom(src => src.Book.Discount))
            .ForMember(dest => dest.BookQuantity, opt => opt.MapFrom(src => src.Book.Quantity));

            CreateMap<CreateOrUpdateBookRequest, Book>();

            CreateMap<BookDto, Book>();
            CreateMap<Book, BookDto>();

            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();

            CreateMap<UserDto, User>();

            CreateMap<Order, OrderDto>()
            .ForMember(dest => dest.OrderId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.OrderDate, opt => opt.MapFrom(src => src.OrderDate ?? DateTime.MinValue));

            CreateMap<OrderDetail, OrderDetailDto>()
            .ForMember(dest => dest.BookName, opt => opt.MapFrom(src => src.Book.Name))
            .ForMember(dest => dest.BookImage, opt => opt.MapFrom(src => src.Book.Image))
            .ForMember(dest => dest.BookPrice, opt => opt.MapFrom(src => src.Book.Price))
            .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity));
        }
    }
}
