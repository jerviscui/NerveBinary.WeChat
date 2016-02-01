using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Core.Domain;
using Web.Areas.Admin.Models.Home;

namespace Web.Areas.Admin
{
    public class AdminObjectProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<SubjectInfo, SubjectInfoModel>()
                .ForMember(o => o.PictureUrl, opt => opt.MapFrom(source => GetGameImg(source.Picture.Url)))
                .ForMember(o => o.ResultPictureUrl, opt => opt.MapFrom(source => GetGameImg(source.ResultPicture.Url)))
                .ForMember(o => o.Options, opt => opt.Ignore());

            CreateMap<SubjectOption, SubjectOptionModel>();
        }

        private static string GetGameImg(string relative)
        {
            return relative;
        }
    }
}