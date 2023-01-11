using TCO.Extensions;
using TCO.Extensions.Attributes;

namespace TCO.UnitTests;

public class RepeatTest : TCOBase
{
    [Fact, Repeat(3)]
    public void RepeatOrderer_ShouldRepeatXTimes()
    {
        RepeatedSingleton.Instance.ExecuteIteration();

        Assert.True(RepeatedSingleton.Instance.ExecutedAllIteration());
    }
}


public sealed class RepeatedSingleton
{
    private static RepeatedSingleton instance = null;
    private static readonly object padlock = new object();

    private int _count;
    private readonly List<int> _iterationList;

    RepeatedSingleton()
    {
        _count = 0;
        _iterationList = new List<int> { 1, 2, 3};
    }

    public void ExecuteIteration()
    {
        _count++;
        _iterationList.Remove(_count);
    }

    public bool ExecutedAllIteration() => _iterationList.Count + _count == 3;

    public static RepeatedSingleton Instance
    {
        get
        {
            lock (padlock)
            {
                if (instance == null)
                {
                    instance = new RepeatedSingleton();
                }
                return instance;
            }
        }
    }
}