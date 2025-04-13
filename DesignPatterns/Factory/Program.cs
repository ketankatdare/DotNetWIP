// See https://aka.ms/new-console-template for more information
using DesignPatterns.Factory;

Console.WriteLine("Hello, World!");

IFactory factory = new ConcreteFactory();
IProduct product = factory.CreateProduct("DefaultType");
product.Operation();

var productA = factory.CreateProduct("A");
productA.Operation();

var productB = factory.CreateProduct("B");
productB.Operation();
