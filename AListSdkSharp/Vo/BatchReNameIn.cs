using System.Text.Json.Serialization;

namespace AListSdkSharp.Vo
{
    public class BatchReNameIn
    {
        [JsonPropertyName("rename_objects")]
        public RenameObjectData[] RenameObjects { get; set; }

        /// <summary>
        /// 源目录
        /// </summary>
        [JsonPropertyName("src_dir")]
        public string SrcDir { get; set; }
        
        public partial class RenameObjectData
        {
            /// <summary>
            /// 新文件名
            /// </summary>
            [JsonPropertyName("new_name")]
            public string NewName { get; set; }

            /// <summary>
            /// 原文件名
            /// </summary>
            [JsonPropertyName("src_name")]
            public string SrcName { get; set; }
        }
    }
}