using System.Threading.Tasks;
using TCache.Communication.Dtos;

namespace TCache.Communication
{
    public class UserApiCommunication : ADS.ApiCommunication.CallApiClient
    {

        public async Task<cm_GetUsersToTestCacheOuput> GetUsersToTestCache(cm_GetUsersToTestCacheInput input)
        {
            return await _ADSWebApiClient.PostAsync<cm_GetUsersToTestCacheOuput>(BaseUrl + _baseApiAddress + "GetUsersToTestCache", input);
        }


        private readonly static string _baseApiAddress = "api/services/app/user/";
    }
}
