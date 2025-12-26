using System;

namespace FlowApprove.Repository.Common;

public class BaseEntity : IEntity
{
    /// <summary>
    /// Unique identifier for the entity.
    /// </summary>
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>
    /// Unique code for the entity.
    /// </summary>
    public string Code { get; set; } = default!;
}
