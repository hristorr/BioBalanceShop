namespace BioBalanceShop.Models
{
    public class CartCookieModel
    {
        public List<CartItemCookieModel> Items { get; set; } = new List<CartItemCookieModel>();

        public void AddProduct(int productId, int quantity)
        {
            var prodInCart = Items.FirstOrDefault(i => i.ProductId == productId);
            if (prodInCart != null)
            {
                prodInCart.Quantity += quantity;
            }
            else
            {
                Items.Add(new CartItemCookieModel { ProductId = productId, Quantity = quantity });
            }
        }
    }
}
