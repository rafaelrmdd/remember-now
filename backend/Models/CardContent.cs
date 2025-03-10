namespace backend.Models;

public class CardContent
{
    public Guid Id { get; set; }
    public string FrontText { get; set; }
    public string BackText { get; set; }

    public CardContent(string frontText, string backText)
    {
        FrontText = frontText;
        BackText = backText;
    }

}