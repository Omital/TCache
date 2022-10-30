using System.Collections.Generic;

namespace TCache.Communication.Dtos
{
    public class cm_GetUsersToTestCacheOuput
    {
        public List<NameValue> Data { get; set; }
        public bool LoadedFromCache { get; set; }
    }
}
