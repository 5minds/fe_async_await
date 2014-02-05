namespace TAP
{
    using System;
    using System.Net;

    class Program
    {
        static void Main(string[] args)
        {
            var program = new Program();
            program.DumpWebPageAsync();

            Console.WriteLine("Waiting for response...{0}", Environment.NewLine);
            Console.ReadKey();
        }

        private async void DumpWebPageAsync()
        {
            var client = new WebClient();

            Console.WriteLine("Request started at: {0}", DateTime.Now.ToString("O"));
            
            var result = await client.DownloadStringTaskAsync(new Uri("http://www.mindassist.net/todo/hello"));
            
            Console.WriteLine("Request finished at {0}", DateTime.Now.ToString("O"));
            Console.WriteLine("{0}Web-Content from mindassist: {1}", Environment.NewLine, result);
        }
    }
}
