using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataSplitter;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using FluentAssertions;

namespace DataSplitterTests
{
	[TestClass()]
	public class TableSplitterTests
	{
		// Orders 測試資料集
		private readonly ReadOnlyCollection<Order> _orders = new List<Order>
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
		}.AsReadOnly();

		// 用於傳入自訂欄位的總和計算式
		private int GetCostCell(Order order)
		{
			return order.Cost;
		}

		// 用於傳入自訂欄位的總和計算式
		private int GetRevenueCell(Order order)
		{
			return order.Revenue;
		}

		// 測試依序每次取出訂單筆數為負數時，應觸發 ArgumentException
		[TestMethod()]
		public void SplitRowsByNegativeNumberAndTriggerArgumentExceptionTest()
		{
			// arrange
			TableSplitter ts = new TableSplitter();

			// act
			Action expected = () =>
			{
				ICollection actual = ts.SplitAndGetSum<Order>(this._orders, -1, (Order order) => 0) as ICollection;
			};

			// act & assert
			expected.ShouldThrow<ArgumentException>();
		}

		// 測試依序每次取出訂單筆數為 0 時，應觸發 ArgumentException
		[TestMethod()]
		public void SplitRowsByZeroAndTriggerArgumentExceptionTest()
		{
			// arrange
			TableSplitter ts = new TableSplitter();

			// act
			Action expected = () =>
			{
				ICollection actual = ts.SplitAndGetSum<Order>(this._orders, 0, (Order order) => 0) as ICollection;
			};

			// act & assert
			expected.ShouldThrow<ArgumentException>();
		}

		// 測試依序每次取出三筆訂單，並回傳每三筆訂單一組的 Cost 欄位總和集合
		[TestMethod()]
		public void SplitEvery3RowsAndGetSumFromCostCellTest()
		{
			// arrange
			TableSplitter ts = new TableSplitter();

			// act
			ICollection actual = ts.SplitAndGetSum<Order>(this._orders, 3, this.GetCostCell) as ICollection;
			ICollection expected = new List<int> { 6, 15, 24, 21 };
			
			// act & assert
			CollectionAssert.AreEqual(expected, actual);
		}

		// 測試依序每次取出四筆訂單，並回傳每四筆訂單一組的 Revenue 欄位總和集合
		[TestMethod()]
		public void SplitEvery4RowsAndGetSumFromRevenueCellTest()
		{
			// arrange
			TableSplitter ts = new TableSplitter();

			// act
			ICollection actual = ts.SplitAndGetSum<Order>(this._orders, 4, this.GetRevenueCell) as ICollection;
			ICollection expected = new List<int> { 50, 66, 60 };
			
			// act & assert
			CollectionAssert.AreEqual(expected, actual);
		}
	}
}