namespace WorkXyz.UI.ViewModel.Utility
{
    public class PageInfo
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages => (int) Math.Ceiling((double)TotalItems / PageSize);
        public bool HasPrevious => PageNumber > 0;
        public bool HasNext => PageNumber < TotalPages;

    }
}
