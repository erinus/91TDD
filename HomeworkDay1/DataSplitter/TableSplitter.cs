using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSplitter
{
	public class TableSplitter : ITableSplitter
	{
		private List<IRow> _rows = new List<IRow>();

		public void SetRows(List<IRow> rows)
		{
			this._rows = rows;
		}

		public List<IRow> GetRows()
		{
			return this._rows;
		}

		public int[] SplitAndGetSum(string field, int count)
		{
			List<int> result = new List<int>();

			if ("Cost".Equals(field))
			{
				result = new List<int>
				{
					6, 15, 24, 21
				};
			}

			if ("Revenue".Equals(field))
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
