using sggw_programming_project.Entity;
using System.Dynamic;

namespace sggw_programming_project.Scene
{
    internal interface IBlock
    {
        IBaseEntity BlockEntity { get; }
        bool CanBeStepIn { get; set; }
        string Icon { get; }
        int X { get; }
        int Y { get; }
        int Point { get; set; }
        void SetCoords(int x, int y);
        void SetRandomLocation();

        int Health { get; set; }
    }
}