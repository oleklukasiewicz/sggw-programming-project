using sggw_programming_project.Entity;

namespace sggw_programming_project.Scene
{
    internal interface IBlock
    {
        IBaseEntity BlockEntity { get; }
        bool CanBeStepIn { get; set; }
        string Icon { get; }
        int X { get; }
        int Y { get; }
        void SetCoords(int x, int y);
         void SetRandomLocation();
    }
}