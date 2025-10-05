public class SmartEnum
{

    private readonly string _name;
    private readonly int _value;


    protected SmartEnum(string name, int value)
    {
        _name = name;
        _value = value;
    }

    public int GetValue() => _value;

    public override string ToString() => _name;

}