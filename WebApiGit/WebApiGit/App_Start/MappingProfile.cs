using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using WebApiGit.Models;

namespace WebApiGit.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<predmet, PredmetModel>();
            CreateMap<PredmetModel, predmet>().ForMember(c => c.id, opt => opt.Ignore());

            CreateMap<students, StudentModel>();
            CreateMap<StudentModel, students>().ForMember(c => c.id, opt => opt.Ignore());

            CreateMap<profesors, ProfesorModel>();
            CreateMap<ProfesorModel, profesors>().ForMember(c => c.id, opt => opt.Ignore());
        }
    }
}