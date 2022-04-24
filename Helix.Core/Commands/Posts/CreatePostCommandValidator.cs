using FluentValidation;

namespace Helix.Core.Commands.Posts
{
    public class CreatePostCommandValidator : AbstractValidator<CreatePostCommand>
    {
        // TODO: Fix this
        public CreatePostCommandValidator()
        {
            RuleFor(command => command.Content)
                .MaximumLength(1024)
                .WithMessage("Content cannot be more than 1024 characters");
        }
    }
}
