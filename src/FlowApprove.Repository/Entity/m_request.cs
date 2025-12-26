using System;
using FlowApprove.Repository.Common;

namespace FlowApprove.Repository.Entity;

public class m_request : AuditableEntity
{
    public Guid WorkflowId { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }

    public m_request(
        Guid WorkflowId,
        string Name,
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
        this.Id = Id ?? Guid.NewGuid();
        this.WorkflowId = WorkflowId;
        this.Name = Name;
        this.Description = Description;
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
