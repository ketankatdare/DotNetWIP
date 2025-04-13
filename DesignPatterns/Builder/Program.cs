// See https://aka.ms/new-console-template for more information
using DesignPatterns.Builder;

Console.WriteLine("Hello, World!");

var director = new Director();
var builder = new ConcreteBuilder();

director.Construct(builder);
var product = builder.GetResult();
product.Show();
