using System;

namespace IT.Valor.Core.Interfaces.Entities
{
    public interface IModifiedEntity : IDbEntity
    {
        public DateTime ModifiedOn { get; set; }
    }
}
