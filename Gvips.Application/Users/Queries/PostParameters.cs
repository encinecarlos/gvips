namespace Gvips.Application.Users.Queries
{
    public class PostParameters
    {
        const int MaxPageSize = 150;
        public int PageNumber { get; set; } = 1;
        private int _PageSize = 100;

        public int PageSize
        {
            get
            {
                return _PageSize;
            }
            set
            {
                _PageSize = (value > MaxPageSize) ? MaxPageSize : value;
            }
        }
    }
}