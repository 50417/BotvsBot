// <copyright file="TestProgramTest.cs">Copyright ©  2017</copyright>

using System;
using ConsoleApplication1;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleApplication1.Tests
{
    [TestClass]
    [PexClass(typeof(TestProgram))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class TestProgramTest
    {

        [PexMethod]
        public string foo([PexAssumeUnderTest]TestProgram target, int p)
        {
  
            PexAssume.IsTrue(p != 1);
            PexAssume.IsTrue(p != 2);
            string result = target.foo(p);
            return result;
            // TODO: add assertions to method TestProgramTest.foo(TestProgram, Int32)
        }
    }
}
