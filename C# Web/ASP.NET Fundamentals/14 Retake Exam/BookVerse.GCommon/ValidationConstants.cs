﻿namespace BookVerse.GCommon
{
    public class ValidationConstants
    {
        public static class Book
        {
            public const int BookTitleMinLength = 3;
            public const int BookTitleMaxLength = 80;

            public const int BookDescriptionMinLength = 10;
            public const int BookDescriptionMaxLength = 250;

            public const string BookDateFormat = "dd-MM-yyyy";
        }

        public static class Genre
        {
            public const int GenreNameMinLength = 3;
            public const int GenreNameMaxLength = 20;
        }
    }
}
