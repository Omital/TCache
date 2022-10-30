using Abp.Application.Services.Dto;
using System.Collections.Generic;

namespace TCache.Users.Dto
{
    public class GetUsersToTestCacheOutput
    {
        public List<NameValueDto> Data { get; set; }
        public bool LoadedFromCache { get; set; }
    }
}
