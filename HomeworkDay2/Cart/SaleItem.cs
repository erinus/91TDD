using System.Collections.Generic;

namespace Cart
{
	public class SaleItem
	{
		public List<CartItem> RelatedCartItems { get; set; }
		public int Combination { get; set; }
		public float Percent { get; set; }
	}
}