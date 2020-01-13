﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TopkaE.FPLDataDownloader.Models.InputModels;
using TopkaE.FPLDataDownloader.Models.OutputModels;

namespace TopkaE.FPLDataDownloader.AutoMapper
{
    public class OutputModelsProfile : Profile
    {
        public OutputModelsProfile()
        {
            CreateMap<Element, EventTransfers>();
            CreateMap<Element, MostGoals>();
        }
    }

   
//public class DomainProfile : Profile
//    {
//        public DomainProfile()
//        {
//            CreateMap<DomainUser, UserViewModel>();
//        }
//    }
}