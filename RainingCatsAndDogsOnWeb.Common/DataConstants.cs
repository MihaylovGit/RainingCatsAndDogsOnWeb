namespace RainingCatsAndDogsOnWeb.Common
{
    public static class DataConstants
    {
        public class Ad
        {
            public const int AdTitleMaxLength = 100;

            public const int AdTitleMinLength = 10;

            public const int AdLocationMaxLength = 50;

            public const int AdLocationMinLength = 4;

            public const int AdDescriptionMaxLength = 1000;

            public const int AdDescriptionMinLength = 20;
        }

        public class ApplicationUser
        {
            public const int ApplicationUserFirstNameMaxLength = 20;

            public const int ApplicationUserFirstNameMinLength = 3;

            public const int ApplicationUserLastNameMaxLength = 20;

            public const int ApplicationUserLastNameMinLength = 3;

            public const int ApplicationUserPhoneNumberMaxLength = 15;
        }

        public class Category
        {
            public const int CategoryNameMaxLength = 20;

            public const int CategoryNameMinLength = 3;
        }

        public class Comment
        {
            public const int CommentContentMaxLength = 500;
        }

        public class Reply
        {
            public const int ReplyContentMaxLength = 500;
        }

        public class Blog
        {
            public const int BlogTitleMaxLength = 100;

            public const int BlogContentMaxLength = 500;
        }

        public class Post
        {
            public const int PostContentMaxLength = 500;
        }
    }
}

