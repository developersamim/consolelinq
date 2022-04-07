using System;
using Xunit;

namespace consolelinq.test;

public class UnitTest1
{
    private readonly Flatten flatten;
    public UnitTest1()
    {
        flatten = new Flatten(Console.ReadLine, Console.WriteLine);
    }

    [Fact]
    public void ListAllPageComponentTest()
    {
        flatten.flattenType["listAllPageComponent"]();
    }

    [Fact]
    public void ListDistinctExtensionTest()
    {
        flatten.flattenType["listDistinctExtension"]();
    }

    [Fact]
    public void ListIndexWithComponentNameTest()
    {
        flatten.flattenType["listIndexWithComponentName"]();
    }
}