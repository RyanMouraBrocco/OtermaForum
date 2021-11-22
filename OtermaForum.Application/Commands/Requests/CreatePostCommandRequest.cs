using MediatR;
using OtermaForum.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtermaForum.Application.Commands.Requests
{
    public class CreatePostCommandRequest : IRequest<Post>, IRequest<CreatePostCommandRequest>
    {
        [Required]
        public object UserId { get; private set; }
        [Required(ErrorMessage = "Title is required")]
        [StringLength(200, MinimumLength = 1, ErrorMessage = "Title must have value")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Description is required")]
        [StringLength(2000, MinimumLength = 1, ErrorMessage = "Description must have value")]
        public string Description { get; set; }
        public IList<Image> Images { get; set; }

        public CreatePostCommandRequest()
        {
            Images = new List<Image>();
        }

        public void AddUserId(object userId)
        {
            UserId = userId;
        }
    }
}
