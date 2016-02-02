using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Core;
using Core.Domain;
using Web.Areas.Admin.Models;
using Web.Models.Game;

namespace Web.Infrastructure
{
    public static class ObjectMappingExtension
    {
        private static readonly IMapper Mapper;

        static ObjectMappingExtension()
        {
            Mapper = ObjectMapper.ConfigMapper().CreateMapper();
        }

        public static SubjectInfoModel ToModel(this SubjectInfo entity)
        {
            return Mapper.Map<SubjectInfo, SubjectInfoModel>(entity);
        }

        public static Areas.Admin.Models.Home.SubjectInfoModel ToAdminModel(this SubjectInfo entity)
        {
            return Mapper.Map<SubjectInfo, Areas.Admin.Models.Home.SubjectInfoModel>(entity);
        }

        public static SubjectInfo ToEntity(this Areas.Admin.Models.Home.SubjectInfoModel model)
        {
            return Mapper.Map<Areas.Admin.Models.Home.SubjectInfoModel, SubjectInfo>(model);
        }

        public static SubjectOptionModel ToModel(this SubjectOption entity)
        {
            return Mapper.Map<SubjectOption, SubjectOptionModel>(entity);
        }

        public static Areas.Admin.Models.Home.SubjectOptionModel ToAdminModel(this SubjectOption entity)
        {
            return Mapper.Map<SubjectOption, Areas.Admin.Models.Home.SubjectOptionModel>(entity);
        }

        public static SubjectOption ToEntity(this Areas.Admin.Models.Home.SubjectOptionModel model)
        {
            return Mapper.Map<Areas.Admin.Models.Home.SubjectOptionModel, SubjectOption>(model);
        }

        public static SubjectResultModel ToModel(this SubjectResult entity)
        {
            return Mapper.Map<SubjectResult, SubjectResultModel>(entity);
        }

        public static Areas.Admin.Models.Home.SubjectResultModel ToAdminModel(this SubjectResult entity)
        {
            return Mapper.Map<SubjectResult, Areas.Admin.Models.Home.SubjectResultModel>(entity);
        }

        public static PageModel<TModel> ToModel<TEntity, TModel>(this IPagedList<TEntity> entityList)
        {
            return new PageModel<TModel>()
            {
                CurrenIndex = entityList.CurrenIndex,
                HasNext = entityList.HasNext,
                HasPrev = entityList.HasPrev,
                PageSize = entityList.PageSize,
                Total = entityList.Total,
                TotalPage = entityList.TotalPage
            };
        }
    }
}