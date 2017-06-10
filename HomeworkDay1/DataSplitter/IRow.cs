using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSplitter
{
	public interface IRow
	{
		Int32 GetValueFromCell(string name);
	}
}
