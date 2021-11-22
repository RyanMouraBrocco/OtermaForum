using MongoDB.Bson;
using OtermaForum.Infra.NoSql.Attributes;
using OtermaForum.Infra.NoSql.Dtos.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtermaForum.Infra.NoSql.Dtos
{
    [MongoCollection("Post")]
    public class PostDto : BaseDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public ObjectId? OriginPostId { get; set; }
        public PostDto OriginPost { get; set; }
        public object CreatorId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public IList<ImageDto> Images { get; set; }
    }
}
