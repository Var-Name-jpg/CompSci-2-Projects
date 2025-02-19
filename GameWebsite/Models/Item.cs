namespace GameWebsite.Models
{
    public abstract class Item
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Id { get; set; }

        public Item(string name, string description)
        {
            Id = name.Replace(" ", "_");
            Name = name;
            Description = description;
        }
    }
}
