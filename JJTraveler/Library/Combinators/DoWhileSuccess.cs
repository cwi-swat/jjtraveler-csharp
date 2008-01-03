using System;

namespace JJTraveler
{
	/// <summary>
	/// Top down traversal as long as a condition holds, with separate actions
	/// during the traversal and at the border.
	/// This combinator can be used to express a number of other combinators;
	/// these are offered through factory methods.
	///
	/// @author Arie van Deursen
	/// @version $Id: DoWhileSuccess.java,v 1.10 2003/08/05 16:07:07 jurgenv Exp $
	/// </summary>
	public class DoWhileSuccess : DefinedCombinator
	{
		private IVisitor action = new Identity();
		private IVisitor condition = new Identity();
		private IVisitor atBorder = new Identity();

		public DoWhileSuccess(IVisitor condition, IVisitor action)
		{
			this.condition = condition;
			this.action = action;
		}
		/** Same as TopDownWhile(v)
		 */
		public DoWhileSuccess(IVisitor condition) 
		{
			this.condition = condition;
		}
		/** Most generic form, having different behavior in
		 *  conditions, at success, and at the failing border.
		 */
		public DoWhileSuccess(IVisitor condition,IVisitor action,IVisitor atBorder) 
		{
			this.condition = condition;
			this.action = action;
			this.atBorder = atBorder;
		}
		/** Reuse DoWhileSuccess(v) as a TopDownWhile(v).
		 */
		public static DoWhileSuccess TopDownWhile(IVisitor v1) 
		{
			return new DoWhileSuccess(v1);
		}

		/** Reuse DoWhileSuccess(v1,id,v2) as a TopDownWhile(v1,v2)
		 */
		public static DoWhileSuccess TopDownWhile(IVisitor v1, IVisitor v2) 
		{
			return new DoWhileSuccess(v1, new Identity(), v2);
		}

		/** Reuse DoWhileSuccess(id,v,id) as a TopDown(v);
		 */
		public static DoWhileSuccess TopDown(IVisitor v) 
		{
			return new DoWhileSuccess(new Identity(), v, new Identity());
		}

		/** Reuse DoWhileSuccess(not(v)) as a TopDownUntil(v);
		 */
		public static DoWhileSuccess TopDownUntil(IVisitor v1) 
		{
			return new DoWhileSuccess(new Not(v1));
		}
	
		/** Reuse DoWhileSuccess(not(v1),id,action) to create
		 *  a TopDownUntil(condition, borderAction);
		 */
		internal static DoWhileSuccess TopDownUntil(IVisitor condition, IVisitor borderAction) 
		{
			return new DoWhileSuccess(new Not(condition), new Identity(), borderAction);
		}

		internal override IVisitor getDefinition() 
		{
			return new IfThenElse(
				condition,
				new Sequence(action, new All(this)),
				atBorder);
		}
	}
}

