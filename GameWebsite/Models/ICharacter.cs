namespace GameWebsite.Models
{
    public interface ICharacter
    {
        string Name { get; set; }
        int Health { get; set; }
        int Damage { get; set; }
        string Id { get; set; }
    }
}
