using MongoDB.Bson;
using OtermaForum.Infra.NoSql.Dtos.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtermaForum.Infra.NoSql.Interfaces
{
    public interface IMongoRepository<TDto> where TDto : BaseDto
    {
        Task InsertAsync(TDto value);
        Task UpdateAsync(ObjectId id, TDto value);
        Task<TDto> GetOneByIdAsync(ObjectId id);
        IQueryable<TDto> GetAll();
    }
}
