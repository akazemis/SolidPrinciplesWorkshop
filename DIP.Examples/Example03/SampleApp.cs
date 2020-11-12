using DIP.Examples.Example02;
using LightInject;

namespace DIP.Examples.Example03
{
    public class SampleApp
    {
        public static void Run()
        {
            // Setup the container
            var container = new ServiceContainer();
            container.Register<IFileSystem, FileSystem>();
            container.Register<ISerializer<Item>, JsonSerializer<Item>>();

            if (Environment.IsTestEnvironment)
                container.Register<IItemRepository, InMemoryRepository>();
            else
                container.Register<IItemRepository, ItemRepository>();


            // Create the item repository itself
            var repository = container.GetInstance<IItemRepository>();
            
            // TODO: Do something with the repository here
        }
    }
}