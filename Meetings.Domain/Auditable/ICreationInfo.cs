using Meetings.Domain.Ids;
using Meetings.Domain.ValueObjects;

namespace Meetings.Domain.Auditable;

public interface ICreationInfo
{
    CreationInfo CreationInfo { get; }

    void SetCreationInfo(DateTimeOffset createdAt, UserId createdById, string createdBy);
}