using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using AListSdkSharp.Vo;
using Flurl.Http;

namespace AListSdkSharp.Api
{
    /// <summary>
    /// 对象相关接口
    /// </summary>
    public static class Fs
    {
        /// <summary>
        /// 列出目录下的文件和文件夹
        /// </summary>
        /// <param name="baseUrl"></param>
        /// <param name="token"></param>
        /// <param name="listInVo"></param>
        /// <returns></returns>
        public static async Task<ListOutVo> List(string baseUrl, string token, ListInVo listInVo)
        {
            return await $"{baseUrl}/api/fs/list".WithHeaders(new {Authorization = token}).PostJsonAsync(listInVo).ReceiveJson<ListOutVo>();
        }

        /// <summary>
        /// 获取文件信息
        /// </summary>
        /// <param name="baseUrl"></param>
        /// <param name="token"></param>
        /// <param name="path"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static async Task<InfoVo> Info(string baseUrl, string token, string path, string password = "")
        {
            return await $"{baseUrl}/api/fs/get".WithHeaders(new {Authorization = token}).PostJsonAsync(new {path, password}).ReceiveJson<InfoVo>();
        }

        /// <summary>
        /// 创建文件夹
        /// </summary>
        /// <param name="baseUrl"></param>
        /// <param name="token"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static async Task<BaseVo> MkDir(string baseUrl, string token, string path)
        {
            return await $"{baseUrl}/api/fs/mkdir".WithHeaders(new {Authorization = token}).PostJsonAsync(new {path}).ReceiveJson<BaseVo>();
        }
        
        /// <summary>
        /// 上传文件，Path需要包含路径和文件名
        /// </summary>
        /// <param name="baseUrl"></param>
        /// <param name="token"></param>
        /// <param name="path">包含路径和文件名</param>
        /// <param name="stream"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static async Task<BaseVo> Upload(string baseUrl, string token, string path, Stream stream, string password = "")
        {
            var headers = new Dictionary<string, string>();
            headers.Add("Authorization", token);
            headers.Add("File-Path", HttpUtility.UrlEncode(path));
            headers.Add("Password", password);
            return await $"{baseUrl}/api/fs/put".WithHeaders(headers).PutAsync(new StreamContent(stream)).ReceiveJson<BaseVo>();
        }

        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="baseUrl"></param>
        /// <param name="token"></param>
        /// <param name="dir">文件所在目录</param>
        /// <param name="names">要删除的文件列表，可以为目录</param>
        public static async Task<BaseVo> Remove(string baseUrl, string token, string dir, params string[] names)
        {
            return await $"{baseUrl}/api/fs/remove".WithHeaders(new {Authorization = token}).PostJsonAsync(new {dir, names}).ReceiveJson<BaseVo>();
        }
        
        /// <summary>
        /// 移动文件或文件夹
        /// </summary>
        /// <param name="baseUrl"></param>
        /// <param name="token"></param>
        /// <param name="dir"></param>
        /// <param name="targetDir"></param>
        /// <param name="names">内容列表，可以包括文件和文件夹名称</param>
        /// <returns></returns>
        public static async Task<BaseVo> Move(string baseUrl, string token, string dir, string targetDir, params string[] names)
        {
            return await $"{baseUrl}/api/fs/move".WithHeaders(new {Authorization = token}).PostJsonAsync(new {src_dir = dir, dst_dir = targetDir, names}).ReceiveJson<BaseVo>();
        }
        
        /// <summary>
        /// 复制文件或文件夹
        /// </summary>
        /// <param name="baseUrl"></param>
        /// <param name="token"></param>
        /// <param name="dir"></param>
        /// <param name="targetDir"></param>
        /// <param name="names">内容列表，可以包括文件和文件夹名称</param>
        /// <returns></returns>
        public static async Task<BaseVo> Copy(string baseUrl, string token, string dir, string targetDir, params string[] names)
        {
            return await $"{baseUrl}/api/fs/copy".WithHeaders(new {Authorization = token}).PostJsonAsync(new {src_dir = dir, dst_dir = targetDir, names}).ReceiveJson<BaseVo>();
        }
        
        /// <summary>
        /// 重命名文件或文件夹
        /// </summary>
        /// <param name="baseUrl"></param>
        /// <param name="token"></param>
        /// <param name="path">要改名的全路径</param>
        /// <param name="name">新文件名</param>
        /// <returns></returns>
        public static async Task<BaseVo> Rename(string baseUrl, string token, string path, string name)
        {
            return await $"{baseUrl}/api/fs/rename".WithHeaders(new {Authorization = token}).PostJsonAsync(new {path, name}).ReceiveJson<BaseVo>();
        }
    }
}