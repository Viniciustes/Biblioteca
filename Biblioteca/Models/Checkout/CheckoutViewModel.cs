using System;

namespace Biblioteca.Models.Checkout
{
    public class CheckoutViewModel
    {
        public CheckoutViewModel() { }

        public CheckoutViewModel(string libraryCardId, string title, Guid assetId, string imageUrl, bool isCheckedOut)
        {
            LibraryCardId = libraryCardId;
            Title = title;
            AssetId = assetId;
            ImageUrl = imageUrl;
            IsCheckedOut = isCheckedOut;
        }

        public string LibraryCardId { get; set; }
        public string Title { get; set; }
        public Guid AssetId { get; set; }
        public string ImageUrl { get; set; }
        public int HoldCount { get; set; }
        public bool IsCheckedOut { get; set; }
    }
}
