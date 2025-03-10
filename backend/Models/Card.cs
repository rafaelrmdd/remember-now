namespace backend.Models;


public class Card
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public Card(string name, string description)
    {
        Name = name;
        Description = description;
    }
}