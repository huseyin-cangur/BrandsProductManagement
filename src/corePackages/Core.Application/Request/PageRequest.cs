

namespace Core.Application.Request
{
    public class PageRequest
    {
        public int? PageIndex { get; set; }
        public int? PageSize { get; set; }
        public bool IsValid =>
       PageIndex.HasValue && PageSize.HasValue;
    }
}