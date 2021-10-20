﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.TodoAppNTier.Dtos.WorkDtos;
using Udemy.TodoAppNTier.Entities.Domains;

namespace Udemy.TodoAppNTier.Business.Mappings.AutoMapper
{
 public   class WorkProfile:Profile
    {
        public WorkProfile()
        {
            CreateMap<Work, WorkCreateDto>().ReverseMap();
            CreateMap<Work, WorkListDto>().ReverseMap();
            CreateMap<Work, WorkUpdateDto>().ReverseMap();
            CreateMap<WorkListDto, WorkUpdateDto>().ReverseMap();

        }
    }
}
