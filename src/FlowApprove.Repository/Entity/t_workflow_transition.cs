using System;
using FlowApprove.Repository.Common;

namespace FlowApprove.Repository.Entity;

public class t_workflow_transition : AuditableEntity
{
    public required Guid WorkflowId { get; set; }
    public required Guid FromNodeId { get; set; }
    public required Guid ToNodeId { get; set; }
    public string? Condition { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }

    public t_workflow_transition(
        Guid WorkflowId,
        Guid FromNodeId,
        Guid ToNodeId,
        string Name,
        string? Condition = null,
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
        if (WorkflowId == Guid.Empty)
            throw new ArgumentException("WorkflowId cannot be empty.", nameof(WorkflowId));

        if (FromNodeId == Guid.Empty)
            throw new ArgumentException("FromNodeId cannot be empty.", nameof(FromNodeId));

        if (ToNodeId == Guid.Empty)
            throw new ArgumentException("ToNodeId cannot be empty.", nameof(ToNodeId));

        if (string.IsNullOrWhiteSpace(Name))
            throw new ArgumentException("Name cannot be null or empty.", nameof(Name));

        if (Name.Length > 128)
            throw new ArgumentException("Name cannot exceed 128 characters.", nameof(Name));

        this.WorkflowId = WorkflowId;
        this.FromNodeId = FromNodeId;
        this.ToNodeId = ToNodeId;
        this.Name = Name;
        this.Condition = Condition;
        this.Description = Description;
        this.Id = Id ?? Guid.NewGuid();
        this.CreatedAt = CreatedAt ?? DateTime.UtcNow;
        this.CreatedById = CreatedById ?? Guid.Empty;
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
