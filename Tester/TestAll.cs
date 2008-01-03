using System;
using dotUnit.Framework;
using JJTraveler;
using JJTraveler.Tests;

namespace JJTraveler.TestApp
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	class TestAll : TestCase
	{
		public TestAll(String test) : base(test)
		{
		}

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			dotUnit.GUI.GUIRunner.Run(suite());
		}
		public static TestSuite suite() 
		{
			TestSuite suite = new TestSuite();
			suite.AddTestSuite(typeof(IdentityTest));
			suite.AddTestSuite(typeof(AllTest));
			suite.AddTestSuite(typeof(FailTest));
			suite.AddTestSuite(typeof(OneTest));
			suite.AddTestSuite(typeof(FailAtNodesTest));
			suite.AddTestSuite(typeof(SomeTest));
			suite.AddTestSuite(typeof(TopDownUntilTest));
			suite.AddTestSuite(typeof(SpineBottomUpTest));
			suite.AddTestSuite(typeof(SpineTopDownTest));
			suite.AddTestSuite(typeof(SuccessCounterTest));
			suite.AddTestSuite(typeof(IfThenElseTest));
			suite.AddTestSuite(typeof(AllSpinesBottomUpTest));
			suite.AddTestSuite(typeof(ChildTest));
			suite.AddTestSuite(typeof(CollectTest));
			suite.AddTestSuite(typeof(DescendantTest));
			suite.AddTestSuite(typeof(DoWhileSuccessTest));
			suite.AddTestSuite(typeof(LoggerTest));
			suite.AddTestSuite(typeof(NestingDepthTest));
			suite.AddTestSuite(typeof(OnceTopDownTest));
			suite.AddTestSuite(typeof(TimeLogVisitorTest));
			suite.AddTestSuite(typeof(LibraryTest));

			return suite;
		}
	}
}
