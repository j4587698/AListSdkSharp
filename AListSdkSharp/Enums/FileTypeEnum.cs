using System.ComponentModel;

namespace AListSdkSharp.Enums
{
    /// <summary>
    /// 文件类型枚举
    /// </summary>
    public enum FileTypeEnum
    {
        [Description("未知")]
        Unknown = 0,
        [Description("文件夹")]
        Folder = 1,
        [Description("视频")]
        Video = 2,
        [Description("音频")]
        Audio = 3,
        [Description("文本")]
        Text = 4,
        [Description("图片")]
        Image = 5,
    }
}