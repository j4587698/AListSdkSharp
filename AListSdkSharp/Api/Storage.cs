using System;
using System.Threading;
using System.Threading.Tasks;
using AListSdkSharp.Vo;
using Flurl.Http;

namespace AListSdkSharp.Api
{
    public class Storage
    {
        private readonly Uri _baseUri;
        
        public Storage(string baseUrl)
        {
            _baseUri = new Uri(baseUrl);
        }
        
        /// <summary>
        /// 获取所有存储列表
        /// </summary>
        /// <param name="token"></param>
        /// <param name="page">页码，默认为null</param>
        /// <param name="prePage">每页条数，默认为null</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<StorageListOut> List(string token, int? page = null, int? prePage = null, CancellationToken cancellationToken = default)
        {
            return new Uri(_baseUri, $"/api/admin/storage/list?page={page}&prePage={prePage}")
                .WithHeader("Authorization", token)
                .GetJsonAsync<StorageListOut>(cancellationToken: cancellationToken);
        }
        
        /// <summary>
        /// 启用存储
        /// </summary>
        /// <param name="token"></param>
        /// <param name="id">存储id，从list中获取</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<Base> Enable(string token, int id, CancellationToken cancellationToken = default)
        {
            return new Uri(_baseUri, $"/api/admin/storage/enable?id={id}")
                .WithHeader("Authorization", token)
                .PostAsync(cancellationToken: cancellationToken)
                .ReceiveJson<Base>();
        }
        
        /// <summary>
        /// 禁用存储
        /// </summary>
        /// <param name="token"></param>
        /// <param name="id">存储id，从list中获取</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<Base> Disable(string token, int id, CancellationToken cancellationToken = default)
        {
            return new Uri(_baseUri, $"/api/admin/storage/disable?id={id}")
                .WithHeader("Authorization", token)
                .PostAsync(cancellationToken: cancellationToken)
                .ReceiveJson<Base>();
        }
    }
}