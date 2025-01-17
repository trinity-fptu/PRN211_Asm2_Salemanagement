﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using PRN211_Asm2_Salemanagement_Library.Models;
using PRN211_Asm2_Salemanagement_Library.Repos.MemberRepo;

namespace PRN211_Asm2_Salemanagement_WinApp.Mapper
{
    public class ProfileMapper : Profile
    {
        public ProfileMapper()
        {
            CreateMap<Member, MemberMapper>();
            CreateMap<Order, OrderMapper>().ForMember(x => x.OrderDate,
                opt => opt.MapFrom(x => x.OrderDate.Date));
            CreateMap<Product, ProductMapper>();
            CreateMap<OrderDetail, OrderDetailMapper>();
        }
    }
}
