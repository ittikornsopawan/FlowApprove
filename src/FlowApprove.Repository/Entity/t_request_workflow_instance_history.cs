using System;
using FlowApprove.Repository.Common;

namespace FlowApprove.Repository.Entity;

public class t_request_workflow_instance_history : AuditableEntity
{
    public required Guid InstanceId { get; set; }
    public Guid? NodeId { get; set; }
    public required string Action { get; set; }
    public string? Decision { get; set; }
    public string? Request { get; set; }
    public string? Response { get; set; }
    public string? Comments { get; set; }
    public t_request_workflow_instance_history(
        Guid InstanceId,
        Guid? NodeId,
        string Action,
        string? Decision = null,
        string? Request = null,
        string? Response = null,
        string? Comments = null,
        Guid? Id = null,
        DateTime? CreatedAt = null,
        Guid? CreatedById = null
    )
    {
        this.InstanceId = InstanceId;
        this.NodeId = NodeId;
        this.Action = Action;
        this.Decision = Decision;
        this.Request = Request;
        this.Response = Response;
        this.Comments = Comments;
        this.Id = Id ?? Guid.NewGuid();
        this.CreatedAt = CreatedAt ?? DateTime.UtcNow;
        this.CreatedById = CreatedById;
    }
}
