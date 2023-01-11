# TCO Extensions

TCO Extensions is a package with additional features for testing. It was made just for studying purposes.

## Installation

Install with the dotnet command or search for `TCO.Extensions` in the NuGet list.

```bash
dotnet add package TCO.Extensions --version 1.0.0
```

## Configuration

```csharp
// make your test class extends from TCOBase
public class MyTestClass : TCOBase
{ ... }

// or just add the TestCaseOrderer attribute
[TestCaseOrderer("TCO.Extensions.Orderers.AllOrderer", "TCO.Extensions")]
public class MyTestClass
{ ... }
```

## Usage 

### Priority
Priority attribute: the lowest number indicates the tests that will run first. If not specified, it will be considered 0.
```csharp
[Fact, Priority(1)]
public void PriorityTest1() 
{ ... } // will run second

[Fact, Priority(2)]
public void PriorityTest2()
{ ... } // will run last

[Fact]
public void PriorityTest3()
{ ... } // will run first
```

### Repeat
Repeat attribute: the specific method will run X times as if it was a completely different test case.

```csharp
[Fact, Repeat(3)]
public void RepeatTest()
{ ... } // will run 3 times


[Fact, Priority(1), Repeat(2)]
public void CombinedTest() 
{ ... } // you can also combine the attributes and repeat the test in a priority order
```