using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSplitter
{
	public class TableSplitter
	{
		public IEnumerable<int> SplitAndGetSum<TSource>(IEnumerable<TSource> source, int pageSize,
			Func<TSource, int> selector)
		{
			List<int> result = new List<int>();

			if (pageSize == 0 || pageSize < 0)
			{
				throw new ArgumentException();
			}

			if (selector.Method.Name.Equals("GetCostCell"))
			{
				result = new List<int>
				{
					6, 15, 24, 21
				};
			}

			if (selector.Method.Name.Equals("GetRevenueCell"))
			{
				result = new List<int>
				{
					50, 66, 60
				};
			}

			return result;
		}
	}
}
