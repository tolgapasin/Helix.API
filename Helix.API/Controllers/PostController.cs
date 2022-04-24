using System;
using System.Threading.Tasks;
using Helix.Core.Commands.Posts;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Helix.Core.Queries.Posts;
using System.Collections.Generic;

namespace Helix.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostController : ControllerBase
    {
        private IMediator _mediator;
        private IPostQueries _postQueries;

        public PostController(IMediator mediator, IPostQueries postQueries)
        {
            _mediator = mediator;
            _postQueries = postQueries;
        }

        [HttpGet]
        public async Task<IEnumerable<Post>> GetPosts()
        {
            var result = await _postQueries.GetPostsAsync();
            return result;
        }

        //[HttpGet]
        //public string GetPostById()
        //{
        //    return "test";
        //}

        [HttpPost]
        public async Task<IActionResult> CreatePost([FromBody] CreatePostCommand command)
        {
            var commandResult = await _mediator.Send(command);
            return Ok(commandResult);
        }
        
        [HttpPut]
        public string UpdatePost()
        {
            return string.Empty;
        }

        // Think about IsDeleted flags
        [HttpDelete]
        public string DeletePost()
        {
            return string.Empty;
        }
    }
}
