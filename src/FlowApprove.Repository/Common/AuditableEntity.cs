using System;

namespace FlowApprove.Repository.Common;

public class AuditableEntity : BaseEntity
{
    /// <summary>
    /// Indicates whether the entity is currently active.
    /// </summary>
    public bool IsActive { get; set; }

    /// <summary>
    /// The date and time when the entity was deactivated, if applicable.
    /// </summary>
    public DateTime? InactiveAt { get; set; }

    /// <summary>
    /// The identifier of the user who deactivated the entity, if applicable.
    /// </summary>
    public Guid? InactiveById { get; set; }

    /// <summary>
    /// Indicates whether the entity has been marked as deleted.
    /// </summary>
    public bool IsDeleted { get; set; }

    /// <summary>
    /// The identifier of the user who deleted the entity, if applicable.
    /// </summary>
    public Guid? DeletedById { get; set; }

    /// <summary>
    /// The date and time when the entity was deleted, if applicable.
    /// </summary>
    public DateTime? DeletedAt { get; set; }

    /// <summary>
    /// The identifier of the user who created the entity.
    /// </summary>
    public Guid? CreatedById { get; set; }

    /// <summary>
    /// The date and time when the entity was created.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// The identifier of the user who last updated the entity, if applicable.
    /// </summary>
    public Guid? UpdatedById { get; set; }

    /// <summary>
    /// The date and time when the entity was last updated, if applicable.
    /// </summary>
    public DateTime? UpdatedAt { get; set; }
}
