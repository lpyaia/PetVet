namespace PetVet.Domain.Common
{
    public static class StringExtensions
    {
        public static bool IsNullOrEmpty(this string value)
        {
            return string.IsNullOrEmpty(value);
        }

        public static bool IsNotNullAndNotEmpty(this string value)
        {
            return !value.IsNullOrEmpty();
        }
    }
}