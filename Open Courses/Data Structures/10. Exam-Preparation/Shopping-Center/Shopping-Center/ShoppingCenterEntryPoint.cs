namespace ShoppingCenter
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Threading;
    using Wintellect.PowerCollections;

    public class ShoppingCenterEntryPoint
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            var userInterface = new ConsoleInterface();
            var commandExecutor = new CommandExecutor(userInterface);
            var shoppingCenter = new ShoppingCenter();

            var engine = new ShoppingCenterEngine(shoppingCenter,userInterface,commandExecutor);
            engine.Run();
        }
    }

    public class ShoppingCenterEngine : IEngine
    {
        private readonly ShoppingCenter shoppingCenter;
        private readonly CommandExecutor commandExecutor;
        private readonly IUserInterface userInterface;

        public ShoppingCenterEngine(ShoppingCenter shoppingCenter, IUserInterface userInterface, CommandExecutor commandExecutor)
        {
            this.shoppingCenter = shoppingCenter;
            this.commandExecutor = commandExecutor;
            this.userInterface = userInterface;
        }

        public void Run()
        {
            var lines = int.Parse(Console.ReadLine());

            while (lines > 0)
            {
                var commandLine = Console.ReadLine();

                try
                {
                    var command = new Command(commandLine);
                    var result = this.commandExecutor.ExecuteCommand(command, this.shoppingCenter);
                    this.userInterface.WriteLine(result);
                }
                catch (Exception ex)
                {
                    this.userInterface.WriteLine(ex.Message);
                }

                lines--;
            }
        }
    }

    public class CommandExecutor
    {
        public CommandExecutor(IUserInterface userInterface)
        {
            this.UserInterface = userInterface;
        }

        public IUserInterface UserInterface { get; private set; }

        public string ExecuteCommand(ICommand command, ShoppingCenter data)
        {
            string result;
            switch (command.Name)
            {
                case Commands.AddProduct:
                    result = this.ProcessAddCommand(command.Parameters, data);
                    break;
                case Commands.DeleteProducts:
                    result = this.ProcessDeleteCommand(command.Parameters, data);
                    break;
                case Commands.FindProductsByName:
                    result = this.ProcessFindProductsByNameCommand(command.Parameters, data);
                    break;
                case Commands.FindProductsByProducer:
                    result = this.ProcessFindProductsByProducerCommand(command.Parameters, data);
                    break;
                case Commands.FindProductsByPriceRange:
                    result = this.ProcessFindProductsByPriceRangeCommand(command.Parameters, data);
                    break;
                default: throw new InvalidOperationException();
            }

            return result;
        }

        public string ProcessAddCommand(IList<string> parameters, ShoppingCenter data)
        {
            var name = parameters[0];
            var price = decimal.Parse(parameters[1]);
            var producer = parameters[2];
            return data.AddProduct(name, price, producer);
        }

        public string ProcessDeleteCommand(IList<string> parameters, ShoppingCenter data)
        {
            if (parameters.Count == 1)
            {
                return this.ProcessDeleteByProducerCommand(parameters, data);
            }

            return this.ProcessDeleteByNameAndProducerCommand(parameters, data);
        }

        public string ProcessDeleteByProducerCommand(IList<string> parameters, ShoppingCenter data)
        {
            return data.DeleteProductByProducer(parameters[0]);
        }

        public string ProcessDeleteByNameAndProducerCommand(IList<string> parameters, ShoppingCenter data)
        {
            return data.DeleteProductByNameAndProducer(parameters[0], parameters[1]);
        }

        public string ProcessFindProductsByNameCommand(IList<string> parameters, ShoppingCenter data)
        {
            var name = parameters[0];
            var result = data.FindProductsByName(name);

            return this.ProcessResult(result);
        }

        public string ProcessFindProductsByProducerCommand(IList<string> parameters, ShoppingCenter data)
        {
            var producer = parameters[0];
            var result = data.FindProductsByProducer(producer);

            return this.ProcessResult(result);
        }

        public string ProcessFindProductsByPriceRangeCommand(IList<string> parameters, ShoppingCenter data)
        {
            var fromPrice = decimal.Parse(parameters[0]);
            var toPrice = decimal.Parse(parameters[1]);
            var result = data.FindProductsByPriceRange(fromPrice, toPrice);

            return this.ProcessResult(result);
        }

        private string ProcessResult(IEnumerable<Product> result)
        {
            if (!result.Any())
            {
                return Messages.NoProductsFound;
            }

            var sorted = new List<Product>(result);
            sorted.Sort();

            return string.Join("\n", sorted);
        }
    }

    public class ShoppingCenter
    {
        private readonly OrderedDictionary<decimal, OrderedBag<Product>> productsByPrice = new OrderedDictionary<decimal, OrderedBag<Product>>();
        private readonly MultiDictionary<string, Product> productsByName = new MultiDictionary<string, Product>(true);
        private readonly MultiDictionary<string, Product> productsByNameAndProducer = new MultiDictionary<string, Product>(true);
        private readonly MultiDictionary<string, Product> productsByProducer = new MultiDictionary<string, Product>(true);

        public string AddProduct(string name, decimal price, string producer)
        {
            var product = new Product
            {
                Name = name,
                Price = price,
                Producer = producer
            };

            this.productsByPrice.AppendValueToKey(price, product);
            this.productsByProducer.Add(producer, product);
            this.productsByName.Add(name, product);
            this.productsByNameAndProducer.Add(this.CombineNameAndProducer(name, producer), product);

            return Messages.ProductAdded;
        }

        public string DeleteProductByProducer(string producer)
        {
            if (!this.productsByProducer.ContainsKey(producer))
            {
                return Messages.NoProductsFound;
            }

            var productsToDelete = this.productsByProducer[producer].ToList();
            var totalProducts = productsToDelete.Count;

            foreach (var product in productsToDelete)
            {
                this.productsByProducer[product.Producer].Remove(product);
                this.productsByName[product.Name].Remove(product);
                this.productsByPrice[product.Price].Remove(product);
                this.productsByNameAndProducer[this.CombineNameAndProducer(product.Name, product.Producer)].Remove(product);
            }

            return string.Format(Messages.ProductsDeleted, totalProducts);
        }

        public string DeleteProductByNameAndProducer(string name, string producer)
        {
            var combinedKey = this.CombineNameAndProducer(name, producer);
            var productsToDelete = this.productsByNameAndProducer[combinedKey].ToList();
            var totalProducts = productsToDelete.Count;

            if (!productsToDelete.Any())
            {
                return Messages.NoProductsFound;
            }

            foreach (var product in productsToDelete)
            {
                this.productsByProducer[product.Producer].Remove(product);
                this.productsByName[product.Name].Remove(product);
                this.productsByPrice[product.Price].Remove(product);
                this.productsByNameAndProducer[combinedKey].Remove(product);
            }

            return string.Format(Messages.ProductsDeleted, totalProducts);
        }

        public IEnumerable<Product> FindProductsByName(string name)
        {
            return this.productsByName[name].ToList();
        }

        public IEnumerable<Product> FindProductsByProducer(string producer)
        {
            return this.productsByProducer[producer].ToList();
        }

        public IEnumerable<Product> FindProductsByPriceRange(decimal fromPrice, decimal toPrice)
        {
            return this.productsByPrice.Range(fromPrice, true, toPrice, true)
                .SelectMany(p => p.Value).ToList();
        }

        private string CombineNameAndProducer(string name, string producer)
        {
            return name + "_" + producer;
        }
    }

    public class Product : IComparable<Product>
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Producer { get; set; }

        public int CompareTo(Product other)
        {
            int resultOfCompare = this.Name.CompareTo(other.Name);
            if (resultOfCompare == 0)
            {
                resultOfCompare = this.Producer.CompareTo(other.Producer);
            }
            if (resultOfCompare == 0)
            {
                resultOfCompare = this.Price.CompareTo(other.Price);
            }
            return resultOfCompare;
        }

        public override string ToString()
        {
            var result = string.Format("{0}{1};{2};{3:0.00}{4}", "{",this.Name, this.Producer, this.Price, "}");
            return result;
        }
    }

    public class Command : ICommand
    {
        public Command(string commandLine)
        {
            this.ParseCommand(commandLine);
        }
        
        public Commands Name { get; private set; }

        public IList<string> Parameters { get; private set; }

        private void ParseCommand(string commandLine)
        {
            var separatorIndex = commandLine.IndexOf(' ');
            var commandString = commandLine.Substring(0, separatorIndex);
            this.Name = (Commands)Enum.Parse(typeof(Commands), commandString, true);
            var commandParts = commandLine.Substring(separatorIndex + 1, commandLine.Length -1 - separatorIndex);
            var commandParameters = this.ParseCommandParameters(commandParts);
            this.Parameters = commandParameters;
        }

        private IList<string> ParseCommandParameters(string commandParameters)
        {
            var parameters = commandParameters.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            return parameters;
        }
    }

    public class ConsoleInterface : IUserInterface
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public void WriteLine(string format, params string[] args)
        {
            Console.WriteLine(format);
        }
    }

    public enum Commands
    {
        AddProduct,
        DeleteProducts,
        FindProductsByName,
        FindProductsByProducer,
        FindProductsByPriceRange
    }

    public interface IEngine
    {
        void Run();
    }

    public interface IUserInterface
    {
        string ReadLine();

        void WriteLine(string format, params string[] args);
    }

    public interface ICommand
    {
        Commands Name { get; }

        IList<string> Parameters { get; }
    }

    public static class Messages
    {
        public const string ProductAdded = "Product added";
        public const string FoundProduct = "{{0};{1};{2}}";
        public const string NoProductsFound = "No products found";
        public const string ProductsDeleted = "{0} products deleted";
    }

    public static class DictionaryExtensions
    {
        /// <summary>
        /// Ensures the specified key exists in the dictionary.
        /// If the key does not exist, it is mapped to a new empty value.
        /// </summary>
        public static void EnsureKeyExists<TKey, TValue>(
            this IDictionary<TKey, TValue> dict, TKey key)
            where TValue : new()
        {
            if (!dict.ContainsKey(key))
            {
                dict.Add(key, new TValue());
            }
        }

        /// <summary>
        /// Appends a new value to the collection of values mapped to the specified
        /// dictionary key. If the collection does not exists for the specified key,
        /// a new empty collection is first created and mapped to this key.
        /// </summary>
        /// <param name="key">The key that holds a collection of values</param>
        /// <param name="value">The value to be added to the collection for this key</param>
        public static void AppendValueToKey<TKey, TCollection, TValue>(
            this IDictionary<TKey, TCollection> dict, TKey key, TValue value)
            where TCollection : ICollection<TValue>, new()
        {
            TCollection collection;
            if (!dict.TryGetValue(key, out collection))
            {
                collection = new TCollection();
                dict.Add(key, collection);
            }
            collection.Add(value);
        }

        /// <summary>
        /// Get a sequence of values assigned to the specified dictionary key.
        /// If the key is missng, an empty sequence is returned.
        /// </summary>
        public static IEnumerable<TValue> GetValuesForKey<TKey, TValue>(
            this IDictionary<TKey, SortedSet<TValue>> dict, TKey key)
        {
            SortedSet<TValue> collection;
            if (dict.TryGetValue(key, out collection))
            {
                return collection;
            }
            return Enumerable.Empty<TValue>();
        }
    }
}