using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sggw_programming_project.Entity
{
    internal class BaseEntity : IBaseEntity
    {
        public int Id { get => _id; }
        private int _id;
        public string Name { get=>_name; }
        private string _name;

        public bool IsImmune { get=>_isImmune; }
        private bool _isImmune;
        public int Health { get => _health; }
        private int _health { get; set; }

        public bool IsAlive { get => _isAlive; }
        private bool _isAlive = true;

        public event EventHandler OnStatsChanged;
        public event EventHandler OnDie;
        public event EventHandler OnTakeDamage;

        public int Damage { get; set; }
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
