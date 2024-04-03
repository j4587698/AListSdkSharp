using System;
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
    public class Fs
    {
        private readonly Uri _baseUri;
        
        public Fs(string baseUrl)
        {
            _baseUri = new Uri(baseUrl);
        }
        
        /// <summary>
        /// 列出文件目录
        /// </summary>
        /// <param name="token"></param>
        /// <param name="listIn"></param>
        /// <returns></returns>
        public Task<ListOut> List(string token, ListIn listIn)
        {
            return new Uri(_baseUri, "/api/fs/list")
                .WithHeader("Authorization", token)
                .PostJsonAsync(listIn)
                .ReceiveJson<ListOut>();
        }
        
        /// <summary>
        /// 获取某个文件/目录信息
        /// </summary>
        /// <param name="token"></param>
        /// <param name="listIn"></param>
        /// <returns></returns>
        public Task<InfoOut> Info(string token, ListIn listIn)
        {
            return new Uri(_baseUri, "/api/fs/get")
                .WithHeader("Authorization", token)
                .PostJsonAsync(listIn)
                .ReceiveJson<InfoOut>();
        }
        
        /// <summary>
        /// 获取目录
        /// </summary>
        /// <param name="token"></param>
        /// <param name="listIn"></param>
        /// <returns></returns>
        public Task<DirIn> Dir(string token, ListIn listIn)
        {
            return new Uri(_baseUri, "/api/fs/dirs")
                .WithHeader("Authorization", token)
                .PostJsonAsync(listIn)
                .ReceiveJson<DirIn>();
        }
        
        /// <summary>
        /// 搜索文件或文件夹
        /// </summary>
        /// <param name="token"></param>
        /// <param name="searchIn"></param>
        /// <returns></returns>
        public Task<SearchOut> Search(string token, SearchIn searchIn)
        {
            return new Uri(_baseUri, "/api/fs/search")
                .WithHeader("Authorization", token)
                .PostJsonAsync(searchIn)
                .ReceiveJson<SearchOut>();
        }
        
        /// <summary>
        /// 新建文件夹
        /// </summary>
        /// <param name="token"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public Task<Base> MkDir(string token, string path)
        {
            return new Uri(_baseUri, "/api/fs/mkdir")
                .WithHeader("Authorization", token)
                .PostJsonAsync(new {path})
                .ReceiveJson<Base>();
            
        }
        
        /// <summary>
        /// 重命名文件
        /// </summary>
        /// <param name="token"></param>
        /// <param name="path">全路径</param>
        /// <param name="name">新名字不支持/</param>
        public Task<Base> ReName(string token, string path, string name)
        {
            return new Uri(_baseUri, "/api/fs/rename")
                .WithHeader("Authorization", token)
                .PostJsonAsync(new {path, name})
                .ReceiveJson<Base>();
        }
        
        /// <summary>
        /// 批量重命名
        /// </summary>
        /// <param name="token"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        public Task<Base> BatchReName(string token, BatchReNameIn body)
        {
            return new Uri(_baseUri, "/api/fs/batch_rename")
                .WithHeader("Authorization", token)
                .PostJsonAsync(body)
                .ReceiveJson<Base>();
        }
        
        /// <summary>
        /// 正则重命名
        /// </summary>
        /// <param name="token"></param>
        /// <param name="srcDir">源目录</param>
        /// <param name="srcNameRegex">源文件匹配正则</param>
        /// <param name="newNameRegex">新文件名正则</param>
        public Task<Base> RegexReName(string token, string srcDir, string srcNameRegex, string newNameRegex)
        {
            return new Uri(_baseUri, "/api/fs/regex_rename")
                .WithHeader("Authorization", token)
                .PostJsonAsync(new {src_dir= srcDir, src_name_regex = srcNameRegex, new_name_regex = newNameRegex})
                .ReceiveJson<Base>();
        }

        /// <summary>
        /// 表单上传文件
        /// </summary>
        /// <param name="token"></param>
        /// <param name="filePath"></param>
        /// <param name="stream"></param>
        /// <returns></returns>
        public Task<Base> Upload(string token, string filePath, Stream stream)
        {
            var headers = new Dictionary<string, string>
            {
                { "Authorization", token },
                { "File-Path", HttpUtility.UrlEncode(filePath) }
            };
            return new Uri(_baseUri, "/api/fs/form")
                .WithHeaders(headers)
                .PutAsync(new StreamContent(stream))
                .ReceiveJson<Base>();
        }
        
        /// <summary>
        /// 移动文件
        /// </summary>
        /// <param name="token"></param>
        /// <param name="srcDir">源文件夹</param>
        /// <param name="dstDir">目标文件夹</param>
        /// <param name="names">文件名</param>
        /// <returns></returns>
        public Task<Base> Move(string token, string srcDir, string dstDir, params string[] names)
        {
            return new Uri(_baseUri, "/api/fs/move")
                .WithHeader("Authorization", token)
                .PostJsonAsync(new {src_dir = srcDir, dst_dir = dstDir, names})
                .ReceiveJson<Base>();
        }
        
        /// <summary>
        /// 复制文件
        /// </summary>
        /// <param name="token"></param>
        /// <param name="srcDir">源文件夹</param>
        /// <param name="dstDir">目标文件夹</param>
        /// <param name="names">文件名</param>
        /// <returns></returns>
        public Task<Base> Copy(string token, string srcDir, string dstDir, params string[] names)
        {
            return new Uri(_baseUri, "/api/fs/copy")
                .WithHeader("Authorization", token)
                .PostJsonAsync(new {src_dir = srcDir, dst_dir = dstDir, names})
                .ReceiveJson<Base>();
        }
        
        /// <summary>
        /// 删除文件或文件夹
        /// </summary>
        /// <param name="token"></param>
        /// <param name="dir"></param>
        /// <param name="names"></param>
        /// <returns></returns>
        public Task<Base> Remove(string token, string dir, params string[] names)
        {
            return new Uri(_baseUri, "/api/fs/remove")
                .WithHeader("Authorization", token)
                .PostJsonAsync(new {dir, names})
                .ReceiveJson<Base>();
        }
        
        /// <summary>
        /// 删除空文件夹
        /// </summary>
        /// <param name="token"></param>
        /// <param name="srcDir"></param>
        /// <returns></returns>
        public Task<Base> RemoveEmptyDir(string token, string srcDir)
        {
            return new Uri(_baseUri, "/api/fs/remove_empty_directory")
                .WithHeader("Authorization", token)
                .PostJsonAsync(new {src_dir = srcDir})
                .ReceiveJson<Base>();
        }
        
        /// <summary>
        /// 聚合移动
        /// </summary>
        /// <param name="token"></param>
        /// <param name="srcDir"></param>
        /// <param name="dstDir"></param>
        public Task<Base> RecursiveMove(string token, string srcDir, string dstDir)
        {
            return new Uri(_baseUri, "/api/fs/recursive_move")
                .WithHeader("Authorization", token)
                .PostJsonAsync(new {src_dir = srcDir, dst_dir = dstDir})
                .ReceiveJson<Base>();
        }
        
        /// <summary>
        /// 添加aria2下载
        /// </summary>
        /// <param name="token"></param>
        /// <param name="path"></param>
        /// <param name="urls"></param>
        /// <returns></returns>
        public Task<Base> AddAria2(string token, string path, params string[] urls)
        {
            return new Uri(_baseUri, "/api/fs/add_aria2")
                .WithHeader("Authorization", token)
                .PostJsonAsync(new {path, urls})
                .ReceiveJson<Base>();
        }
        
        /// <summary>
        /// 添加qBittorrent下载
        /// </summary>
        /// <param name="token"></param>
        /// <param name="path"></param>
        /// <param name="urls"></param>
        /// <returns></returns>
        public Task<Base> AddQBit(string token, string path, params string[] urls)
        {
            return new Uri(_baseUri, "/api/fs/add_qbit")
                .WithHeader("Authorization", token)
                .PostJsonAsync(new {path, urls})
                .ReceiveJson<Base>();
        }

        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="rawUrl"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public Task<Stream> Download(string rawUrl)
        {
            if (rawUrl == null)
            {
                throw new Exception("raw url is null");
            }
            return rawUrl.GetStreamAsync();
        }

        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="infoOut"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public Task<Stream> Download(InfoOut infoOut)
        {
            if (infoOut.Code != 200)
            {
                throw new Exception(infoOut.Message);
            }

            return Download(infoOut.Data.RawUrl);
        }
    }
}