using System;

namespace PetVet.Domain.Common
{
    public class AuditableEntity : Entity
    {
        public AuditableEntity()
        {
            CreatedBy = Guid.Empty;
        }

        public Guid CreatedBy { get; set; }

        public DateTime Created { get; set; }

        public Guid? LastModifiedBy { get; set; }

        public DateTime? LastModified { get; set; }
    }
}