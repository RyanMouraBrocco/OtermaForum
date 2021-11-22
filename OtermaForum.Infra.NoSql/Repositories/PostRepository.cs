using Microsoft.Extensions.Options;
using OtermaForum.Infra.NoSql.Dtos;
using OtermaForum.Infra.NoSql.Interfaces;
using OtermaForum.Infra.NoSql.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtermaForum.Infra.NoSql.Repositories
{
    public class PostRepository : MongoRepository<PostDto>, IPostRepository
    {
        public PostRepository(IOptions<MongoDbSettings> options) : base(options)
        {

        }
    }
}
