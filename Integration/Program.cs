using Integration.Service;

namespace Integration {
    public class Program
    {
        public static void Main(string[] args)
        {
            ItemIntegrationService service = new ItemIntegrationService();


            ThreadPool.QueueUserWorkItem((x) => service.SaveItem("a"));
            ThreadPool.QueueUserWorkItem((x) => service.SaveItem("b"));
            ThreadPool.QueueUserWorkItem((x) => service.SaveItem("c"));

            Thread.Sleep(500);

            ThreadPool.QueueUserWorkItem((x) => service.SaveItem("a"));
            ThreadPool.QueueUserWorkItem((x) => service.SaveItem("b"));
            ThreadPool.QueueUserWorkItem((x) => service.SaveItem("c"));

            Thread.Sleep(5000);

            Console.WriteLine("Everything recorded:");

            service.GetAllItems().ForEach(x => Console.WriteLine(x));

            Console.ReadLine();
        }


    }
}
