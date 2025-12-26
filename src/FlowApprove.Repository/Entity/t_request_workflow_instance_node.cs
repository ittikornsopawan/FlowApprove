using System;
using FlowApprove.Repository.Common;

namespace FlowApprove.Repository.Entity;

public class t_request_workflow_instance_node : AuditableEntity
{
    public required Guid InstanceId { get; set; }
    public required Guid NodeId { get; set; }
    public required string Status { get; set; }
    public DateTime? StartedAt { get; set; }
    public DateTime? CompletedAt { get; set; }

    public t_request_workflow_instance_node(
        Guid InstanceId,
        Guid NodeId,
        string Status,
        DateTime? StartedAt = null,
        DateTime? CompletedAt = null,
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
        if (InstanceId == Guid.Empty)
            throw new ArgumentException("InstanceId cannot be empty.", nameof(InstanceId));

        if (NodeId == Guid.Empty)
            throw new ArgumentException("NodeId cannot be empty.", nameof(NodeId));

        if (string.IsNullOrWhiteSpace(Status))
            throw new ArgumentException("Status cannot be null or empty.", nameof(Status));

        var validStatuses = new[] { "PENDING", "IN_PROGRESS", "COMPLETED", "REJECTED", "CANCELLED" };
        if (!validStatuses.Contains(Status))
            throw new ArgumentException($"Status must be one of: {string.Join(", ", validStatuses)}", nameof(Status));

        this.InstanceId = InstanceId;
        this.NodeId = NodeId;
        this.Status = Status;
        this.StartedAt = StartedAt;
        this.CompletedAt = CompletedAt;
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
