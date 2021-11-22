using OtermaForum.Domain.Entities;
using OtermaForum.Infra.NoSql.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtermaForum.Infra.NoSql.Mappers
{
    public static class ImageMapper
    {
        public static Image MapToDomain(this ImageDto dto)
        {
            return new Image()
            {
                ImageUrl = dto.ImageUrl,
                SubTitle = dto.SubTitle
            };
        }

        public static ImageDto MapToDto(this Image entity)
        {
            return new ImageDto()
            {
                ImageUrl = entity.ImageUrl,
                SubTitle = entity.SubTitle
            };
        }
    }
}
