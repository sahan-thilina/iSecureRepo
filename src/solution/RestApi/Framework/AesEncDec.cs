using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Security.Cryptography;
using System.Text;

namespace RestApi.Framework
{
    public static class AesEncDec
    {
        public static string IV = "qo1lc3sjd8zpt9cx";
        public static string Key = "ow7dxys8glfor9tnc2ansdfo1etkfjcv";

        public static string Encrypt(string decrypted)
        {
            byte[] textbytes = Encoding.ASCII.GetBytes(decrypted);
            AesCryptoServiceProvider encdec = new AesCryptoServiceProvider();

            encdec.BlockSize = 128;
            encdec.KeySize = 256;
            encdec.Key = Encoding.ASCII.GetBytes(Key);
            encdec.IV = Encoding.ASCII.GetBytes(IV);
            encdec.Padding = PaddingMode.PKCS7;
            encdec.Mode = CipherMode.CBC;

            ICryptoTransform icrypt = encdec.CreateEncryptor(encdec.Key, encdec.IV);

            byte[] enc = icrypt.TransformFinalBlock(textbytes, 0, textbytes.Length);
            icrypt.Dispose();

            return Convert.ToBase64String(enc);
        }

        public static string Decrypt(string encrypted)
        {
            byte[] encbytes = Convert.FromBase64String(encrypted);
            AesCryptoServiceProvider encdec = new AesCryptoServiceProvider();

            encdec.BlockSize = 128;
            encdec.KeySize = 256;
            encdec.Key = Encoding.ASCII.GetBytes(Key);
            encdec.IV = Encoding.ASCII.GetBytes(IV);
            encdec.Padding = PaddingMode.PKCS7;
            encdec.Mode = CipherMode.CBC;

            ICryptoTransform icrypt = encdec.CreateDecryptor(encdec.Key, encdec.IV);

            byte[] dec = icrypt.TransformFinalBlock(encbytes, 0, encbytes.Length);
            icrypt.Dispose();

            return Encoding.ASCII.GetString(dec);
        }
    }
}