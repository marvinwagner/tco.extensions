using TCO.Extensions;
using TCO.Extensions.Attributes;

namespace TCO.UnitTests;

public class PriorityTest : TCOBase
{
    [Fact]
    public void PriorityOrderer_ShouldRunFirst()
    {
        PrioritySingleton.Instance.ExecuteIteration(0);
    }

    [Fact, Priority(1)]
    public void PriorityOrderer_ShouldRunAfter0()
    {
        PrioritySingleton.Instance.ExecuteIteration(1);
    }

    [Fact, Priority(2), Repeat(2)]
    public void PriorityOrderer_ShouldRunAfter1()
    {
        PrioritySingleton.Instance.ExecuteIteration(2);
    }

    [Fact, Priority(3)]
    public void PriorityOrderer_ShouldRunAfter2()
    {
        PrioritySingleton.Instance.ExecuteIteration(3);

        Assert.Equal("0,1,2,2,3", PrioritySingleton.Instance.GetPriorityOrder());
    }
}


public sealed class PrioritySingleton
{
    private static PrioritySingleton instance = null;
    private static readonly object padlock = new object();

    private readonly List<int> _iterationList;

    PrioritySingleton()
    {
        _iterationList = new List<int>();
    }

    public void ExecuteIteration(int priority)
    {
        _iterationList.Add(priority);
    }

    public string GetPriorityOrder() => string.Join(',', _iterationList);

    public static PrioritySingleton Instance
    {
        get
        {
            lock (padlock)
            {
                if (instance == null)
                {
                    instance = new PrioritySingleton();
                }
                return instance;
            }
        }
    }
}