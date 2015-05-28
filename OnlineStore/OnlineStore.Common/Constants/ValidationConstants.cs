namespace OnlineStore.Common.Constants
{
    using System.Collections.Generic;

    public class ValidationConstants
    {
        public const int ProductNameMinLength = 5;

        public const int ProductNameMaxLength = 100;

        public const int ProductDescriptionMinLength = 10;

        public const int ProductDescriptionMaxLength = 1000;

        public const int ProductMinPrice = 0;

        public const int ProductMaxPrice = int.MaxValue;

        public const int ProductMinQuantity = 0;

        public const int ProductMaxQuantity = int.MaxValue;

        public const int PictureMaxSize = 1 * 1024 * 1024;

        public static readonly IList<string> AllowedPictureFormats = new List<string> { ".png", ".jpg", ".jpeg" }.AsReadOnly();
    }
}
