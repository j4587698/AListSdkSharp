using System;
using System.Text.Json.Serialization;
using AListSdkSharp.Enums;

namespace AListSdkSharp.Vo
{
    public class InfoOut : Base
    {
        public InfoData Data { get; set; }
        
        public class InfoData
        {
            [JsonPropertyName("is_dir")]
            public bool IsDir { get; set; }

            public DateTime Modified { get; set; }

            public string Name { get; set; }

            public string Provider { get; set; }

            [JsonPropertyName("raw_url")]
            public string RawUrl { get; set; }

            public string Readme { get; set; }

            public string Related { get; set; }

            public string Sign { get; set; }

            public long Size { get; set; }

            public string Thumb { get; set; }
            
            /// <summary>
            /// 文件类型
            /// </summary>
            public FileTypeEnum Type { get; set; }
        }
    }
}