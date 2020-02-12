using System;

namespace PlazaProject
{
    class Program
    {
        static void Main(string[] args)
        {
            bool ez = false;
            bool az = true;
            if(ez != az)
            { throw new ArgumentException("plaza is closed sorry"); }
        }
    }
}
