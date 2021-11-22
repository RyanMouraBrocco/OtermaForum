using Ganss.XSS;
using MediatR;
using OtermaForum.Application.Commands.Requests;
using OtermaForum.Domain.Entities;
using OtermaForum.Infra.NoSql.Interfaces;
using OtermaForum.Infra.NoSql.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OtermaForum.Application.Handlers
{
    public class PostHandler : IRequestHandler<CreatePostCommandRequest, Post>,
                               IRequestHandler<CreateCommentCommandRequest, Post>,
                               IRequestHandler<GetAllPostsCommandRequest, IEnumerable<Post>>,
                               IRequestHandler<GetPostByIdCommandRequest, Post>
    {
        private readonly IPostRepository _postRepository;
        private readonly IHtmlSanitizer _htmlSanitizer;

        public PostHandler(IPostRepository postRepository,
                           IHtmlSanitizer htmlSanitizer)
        {
            _postRepository = postRepository;
            _htmlSanitizer = htmlSanitizer;
        }

        public async Task<Post> Handle(CreatePostCommandRequest request, CancellationToken cancellationToken)
        {
            var newPost = new Post()
            {
                Title = _htmlSanitizer.Sanitize(request.Title),
                Description = _htmlSanitizer.Sanitize(request.Description),
                CreationDate = DateTime.Now,
                CreatorId = request.UserId,
                Images = request.Images
            };

            await _postRepository.InsertAsync(newPost.MapToDto());

            return newPost;
        }

        public async Task<Post> Handle(CreateCommentCommandRequest request, CancellationToken cancellationToken)
        {
            var originPostCheck = (await _postRepository.GetOneByIdAsync((string)request.OriginPostId)).MapToDomain();
            if (originPostCheck == null)
                throw new UnauthorizedAccessException("Origin Post was not found");

            originPostCheck.OriginPost = null;

            var newComment = new Post()
            {
                Title = _htmlSanitizer.Sanitize(request.Title),
                Description = _htmlSanitizer.Sanitize(request.Description),
                CreationDate = DateTime.Now,
                CreatorId = request.UserId,
                Images = request.Images,
                OriginPostId = request.OriginPostId,
                OriginPost = originPostCheck
            };

            await _postRepository.InsertAsync(newComment.MapToDto());

            return newComment;
        }

        public async Task<IEnumerable<Post>> Handle(GetAllPostsCommandRequest request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_postRepository.GetAll().Where(x => x.OriginPost == null)
                                                                 .OrderByDescending(x => x.CreationDate)
                                                                 .Take(request.Top)
                                                                 .Skip(request.Skip)
                                                                 .ToList()
                                                                 .Select(x => x.MapToDomain()));
        }

        public async Task<Post> Handle(GetPostByIdCommandRequest request, CancellationToken cancellationToken)
        {
            return (await _postRepository.GetOneByIdAsync((string)request.Id)).MapToDomain();
        }
    }
}
