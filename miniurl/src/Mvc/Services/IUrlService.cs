namespace miniUrl.Mvc.Services {
    using Models;

    public interface IUrlService {
        bool IsValidUrlId(string shortUrl);
        UrlEntity GetUrl(string shortUrl);
        UrlEntity GetByOriginalUrl(string shortUrl);
        UrlEntity Minimize(string longUrl);
        void AddViewCount(string shortUrl);
        bool ContainsUrl(string longUrl);
    }
}
