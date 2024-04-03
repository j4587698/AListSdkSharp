using System;
using System.Threading.Tasks;
using AListSdkSharp.Vo;
using Flurl.Http;

namespace AListSdkSharp.Api
{
    /// <summary>
    /// 验证相关接口
    /// </summary>
    public class Auth
    {
        private readonly Uri _baseUri;

        public Auth(string baseUrl)
        {
            _baseUri = new Uri(baseUrl);
        }
        
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public Task<Login> Login(string username, string password)
        {
            return new Uri(_baseUri, "/api/auth/login")
                .PostJsonAsync(new { username, password })
                .ReceiveJson<Login>();
        }

        /// <summary>
        /// Hash方式登录
        /// </summary>
        /// <param name="username"></param>
        /// <param name="passwordHash"></param>
        /// <param name="optCode"></param>
        /// <returns></returns>
        public Task<Login> LoginHash(string username, string passwordHash, string optCode)
        {
            return new Uri(_baseUri, "/api/auth/login/hash")
                .PostJsonAsync(new { username, password = passwordHash, otp_code= optCode })
                .ReceiveJson<Login>();
        }

        /// <summary>
        /// 创建2FA认证
        /// </summary>
        /// <param name="token"></param>
        public Task<FaOut> Generate2FA(string token)
        {
            return new Uri(_baseUri, "/api/auth/2fa/generate")
                .WithHeader("Authorization", token)
                .PostAsync()
                .ReceiveJson<FaOut>();
        }

        /// <summary>
        /// 验证2FA
        /// </summary>
        /// <param name="token"></param>
        /// <param name="code"></param>
        /// <param name="secret"></param>
        /// <returns></returns>
        public Task<Base> Verify2FA(string token, string code, string secret)
        {
            return new Uri(_baseUri, "/api/auth/2fa/verify")
                .WithHeader("Authorization", token)
                .PostJsonAsync(new { code, secret })
                .ReceiveJson<Base>();
        }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<UserInfoOut> GetUserInfo(string token)
        {
            return new Uri(_baseUri, "/api/me")
                .WithHeader("Authorization", token)
                .GetAsync()
                .ReceiveJson<UserInfoOut>();
        }
    }
}