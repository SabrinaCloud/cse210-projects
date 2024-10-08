public class Comment
{
    private string _commmenterName;
    private string _text;

    public Comment(string commenterName, string text)
    {
        _commmenterName = commenterName;
        _text = text;
    }
    public string GetCommenterName() => _commmenterName;
    public string GetText() => _text;
}