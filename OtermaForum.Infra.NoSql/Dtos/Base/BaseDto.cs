using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtermaForum.Infra.NoSql.Dtos.Base
{
    public class BaseDto
    {
        [BsonId]
        public ObjectId Id { get; set; }
    }
}
