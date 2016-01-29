using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Core.Domain;
using Web.Models.Game;

namespace Web.Infrastructure
{
    public class ObjectMapper
    {
        public static void ConfigMapper()
        {
            Mapper.CreateMap<SubjectInfo, SubjectInfoModel>()
                .ForMember(o => o.PictureUrl, opt => opt.MapFrom(source => GetGameImg(source.Picture.Url)));

            Mapper.CreateMap<SubjectOption, SubjectOptionModel>();

            Mapper.CreateMap<SubjectResult, SubjectResultModel>()
                .ForMember(o => o.PictureUrl, opt => opt.MapFrom(source => GetGameImg(source.ResultPicture.Url)));
        }

        private static string GetGameImg(string relative)
        {
            return relative;
            //return HttpContext.Current.Request.Url.Authority + relative;
        }
    }
}