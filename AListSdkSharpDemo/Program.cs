﻿// See https://aka.ms/new-console-template for more information

using AListSdkSharp.Api;
using AListSdkSharp.Vo;

var baseUrl = "Alist服务器地址(https://alist.pages.dev/)";
var username = "服务器用户名";
var password = "服务器密码";

var auth = new Auth(baseUrl); // 创建一个Auth对象
var a = await auth.Login(username, password); // 登录
var token = a.Data.Token; // 获取token

var fs = new Fs(baseUrl); // 创建一个Fs对象
var b = await fs.List(token, new ListIn()
{
    Path = "要获取的目录"
}); // 获取目录信息

var c = await fs.Info(token, new ListIn()
{
    Path = "要获取的文件"
});

var stream = await fs.Download(c); // 下载文件
var file = File.Create("文件");
await stream.CopyToAsync(file);
file.Close();

Console.ReadKey();
