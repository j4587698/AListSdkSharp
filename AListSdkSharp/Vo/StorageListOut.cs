using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AListSdkSharp.Vo
{
    public class StorageListOut: Base
    {
        public StorageListOutData Data { get; set; }
        
        public class StorageListOutData
        {
            public List<StorageListOutContent> Content { get; set; }
            
            public int Total { get; set; }
        }
        
        public class StorageListOutContent
        {
            public int Id { get; set; }

            [JsonPropertyName("mount_path")]
            public string MountPath { get; set; }
            
            public int Order { get; set; }
            
            public string Driver { get; set; }

            [JsonPropertyName("cache_expiration")]
            public int CacheExpiration { get; set; }
            
            public string Status { get; set; }
            
            public string Addition { get; set; }
            
            public string Remark { get; set; }
            
            public DateTime Modified { get; set; }
            
            public bool Disabled { get; set; }

            [JsonPropertyName("enable_sign")]
            public bool EnableSign { get; set; }

            [JsonPropertyName("order_by")]
            public string OrderBy { get; set; }

            [JsonPropertyName("order_direction")]
            public string OrderDirection { get; set; }

            [JsonPropertyName("extract_folder")]
            public string ExtractFolder { get; set; }

            [JsonPropertyName("web_proxy")]
            public bool WebProxy { get; set; }

            [JsonPropertyName("webdav_policy")]
            public string WebdavPolicy { get; set; }

            [JsonPropertyName("down_proxy_url")]
            public string DownProxyUrl { get; set; }
        }
    }
}