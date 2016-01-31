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
        public static SubjectInfoModel ToModel(this SubjectInfo entity)
        {
            return Mapper.Map<SubjectInfo, SubjectInfoModel>(entity);
        }

        public static SubjectOptionModel ToModel(this SubjectOption entity)
        {
            return Mapper.Map<SubjectOption, SubjectOptionModel>(entity);
        }

        public static SubjectResultModel ToModel(this SubjectResult entity)
        {
            return Mapper.Map<SubjectResult, SubjectResultModel>(entity);
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