using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Helix.Core.Commands.Posts;
using Helix.Core.Queries.Posts;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Helix.API.Controllers
{
    [EnableCors("Policy1")]
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
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IEnumerable<Post>> GetPosts()
        {
            return await _postQueries.GetPostsAsync();
        }

        [Route("{postId}")]
        [HttpGet]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<Post> GetPostById(Guid postId)
        {
            return await _postQueries.GetPostByIdAsync(postId);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreatePost([FromBody] CreatePostCommand command)
        {
            var commandResult = await _mediator.Send(command);
            return Ok(commandResult);
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdatePost([FromBody] UpdatePostCommand command)
        {
            var commandResult = await _mediator.Send(command);
            return Ok(commandResult);
        }

        // Think about IsDeleted flags
        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public string DeletePost()
        {
            return string.Empty;
        }
    }
}
