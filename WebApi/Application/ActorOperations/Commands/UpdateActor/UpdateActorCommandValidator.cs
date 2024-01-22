using FluentValidation;

namespace WebApi.Application.ActorOperations.Commands.UpdateActor
{
    public class UpdateActorCommandValidator : AbstractValidator<UpdateActorCommand>
    {
        public UpdateActorCommandValidator()
        {
            RuleFor(x=> x.ActorId).GreaterThan(0);
            RuleFor(x=> x.Model.FirstName).NotEmpty().MinimumLength(2);
            RuleFor(x=> x.Model.LastName).NotEmpty().MinimumLength(2);
        }
    }
}