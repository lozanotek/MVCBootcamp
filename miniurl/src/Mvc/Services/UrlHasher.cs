namespace miniUrl.Mvc.Services {
    using System.Security.Cryptography;
    using System.Text;

    public class UrlHasher {
        const string chars = "abcdefghijkmnopqrstuvwxyz1234567890";

        public string Hash(string url) {
            var urlBytes = Encoding.Default.GetBytes(url);
            var provider = new SHA1CryptoServiceProvider();
            
            urlBytes = provider.ComputeHash(urlBytes, 0, urlBytes.Length);
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < 6; i++) {
                var b = urlBytes[i];
                result.Append(chars[b % (chars.Length - 1)]);
            }

            return result.ToString();
        }
    }
}
