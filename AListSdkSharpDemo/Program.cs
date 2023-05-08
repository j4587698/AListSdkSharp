// See https://aka.ms/new-console-template for more information

using AListSdkSharp.Api;
using AListSdkSharp.Vo;

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
// await Fs.List(baseUrl, token, new ListInVo()
// {
//     Path = "要获取的路径"
// });

// await Fs.Info(baseUrl, token, "你的文件路径");

// var myProfile = await User.GetMyProfile(baseUrl, token);
// Console.WriteLine("我的信息：" + myProfile.Data.Username);

// await Fs.MkDir(baseUrl, token, "要创建的文件夹全路径");

// await Fs.Upload(baseUrl, token, "要上传的目录，包含文件名", 文件流, "如果是加密文件，需要传入密码");));

// await Fs.Remove(baseUrl, token, "要删除的基础目录", "要删除的文件名或文件夹名列表");

// await Fs.Move(baseUrl, token, "源路径", "目的路径", "文件名或文件夹名列表");

// await Fs.Copy(baseUrl, token, "源路径", "目的路径", "文件名或文件夹名列表");

// await Fs.Rename(baseUrl, token, "要改名的全路径", "新文件名");