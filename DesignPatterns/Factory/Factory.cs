namespace DesignPatterns.Factory
{
    // Product interface
    public interface IProduct
    {
        void Operation();
    }

    // Concrete Product
    public class ConcreteProduct : IProduct
    {
        public void Operation()
        {
            Console.WriteLine("ConcreteProduct operation executed.");
        }
    }

    // Additional Concrete Product A
    public class ConcreteProductA : IProduct
    {
        public void Operation()
        {
            Console.WriteLine("ConcreteProductA operation executed.");
        }
    }

    // Additional Concrete Product B
    public class ConcreteProductB : IProduct
    {
        public void Operation()
        {
            Console.WriteLine("ConcreteProductB operation executed.");
        }
    }

    // Factory interface
    public interface IFactory
    {
        IProduct CreateProduct(string productType);
    }

    // Updated Factory
    public class ConcreteFactory : IFactory
    {
        public IProduct CreateProduct(string productType)
        {
            return productType switch
            {
                "A" => new ConcreteProductA(),
                "B" => new ConcreteProductB(),
                _ => new ConcreteProduct()
            };
        }
    }
}
