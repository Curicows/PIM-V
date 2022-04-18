using System;
using System.Security.Cryptography;
using System.Text;

namespace PIM_V.Helpers
{
    public class Md5Helper
    {
        public string RetornarMd5(string senha)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                return RetonarHash(md5Hash, senha);
            }
        }

        public bool ComparaMd5(string senhaUser, string senhaBanco)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                var senha = RetornarMd5(senhaUser);
                if (VerificarHash(md5Hash, senhaBanco, senha))
                {
                    return true;
                }
                return false;
            }
        }

        private string RetonarHash(MD5 md5Hash, string input)
        {
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }

        private bool VerificarHash(MD5 md5Hash, string input, string hash)
        {
            StringComparer compara = StringComparer.OrdinalIgnoreCase;

            if (0 == compara.Compare(input, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}