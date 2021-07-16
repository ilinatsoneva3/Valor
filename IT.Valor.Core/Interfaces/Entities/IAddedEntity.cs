using System;

namespace IT.Valor.Core.Interfaces.Entities
{
    public interface IAddedEntity : IDbEntity
    {
        public DateTime AddedOn { get; set; }
    }
}
