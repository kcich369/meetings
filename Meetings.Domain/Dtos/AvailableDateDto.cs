namespace Meetings.Domain.Dtos;

public record AvailableDateDto(DateOnly Date, TimeOnly From, TimeOnly To);