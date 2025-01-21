public class Reference
{
    public string Text { get; private set; }

    public Reference(string text)
    {
        Text = text;
    }

    public override string ToString()
    {
        return Text;
    }
}
