// See https://aka.ms/new-console-template for more information
using DesignPatterns.Singleton;

Console.WriteLine("Hello, World!");

var singleton1 = Singleton.Instance;
singleton1.DisplayMessage();

var singleton2 = Singleton.Instance;
Console.WriteLine(ReferenceEquals(singleton1, singleton2)); // Should print 'True'
