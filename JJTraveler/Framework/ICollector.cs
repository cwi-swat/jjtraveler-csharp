using System;
using System.Collections;

namespace JJTraveler
{
	/// <summary>
	/// A visitor combinator for collecting items.
	/// </summary>
	public interface ICollector : IVisitor
	{
		ICollection getCollection();
	}
}
