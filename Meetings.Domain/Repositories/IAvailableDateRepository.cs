using Meetings.Domain.Dtos;
using Meetings.Domain.Entities;
using Meetings.Domain.Ids;

namespace Meetings.Domain.Repositories;

public interface IAvailableDateRepository
{
    Task AddRangeAsync(IEnumerable<AvailableDate> availableDates, CancellationToken cancellationToken);

    void Delete(IEnumerable<AvailableDateId> availableDatesIds, CancellationToken cancellationToken);

    Task<IList<AvailableDateDto>> GetAvailableDates(DateOnly? from = null, DateOnly? to = null,
        CancellationToken cancellationToken = default);
}