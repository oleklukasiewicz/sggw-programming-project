using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sggw_programming_project.Entity
{
    delegate void DieHandler(object sender, EventArgs e);
    delegate void TakeDamageHandler(object sender, EventArgs e);
    delegate void StatsChangedHandler (object sender, EventArgs e);
    internal class BaseEntity
    {
        public int Id { get => _id; }
        private int _id;
        public string Name { get=>_name; }
        private string _name;

        public bool IsImmune { get; set; } = true;
        public int Health { get; set; } = 10;
        public bool IsAlive { get => _isAlive; }
        private bool _isAlive = true;

        public event StatsChangedHandler OnStatsChanged;
        public event DieHandler OnDie;
        public event TakeDamageHandler OnTakeDamage;

        private int _damage { get; set; } = 0;

        private bool _damageUpdated { get; set; } = false;
        public bool DamageUpdated { get=>_damageUpdated; }
        public int Damage
        {
            get => _damage;
            set
            {
                _damage = value;
            }
        }
        public int Healing { get; set; } = 0;
        public int UpdateDamage { get; set; } = 0;
        public bool IsItem { get; set; } = false;
        public int TakeDamage(int damage)
        {
            if (!IsImmune&&!IsItem)
                Health -= damage;

            OnTakeDamage?.Invoke(this, new EventArgs());

            if (Health <= 0)
            {
                Health = 0;
                _isAlive = false;
                OnDie?.Invoke(this, new EventArgs());  
            }else
            {
                OnStatsChanged?.Invoke(this, new EventArgs());
            }
            return Health;
        }

        public bool UpgradeDamage(int dmg)
        {
            Damage += dmg;
            _damageUpdated=true;

            return true;
        }
        public int Heal(int hp)
        {
            Health += hp;

            OnStatsChanged?.Invoke(this, new EventArgs());
            return Health;
        }
    }
}
