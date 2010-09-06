namespace miniUrl.Models {
    public static class UrlExt {
        public static UrlEntity ToModel(this Url record) {
            return new UrlEntity
                       {
                           Created = record.CreatedDate,
                           Id = record.Id,
                           Url = record.LongUrl,
                           UrlHash = record.Hash,
                           Views = record.UrlViews.Count
                       };
        }
    }
}
