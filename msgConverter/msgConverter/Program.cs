using System;

namespace msgConverter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Globals.Instance.StartUp().GetAwaiter().GetResult();
        }
    }
}
