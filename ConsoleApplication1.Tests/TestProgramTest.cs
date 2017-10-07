// <copyright file="TestProgramTest.cs">Copyright ©  2017</copyright>

using System;
using ConsoleApplication1;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleApplication1.Tests
{
    /// <summary>This class contains parameterized unit tests for TestProgram</summary>
    [TestClass]
    [PexClass(typeof(TestProgram))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class TestProgramTest
    {
    }
}
