using System;
using FlowApprove.Repository.Common;

namespace FlowApprove.Repository.Entity;

public class t_request_workflow_instance_node_approval : AuditableEntity
{
    public required Guid InstanceNodeId { get; set; }
    public required string AssigneeType { get; set; }
    public required string AssigneeName { get; set; }
    public required string AssigneeContact { get; set; }
    public string? Decision { get; set; }
    public DateTime? DecisionAt { get; set; }
    public string? Comments { get; set; }
    public t_request_workflow_instance_node_approval(
        Guid InstanceNodeId,
        string AssigneeType,
        string AssigneeName,
        string AssigneeContact,
        string? Decision = null,
        DateTime? DecisionAt = null,
        string? Comments = null,
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
        if (string.IsNullOrWhiteSpace(AssigneeType))
            throw new ArgumentException("AssigneeType cannot be null or empty.", nameof(AssigneeType));

        if (string.IsNullOrWhiteSpace(AssigneeName))
            throw new ArgumentException("AssigneeName cannot be null or empty.", nameof(AssigneeName));

        if (string.IsNullOrWhiteSpace(AssigneeContact))
            throw new ArgumentException("AssigneeContact cannot be null or empty.", nameof(AssigneeContact));

        if (!string.IsNullOrEmpty(Decision) && !new[] { "PENDDING", "APPROVED", "REJECTED", "REVISED", "TASK_DONE", "TASK_RETRY", "CANCELLED" }.Contains(Decision))
            throw new ArgumentException("Decision has an invalid value.", nameof(Decision));

        this.InstanceNodeId = InstanceNodeId;
        this.AssigneeType = AssigneeType;
        this.AssigneeName = AssigneeName;
        this.AssigneeContact = AssigneeContact;
        this.Decision = Decision;
        this.DecisionAt = DecisionAt;
        this.Comments = Comments;
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
