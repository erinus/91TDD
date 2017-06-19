using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Dynamic;
using System.Linq;

namespace Cart
{
	public class Cart
	{
		public List<SaleItem> SaleItems = new List<SaleItem>();
		public List<CartItem> CartItems = new List<CartItem>();

		public void AddSaleItem(SaleItem saleItem)
		{
			this.SaleItems.Add(saleItem);
		}

		public void AddCartItem(CartItem cartItem)
		{
			this.CartItems.Add(cartItem);
		}

		public int GetTotalPrice()
		{
			int result = 0;

			List<CartItem> cartItems = new List<CartItem>(this.CartItems);

			// 當購物車裡還有未納入計算的購物項目時繼續執行
			while (this.GetTotalCountOfCartItems(cartItems) > 0)
			{
				// 取出最符合的優惠項目
				SaleItem saleItem = this.GetSaleItemInCartItems(cartItems);

				// 如果找不到優惠項目則將剩下未納入計算的購物項目依原價計算
				if (saleItem == null)
				{
					foreach (CartItem cartItem in cartItems)
					{
						result += (cartItem.Price * cartItem.Count);
					}
					break;
				}

				// 優惠項目小計
				int subTotal = 0;
				// 優惠項目所需不同項目數量
				int combination = saleItem.Combination;
				// 依照優惠項目扣除對應購物項目數量，扣除購物項目價格依優惠比例計算
				foreach (CartItem cartItem in cartItems)
				{
					if (cartItem.Count > 0)
					{
						cartItem.Count--;
						combination--;
						subTotal += Convert.ToInt32(cartItem.Price * saleItem.Percent);
						if (combination == 0)
						{
							break;
						}
					}
				}
				result += subTotal;
			}

			return result;
		}

		private int GetTotalCountOfCartItems(List<CartItem> cartItems)
		{
			int result = 0;

			foreach (CartItem cartItem in cartItems)
			{
				result += cartItem.Count;
			}

			return result;
		}

		private SaleItem GetSaleItemInCartItems(List<CartItem> cartItems)
		{
			List<SaleItem> matchedSaleItems = new List<SaleItem>();

			foreach (SaleItem saleItem in this.SaleItems)
			{
				// 判斷購物清單是否符合優惠項目
				if (this.IsMatchedSaleItem(cartItems, saleItem))
				{
					matchedSaleItems.Add(saleItem);
				}
			}

			if (matchedSaleItems.Count == 0)
			{
				return null;
			}

			SaleItem matchedSaleItem = null;

			foreach (SaleItem saleItem in matchedSaleItems)
			{
				if (matchedSaleItem == null)
				{
					matchedSaleItem = saleItem;
					continue;
				}
				// 優惠項目優先規則，不同購物項目符合數越多者優先
				if (matchedSaleItem.Combination < saleItem.Combination)
				{
					matchedSaleItem = saleItem;
				}
			}

			return matchedSaleItem;
		}

		private bool IsMatchedSaleItem(List<CartItem> cartItems, SaleItem saleItem)
		{
			int combination = 0;

			foreach (CartItem cartItem in cartItems)
			{
				if (cartItem.Count > 0)
				{
					combination++;
				}
			}

			return combination >= saleItem.Combination;
		}
	}
}