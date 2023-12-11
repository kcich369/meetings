using MediatR;
using Meetings.Domain.Dtos;
using Meetings.Domain.Entities;
using Meetings.Domain.Ids;
using Meetings.Domain.Repositories;
using Meetings.Domain.Results;
using Meetings.Domain.UnitOfWork;
using Meetings.Domain.ValueObjects;

namespace Meetings.Application.AvailableDates.Commands.Add;

public record AddAvailableDateCommand
    (IEnumerable<DateOnly> Dates, TimeOnly From, TimeOnly To) : IRequest<IResult<bool>>;

public class AddAvailableDateCommandHandler : IRequestHandler<AddAvailableDateCommand, IResult<bool>>
{
    private readonly IAvailableDateRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public AddAvailableDateCommandHandler(IAvailableDateRepository repository,
        IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IResult<bool>> Handle(AddAvailableDateCommand request, CancellationToken cancellationToken)
    {
        var minDate = request.Dates.MinBy(x => x);
        var maxDate = request.Dates.MaxBy(x => x);
        var existingDates = await _repository.GetAvailableDates(minDate, maxDate, cancellationToken);
        var newDates = request.Dates
            .Select(x => new AvailableDateDto(x, request.From, request.To))
            .Except(existingDates)
            .Select(x => new AvailableDate(new AvailableDateId(), new MeetingData(x.Date, x.From, x.To)));
        await _repository.AddRangeAsync(newDates, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result<bool>.Success(true);
    }
}