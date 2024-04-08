using System;
using System.Threading;
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
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<Login> Login(string username, string password, CancellationToken cancellationToken = default)
        {
            return new Uri(_baseUri, "/api/auth/login")
                .PostJsonAsync(new { username, password }, cancellationToken: cancellationToken)
                .ReceiveJson<Login>();
        }

        /// <summary>
        /// Hash方式登录
        /// </summary>
        /// <param name="username"></param>
        /// <param name="passwordHash"></param>
        /// <param name="optCode"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<Login> LoginHash(string username, string passwordHash, string optCode, CancellationToken cancellationToken = default)
        {
            return new Uri(_baseUri, "/api/auth/login/hash")
                .PostJsonAsync(new { username, password = passwordHash, otp_code= optCode }, cancellationToken: cancellationToken)
                .ReceiveJson<Login>();
        }

        /// <summary>
        /// 创建2FA认证
        /// </summary>
        /// <param name="token"></param>
        /// <param name="cancellationToken"></param>
        public Task<FaOut> Generate2FA(string token, CancellationToken cancellationToken = default)
        {
            return new Uri(_baseUri, "/api/auth/2fa/generate")
                .WithHeader("Authorization", token)
                .PostAsync(cancellationToken: cancellationToken)
                .ReceiveJson<FaOut>();
        }

        /// <summary>
        /// 验证2FA
        /// </summary>
        /// <param name="token"></param>
        /// <param name="code"></param>
        /// <param name="secret"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<Base> Verify2FA(string token, string code, string secret, CancellationToken cancellationToken = default)
        {
            return new Uri(_baseUri, "/api/auth/2fa/verify")
                .WithHeader("Authorization", token)
                .PostJsonAsync(new { code, secret }, cancellationToken: cancellationToken)
                .ReceiveJson<Base>();
        }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="token"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<UserInfoOut> GetUserInfo(string token, CancellationToken cancellationToken = default)
        {
            return new Uri(_baseUri, "/api/me")
                .WithHeader("Authorization", token)
                .GetAsync(cancellationToken: cancellationToken)
                .ReceiveJson<UserInfoOut>();
        }
    }
}