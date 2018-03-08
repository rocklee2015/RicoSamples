using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Rico.S14.MaoYanMovie.Common
{
    public class ImageHelper
    {
        private static HttpClient _httpClient;
        static ImageHelper()
        {
            _httpClient = new HttpClient();
        }

        /// <summary>
        /// 下载图片
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static async Task<byte[]> DownloadPicture(string url)
        {
            var stream = await _httpClient.GetStreamAsync(url);

            MemoryStream ms = new MemoryStream();
            Bitmap bmp = new Bitmap(stream);
            bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] arr = new byte[ms.Length];
            ms.Position = 0;
            ms.Read(arr, 0, (int)ms.Length);

            return arr;
        }
    }
}
