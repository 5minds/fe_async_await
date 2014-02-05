namespace APM
{
    using System;
    using System.Net;

    class Program
    {
        static void Main(string[] args)
        {
            var program = new Program();
            program.LookupHostName();

            Console.WriteLine("Waiting for response...{0}", Environment.NewLine);
            Console.ReadKey();
        }

        private void LookupHostName()
        {
            var context = string.Format("Request started at: {0}", DateTime.Now.ToString("O"));
            Dns.BeginGetHostAddresses("google.com", this.OnHostNameResolved, context);
        }

        private void OnHostNameResolved(IAsyncResult result)
        {
            var context = result.AsyncState;

            Console.WriteLine(context);
            Console.WriteLine("Request finished at {0}", DateTime.Now.ToString("O"));

            var addresses = Dns.EndGetHostAddresses(result);

            Console.WriteLine("{0}IP-Adresses for google.com:", Environment.NewLine);

            foreach (var address in addresses)
            {
                Console.WriteLine(address);
            }
        }
    }
}
