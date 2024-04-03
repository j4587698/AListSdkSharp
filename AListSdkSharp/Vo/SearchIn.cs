using System.Text.Json.Serialization;
using AListSdkSharp.Enums;

namespace AListSdkSharp.Vo
{
    public class SearchIn
    {
        /// <summary>
        /// 关键词
        /// </summary>
        public string Keywords { get; set; }

        /// <summary>
        /// 页数
        /// </summary>
        public long Page { get; set; }

        /// <summary>
        /// 搜索目录
        /// </summary>
        public string Parent { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 每页数目
        /// </summary>
        [JsonPropertyName("per_page")]
        public long PerPage { get; set; }

        /// <summary>
        /// 搜索类型，0-全部 1-文件夹 2-文件
        /// </summary>
        public ScopeEnum Scope { get; set; }
    }
}