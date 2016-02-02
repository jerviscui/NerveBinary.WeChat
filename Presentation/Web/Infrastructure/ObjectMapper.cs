using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Core.Domain;
using Web.Areas.Admin;
using Web.Models.Game;

namespace Web.Infrastructure
{
    public class ObjectMapper
    {
        //public static void ConfigMapper()
        //{
        //    Mapper.CreateMap<SubjectInfo, SubjectInfoModel>()
        //        .ForMember(o => o.PictureUrl, opt => opt.MapFrom(source => GetGameImg(source.Picture.Url)));

        //    Mapper.CreateMap<SubjectOption, SubjectOptionModel>();

        //    Mapper.CreateMap<SubjectResult, SubjectResultModel>()
        //        .ForMember(o => o.PictureUrl, opt => opt.MapFrom(source => GetGameImg(source.Picture.Url)));
        //}

        public static MapperConfiguration ConfigMapper()
        {
            var config = new MapperConfiguration(configuration =>
            {
                //configuration.CreateMap<SubjectInfo, SubjectInfoModel>()
                //    .BeforeMap((src, dest) => src.Title = src.Title)
                //    .AfterMap((src, dest) => dest.Title = dest.Title)
                //    .ForMember(o => o.PictureUrl, opt =>
                //    {
                //        opt.MapFrom(source => GetGameImg(source.ResultPicture.Url));
                //    });

                configuration.CreateMap<SubjectInfo, SubjectInfoModel>()
                    .ForMember(o => o.PictureUrl, opt => opt.MapFrom(source => GetGameImg(source.Picture.Url)));
                configuration.CreateMap<SubjectOption, SubjectOptionModel>();
                configuration.CreateMap<SubjectResult, SubjectResultModel>()
                    .ForMember(o => o.PictureUrl, opt => opt.MapFrom(source => GetGameImg(source.ResultPicture.Url)))
                    .ForMember(o => o.CreateOnUtc, opt => opt.MapFrom(source => source.CreateOnUtc.ToLocalTime()));

                configuration.AddProfile<AdminObjectProfile>();
            });

            return config;
        }

        private static string GetGameImg(string relative)
        {
            return relative;
            //return HttpContext.Current.Request.Url.Authority + relative;
        }
    }
}