# AListSdkSharp
<<<<<<< HEAD

AListSdkSharp 是C#的AList SDK访问层，用于访问AList的API。
使用flurl作为http请求库。

基本用法
```csharp
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
=======
AList .Net Sdk

# 安装

```
dotnet add package AListSdkSharp
```

# 使用

```
var baseUrl = "服务器路径";
var username = "用户名";
var password = "密码";
var login = await User.GetToken(baseUrl, username, password);
if (login.Code != 200)
{
    Console.WriteLine("登录失败，错误信息：" + login.Message);
    return;
}

Console.WriteLine("登录成功，Token：" + login.Data.Token);
var token = login.Data.Token;
await Fs.List(baseUrl, token, new ListInVo()
{
    Path = "要获取的路径"
});

await Fs.Info(baseUrl, token, "你的文件路径");

var myProfile = await User.GetMyProfile(baseUrl, token);
Console.WriteLine("我的信息：" + myProfile.Data.Username);

await Fs.MkDir(baseUrl, token, "要创建的文件夹全路径");

await Fs.Upload(baseUrl, token, "要上传的目录，包含文件名", 文件流, "如果是加密文件，需要传入密码");));

await Fs.Remove(baseUrl, token, "要删除的基础目录", "要删除的文件名或文件夹名列表");

await Fs.Move(baseUrl, token, "源路径", "目的路径", "文件名或文件夹名列表");

await Fs.Copy(baseUrl, token, "源路径", "目的路径", "文件名或文件夹名列表");

await Fs.Rename(baseUrl, token, "要改名的全路径", "新文件名");
>>>>>>> origin/master
```
