using Xunit.Abstractions;
using Xunit.Sdk;

namespace TCO.Extensions.Orderers;

public class AllOrderer : ITestCaseOrderer
{
    public IEnumerable<TTestCase> OrderTestCases<TTestCase>(IEnumerable<TTestCase> testCases) where TTestCase : ITestCase
    {
        var repeated = new RepeatOrderer().OrderTestCases(testCases);
        return new PriorityOrderer().OrderTestCases(repeated);
    }
}
