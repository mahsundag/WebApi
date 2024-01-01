using Atolla.Api.Framework.Models.Base;
using Atolla.Core.BaseRepository;
using Atolla.Core.Mapper;
using System;
using System.Collections.Generic;

namespace Atolla.Api.Framework.Extensions
{
    public static class MapperExtensions
    {
        private static TDestination Map<TDestination>(this object source)
        {
            return AutoMapperConfiguration.Mapper.Map<TDestination>(source);
        }
        private static TDestination MapTo<TSource, TDestination>(this TSource source, TDestination destination)
        {
            return AutoMapperConfiguration.Mapper.Map(source, destination);
        }

        public static TModel ToModel<TModel>(this BaseEntity entity) where TModel : BaseModel
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            return entity.Map<TModel>();
        }

        public static IEnumerable<TModel> ToModel<TModel>(this IEnumerable<BaseEntity> entity) where TModel : BaseModel
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            return entity.Map<IEnumerable<TModel>>();
        }

        public static TEntity ToEntity<TEntity>(this BaseModel model) where TEntity : BaseEntity
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            return model.Map<TEntity>();
        }
    }
}
