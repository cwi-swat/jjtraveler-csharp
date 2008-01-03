using System;
using System.Collections;


namespace JJTraveler
{
	/// <summary>
	/// Logs events and allows their trace to be inspected.
	/// </summary>
	public class Logger 
	{

		internal ArrayList trace = new ArrayList();

		public Logger() {}

		/** 
		 *  Create a new Logger which has as initialt trace a single
		 *  visit of a particular node.
		 */
		public Logger(IVisitor v, IVisitable n) 
		{
			log( new Event(v, n) );
		}

		/**
		 * Create a new Logger, which has as initial trace a sequence of
		 * visiting events where the visitor <code>v</code> visits each of
		 * the <code>nodes</code>
		 */
		public Logger (IVisitor v, IVisitable[] nodes) 
		{
			for (int i = 0; i < nodes.Length; i++) 
			{
				log( new Event(v, nodes[i]) );
			}
		}

		/**
		 * Log a single event.
		 */
		public virtual void log( Event e ) 
		{
			trace.Add( e );
		}

		/**
		 * Produces a string representation of the trace of events that
		 * have been logged so far.
		 */
		public override String ToString() 
		{
			String result = "";
			foreach (Event e in trace)
			{
				result += e.ToString() + "\n";
			}
			return result;
		}
       
		/**
		 * Loggers are equal if and only of their traces are.
		 */
		public override bool Equals(Object o) 
		{
			if (o is Logger) 
			{
				return ( (Logger) o).ToString().Equals(ToString());
			} 
			else 
			{
				return false;
			}
		}

		/**
		 * Hashcode must be redefined if equality is redefined.
		 */
		public override int GetHashCode() 
		{
			return ToString().GetHashCode();
		}

		/**
		 * Compute the elapsed time (in milliseconds) between the first
		 * and last event on the logger's trace.
		 */
		public virtual long getElapsedTime() 
		{
			long startTime = ((Event) trace[0]).getTimeStamp();
			long endTime = ((Event) trace[trace.Count-1]).getTimeStamp();
			return endTime - startTime;
		}
	}
}

