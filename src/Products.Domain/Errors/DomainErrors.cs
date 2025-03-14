using Products.Domain.Shared;

namespace Products.Domain.Errors
{
    public static class DomainErrors
    {
        public static class Name
        {
            public static readonly Error Empty = new(
                "Name.Empty",
                "Name is empty.");

            public static readonly Error TooLong = new(
                "Name.TooLong",
                "Name name is too long.");
        }
    }

}
