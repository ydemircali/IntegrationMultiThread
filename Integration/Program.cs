using Integration.Service;

namespace Integration {
    public class Program
    {
        public static void Main(string[] args)
        {
            ItemIntegrationService service = new ItemIntegrationService();

            var t0 = Task.Run(async () => { await service.SaveItem("a"); });
            var t1 = Task.Run(async () => { await service.SaveItem("b"); });
            var t2 = Task.Run(async () => { await service.SaveItem("c"); });
            var t3 = Task.Run(async () => { await service.SaveItem("a"); });
            var t4 = Task.Run(async () => { await service.SaveItem("b"); });
            var t5 = Task.Run(async () => { await service.SaveItem("c"); });
            Task.WaitAll(t0, t1, t2, t3, t4, t5);

            Console.WriteLine("Everything recorded:");

            service.GetAllItems().ForEach(x => Console.WriteLine(x));

            Console.ReadLine();
        }


    }
}
