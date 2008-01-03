using System;

namespace JJTraveler
{
	/// <summary>
	/// Counter of the number of nested occurrences of a construct
	/// recognized by the argument visitor on a single given path.
	///
	/// A typical example of its usage is for counting the
	/// maximum nesting level of if-statements in a program.
	///
	/// @author Arie van Deursen, CWI
	/// </summary>
	public class NestingDepth : IVisitor, System.ICloneable
	{
		internal IVisitor nestingRecognizer;
		internal IVisitor goOnWhileSuccess = new Identity();
		internal int nestingLevel = 0;
		internal int maxNestingDepth = 0;

		/** Create a nesting counter given the recognizer argument.
		 *  The recognizer fails at all nodes, except for the ones
		 *  recognized, at which it succeeds.
		 */
		public NestingDepth(IVisitor nestingRecognizer, IVisitor goOn) 
		{
			this.nestingRecognizer = nestingRecognizer;
			this.goOnWhileSuccess = goOn;
		}

		/** Create a nesting counter given the recognizer argument.
		  */
		public NestingDepth(IVisitor nestingRecognizer)
		{
			this.nestingRecognizer = nestingRecognizer;
		}
		/** Restart a visitor after having recognized a relevant construct.
		*/
		private NestingDepth restart() {
			NestingDepth nextDepth = (NestingDepth) this.Clone();
			nextDepth.maxNestingDepth = max(maxNestingDepth, nestingLevel + 1);
			nextDepth.nestingLevel++;
			return nextDepth;
		}

		public virtual Object Clone() {
			NestingDepth theClone = new NestingDepth(nestingRecognizer, goOnWhileSuccess);
			theClone.nestingLevel = nestingLevel;
			theClone.maxNestingDepth = maxNestingDepth;
			return theClone;
		}

		private NestingDepth apply(IVisitable x) {
			(new GuaranteeSuccess(new All(this))).visit(x);
			return this;
		}

		/** Return the maximum nesting depth found.
		*/
		public virtual int getDepth() {
			return maxNestingDepth;
		}


		internal virtual bool countingShouldContinue(IVisitable x) {
			bool goOn = false;
			try {
				goOnWhileSuccess.visit(x);
				goOn = true;
			} catch (VisitFailure) {
				goOn = false;
			}
			return goOn;
		}

		internal virtual bool isNestingConstruct(IVisitable x) {
			bool isNesting = false;
			try {
				nestingRecognizer.visit(x);
				isNesting = true;
			} catch (VisitFailure) {
				isNesting = false;
			}
			return isNesting;
		}

		/** Status printing that can be used for debugging purposes.
		private String status() {
			return " maxNestingDepth = " + maxNestingDepth + "; " + "nestingLevel = " + nestingLevel;
		}
		*/

		/** Where is this one in the Java API?
		*/
		private int max(int i1, int i2) {
			return (i1 > i2 ? i1 : i2);
		}

		#region IVisitor Members

		/** Apply the nesting depth counter to a given visitable.
		*/
		public virtual IVisitable visit(IVisitable x) // throws VisitFailure 
		{
			if (countingShouldContinue(x)) 
			{
				if (isNestingConstruct(x)) 
				{
					maxNestingDepth = restart().apply(x).getDepth();
				} 
				else 
				{
					this.apply(x);
				}
			}
			return x;
		}
		#endregion
	}
}