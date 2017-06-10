using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSplitter
{
	public abstract class Row : IRow
	{
		public Int32 GetValueFromCell(string name)
		{
			var prop = this.GetType().GetField(name);
			var val = prop.GetValue(this);
			return Convert.ToInt32(val);
		}
	}
}
