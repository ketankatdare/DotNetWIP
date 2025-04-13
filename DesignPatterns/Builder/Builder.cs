namespace DesignPatterns.Builder
{
    // Product class
    public class Product
    {
        private readonly List<string> _parts = new();

        public void Add(string part)
        {
            _parts.Add(part);
        }

        public void Show()
        {
            Console.WriteLine("Product Parts:");
            foreach (var part in _parts)
            {
                Console.WriteLine(part);
            }
        }
    }

    // Builder interface
    public interface IBuilder
    {
        void BuildPartA();
        void BuildPartB();
        Product GetResult();
    }

    // Concrete Builder
    public class ConcreteBuilder : IBuilder
    {
        private readonly Product _product = new();

        public void BuildPartA()
        {
            _product.Add("PartA");
        }

        public void BuildPartB()
        {
            _product.Add("PartB");
        }

        public Product GetResult()
        {
            return _product;
        }
    }

    // Director class
    public class Director
    {
        public void Construct(IBuilder builder)
        {
            builder.BuildPartA();
            builder.BuildPartB();
        }
    }
}
