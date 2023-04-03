using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGpt.Shared.Base
{
    public abstract class AggregateRoot : Entity, IHasCreationCreator, IHasDeleteCreator, IHasModificationCreator, IHasSoftDelete
    {
        public Guid? DeleteCreatorId { get; protected set; }
        public DateTime? DeleteTime { get; protected set; }
        public bool IsDeleted { get; protected set; }
        public Guid? CreatorId { get; protected set; }
        public DateTime CreationTime { get; protected set; }
        public DateTime? ModificationTime { get; protected set; }
        public Guid? ModifierId { get; protected set; }

        protected AggregateRoot()
        {
            Id = Guid.NewGuid();
            ModificationTime = DateTime.Now;
            CreationTime = DateTime.Now;
            ModifierId = CreatorId;
            IsDeleted = false;
        }
        protected AggregateRoot(Guid CreatorId)
        {
            Id = Guid.NewGuid();
            ModificationTime = DateTime.Now;
            CreationTime = DateTime.Now;
            this.CreatorId = CreatorId;
            ModifierId = CreatorId;
            IsDeleted = false;
        }
    }
}
