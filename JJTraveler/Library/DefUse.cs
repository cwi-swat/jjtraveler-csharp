using System;
#if false
namespace JJTraveler
{
	/// <summary>
	/// A generic algorithm for use-def analysis.
	/// </summary>
	public class DefUse : TopDown
	{
		ICollector use;
		ICollector def;
		/**
		 * @param use visitor combinator that collects used entities.
		 * @param def visitor combinator that collects defined entities.
		*/
		public DefUse(ICollector use, ICollector def) : base(new Sequence(use,def))
		{
			this.use = use;
			this.def = def;
		}
		/**
		 * Return those entities that are defined, but not used.
		 */
		public ICollection getUnused() 
		{
			Hashtable result = new Hashtable();
			result.addAll(def.getCollection());
			result.removeAll(use.getCollection());
			return result;
		}

		/**
		 * Return those entities that are used, but not defined.
		 */
		public Collection getUndefined() 
		{
			HashSet result = new HashSet();
			result.addAll(use.getCollection());
			result.removeAll(def.getCollection());
			return result;
		}
	}
}


}
    
#endif
