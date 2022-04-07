// See https://aka.ms/new-console-template for more information
using consolelinq;

Console.WriteLine("Hello, World!");
var flatten = new Flatten(Console.ReadLine, Console.WriteLine);

//flatten.flattenType["listAllPageComponent"]();
//flatten.flattenType["listDistinctExtension"]();
//flatten.flattenType["listIndexWithComponentName"]();
//flatten.flattenType["listPageNameWithComponentName"]();
//flatten.flattenType["listPageNameWithComponentNameAnotherWay"]();
flatten.flattenType["listPageNameWithIndexAndComponentName"]();
