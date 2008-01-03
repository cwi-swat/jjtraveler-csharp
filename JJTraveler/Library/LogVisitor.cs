using System;

namespace JJTraveler
{
	/// <summary>
	/// A combinator that generates a loggable event each time that its
	/// argument visitor is invoked.
	/// </summary>
	public class LogVisitor : IVisitor 
	{
		internal IVisitor visitor;
		internal Logger logger;

		public LogVisitor(IVisitor v, Logger l) 
		{
			visitor = v;
			logger = l;
		}

		public virtual IVisitable visit(IVisitable visitable) // throws VisitFailure 
		{
			logger.log( new Event(visitor, visitable) );
			return visitor.visit( visitable );
		}
	}
}
