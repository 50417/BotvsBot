using System;
namespace ConsoleApplication1
{
    public class TestProgram
    {   public String foo(int p)
        {
            if (p > 0)
            {
                return "a" + p;
            }
            else
                return "b" + (-p);
        }
    }
}