using Meetings.Domain.Ids;
using Meetings.Domain.ValueObjects;

namespace Meetings.Domain.Auditable;

public interface IUpdateInfo
{
    UpdateInfo UpdateInfo { get; }
    void SetUpdateInfoData(DateTimeOffset updatedAt, UserId updatedById, string updatedBy);
}