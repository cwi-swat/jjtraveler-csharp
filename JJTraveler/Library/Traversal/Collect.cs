using System;
using System.Collections;

namespace JJTraveler
{
	/// <summary>
	/// A visitor combinator that collects the visitables that result from
	/// succesful applications of its argument visitor. The visitor itself
	/// does not iterate, but factory methods are provided that construct
	/// iterating variants.
	/// </summary>
	public class Collect : IVisitor
	{
		private ArrayList collection;
		private IVisitor visitor;
		/**
		 * Construct a (non-iterating) collect visitor with initial
		 * collection <code>c</code>.
		 */
		public Collect(IVisitor v, ArrayList c)
		{
			collection = c;
			visitor = v;
		}
		/**
		 * Constructor which uses a new empty HashSet as collection.
		 */
		public Collect(IVisitor v) : this(v, new ArrayList())
		{
		}
		/**
		 * Return the collection that has been built up so far.
		 */
		public virtual ArrayList getCollection() 
		{
			return collection;
		}

		#region IVisitor Members
		/**
		 * Apply the argument strategy to the visitable <code>x</code>,
		 * and add the resulting visitable to the collection if
		 * successful.
		 */
		public virtual IVisitable visit(IVisitable x) // throws VisitFailure
		{  
			IVisitable result = visitor.visit(x);
			collection.Add(result);
			return result;
		}
		#endregion

		/**
		 * Factory method that produces a collecting visitor that iterates
		 * in top-down fashion.
		 */
		public static GuaranteeSuccess topdown(IVisitor v, ArrayList c) 
		{
			return (new GuaranteeSuccess
				(new TopDown
				(new Try(new Collect(v,c)))));
		}

		/**
		 * Factory method that produces a collecting visitor that iterates
		 * left-to-right over immediate children.
		 */
		public static GuaranteeSuccess all(IVisitor v, ArrayList c) 
		{
			return (new GuaranteeSuccess
				(new All
				(new Try(new Collect(v,c)))));
		}
	}
}
