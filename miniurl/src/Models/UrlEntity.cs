namespace miniUrl.Models {
    using System;

    [Serializable]
    public class UrlEntity {
        public int Id { get; set; }
        public string UrlHash { get; set; }
        public string Url { get; set; }
        public DateTime? Created { get; set; }
        public int Views { get; set; }
    }
}