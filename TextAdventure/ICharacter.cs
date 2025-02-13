namespace TextAdventure
{
    public interface ICharacter
    {
        string Name { get; set; }
        int Health { get; set; }
        int Damage { get; set; }

        /// <summary>
        /// This allows every character to fight eachother
        /// </summary>
        /// <param name="target">ICharacter that the current one is fighting</param>
        public void Fight(ICharacter enemy);

        public void TakeDamage(int damage);
    }
}