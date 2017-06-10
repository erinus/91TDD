using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataSplitter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace DataSplitterTests
{
	[TestClass()]
	public class RowTests
	{
		[TestMethod()]
		public void GetExceptionByWrongColumnNameTest()
		{
			//---------//
			// arrange //
			//---------//
			Order row = new Order
			{
				Id = 1,
				Cost = 1,
				Revenue = 11,
				SellPrice = 21
			};

			//-----//
			// act //
			//-----//
			string name = "Wrong";

			//--------//
			// assert //
			//--------//
			Action act = () => row.GetValueFromCell(name);
			act.ShouldThrow<NullReferenceException>();
		}
	}
}