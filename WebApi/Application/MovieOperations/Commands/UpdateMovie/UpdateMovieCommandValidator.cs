using System;
using System.Linq;
using FluentValidation;
using WebApi.DBOperations;

namespace WebApi.Application.MovieOperations.Commands.UpdateMovie
{
    public class UpdateMovieCommandValidator : AbstractValidator<UpdateMovieCommand>
    {
        public UpdateMovieCommandValidator()
        {
            RuleFor(command => command.Model.DirectorID).GreaterThan(0);
            RuleFor(command => command.Model.GenreID).GreaterThan(0);
            RuleFor(command => command.Model.Name).MinimumLength(2);
            RuleFor(command => command.Model.Price).GreaterThan(0);
            RuleFor(command => command.Model.ReleaseDate.Date).NotEmpty().LessThan(DateTime.Now.Date);
        }
    }
}