using System;
public class Reference
{
    private string _book;
    private int _charpter;
    private int _verse;
    private int _endVerse;

    public Reference(string book, int charpter, int verse)
    {
        _book = book;
        _charpter = charpter;
        _verse = verse;
        _endVerse = verse;
    }

    public Reference(string book, int charpter, int startVerse, int endVerse)
    {
        _book = book;
        _charpter = charpter;
        _verse = startVerse;
        _endVerse = endVerse;
    }
    public string GetDisplayText()
    {
        if(_verse == _endVerse)
        {
            return $"{_book} {_charpter}:{_verse}";
        }
        else
        {
            return $"{_book} {_charpter}:{_verse}-{_endVerse}";
        }
    }
}