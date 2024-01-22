using FluentValidation;

namespace WebApi.Application.MovieOperations.Commands.CreateMovie
{
    public class CreateMovieCommandValidator : AbstractValidator<CreateMovieCommand>
    {
        public CreateMovieCommandValidator()
        {
            RuleFor(command => command.Model.GenreID).GreaterThan(0);
            RuleFor(command => command.Model.DirectorID).GreaterThan(0);
            RuleFor(command => command.Model.Name).NotEmpty().MinimumLength(2);
            RuleFor(command => command.Model.Price).GreaterThan(0);
            RuleFor(command => command.Model.ReleaseDate.Date).NotEmpty().LessThan(System.DateTime.Now.Date);
        }
    }
}