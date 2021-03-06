using System;
// <copyright file="PexAssemblyInfo.cs">Copyright ©  2017</copyright>
using Microsoft.Pex.Framework.Coverage;
using Microsoft.Pex.Framework.Creatable;
using Microsoft.Pex.Framework.Instrumentation;
using Microsoft.Pex.Framework.Settings;
using Microsoft.Pex.Framework.Validation;

// Microsoft.Pex.Framework.Settings
[assembly: PexAssemblySettings(TestFramework = "VisualStudioUnitTest")]

// Microsoft.Pex.Framework.Instrumentation
[assembly: PexAssemblyUnderTest("ConsoleApplication1")]
[assembly: PexInstrumentAssembly("Accord.Math")]
[assembly: PexInstrumentAssembly("Accord.IO")]
[assembly: PexInstrumentAssembly("Accord")]
[assembly: PexInstrumentAssembly("System.Data")]
[assembly: PexInstrumentAssembly("Accord.Statistics")]
[assembly: PexInstrumentAssembly("Accord.MachineLearning")]

// Microsoft.Pex.Framework.Creatable
[assembly: PexCreatableFactoryForDelegates]

// Microsoft.Pex.Framework.Validation
[assembly: PexAllowedContractRequiresFailureAtTypeUnderTestSurface]
[assembly: PexAllowedXmlDocumentedException]

// Microsoft.Pex.Framework.Coverage
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "Accord.Math")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "Accord.IO")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "Accord")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "System.Data")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "Accord.Statistics")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "Accord.MachineLearning")]
[assembly: PexInstrumentType(typeof(Random))]

