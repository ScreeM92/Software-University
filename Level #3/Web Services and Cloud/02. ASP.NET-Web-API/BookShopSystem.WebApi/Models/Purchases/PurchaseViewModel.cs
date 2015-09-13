namespace BookShopSystem.WebApi.Models.Purchases
{
    using System;
    using BookShopSystem.Models;

    public class PurchaseViewModel
    {
        public int Id { get; set; }

        public string BookTitle { get; set; }

        public decimal Price { get; set; }

        public DateTime DateOfPurchase { get; set; }

        public bool IsRecalled { get; set; }

        public static PurchaseViewModel Create(Purchase purchase)
        {
            var purchaseView = new PurchaseViewModel
            {
                Id = purchase.Id,
                BookTitle = purchase.Book.Title,
                Price = purchase.Price,
                DateOfPurchase = purchase.DateOfPurchase,
                IsRecalled = purchase.IsRecalled
            };

            return purchaseView;
        }
    }
}