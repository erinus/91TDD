using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CartTests
{
	using Cart;

	[TestClass]
	public class CartTest
	{
		Cart _cart = new Cart();

		public CartTest()
		{
			List<CartItem> relatedCartItems = new List<CartItem>
			{
				new CartItem { ID = 1 },
				new CartItem { ID = 2 },
				new CartItem { ID = 3 },
				new CartItem { ID = 4 },
				new CartItem { ID = 5 }
			};
			
			_cart.AddSaleItem(new SaleItem
			{
				RelatedCartItems = relatedCartItems,
				Combination = 2,
				Percent = 0.95F
			});
			_cart.AddSaleItem(new SaleItem
			{
				RelatedCartItems = relatedCartItems,
				Combination = 3,
				Percent = 0.90F
			});
			_cart.AddSaleItem(new SaleItem
			{
				RelatedCartItems = relatedCartItems,
				Combination = 4,
				Percent = 0.80F
			});
			_cart.AddSaleItem(new SaleItem
			{
				RelatedCartItems = relatedCartItems,
				Combination = 5,
				Percent = 0.75F
			});
		}

		[TestMethod]
		public void Test_Total_Price_Should_Be_100_When_1x_Potter_EP1_Is_In_Cart()
		{
			// arrange
			_cart.AddCartItem(new CartItem
			{
				ID = 1,
				Name = "Harry Potter (Book 1)",
				Price = 100,
				Count = 1
			});

			// act
			int actual = _cart.GetTotalPrice();
			int expected = 100;

			// assert
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void Test_Total_Price_Should_Be_190_When_1x_Potter_EP1_And_1x_Potter_EP2_Are_In_Cart()
		{
			// arrange
			_cart.AddCartItem(new CartItem
			{
				ID = 1,
				Name = "Harry Potter (Book 1)",
				Price = 100,
				Count = 1
			});
			_cart.AddCartItem(new CartItem
			{
				ID = 2,
				Name = "Harry Potter (Book 2)",
				Price = 100,
				Count = 1
			});

			// act
			int actual = _cart.GetTotalPrice();
			int expected = 190;

			// assert
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void Test_Total_Price_Should_Be_270_When_1x_Potter_EP1_And_1x_Potter_EP2_And_1x_Potter_EP3_Are_In_Cart()
		{
			// arrange
			_cart.AddCartItem(new CartItem
			{
				ID = 1,
				Name = "Harry Potter (Book 1)",
				Price = 100,
				Count = 1
			});
			_cart.AddCartItem(new CartItem
			{
				ID = 2,
				Name = "Harry Potter (Book 2)",
				Price = 100,
				Count = 1
			});
			_cart.AddCartItem(new CartItem
			{
				ID = 3,
				Name = "Harry Potter (Book 3)",
				Price = 100,
				Count = 1
			});

			// act
			int actual = _cart.GetTotalPrice();
			int expected = 270;

			// assert
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void Test_Total_Price_Should_Be_320_When_1x_Potter_EP1_And_1x_Potter_EP2_And_1x_Potter_EP3_And_1x_Potter_EP4_Are_In_Cart()
		{
			// arrange
			_cart.AddCartItem(new CartItem
			{
				ID = 1,
				Name = "Harry Potter (Book 1)",
				Price = 100,
				Count = 1
			});
			_cart.AddCartItem(new CartItem
			{
				ID = 2,
				Name = "Harry Potter (Book 2)",
				Price = 100,
				Count = 1
			});
			_cart.AddCartItem(new CartItem
			{
				ID = 3,
				Name = "Harry Potter (Book 3)",
				Price = 100,
				Count = 1
			});
			_cart.AddCartItem(new CartItem
			{
				ID = 4,
				Name = "Harry Potter (Book 4)",
				Price = 100,
				Count = 1
			});

			// act
			int actual = _cart.GetTotalPrice();
			int expected = 320;

			// assert
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void Test_Total_Price_Should_Be_375_When_1x_Potter_EP1_And_1x_Potter_EP2_And_1x_Potter_EP3_And_1x_Potter_EP4_And_1x_Potter_EP5_Are_In_Cart()
		{
			// arrange
			_cart.AddCartItem(new CartItem
			{
				ID = 1,
				Name = "Harry Potter (Book 1)",
				Price = 100,
				Count = 1
			});
			_cart.AddCartItem(new CartItem
			{
				ID = 2,
				Name = "Harry Potter (Book 2)",
				Price = 100,
				Count = 1
			});
			_cart.AddCartItem(new CartItem
			{
				ID = 3,
				Name = "Harry Potter (Book 3)",
				Price = 100,
				Count = 1
			});
			_cart.AddCartItem(new CartItem
			{
				ID = 4,
				Name = "Harry Potter (Book 4)",
				Price = 100,
				Count = 1
			});
			_cart.AddCartItem(new CartItem
			{
				ID = 5,
				Name = "Harry Potter (Book 5)",
				Price = 100,
				Count = 1
			});

			// act
			int actual = _cart.GetTotalPrice();
			int expected = 375;

			// assert
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void Test_Total_Price_Should_Be_935_When_2x_Potter_EP1_And_1x_Potter_EP2_And_3x_Potter_EP3_And_4x_Potter_EP4_And_1x_Potter_EP5_Are_In_Cart()
		{
			// arrange
			_cart.AddCartItem(new CartItem
			{
				ID = 1,
				Name = "Harry Potter (Book 1)",
				Price = 100,
				Count = 2
			});
			_cart.AddCartItem(new CartItem
			{
				ID = 2,
				Name = "Harry Potter (Book 2)",
				Price = 100,
				Count = 1
			});
			_cart.AddCartItem(new CartItem
			{
				ID = 3,
				Name = "Harry Potter (Book 3)",
				Price = 100,
				Count = 3
			});
			_cart.AddCartItem(new CartItem
			{
				ID = 4,
				Name = "Harry Potter (Book 4)",
				Price = 100,
				Count = 4
			});
			_cart.AddCartItem(new CartItem
			{
				ID = 5,
				Name = "Harry Potter (Book 5)",
				Price = 100,
				Count = 1
			});

			// act
			int actual = _cart.GetTotalPrice();
			int expected = 935;

			// assert
			Assert.AreEqual(expected, actual);
		}
	}
}
