namespace miniUrl.Mvc.Services {
    using System;
    using System.Linq;
    using Models;

    public class UrlService : IUrlService {
        public UrlService()
            : this(new UrlHasher()) {
        }

        public UrlService(UrlHasher hasher) {
            Hasher = hasher;
        }

        public UrlHasher Hasher { get; private set; }

        public bool IsValidUrlId(string shortUrl) {
            if (string.IsNullOrEmpty(shortUrl)) return false;

            using (var context = new MiniUrlDataContext()) {
                return context.Urls.Any(url => shortUrl == url.Hash);
            }
        }

        public UrlEntity GetUrl(string shortUrl) {
            if (string.IsNullOrEmpty(shortUrl)) return null;

            using (var context = new MiniUrlDataContext()) {
                var record = context.Urls
                    .Where(url => shortUrl == url.Hash)
                    .FirstOrDefault();

                return (record == null) ? null : record.ToModel();
            }
        }

        public UrlEntity GetByOriginalUrl(string longUrl) {
            if (string.IsNullOrEmpty(longUrl)) return null;

            using (var context = new MiniUrlDataContext()) {
                var record = context.Urls
                    .Where(url => longUrl == url.LongUrl)
                    .FirstOrDefault();

                return (record == null) ? null : record.ToModel();
            }
        }

        public UrlEntity Minimize(string longUrl) {
            var record = new Url
            {
                LongUrl = longUrl,
                CreatedDate = DateTime.UtcNow,
                Hash = Hasher.Hash(longUrl)
            };

            using (var context = new MiniUrlDataContext()) {


                context.Urls.InsertOnSubmit(record);
                context.SubmitChanges();
            }

            return record.ToModel();
        }

        public void AddViewCount(string shortUrl) {
            using (var context = new MiniUrlDataContext()) {
                var record = context.Urls
                    .Where(url => shortUrl == url.Hash)
                    .FirstOrDefault();

                var view = new UrlView { Url = record };
                record.UrlViews.Add(view);

                context.UrlViews.InsertOnSubmit(view);
                context.SubmitChanges();
            }
        }

        public bool ContainsUrl(string longUrl) {
            if (string.IsNullOrEmpty(longUrl)) return false;

            var hashedUrl = Hasher.Hash(longUrl);
            return IsValidUrlId(hashedUrl);
        }
    }
}