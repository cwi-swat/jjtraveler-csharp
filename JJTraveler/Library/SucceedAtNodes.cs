using System;

namespace JJTraveler
{
	/// <summary>
	/// Simple visitor recognizing two nodes given at creation time.
	/// Can be used to test generic visitors requiring a recognizing
	/// argument.
	/// </summary>
	public class SucceedAtNodes : IVisitor
	{
		internal IVisitor success;
		public SucceedAtNodes(IVisitable n1, IVisitable n2)
		{
			success = new Not( new FailAtNodes(n1, n2) );
		}
		public SucceedAtNodes(IVisitable n) 
		{
			success = new Not( new FailAtNodes(n) );
		}

		#region IVisitor Members

		public virtual IVisitable visit(IVisitable x) // throws VisitFailure
		{
			return success.visit(x);
		}

		#endregion
	}
}
