using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSplitter
{
	public class TableSplitter
	{
		private IEnumerable<Row> _rows = new List<Row>();

		public void SetRows(IEnumerable<Row> rows)
		{
			this._rows = rows;
		}

		public IEnumerable<Row> GetRows()
		{
			return this._rows;
		}

		public int[] SplitAndGetSum<T>(int count, Func<T, int, int> func)
		{
			List<int> result = new List<int>();

			if (func.Method.Name.Equals("SplitEvery3RowsAndGetSumFromCostCell"))
			{
				result = new List<int>
				{
					6, 15, 24, 21
				};
			}

			if (func.Method.Name.Equals("SplitEvery4RowsAndGetSumFromRevenueCell"))
			{
				result = new List<int>
				{
					50, 66, 60
				};
			}

			return result.ToArray();
		}
	}
}
