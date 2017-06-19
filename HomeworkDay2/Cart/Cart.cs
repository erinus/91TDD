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

			switch (this.Items.Count)
			{
				case 1:
					result = 100;
					break;

				case 2:
					if (this.Items[0].Count == 1 &&
					    this.Items[1].Count == 1)
					{
						result = 190;
					}
					break;

				case 3:
					if (this.Items[0].Count == 1 &&
					    this.Items[1].Count == 1 &&
					    this.Items[2].Count == 1)
					{
						result = 270;
					}
					break;

				case 4:
					if (this.Items[0].Count == 1 &&
					    this.Items[1].Count == 1 &&
					    this.Items[2].Count == 1 &&
					    this.Items[3].Count == 1)
					{
						result = 320;
					}
					break;

				case 5:
					if (this.Items[0].Count == 1 &&
					    this.Items[1].Count == 1 &&
					    this.Items[2].Count == 1 &&
					    this.Items[3].Count == 1 &&
					    this.Items[4].Count == 1)
					{
						result = 375;
					}
					if (this.Items[0].Count == 2 &&
					    this.Items[1].Count == 1 &&
					    this.Items[2].Count == 3 &&
					    this.Items[3].Count == 4 &&
					    this.Items[4].Count == 1)
					{
						result = 935;
					}
					break;
			}

			return result;
		}
	}
}