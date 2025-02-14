namespace TextAdventure
{
    public interface ICharacter
    {
        string Name { get; set; }
        int Health { get; set; }
        int Damage { get; set; }

        /// <summary>
        /// Yuh
        /// </summary>
        /// <param name="enemy">The enemy being interacted with</param>
        public void Fight(ICharacter enemy);
    }
}