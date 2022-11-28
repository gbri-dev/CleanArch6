using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.Entities
{
    public abstract class EntityBase
    {
        public int Id { get; protected set; }
        //DateTime CreatedDate { get; set; }
        //DateTime? ModifiedDate { get; set; }
        //string CreatedBy { get;  set; }
        //string ModifiedBy { get; set; }

        //value object e agregation
    }
}
