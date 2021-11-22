using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OtermaForum.Api.Controllers.Base;
using OtermaForum.Api.Helpers;
using OtermaForum.Application.Commands.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OtermaForum.Api.Controllers
{
    public class PostController : BaseController
    {
        private readonly IMediator _mediator;

        public PostController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("All")]
        [Authorize()]
        public async Task<IActionResult> GetAllAsync([FromQuery] PageQuery pageQuery)
        {
            return Ok(await _mediator.Send(new GetAllPostsCommandRequest(pageQuery.Top, pageQuery.Skip)));
        }

        [HttpGet("ById/{id}")]
        [Authorize()]
        public async Task<IActionResult> GetAllAsync(string id)
        {
            return Ok(await _mediator.Send(new GetPostByIdCommandRequest(id)));
        }

        [HttpPost()]
        [Authorize()]
        public async Task<IActionResult> GetAllAsync([FromBody] CreatePostCommandRequest body)
        {
            body.AddUserId(GetUserId());
            return Ok(await _mediator.Send(body));
        }

        [HttpPost("{originPostId}/Comment")]
        [Authorize()]
        public async Task<IActionResult> GetAllAsync(string originPostId, [FromBody] CreateCommentCommandRequest body)
        {
            body.AddUserId(GetUserId());
            body.AddOriginPostId(originPostId);
            return Ok(await _mediator.Send(body));
        }
    }
}
