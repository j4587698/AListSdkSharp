using System.Text.Json.Serialization;

namespace AListSdkSharp.Vo
{
    /// <summary>
    /// 用户信息
    /// </summary>
    public class UserInfoVo : BaseVo
    {
        /// <summary>
        /// 用户信息
        /// </summary>
        public UserInfoData Data { get; set; }
        
        /// <summary>
        /// 用户信息
        /// </summary>
        public class UserInfoData
        {
            /// <summary>
            /// 基础路径
            /// </summary>
            [JsonPropertyName("base_path")]
            public string BasePath { get; set; }

            /// <summary>
            /// 是否禁用
            /// </summary>
            public bool Disabled { get; set; }

            /// <summary>
            /// 用户id
            /// </summary>
            public int Id { get; set; }

            /// <summary>
            /// 用户密码
            /// </summary>
            public string Password { get; set; }

            /// <summary>
            /// 用户权限
            /// </summary>
            public int Permission { get; set; }

            /// <summary>
            /// 用户角色
            /// </summary>
            public int Role { get; set; }

            /// <summary>
            /// 统一登录id
            /// </summary>
            [JsonPropertyName("sso_id")]
            public string SsoId { get; set; }

            /// <summary>
            /// 用户名
            /// </summary>
            public string Username { get; set; }
        }
    }
}