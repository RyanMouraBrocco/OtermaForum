using OtermaForum.Infra.NoSql.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtermaForum.Infra.NoSql.Interfaces
{
    public interface IPostRepository : IMongoRepository<PostDto>
    {
    }
}
