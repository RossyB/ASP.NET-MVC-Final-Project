namespace BookStore.Common
{
    public class ValidationConstants
    {
        public const int UserNameMinLength = 3;
        public const int UserNameMaxLength = 20;

        public const int UserStringMinLength = 3;
        public const int UserStringMaxLength = 50;

        public const int UserImageUrlMinLength = 3;
        public const int UserImageUrlMaxLength = 200;

        public const int CategoryMinLength = 5;
        public const int CategoryMaxLength = 50;

        public const int BookTitleMinLength = 3;
        public const int BookTitleMaxLength = 50;

        public const int BookAuthorMinLength = 3;
        public const int BookAuthorMaxLength = 50;

        public const int BookImageUrlMinLength = 10;
        public const int BookImageUrlMaxLength = 200;

        public const string BookPriceMinValue = "0.01";
        public const string BookPriceMaxValue = "999999999.99";

        public const int BookDescriptionMinLength = 50;
        public const int BookDescriptionMaxLength = 1000;

        public const string BookRatingMinValue = "0";
        public const string BookRatingMaxValue = "10";

        public const int CommentContentMinLength = 10;
        public const int CommentContentMaxLength = 500;

        public const string MinLengthFieldErrorMessage = "Field {0} must be min {1} symbols";
        public const string MaxLengthFieldErrorMessage = "Field {0} must be max {1} symbols";
        public const string PriceOutOfRangeErrorMessage = "{0} Invalid price - 0,01, 999 999 999.99.";
        public const string RatingOutOfRangeErrorMessage = "{0} Invalid range, must be between - 0 and 10.";

    }
}
