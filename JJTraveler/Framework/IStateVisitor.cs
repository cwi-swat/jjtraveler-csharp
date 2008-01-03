using System;

namespace JJTraveler
{
	/// <summary>
	/// Summary description for IStateVisitor.
	/// </summary>
	public interface IStateVisitor : IVisitor
	{
		Object getState();
		void setState(Object state);
	}
}
