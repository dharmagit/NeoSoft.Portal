using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NeoSoft.Portal.Service
{
    public class EntityBase
    {
        public long Id { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }

    }
}

