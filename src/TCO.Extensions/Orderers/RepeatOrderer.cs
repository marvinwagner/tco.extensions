using TCO.Extensions.Attributes;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace TCO.Extensions.Orderers;

public class RepeatOrderer : ITestCaseOrderer
{

    //public IEnumerable<TTestCase> OrderTestCases<TTestCase>(IEnumerable<TTestCase> testCases) where TTestCase : ITestCase
    //{
    //    return testCases
    //        .Where(HasRepeatAttribute)
    //        .SelectMany(RepeatTestCase)
    //        .Concat(testCases.Where(testCase => !HasRepeatAttribute(testCase)))
    //        .ToList();
    //}

    //private bool HasRepeatAttribute<TTestCase>(TTestCase testCase) where TTestCase : ITestCase
    //{
    //    return testCase.TestMethod.Method.GetCustomAttributes(typeof(RepeatAttribute)).FirstOrDefault() != null;
    //}

    //private IEnumerable<TTestCase> RepeatTestCase<TTestCase>(TTestCase testCase) where TTestCase : ITestCase
    //{
    //    return Enumerable.Range(0, ((RepeatAttribute)testCase.TestMethod.Method.GetCustomAttributes(typeof(RepeatAttribute)).First()).Count).Select(_ => testCase);
    //}

    public IEnumerable<TTestCase> OrderTestCases<TTestCase>(IEnumerable<TTestCase> testCases) where TTestCase : ITestCase
    {
        List<TTestCase> result = new();
        testCases.ToList().ForEach(testCase =>
        {
            var repeat = (ReflectionAttributeInfo)testCase.TestMethod.Method.GetCustomAttributes(typeof(RepeatAttribute)).FirstOrDefault();
            if (repeat != null && repeat.Attribute is RepeatAttribute)
            {
                var attr = repeat.Attribute as RepeatAttribute;
                Enumerable.Range(0, attr.Count).ToList().ForEach((_) => { result.Add(testCase); });
            }
            else
            {
                result.Add(testCase);
            }
        });

        return result;
    }
}