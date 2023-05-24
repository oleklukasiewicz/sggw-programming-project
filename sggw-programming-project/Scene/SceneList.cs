using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sggw_programming_project.Scene
{
    internal class SceneList
    {
        // id listy scen (readonly)(tak na wszelki wypadek)
        public string Id { get => _id; }

        private string _id;

        public List<BaseScene> Scenes { get; set; }
    }
}
