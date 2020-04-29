using System;

namespace PatternStateTrafficLight
{
    class Program
    {
        static void Main(string[] args)
        {
            TrafficLight tl = new TrafficLight();
            Console.WriteLine(tl.CurrentLight);
            tl.Next();
            Console.WriteLine(tl.CurrentLight);
            tl.Next();
            Console.WriteLine(tl.CurrentLight);
            

            tl.Manual("G");
            Console.WriteLine(tl.CurrentLight);
            tl.Manual("Y");
            Console.WriteLine(tl.CurrentLight);
            
            tl.Next();
            Console.WriteLine(tl.CurrentLight);
            tl.Next();
            Console.WriteLine(tl.CurrentLight);

        }
    }
}
