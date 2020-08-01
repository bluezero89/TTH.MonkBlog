using Volo.Abp.Application.Dtos;

namespace TTH.MonkBlog.Shared
{
    public class LookupRequestDto : PagedResultRequestDto
    {
        public string Filter { get; set; }
    }
}