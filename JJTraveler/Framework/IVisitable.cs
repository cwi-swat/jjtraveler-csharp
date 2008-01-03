using System;

namespace JJTraveler
{
	/// <summary>
	/// Any class that needs to be visitable by a visitor should implement the Visitable interface.
	/// </summary>
	public interface IVisitable
	{
	   /**
	    * Returns the ith child of any visitable. Counting starts
	    * at 0. Thus, to get the last child of a visitable with n
	    * children, use getChild(n-1).
	    */
	   IVisitable getChildAt(int i);

       /**
	    * Replaces the ith child of any visitable, and returns this
	    * visitable. Counting starts at 0. Thus, to set the last child of
	    * a visitable with n children, use setChild(n-1). 
	    */
	   IVisitable setChildAt(int i, IVisitable child);

       /**
	    * Returns the number of children of any visitable.
	    */
	   int getChildCount();
	}
}
