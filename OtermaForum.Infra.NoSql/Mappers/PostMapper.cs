using MongoDB.Bson;
using OtermaForum.Domain.Entities;
using OtermaForum.Infra.NoSql.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtermaForum.Infra.NoSql.Mappers
{
    public static class PostMapper
    {
        public static Post MapToDomain(this PostDto dto)
        {
            return new Post()
            {
                Id = dto.Id,
                Title = dto.Title,
                Description = dto.Description,
                CreationDate = dto.CreationDate,
                CreatorId = dto.CreatorId,
                OriginPost = dto.OriginPost?.MapToDomain(),
                Images = dto.Images?.Select(x => x.MapToDomain()).ToList() ?? new List<Image>(),
                OriginPostId = dto.OriginPostId,
                UpdateDate = dto.UpdateDate
            };
        }

        public static PostDto MapToDto(this Post entity)
        {
            return new PostDto()
            {
                Id = (ObjectId)entity.Id,
                Title = entity.Title,
                Description = entity.Description,
                CreationDate = entity.CreationDate,
                CreatorId = entity.CreatorId,
                OriginPost = entity.OriginPost?.MapToDto(),
                Images = entity.Images?.Select(x => x.MapToDto()).ToList() ?? new List<ImageDto>(),
                OriginPostId = (ObjectId)entity.OriginPostId,
                UpdateDate = entity.UpdateDate
            };
        }
    }
}
