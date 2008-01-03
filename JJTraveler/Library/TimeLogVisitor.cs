using System;

namespace JJTraveler
{
	/// <summary>
	/// This specialization of the LogVisitor additionally times the
	/// invocation and return moments of the argument visitor.
	/// </summary>
	public class TimeLogVisitor : LogVisitor
	{
		internal long firstInvocationTimeStamp = 0;
		internal long lastReturnTimeStamp;
		internal long consumedTime = 0;

		public TimeLogVisitor(IVisitor v, Logger l) : base(v,l)
		{
		}
		
		public override IVisitable visit(IVisitable visitable) // throws VisitFailure 
		{
			long startTime = DateTime.Now.Ticks;
			if (firstInvocationTimeStamp == 0) 
			{
				firstInvocationTimeStamp = startTime;
			}

			logger.log( new Event(visitor,visitable) );
			IVisitable result = visitor.visit( visitable );

			long endTime = DateTime.Now.Ticks;
			lastReturnTimeStamp = endTime;
			consumedTime = consumedTime + (endTime - startTime);

			return result;
		}

		/**
		 * Retrieve the total elapsed time (in milliseconds) since the
		 * first invocation of the argument visitor.
		 */
		public virtual long getElapsedTime() 
		{
			return lastReturnTimeStamp - firstInvocationTimeStamp;
		}
		/**
		 * Retrieve the cumulatively consumed time (in milliseconds)
		 * during all executions of the argument visitor.
		 */
		public virtual long getConsumedTime() 
		{
			return consumedTime;
		}
	}
}