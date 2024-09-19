using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkXyz.Entities;
using WorkXyz.UI.ViewModel.BranchViewModel;
using WorkXyz.UI.ViewModel.SubjectViewModel;

namespace WorkXyz.UI.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // CreateMap<Source, Destination>()
            CreateMap<Branch, BranchViewModel>().ReverseMap();
            CreateMap<CreateBranchViewModel, Branch>();
            CreateMap<Subjects, SubjectViewModel>().ReverseMap();
        }

    }
}
