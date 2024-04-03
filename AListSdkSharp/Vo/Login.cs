namespace AListSdkSharp.Vo
{
    /// <summary>
    /// 登录信息
    /// </summary>
    public class Login : Base
    {
        /// <summary>
        /// 登录数据
        /// </summary>
        public LoginData Data { get; set; }
        
        public class LoginData
        {
            public string Token { get; set; }
        }
    }
}