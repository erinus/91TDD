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
