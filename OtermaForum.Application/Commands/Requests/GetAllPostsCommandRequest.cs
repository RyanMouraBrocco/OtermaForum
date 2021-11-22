using MediatR;
using OtermaForum.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtermaForum.Application.Commands.Requests
{
    public class GetAllPostsCommandRequest : IRequest<IEnumerable<Post>>, IRequest<GetAllPostsCommandRequest>
    {
        public int Top { get; set; }
        public int Skip { get; set; }

        public GetAllPostsCommandRequest(int top, int skip)
        {
            Top = top;
            Skip = skip;
        }
    }
}
