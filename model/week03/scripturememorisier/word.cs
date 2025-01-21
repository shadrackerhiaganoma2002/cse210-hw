public class Word
{
    public string Original { get; private set; }
    public bool IsHidden { get; private set; }

    public Word(string original)
    {
        Original = original;
        IsHidden = false;
    }

    public string Display()
    {
        return IsHidden ? new string('_', Original.Length) : Original;
    }

    public void Hide()
    {
        IsHidden = true;
    }
}
