using System.Text.Json.Serialization;

namespace AListSdkSharp.Vo
{
    /// <summary>
    /// 列表读取参数
    /// </summary>
    public class ListInVo
    {
        /// <summary>
        /// 第几页
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// 文件夹密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 访问路径
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// 每页条数
        /// </summary>
        [JsonPropertyName("pre_page")]
        public int PrePage { get; set; }

        /// <summary>
        /// 是否需要刷新
        /// </summary>
        public bool Refresh { get; set; }
    }
}