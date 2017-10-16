using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class MotivatingExampleProgram
    {
        public String foo(int p)
        {
            if (p > 0)
            {
                return "a" +" "+ p;
            }
            else
                return "b" +" "+ (-p);
        }
    }
}
