using Integration.Service;

namespace Integration {
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Time:"+ DateTime.Now.ToLongTimeString());
            ItemIntegrationService service = new ItemIntegrationService();


            var t0 = Task.Run(() => { service.SaveItem("a"); });
            var t1 = Task.Run(() => { service.SaveItem("b"); });
            var t2 = Task.Run(() => { service.SaveItem("c"); });
            var t3 = Task.Run(() => { service.SaveItem("a"); });
            var t4 = Task.Run(() => { service.SaveItem("b"); });
            var t5 = Task.Run(() => { service.SaveItem("c"); });
            Task.WaitAll(t0, t1, t2, t4, t5);

            //ThreadPool.QueueUserWorkItem((x) => service.SaveItem("a"));
            //ThreadPool.QueueUserWorkItem((x) => service.SaveItem("b"));
            //ThreadPool.QueueUserWorkItem((x) => service.SaveItem("c"));
            //ThreadPool.QueueUserWorkItem((x) => service.SaveItem("a"));
            //ThreadPool.QueueUserWorkItem((x) => service.SaveItem("b"));
            //ThreadPool.QueueUserWorkItem((x) => service.SaveItem("c"));

            //Thread.Sleep(10_00);

            Console.WriteLine("Everything recorded:");

            service.GetAllItems().ForEach(x => Console.WriteLine(x));

            Console.WriteLine("Time:" + DateTime.Now.ToLongTimeString());

            Console.ReadLine();
        }


    }
}
