using System;

namespace JJTraveler
{
	/// <summary>
	/// x.accept(Fail)</code> always raises a VisitFailure exception. 
	/// <p>
	/// Basic visitor combinator without arguments, that always fails.
	/// <p>
	/// Test case documentation:
	/// <a href="FailTest.java">FailTest</a>
	///
	/// </summary>
	public class Fail : IVisitor
	{
		private String message;
		
		/** 
		 * Construct Fail combinator with empty failure message.
		 */
		public Fail() 
		{ 
			this.message = ""; 
		}
		/**
		 * Construct Fail combinator with a failure message to be passed to the
		 * VisitFailure that it throws.
		 */
		public Fail(string message)
		{
			this.message = message;
		}
		public virtual IVisitable visit(IVisitable any) // throws VisitFailure 
		{
			throw new VisitFailure(message);
		}
	}

	}
