using System.Security.Cryptography;
using System.Text;

namespace WebCursos.Domain.Services.Utils
{
    public class Criptografia
    {
        public string CriarHash(string senha)
        {
            var md5 = MD5.Create();
            byte[] bytes = Encoding.ASCII.GetBytes(senha);
            byte[] hash = md5.ComputeHash(bytes);

            var sb = new StringBuilder();

            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }

            return sb.ToString();
        }
    }
}
