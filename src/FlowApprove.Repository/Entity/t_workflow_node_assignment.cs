using System;
using FlowApprove.Repository.Common;

namespace FlowApprove.Repository.Entity;

public class t_workflow_node_assignment : AuditableEntity
{
    public required Guid NodeId { get; set; }
    public required string AssigneeType { get; set; }
    public required string AssigneeName { get; set; }
    public required string AssigneeContact { get; set; }

    public t_workflow_node_assignment(
        Guid NodeId,
        string AssigneeType,
        string AssigneeName,
        string AssigneeContact,
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

        if (NodeId == Guid.Empty)
            throw new ArgumentException("NodeId cannot be empty.", nameof(NodeId));

        this.NodeId = NodeId;
        this.AssigneeType = AssigneeType;
        this.AssigneeName = AssigneeName;
        this.AssigneeContact = AssigneeContact;
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
