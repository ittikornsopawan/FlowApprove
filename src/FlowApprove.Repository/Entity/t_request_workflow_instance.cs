using System;
using FlowApprove.Repository.Common;

namespace FlowApprove.Repository.Entity;

public class t_request_workflow_instance : AuditableEntity
{
    public required Guid RequestId { get; set; }
    public required Guid WorkflowId { get; set; }
    public required Guid CurrentNodeId { get; set; }
    public required string Status { get; set; }

    public t_request_workflow_instance(
        Guid RequestId,
        Guid WorkflowId,
        Guid CurrentNodeId,
        string Status,
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
        if (RequestId == Guid.Empty)
            throw new ArgumentException("RequestId cannot be empty", nameof(RequestId));

        if (WorkflowId == Guid.Empty)
            throw new ArgumentException("WorkflowId cannot be empty", nameof(WorkflowId));

        if (string.IsNullOrWhiteSpace(Status))
            throw new ArgumentException("Status cannot be null or empty", nameof(Status));

        if (!new[] { "PENDING", "IN_PROGRESS", "COMPLETED", "REJECTED", "CANCELLED" }.Contains(Status))
            throw new ArgumentException($"Status '{Status}' is not valid", nameof(Status));

        this.RequestId = RequestId;
        this.WorkflowId = WorkflowId;
        this.CurrentNodeId = CurrentNodeId;
        this.Status = Status;
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
