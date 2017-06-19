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

			while (this.GetTotalCountOfCartItems(cartItems) > 0)
			{
				SaleItem saleItem = this.GetSaleItemInCartItems(cartItems);

				if (saleItem == null)
				{
					foreach (CartItem cartItem in cartItems)
					{
						result += (cartItem.Price * cartItem.Count);
					}
					break;
				}

				int subTotal = 0;
				int combination = saleItem.Combination;
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