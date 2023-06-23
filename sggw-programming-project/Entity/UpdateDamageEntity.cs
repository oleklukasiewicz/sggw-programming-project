using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sggw_programming_project.Entity
{
    internal class UpdateDamageEntity : BaseEntity
    {
        public UpdateDamageEntity(int upt =10):base()
        {
            UpdateDamage = upt;
            IsItem = true;
        }
    }
}
