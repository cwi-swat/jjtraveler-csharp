using System;

namespace JJTraveler
{
	/// <summary>
	/// Counter which keeps track of how
	///  often its argument visitor succeeds
	///  and how often it fails.
	///  Can be used for various metrics
	///  combinators. 
	/// 
	/// @author Arie van Deursen; Jun 30, 2003 
	/// @version $Id: SuccessCounter.java,v 1.2 2003/06/30 17:28:37 arie Exp $
	/// </summary>
	public class SuccessCounter : IVisitor
	{
		internal int success = 0;
		internal int failure = 0;
		internal IVisitor action;

		public SuccessCounter(IVisitor v) 
		{
			action = v;
		}
		public virtual int getSuccesses() 
		{
			return success;
		}

		public virtual int getFailures() 
		{
			return failure;
		}

		#region IVisitor Members

		public virtual IVisitable visit(IVisitable x)
		{
			try 
			{
				action.visit(x);
				success++;
			} 
			catch (VisitFailure) 
			{
				failure++;
			}
			return x;
		}
		#endregion
	}
}