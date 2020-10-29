using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Craunch
{
    class Crypto
    {
        internal static byte[] SALT = new byte[] { 0x13, 0x87, 0xD5, 0xAA, 0xF9, 0x00, 0xA7, 0xD3, 0xEA, 0xD8 };

        public static byte[] Encrypt(byte[] input, string password)
        {
            PasswordDeriveBytes pdb = new PasswordDeriveBytes(password, SALT);
            using (MemoryStream ms = new MemoryStream())
            {
                using (Aes aes = new AesManaged())
                {
                    aes.Key = pdb.GetBytes(aes.KeySize / 8);
                    aes.IV = pdb.GetBytes(aes.BlockSize / 8);
                    CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write);

                    byte[] hash = HashPassword(password);
                    cs.Write(hash, 0, hash.Length);
                    cs.Write(input, 0, input.Length);
                    cs.Close();

                    return ms.ToArray();
                }
            }
        }

        public static byte[] Decrypt(byte[] input, string password)
        {
            PasswordDeriveBytes pdb = new PasswordDeriveBytes(password, SALT);
            using (MemoryStream ms = new MemoryStream())
            {
                using (Aes aes = new AesManaged())
                {
                    aes.Key = pdb.GetBytes(aes.KeySize / 8);
                    aes.IV = pdb.GetBytes(aes.BlockSize / 8);
                    using (CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        byte[] hash = HashPassword(password);
                        cs.Write(input, 0, input.Length);
                        cs.Close();

                        byte[] data = ms.ToArray();
                        if (data.Length < hash.Length)
                            return null;

                        for (int i = 0; i < hash.Length; i++)
                        {
                            if (data[i] != hash[i])
                                return null;
                        }

                        byte[] result = new byte[data.Length - hash.Length];
                        for (int i = 0; i < result.Length; i++)
                        {
                            result[i] = data[i + hash.Length];
                        }

                        return result;
                    }
                }
            }
        }


        private static byte[] HashPassword(string password)
        {
            List<byte> bytes = new List<byte>();
            bytes.AddRange(Encoding.UTF8.GetBytes(password));
            bytes.AddRange(SALT);
            bytes.AddRange(BitConverter.GetBytes(password.Length));
            return Hash(bytes.ToArray());
        }

        public static string HashString(string data)
        {
            return HashString(Encoding.UTF8.GetBytes(data));
        }
        public static byte[] Hash(string data)
        {
            return Hash(Encoding.UTF8.GetBytes(data));
        }

        public static string HashString(byte[] data)
        {
            byte[] bytes = Hash(data);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                sb.Append(bytes[i].ToString("x2"));
            }

            return sb.ToString();
        }
        public static byte[] Hash(byte[] data)
        {
            using (SHA256 hasher = SHA256.Create())
            {
                return hasher.ComputeHash(data);
            }
        }
    }
}
