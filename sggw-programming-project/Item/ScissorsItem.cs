using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sggw_programming_project.Item
{
    internal class ScissorsItem:BaseItem
    {
        public override string Icon { get; set; } = "\u2702\ufe0f";
        public override int Damage { get; set; } = 10;
    }
}
