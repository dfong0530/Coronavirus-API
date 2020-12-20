using ApiPractice.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiPractice.Data
{
    public class CovidStatsProfile: Profile
    {
        public CovidStatsProfile()
        {
            CreateMap<GlobalCases, GlobalCasesModels>().ReverseMap();

            CreateMap<NumCasesPerCountry, NumCasesPerCountryModel>().ReverseMap();

            CreateMap<PercentCases, PercentCasesModels>().ReverseMap();
        }
    }
}