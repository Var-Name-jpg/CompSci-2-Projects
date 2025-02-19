﻿namespace GameWebsite.Models
{
    public class Weapon : Item
    {
        public int Damage { get; set; }

        public Weapon(string name, string description, int damage) : base(name, description)
        {
            Damage = damage;
        }
    }
}
