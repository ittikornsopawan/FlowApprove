using System;
using FlowApprove.Repository.Common;

namespace FlowApprove.Repository.Entity;

public class t_workflow_node_task : AuditableEntity
{
    public required Guid NodeId { get; set; }
    public required string RequestMethod { get; set; }
    public required string RequestUrl { get; set; }
    public string? RequestHeaders { get; set; }
    public string? RequestPayload { get; set; }

    public t_workflow_node_task(
        Guid NodeId,
        string RequestMethod,
        string RequestUrl,
        string? RequestHeaders = null,
        string? RequestPayload = null,
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
        if (NodeId == Guid.Empty)
            throw new ArgumentException("NodeId cannot be empty.", nameof(NodeId));

        if (string.IsNullOrWhiteSpace(RequestMethod))
            throw new ArgumentException("RequestMethod cannot be null or empty.", nameof(RequestMethod));

        if (string.IsNullOrWhiteSpace(RequestUrl))
            throw new ArgumentException("RequestUrl cannot be null or empty.", nameof(RequestUrl));

        this.NodeId = NodeId;
        this.RequestMethod = RequestMethod;
        this.RequestUrl = RequestUrl;
        this.RequestHeaders = RequestHeaders;
        this.RequestPayload = RequestPayload;
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
