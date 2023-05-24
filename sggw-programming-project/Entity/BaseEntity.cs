using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sggw_programming_project.Entity
{
    internal class BaseEntity : IBaseEntity
    {
        //podstawowy obiekt (przeciwnik/ zwierze/ gracz)
        public int Id { get => _id; }
        private int _id;
        public string Name { get=>_name; }
        private string _name;

        // gdy obiekt ma byc niesniszcalny (wejście, wyjsćie z planszy itp)
        public bool IsImmune { get=>_isImmune; }
        private bool _isImmune;
        public int Health { get => _health; }
        private int _health { get; set; }

        public bool IsAlive { get => _isAlive; }
        private bool _isAlive = true;

        //ile obrazeń zadaje (np. potwór -> 3)
        public int Damage { get; set; }

        //string do wyświetlania bloku (np. dla drzewa może być 
        // // \\/n  |  /n  |  
        // czyli
        // 
        //    // \\
        //      |
        //      |
        public int TakeDamage(int damage)
        {
            if (!IsImmune)
                _health -= damage;
            if (_health < 0)
            {
                _health = 0;
                _isAlive = false;
            }
            return _health;
        }

    }
}
