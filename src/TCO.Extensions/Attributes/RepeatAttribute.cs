namespace TCO.Extensions.Attributes;

public class RepeatAttribute : Attribute
{
    public int Count { get; init; }
    public RepeatAttribute(int count)
    {
        Count = count;
    }
}