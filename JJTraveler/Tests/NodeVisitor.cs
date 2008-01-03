using System;

namespace JJTraveler.Tests
{
	/// <summary>
	/// An (abstract) implementation of the <code>Visitor</code> interface
	/// for testing purposes.
	/// </summary>
	public abstract class NodeVisitor : IVisitor
	{
		#region IVisitor Members

		public virtual IVisitable visit(IVisitable any)
		{

			IVisitable result;
            if (any is Node) {
               result = ((Node) any).accept(this);
			} 
			else {
				throw new VisitFailure();
			}
			return result;
        }
		#endregion
		public abstract Node visitNode(Node x);
	}
}
