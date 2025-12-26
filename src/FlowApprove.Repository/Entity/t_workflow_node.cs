using System;
using FlowApprove.Repository.Common;

namespace FlowApprove.Repository.Entity;

public class t_workflow_node : AuditableEntity
{
    public required Guid WorkflowId { get; set; }
    public required string Type { get; set; }
    public required int Sequence { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public required string ApproverSource { get; set; }
    public required string ApprovalPolicy { get; set; }

    public t_workflow_node(
        Guid WorkflowId,
        string Type,
        int Sequence,
        string Name,
        string ApproverSource,
        string ApprovalPolicy,
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
        if (string.IsNullOrWhiteSpace(Type) || !new[] { "BEGIN", "END", "APPROVAL", "NOTIFICATION", "TASK" }.Contains(Type))
            throw new ArgumentException("Type must be one of the following values: 'BEGIN', 'END', 'APPROVAL', 'NOTIFICATION', 'TASK'.", nameof(Type));

        if (string.IsNullOrWhiteSpace(Name))
            throw new ArgumentException("Name cannot be null or whitespace.", nameof(Name));

        if (string.IsNullOrWhiteSpace(ApproverSource) || !new[] { "STATIC", "DYNAMIC", "EXTERNAL" }.Contains(ApproverSource))
            throw new ArgumentException("ApproverSource must be one of the following values: 'STATIC', 'DYNAMIC', 'EXTERNAL'.", nameof(ApproverSource));

        if (string.IsNullOrWhiteSpace(ApprovalPolicy))
            throw new ArgumentException("ApprovalPolicy cannot be null or whitespace.", nameof(ApprovalPolicy));

        this.WorkflowId = WorkflowId;
        this.Type = Type;
        this.Sequence = Sequence;
        this.Name = Name;
        this.ApproverSource = ApproverSource;
        this.ApprovalPolicy = ApprovalPolicy;
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
