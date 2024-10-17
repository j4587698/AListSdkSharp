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
        
        public Task<StorageListOut> List(string token, int page, int prePage, CancellationToken cancellationToken = default)
        {
            return new Uri(_baseUri, $"/api/admin/storage/list?page={page}&prePage={prePage}")
                .WithHeader("Authorization", token)
                .GetJsonAsync<StorageListOut>(cancellationToken: cancellationToken);
        }
    }
}