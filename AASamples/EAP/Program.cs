namespace EAP
{
    using System;
    using System.Net;

    class Program
    {
        static void Main(string[] args)
        {
            var program = new Program();
            program.DumpWebPage();

            Console.WriteLine("Waiting for response...{0}", Environment.NewLine);
            Console.ReadKey();
        }

        private void DumpWebPage()
        {
            var client = new WebClient();
            client.DownloadStringCompleted += this.OnDumpWebPageCompleted;

            Console.WriteLine("Request started at: {0}", DateTime.Now.ToString("O"));
            client.DownloadStringAsync(new Uri("http://www.mindassist.net/todo/hello"));
        }

        private void OnDumpWebPageCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            Console.WriteLine("Request finished at {0}", DateTime.Now.ToString("O"));
            Console.WriteLine("{0}Web-Content from mindassist: {1}", Environment.NewLine, e.Result);
        }
    }
}
