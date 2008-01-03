using System;

namespace JJTraveler
{
	/// <summary>
	/// Summary description for IfThenElse.
	/// </summary>
	public class IfThenElse : IVisitor
	{
		internal IVisitor condition;
		internal IVisitor trueCase;
		internal IVisitor falseCase;

		public IfThenElse(IVisitor c, IVisitor t, IVisitor f) 
		{
			condition = c;
			trueCase = t;
			falseCase = f;
		}

		public IfThenElse(IVisitor c, IVisitor t) 
		{
			condition = c;
			trueCase = t;
			falseCase = new Identity();
		}
		
		#region IVisitor Members
		public virtual IVisitable visit(IVisitable x) // throws VisitFailure 
		{
			bool success;
			IVisitable result;
			try 
			{
				condition.visit(x);
				success = true;
			} 
			catch (VisitFailure) 
			{
				success = false;
			}
			if (success) 
			{
				result = trueCase.visit(x);
			} 
			else 
			{
				result = falseCase.visit(x);
			}
			return result;
		}
		#endregion
	}
}
