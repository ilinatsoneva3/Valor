using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT.Valor.Core.Interfaces.Entities
{
    public interface BaseEntity
    {
        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }
    }
}
