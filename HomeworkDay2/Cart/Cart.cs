using System.Collections.Generic;

namespace Cart
{
	public class Cart
	{
		public List<CartItem> Items = new List<CartItem>();

		public void AddItem(CartItem cartItem)
		{
			this.Items.Add(cartItem);
		}

		public int GetTotalPrice()
		{
			int result = 0;
			
			foreach (CartItem cartItem in this.Items)
			{
				result += (cartItem.Price * cartItem.Count);
			}

			return result;
		}
	}
}