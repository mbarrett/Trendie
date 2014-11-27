namespace Trendie.Core.Extensions
{
    public static class TweetExtensions
    {
        public static string ToSafeString(this string value)
        {
            value = value.Replace(" ", string.Empty);
            value = value.Replace("'", string.Empty);
            value = value.Replace("#", string.Empty);

            return value;
        } 
    }
}