using System;
using FlowApprove.Repository.Entity;
using Microsoft.EntityFrameworkCore;

namespace FlowApprove.Repository.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
    }

    public DbSet<m_request> m_request { get; set; }
    public DbSet<m_request_property> m_request_property { get; set; }
    public DbSet<t_request_workflow_instance> t_request_workflow_instance { get; set; }
    public DbSet<t_request_workflow_instance_history> t_request_workflow_instance_history { get; set; }
    public DbSet<t_request_workflow_instance_node> t_request_workflow_instance_node { get; set; }
    public DbSet<t_request_workflow_instance_node_approval> t_request_workflow_instance_node_approval { get; set; }
    public DbSet<t_workflow> t_workflow { get; set; }
    public DbSet<t_workflow_node> t_workflow_node { get; set; }
    public DbSet<t_workflow_node_assignment> t_workflow_node_assignment { get; set; }
    public DbSet<t_workflow_node_task> t_workflow_node_task { get; set; }
    public DbSet<t_workflow_transition> t_workflow_transition { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<m_request>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedById).HasColumnName("created_by");
            entity.Property(e => e.CreatedAt).HasColumnName("created_at");
            entity.Property(e => e.UpdatedById).HasColumnName("updated_by");
            entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.InactiveAt).HasColumnName("inactive_at");
            entity.Property(e => e.InactiveById).HasColumnName("inactive_by");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
            entity.Property(e => e.DeletedById).HasColumnName("deleted_by");

            entity.Property(e => e.WorkflowId).HasColumnName("workflow_id");
            entity.Property(e => e.Name).HasColumnName("name").IsRequired();
            entity.Property(e => e.Description).HasColumnName("description");
        });

        modelBuilder.Entity<m_request_property>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedById).HasColumnName("created_by");
            entity.Property(e => e.CreatedAt).HasColumnName("created_at");
            entity.Property(e => e.UpdatedById).HasColumnName("updated_by");
            entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.InactiveAt).HasColumnName("inactive_at");
            entity.Property(e => e.InactiveById).HasColumnName("inactive_by");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
            entity.Property(e => e.DeletedById).HasColumnName("deleted_by");

            entity.Property(e => e.RequestId).HasColumnName("request_id");
            entity.Property(e => e.Key).HasColumnName("key").IsRequired();
            entity.Property(e => e.Title).HasColumnName("title").IsRequired();
            entity.Property(e => e.Type).HasColumnName("type").IsRequired();
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.IsRequired).HasColumnName("is_required");
        });

        modelBuilder.Entity<t_request_workflow_instance>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedById).HasColumnName("created_by");
            entity.Property(e => e.CreatedAt).HasColumnName("created_at");
            entity.Property(e => e.UpdatedById).HasColumnName("updated_by");
            entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.InactiveAt).HasColumnName("inactive_at");
            entity.Property(e => e.InactiveById).HasColumnName("inactive_by");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
            entity.Property(e => e.DeletedById).HasColumnName("deleted_by");

            entity.Property(e => e.RequestId).HasColumnName("request_id");
            entity.Property(e => e.WorkflowId).HasColumnName("workflow_id");
            entity.Property(e => e.CurrentNodeId).HasColumnName("current_node_id");
            entity.Property(e => e.Status).HasColumnName("status").IsRequired();
        });

        modelBuilder.Entity<t_request_workflow_instance_history>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedById).HasColumnName("created_by");
            entity.Property(e => e.CreatedAt).HasColumnName("created_at");
            entity.Property(e => e.UpdatedById).HasColumnName("updated_by");
            entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.InactiveAt).HasColumnName("inactive_at");
            entity.Property(e => e.InactiveById).HasColumnName("inactive_by");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
            entity.Property(e => e.DeletedById).HasColumnName("deleted_by");

            entity.Property(e => e.InstanceId).HasColumnName("instance_id");
            entity.Property(e => e.NodeId).HasColumnName("node_id");
            entity.Property(e => e.Action).HasColumnName("action").IsRequired();
            entity.Property(e => e.Decision).HasColumnName("decision");
            entity.Property(e => e.Request).HasColumnName("request");
            entity.Property(e => e.Response).HasColumnName("response");
            entity.Property(e => e.Comments).HasColumnName("comments");
        });

        modelBuilder.Entity<t_request_workflow_instance_node>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedById).HasColumnName("created_by");
            entity.Property(e => e.CreatedAt).HasColumnName("created_at");
            entity.Property(e => e.UpdatedById).HasColumnName("updated_by");
            entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.InactiveAt).HasColumnName("inactive_at");
            entity.Property(e => e.InactiveById).HasColumnName("inactive_by");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
            entity.Property(e => e.DeletedById).HasColumnName("deleted_by");

            entity.Property(e => e.InstanceId).HasColumnName("instance_id");
            entity.Property(e => e.NodeId).HasColumnName("node_id");
            entity.Property(e => e.Status).HasColumnName("status").IsRequired();
            entity.Property(e => e.StartedAt).HasColumnName("started_at");
            entity.Property(e => e.CompletedAt).HasColumnName("completed_at");
        });

        modelBuilder.Entity<t_request_workflow_instance_node_approval>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedById).HasColumnName("created_by");
            entity.Property(e => e.CreatedAt).HasColumnName("created_at");
            entity.Property(e => e.UpdatedById).HasColumnName("updated_by");
            entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.InactiveAt).HasColumnName("inactive_at");
            entity.Property(e => e.InactiveById).HasColumnName("inactive_by");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
            entity.Property(e => e.DeletedById).HasColumnName("deleted_by");

            entity.Property(e => e.InstanceNodeId).HasColumnName("instance_node_id");
            entity.Property(e => e.AssigneeType).HasColumnName("assignee_type").IsRequired();
            entity.Property(e => e.AssigneeName).HasColumnName("assignee_name").IsRequired();
            entity.Property(e => e.AssigneeContact).HasColumnName("assignee_contact").IsRequired();
            entity.Property(e => e.Decision).HasColumnName("decision");
            entity.Property(e => e.DecisionAt).HasColumnName("decision_at");
            entity.Property(e => e.Comments).HasColumnName("comments");
        });

        modelBuilder.Entity<t_workflow>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedById).HasColumnName("created_by");
            entity.Property(e => e.CreatedAt).HasColumnName("created_at");
            entity.Property(e => e.UpdatedById).HasColumnName("updated_by");
            entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.InactiveAt).HasColumnName("inactive_at");
            entity.Property(e => e.InactiveById).HasColumnName("inactive_by");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
            entity.Property(e => e.DeletedById).HasColumnName("deleted_by");

            entity.Property(e => e.Type).HasColumnName("type").IsRequired();
            entity.Property(e => e.Name).HasColumnName("name").IsRequired();
            entity.Property(e => e.Description).HasColumnName("description");
        });

        modelBuilder.Entity<t_workflow_node>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedById).HasColumnName("created_by");
            entity.Property(e => e.CreatedAt).HasColumnName("created_at");
            entity.Property(e => e.UpdatedById).HasColumnName("updated_by");
            entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.InactiveAt).HasColumnName("inactive_at");
            entity.Property(e => e.InactiveById).HasColumnName("inactive_by");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
            entity.Property(e => e.DeletedById).HasColumnName("deleted_by");

            entity.Property(e => e.WorkflowId).HasColumnName("workflow_id");
            entity.Property(e => e.Type).HasColumnName("type").IsRequired();
            entity.Property(e => e.Sequence).HasColumnName("sequence");
            entity.Property(e => e.Name).HasColumnName("name").IsRequired();
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.ApproverSource).HasColumnName("approver_source").IsRequired();
            entity.Property(e => e.ApprovalPolicy).HasColumnName("approval_policy").IsRequired();
        });

        modelBuilder.Entity<t_workflow_node_assignment>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedById).HasColumnName("created_by");
            entity.Property(e => e.CreatedAt).HasColumnName("created_at");
            entity.Property(e => e.UpdatedById).HasColumnName("updated_by");
            entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.InactiveAt).HasColumnName("inactive_at");
            entity.Property(e => e.InactiveById).HasColumnName("inactive_by");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
            entity.Property(e => e.DeletedById).HasColumnName("deleted_by");

            entity.Property(e => e.NodeId).HasColumnName("node_id");
            entity.Property(e => e.AssigneeType).HasColumnName("assignee_type").IsRequired();
            entity.Property(e => e.AssigneeName).HasColumnName("assignee_name").IsRequired();
            entity.Property(e => e.AssigneeContact).HasColumnName("assignee_contact").IsRequired();
        });

        modelBuilder.Entity<t_workflow_node_task>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedById).HasColumnName("created_by");
            entity.Property(e => e.CreatedAt).HasColumnName("created_at");
            entity.Property(e => e.UpdatedById).HasColumnName("updated_by");
            entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.InactiveAt).HasColumnName("inactive_at");
            entity.Property(e => e.InactiveById).HasColumnName("inactive_by");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
            entity.Property(e => e.DeletedById).HasColumnName("deleted_by");

            entity.Property(e => e.NodeId).HasColumnName("node_id");
            entity.Property(e => e.RequestMethod).HasColumnName("request_method").IsRequired();
            entity.Property(e => e.RequestUrl).HasColumnName("request_url").IsRequired();
            entity.Property(e => e.RequestHeaders).HasColumnName("request_headers");
            entity.Property(e => e.RequestPayload).HasColumnName("request_payload");
        });

        modelBuilder.Entity<t_workflow_transition>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedById).HasColumnName("created_by");
            entity.Property(e => e.CreatedAt).HasColumnName("created_at");
            entity.Property(e => e.UpdatedById).HasColumnName("updated_by");
            entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.InactiveAt).HasColumnName("inactive_at");
            entity.Property(e => e.InactiveById).HasColumnName("inactive_by");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
            entity.Property(e => e.DeletedById).HasColumnName("deleted_by");

            entity.Property(e => e.WorkflowId).HasColumnName("workflow_id");
            entity.Property(e => e.FromNodeId).HasColumnName("from_node_id");
            entity.Property(e => e.ToNodeId).HasColumnName("to_node_id");
            entity.Property(e => e.Name).HasColumnName("name").IsRequired();
            entity.Property(e => e.Condition).HasColumnName("condition");
            entity.Property(e => e.Description).HasColumnName("description");
        });
    }
}
