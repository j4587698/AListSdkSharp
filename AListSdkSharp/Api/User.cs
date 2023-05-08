using System.Threading.Tasks;
using AListSdkSharp.Vo;
using Flurl.Http;

namespace AListSdkSharp.Api
{
    /// <summary>
    /// 用户相关接口
    /// </summary>
    public static class User
    {
        /// <summary>
        /// 获取用户token
        /// </summary>
        /// <param name="baseUrl"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public static async Task<LoginVo> GetToken(string baseUrl, string username, string password)
        {
            return await $"{baseUrl}/api/auth/login".PostJsonAsync(new { username, password }).ReceiveJson<LoginVo>();
        }
        
        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="baseUrl"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static async Task<UserInfoVo> GetMyProfile(string baseUrl, string token)
        {
            return await $"{baseUrl}/api/me".WithHeaders(new {Authorization = token}).GetJsonAsync<UserInfoVo>();
        }
    }
}