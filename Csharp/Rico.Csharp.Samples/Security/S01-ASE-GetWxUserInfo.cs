using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Rico.Csharp.Samples.Security
{
    [TestClass]
    public class AceTest
    {
        [TestMethod]
        public void GetUserInfo()
        {
            var aesIV = "NfKA8WVNM0p4TZ2Z2ruC5Q==";
            var aesKey = "hhCr3Nr3hVjHt+vagZbxqQ==";
            string encryptedData =
                "C4p9aWiQpm4tAVjSSxZAU7R1On1VT0mLepEh0trIrJ5wdo+t0aRwmSBE6yPCkQ9NrM6tHYANT7zA56KmHZuJTCVXdYHtiNXgkf6ENp5KgPYPYH1E8iUYUV26z/jWEqMTbCPdTmOS3eHEvcWnR7dCFB3AVSeRyngNCyY0aOgPL7q/zEnLrbHklsSSW3QucTvQqjgunQRSvM/j3AZ1Vbxou6KYGrygLWWzLxNyvfv+V83e0YgZWGICeu4oJ3Nr5FPZ4cZMMJuk6fqt3cXEY4BDw86HypaGCY1JwYVQl4bFseY2PJZMm6AYJNoyFjbKhHlHQUDpi08AGKbZQALjzDfpislK3VBWKznXB1Ej56pOIvPf/WdD0r+zMM2a4fbkdkWdYs0RUP30zlW0/GSQ00fPIT1ZkiLJxTahtxp9PbzUsP6Dl3pbxe3c1MVri7jVlhhSim+T/XQhEeN1FJrAY4pOs3MZdzGXXLjfewFikIJ8agqaR1nr91NWNaLXMuh71QAOlFxnWA+7u+AIqsPP05Vw1Q==";
            //string encryptedData = "7zPUmKdWHh+vd+LTgNAzZr874mfo22LNwPVjBuRsM2ttdysURy0+q4rGNbQe95A6NlX10fkjuwTZtBhnoA1+atIXKjU164nSNuYxj8SIe5aE/Hmi9ykKmGBRnj25XFMz/x9HvcVZM0r7i7biFwS7gLY3kSGNcFuo64gBjEkzkbFuDw7czi3ypwvol/FVQs1NnPiN+YGQ9z+b3pPxTbxAOkAyfn0DJv0oc28F9FLdrXccFw75QIWYVt19OenYDHgnUYRyGWrdc4x2D1ROWAdAv9we7lt4QOHR5jJrngEFexqKa01fbOiUKa82V7tG5xoVUbFQ+g9R6CA1+fQGBRCtZEJbnR2n3J9KRZ0nE5xytv7TwVAcpQOQy7m2AOIfOBcnx9qcXE0PUiWQjbzo3Bwxq9Oh+9HBs7mM7rBmUO8ghB039PZP5tM0HQhwULzgZeyZI7kBIzjFEl2T6HGjv+h12w==";
            string result = GetUsersHelper.AESDecrypt(aesKey, aesIV, encryptedData);
            Console.WriteLine(result);
        }
    }

    public class GetUsersHelper
    {

        #region 微信小程序用户数据解密 


        /// <summary> 
        /// AES解密 
        /// </summary> 
        /// <param name="inputdata">输入的数据encryptedData</param> 
        /// <param name="AesKey">key</param> 
        /// <param name="AesIV">向量128</param> 
        /// <returns name="result">解密后的字符串</returns> 
        public static string AESDecrypt(string inputdata, string AesKey, string AesIV)
        {
            try
            {
                AesIV = AesIV.Replace(" ", "+");
                AesKey = AesKey.Replace(" ", "+");
                inputdata = inputdata.Replace(" ", "+");
                byte[] encryptedData = Convert.FromBase64String(inputdata);

                RijndaelManaged rijndaelCipher = new RijndaelManaged();
                rijndaelCipher.Key = Convert.FromBase64String(AesKey); // Encoding.UTF8.GetBytes(AesKey); 
                rijndaelCipher.IV = Convert.FromBase64String(AesIV);// Encoding.UTF8.GetBytes(AesIV); 
                rijndaelCipher.Mode = CipherMode.CBC;
                rijndaelCipher.Padding = PaddingMode.PKCS7;
                ICryptoTransform transform = rijndaelCipher.CreateDecryptor();
                byte[] plainText = transform.TransformFinalBlock(encryptedData, 0, encryptedData.Length);
                string result = Encoding.UTF8.GetString(plainText);

                return result;
            }
            catch (Exception)
            {
                return null;

            }
        }
        #endregion
    }
}
