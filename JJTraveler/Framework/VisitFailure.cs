using System;

namespace JJTraveler
{
	/// <summary>
	/// The VisitFailure exception is used to model success and failure
	/// of visitor combinators. On failure, the exception is raised. At
	/// choice points, the try and 
	/// catch constructs are used to recover
	/// from failed visits.
	/// </summary>
	public class VisitFailure : Exception
	{
		public VisitFailure(): base()
		{
		}
		public VisitFailure(string msg) : base(msg)
		{
		}
	}
}

