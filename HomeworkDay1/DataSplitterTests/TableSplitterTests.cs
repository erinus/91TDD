using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataSplitter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSplitterTests
{
	[TestClass()]
	public class TableSplitterTests
	{
		// Orders 測試資料集
		private readonly List<Row> _orders = new List<Row>
		{
			new Order {Id = 1, Cost = 1, Revenue = 11, SellPrice = 21},
			new Order {Id = 2, Cost = 2, Revenue = 12, SellPrice = 22},
			new Order {Id = 3, Cost = 3, Revenue = 13, SellPrice = 23},
			new Order {Id = 4, Cost = 4, Revenue = 14, SellPrice = 24},
			new Order {Id = 5, Cost = 5, Revenue = 15, SellPrice = 25},
			new Order {Id = 6, Cost = 6, Revenue = 16, SellPrice = 26},
			new Order {Id = 7, Cost = 7, Revenue = 17, SellPrice = 27},
			new Order {Id = 8, Cost = 8, Revenue = 18, SellPrice = 28},
			new Order {Id = 9, Cost = 9, Revenue = 19, SellPrice = 29},
			new Order {Id = 10, Cost = 10, Revenue = 20, SellPrice = 30},
			new Order {Id = 11, Cost = 11, Revenue = 21, SellPrice = 31}
		};

		// 測試訂單資料集寫入後，訂單數量是否正確
		[TestMethod()]
		public void SetRowsTest()
		{
			//---------//
			// arrange //
			//---------//
			TableSplitter ts = new TableSplitter();

			//--------//
			// assert //
			//--------//
			Assert.AreEqual(0, ts.GetRows().Count);

			//-----//
			// act //
			//-----//
			ts.SetRows(this._orders);
			int actual = ts.GetRows().Count;
			int expected = this._orders.Count;

			//--------//
			// assert //
			//--------//
			Assert.AreEqual(expected, actual);
		}

		// 測試訂單資料集寫入後，第三筆訂單的 Revenue 欄位是否正確
		[TestMethod()]
		public void GetRevenueCellValueFromThirdRowTest()
		{
			//---------//
			// arrange //
			//---------//
			TableSplitter ts = new TableSplitter();

			//-----//
			// act //
			//-----//
			ts.SetRows(this._orders);

			//--------------//
			// act & assert //
			//--------------//
			Row row = ts.GetRows()[2];
			Assert.IsNotNull(row);

			//--------------//
			// act & assert //
			//--------------//
			int actual = row.GetValueFromCell("Revenue");
			Order order = this._orders[2] as Order;
			int expected = order.Revenue;
			Assert.IsNotNull(order);
			Assert.AreEqual(expected, actual);
		}

		// 測試依序每次取出三筆訂單，並回傳每三筆訂單一組的 Cost 欄位總和集合
		[TestMethod()]
		public void SplitEvery3RowsAndGetSumFromCostCellTest()
		{
			//---------//
			// arrange //
			//---------//
			TableSplitter ts = new TableSplitter();

			//-----//
			// act //
			//-----//
			ts.SetRows(this._orders);
			int[] actual = ts.SplitAndGetSum("Cost", 3);
			int[] expected = new int[] { 6, 15, 24, 21 };

			//--------------//
			// act & assert //
			//--------------//
			CollectionAssert.AreEqual(expected, actual);
		}

		// 測試依序每次取出四筆訂單，並回傳每四筆訂單一組的 Revenue 欄位總和集合
		[TestMethod()]
		public void SplitEvery4RowsAndGetSumFromRevenueCellTest()
		{
			//---------//
			// arrange //
			//---------//
			TableSplitter ts = new TableSplitter();

			//-----//
			// act //
			//-----//
			ts.SetRows(this._orders);
			int[] actual = ts.SplitAndGetSum("Revenue", 4);
			int[] expected = new int[] { 50, 66, 60 };

			//--------------//
			// act & assert //
			//--------------//
			CollectionAssert.AreEqual(expected, actual);
		}
	}
}