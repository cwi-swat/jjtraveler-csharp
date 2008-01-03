using System;

namespace JJTraveler
{
	/// <summary>
	/// A class to represent a visting event: the fact that a visitable
	/// node is visited by a particular visitor.
	/// </summary>
	
	public class Event 
	{
 
		internal IVisitor visitor;
		internal IVisitable node;
		internal long timeStamp;
    

		public Event(IVisitor v, IVisitable n) 
		{
			visitor = v;
			node = n;
			timeStamp = DateTime.Now.Ticks;
		}

		public override String ToString() 
		{
			return visitor + ".visit(" + node + ")";
		}

		public override bool Equals(Object o) 
		{
			bool result = false;
			if (o is Event) {
				Event e = (Event) o;
				result = ToString()==e.ToString();
			}
			return result;
		}
		public override int GetHashCode() 
		{
			return ToString().GetHashCode();
		}

		/**
		 * Return the time (in milliseconds) at which the event was generated.
		 */
		public virtual long getTimeStamp() 
		{
			return timeStamp;
		}
	}

}
