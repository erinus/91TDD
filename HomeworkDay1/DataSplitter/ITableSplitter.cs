using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSplitter
{
	interface ITableSplitter
	{
		void SetRows(List<IRow> rows);

		List<IRow> GetRows();

		int[] SplitAndGetSum(string field, int count);
	}
}
