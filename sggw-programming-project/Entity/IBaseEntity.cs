namespace sggw_programming_project.Entity
{
    internal interface IBaseEntity
    {
        //podstawowy interface dla stworzeń (pola i metody które każde entit musi mieć)
        int Id { get; }
        string Name { get; }

        bool IsImmune { get; }
        int Damage { get; set; }
        int Health { get; }
        bool IsAlive { get; }

        int TakeDamage(int damage);
    }
}