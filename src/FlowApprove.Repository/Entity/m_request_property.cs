using System;
using FlowApprove.Repository.Common;

namespace FlowApprove.Repository.Entity;

public class m_request_property : AuditableEntity
{
    public required Guid RequestId { get; set; }
    public required string Key { get; set; }
    public required string Title { get; set; }
    public required string Type { get; set; }
    public string? Description { get; set; }
    public bool IsRequired { get; set; }

    public m_request_property(
        Guid RequestId,
        string Key,
        string Title,
        string Type,
        bool IsRequired = false,
        string? Description = null,
        Guid? Id = null,
        DateTime? CreatedAt = null,
        Guid? CreatedById = null,
        DateTime? UpdatedAt = null,
        Guid? UpdatedById = null,
        bool IsActive = false,
        DateTime? InactiveAt = null,
        Guid? InactiveById = null,
        bool IsDeleted = false,
        DateTime? DeletedAt = null,
        Guid? DeletedById = null
    )
    {
        this.RequestId = RequestId;
        this.Key = Key;
        this.Title = Title;
        this.Type = Type;
        this.IsRequired = IsRequired;
        this.Description = Description;
        this.Id = Id ?? Guid.NewGuid();
        this.CreatedAt = CreatedAt ?? DateTime.UtcNow;
        this.CreatedById = CreatedById;
        this.UpdatedAt = UpdatedAt;
        this.UpdatedById = UpdatedById;
        this.IsActive = IsActive;
        this.InactiveAt = InactiveAt;
        this.InactiveById = InactiveById;
        this.IsDeleted = IsDeleted;
        this.DeletedAt = DeletedAt;
        this.DeletedById = DeletedById;
    }
}
