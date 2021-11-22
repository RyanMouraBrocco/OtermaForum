using MediatR;
using OtermaForum.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtermaForum.Application.Commands.Requests
{
    public class GetPostByIdCommandRequest : IRequest<Post>, IRequest<GetPostByIdCommandRequest>
    {
        public object Id { get; set; }

        public GetPostByIdCommandRequest(object id)
        {
            Id = id;
        }
    }
}
