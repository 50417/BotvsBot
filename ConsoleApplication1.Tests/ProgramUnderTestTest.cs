// <copyright file="ProgramUnderTestTest.cs">Copyright ©  2017</copyright>

using System;
using ConsoleApplication1;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleApplication1.Tests
{
    [TestClass]
    [PexClass(typeof(ProgramUnderTest))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class ProgramUnderTestTest
    {

        [PexMethod(MaxConstraintSolverTime = 2)]
        public string createText(
            [PexAssumeUnderTest]ProgramUnderTest target,
            int numOfWords,
            int type
        )
        {
            string result = target.createText(numOfWords, type);
            return result;
            // TODO: add assertions to method ProgramUnderTestTest.createText(ProgramUnderTest, Int32, Int32)
        }
    }
}
