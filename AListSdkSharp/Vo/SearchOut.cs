using System.Text.Json.Serialization;

namespace AListSdkSharp.Vo
{
    public class SearchOut: Base
    {
        public SearchData Data { get; set; }
        
        public class SearchData
        {
            public ContentData[] Content { get; set; }

            /// <summary>
            /// 总数
            /// </summary>
            public long Total { get; set; }
        }

        public class ContentData
        {
            /// <summary>
            /// 是否是文件夹
            /// </summary>
            [JsonPropertyName("is_dir")]
            public bool IsDir { get; set; }

            /// <summary>
            /// 文件名
            /// </summary>
            public string Name { get; set; }

            /// <summary>
            /// 路径
            /// </summary>
            public string Parent { get; set; }

            /// <summary>
            /// 大小
            /// </summary>
            public long Size { get; set; }

            /// <summary>
            /// 类型
            /// </summary>
            public long Type { get; set; }
        }
    }
}