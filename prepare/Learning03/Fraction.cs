using System;
public class Fraction
{
    private int _top;
    private int _bottom;

    public Fraction()
    {
        _top = 1;
        _bottom = 1;
    }
    public Fraction(int top)
    {
        _top = top;
        _bottom = 1;
    }
    public Fraction(int top, int bottom)
    {
        _top = top;
        _bottom = bottom;
    }
    //Getter for _top
    public int GetTop()
    {
        return _top;
    }
    //Setter for _top
    public void SetTop(int top)
    {
        _top = top;
    }
    //Get for _bottom
    public int GetBottom()
    {
        return _bottom;
    }
    //Setter for _bottom
    public void SetBottom(int bottom)
    {
        _bottom = bottom;
    }
    //show fraction in string format
    public string GetFractionString()
    {
        return$"{_top}/{_bottom}";
    }
    //show decimal format
    public double GetDecimalValue()
    {
        return (double)_top/(double)_bottom;
    }
}