using System;
using System.Collections;

namespace JJTraveler
{
	/// <summary>
	/// Simple visitor recognizing two nodes given at creation time.
	/// Can be used to test generic visitors requiring a recognizing
	/// argument.
	/// </summary>
	public class FailAtNodes : IVisitor
	{
		internal ArrayList visitables = new ArrayList();
		public FailAtNodes(ICollection visitables)
		{
			this.visitables.AddRange(visitables);

		}

		public FailAtNodes(IVisitable n) 
		{
			visitables.Add(n);
		}

		public FailAtNodes(IVisitable n1, IVisitable n2) 
		{
			visitables.Add(n1);
			visitables.Add(n2);
		}

		#region IVisitor Members

		public virtual IVisitable visit(IVisitable x) // throws VisitFailure
		{
			if (visitables.Contains(x)) 
			{
				throw (new VisitFailure());
			} 
			return x;
		}

		#endregion
	}
}