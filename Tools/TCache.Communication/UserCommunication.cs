using System.Threading.Tasks;
using TCache.Communication.Dtos;

namespace TCache.Communication
{
    public class UserCommunication
    {
        public async Task<cm_GetUsersToTestCacheOuput> GetUsersToTestCache(cm_GetUsersToTestCacheInput input)
        {
            return await testClient.GetUsersToTestCache(input);
        }

        private string _tenatName;
        private string _userName;
        private string _password;
        private string _baseUrl;

        UserApiCommunication testClient;

        public UserCommunication(string tenatName, string userName, string password, string baseUrl)
        {
            _tenatName = tenatName;
            _userName = userName;
            _password = password;
            _baseUrl = baseUrl;
            Initialize();
        }

        public UserCommunication(string baseUrl)
        {
            _baseUrl = baseUrl;

            testClient = new UserApiCommunication();
            testClient.BaseUrl = _baseUrl;
        }

        private void Initialize()
        {

            testClient = new UserApiCommunication();
            testClient.BaseUrl = _baseUrl;

            testClient.UserName = _userName;
            testClient.Password = _password;
            testClient.TenancyName = _tenatName;

            testClient.TokenBasedAuth();
        }
    }
}
