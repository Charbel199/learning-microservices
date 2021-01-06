using System;

namespace GithubService.Jobs
{
    public class PrintJob: IPrintJob
    {
        public void print()
        {
            Console.WriteLine("Hello");
        }
        
    }
}