using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CartTests
{
	using Cart;

	[TestClass]
	public class CartTest
	{
		[TestMethod]
		public void Test_Total_Price_Should_Be_100_When_Potter_EP1()
		{
			// arrange
			Cart cart = new Cart();

			// act
			cart.AddItem(new CartItem
			{
				ID = 1,
				Name = "Harry Potter (Book 1)",
				Price = 100,
				Count = 1
			});
			int actual = cart.GetTotalPrice();
			int expected = 100;

			// assert
			Assert.AreEqual(expected, actual);
		}
	}
}
