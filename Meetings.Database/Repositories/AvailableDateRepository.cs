using Meetings.Database.Context;
using Meetings.Domain.Dtos;
using Meetings.Domain.Entities;
using Meetings.Domain.Ids;
using Meetings.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Meetings.Database.Repositories;

public sealed class AvailableDateRepository : IAvailableDateRepository
{
    private readonly IAppDbContext _context;

    public AvailableDateRepository(IAppDbContext context)
    {
        _context = context;
    }

    public async Task AddRangeAsync(IEnumerable<AvailableDate> availableDates, CancellationToken cancellationToken)
    {
        await _context.Set<AvailableDate>().AddRangeAsync(availableDates, cancellationToken);
    }

    public void Delete(IEnumerable<AvailableDateId> availableDatesIds, CancellationToken cancellationToken)
    {
        _context.Set<AvailableDate>()
            .Where(x => availableDatesIds.Contains(x.Id))
            .ExecuteDelete();
    }

    public async Task<IList<AvailableDateDto>> GetAvailableDates(DateOnly? from = null, DateOnly? to = null, CancellationToken cancellationToken = default)
    {
        from ??= DateOnly.MinValue;
        to ??= DateOnly.MaxValue;
        return await _context.Set<AvailableDate>()
            .Where(x => x.MeetingData.Date >= from.Value && x.MeetingData.Date <= to.Value)
            .Select(x => new AvailableDateDto(x.MeetingData.Date, x.MeetingData.From, x.MeetingData.To))
            .ToListAsync(cancellationToken);
    }
}