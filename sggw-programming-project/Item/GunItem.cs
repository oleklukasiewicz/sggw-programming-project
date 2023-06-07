using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sggw_programming_project.Item
{
    internal class GunItem:BaseItem
    {
        public override string Icon { get; set; } = "\ud83d\udd2b";
        public override int Damage { get; set; } = 50;
        
    }
}
