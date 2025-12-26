using System;
using FlowApprove.Repository.Common;

namespace FlowApprove.Repository.Entity;

public class t_workflow : AuditableEntity
{
    public required string Type { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }

    public t_workflow(
        string Type,
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
        if (string.IsNullOrWhiteSpace(Type))
            throw new ArgumentException("Type cannot be null or whitespace.", nameof(Type));

        if (string.IsNullOrWhiteSpace(Name))
            throw new ArgumentException("Name cannot be null or whitespace.", nameof(Name));

        this.Type = Type;
        this.Name = Name;
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
