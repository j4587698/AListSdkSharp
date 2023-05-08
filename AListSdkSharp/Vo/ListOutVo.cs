using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using AListSdkSharp.Enums;

namespace AListSdkSharp.Vo
{
    /// <summary>
    /// 列表输出参数
    /// </summary>
    public class ListOutVo : BaseVo
    {
        /// <summary>
        /// 内容
        /// </summary>
        public ListOutData Data { get; set; }
        
        /// <summary>
        /// 输出内容
        /// </summary>
        public class ListOutData
        {
            /// <summary>
            /// 文件列表
            /// </summary>
            public List<ContentData> Content { get; set; }

            /// <summary>
            /// 提供程序
            /// </summary>
            public string Provider{ get; set; }

            /// <summary>
            /// 说明文档
            /// </summary>
            public string Readme { get; set; }

            /// <summary>
            /// 数据总条数
            /// </summary>
            public int Total { get; set; }

            /// <summary>
            /// 是否可写
            /// </summary>
            public bool Write { get; set; }
        }
        
        /// <summary>
        /// 内容
        /// </summary>
        public class ContentData
        {
            /// <summary>
            /// 是否为文件夹
            /// </summary>
            [JsonPropertyName("is_dir")]
            public bool IsDir { get; set; }

            /// <summary>
            /// 最后修改时间
            /// </summary>
            public DateTime Modified { get; set; }

            /// <summary>
            /// 文件名
            /// </summary>
            public string Name { get; set; }

            /// <summary>
            /// 文件签名
            /// </summary>
            public string Sign { get; set; }

            /// <summary>
            /// 文件大小
            /// </summary>
            public long Size { get; set; }

            /// <summary>
            /// 缩略图
            /// </summary>
            public string Thumb { get; set; }

            /// <summary>
            /// 文件类型
            /// </summary>
            public FileTypeEnum Type { get; set; }
        }
    }
}