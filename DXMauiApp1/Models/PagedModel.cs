namespace DXMauiApp1.Models
{
    public class PagedModel<T> where T : class
    {
        public int TotalCount { get; set; }

        public List<T> Items { get; set; } = new List<T>();
    }
}