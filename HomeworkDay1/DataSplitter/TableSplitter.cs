using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSplitter
{
	public class TableSplitter
	{
		public IEnumerable<int> SplitAndGetSum<TSource>(IEnumerable<TSource> sources, int pageSize,
			Func<TSource, int> selector)
		{
			List<int> result = new List<int>();

			// 每次取出訂單筆數為 0 或負數時，應觸發 ArgumentException
			if (pageSize == 0 || pageSize < 0)
			{
				throw new ArgumentException();
			}

			// 將資料集依序取出單筆資料後，依指定欄位取出值放入 List
			IEnumerator<TSource> enumarator = sources.GetEnumerator();

			List<int> extracted = new List<int>();

			while (enumarator.MoveNext())
			{
				TSource source = enumarator.Current;

				extracted.Add(selector(source));
			}

			// 按照 pageSize 每次取出對應數量的值並加總後放入回傳資料集
			for (int i = 0; i < extracted.Count; i += pageSize)
			{
				int sum = extracted.GetRange(i, i + pageSize < extracted.Count ? pageSize : extracted.Count - i).Sum();

				result.Add(sum);
			}

			return result;
		}
	}
}
