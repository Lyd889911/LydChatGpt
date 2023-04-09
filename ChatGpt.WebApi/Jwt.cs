using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ChatGpt.WebApi
{
    public class Jwt
    {
        IConfiguration _configuration;
        public Jwt(IConfiguration configuration)
        {
            this._configuration = configuration;
        }
        public string Create(Guid id, string username, params string[] roles)
        {
            //主体内容payload
            //可以自定义键值对，也可以使用ClaimTypes里面定义的一些东西
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.NameIdentifier, id.ToString()));
            claims.Add(new Claim(ClaimTypes.Name, username));
            foreach (string role in roles)
            {
                //可以添加多个相同的Type
                claims.Add(new Claim(ClaimTypes.Role, role));
            }


            //密钥，保存在配置文件的
            string SecurityKey = _configuration["SecurityKey"];
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecurityKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256); //使用签名算法

            //过期时间,一般授权jwt过期时间很短，只有几分钟，免得被人拿到了一直用
            var expires = DateTime.Now.AddMinutes(5);

            //这是创建token
            var token = new JwtSecurityToken(
                claims: claims,
                expires: expires,
                signingCredentials: credentials
            );
            //最终生成了token字符串
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }
    }
}
