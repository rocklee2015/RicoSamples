using System.Collections;
using System.Drawing;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;

namespace Rico.S01.NPOISample
{
    [TestClass]
    public class PictureTest:BaseTest
    {
        public PictureTest()
        {
            _testResultDirectory = "PictureTestResult";
        }

        [TestMethod]
        public void ExtractPicturesFromXls()
        {
            InitializeWorkbook(GetTestFile("clothes.xls"));

            IList pictures = hssfworkbook.GetAllPictures();
            int i = 0;
            foreach (HSSFPictureData pic in pictures)
            {
                string ext = pic.SuggestFileExtension();
                if (ext.Equals("jpeg"))
                {
                    Image jpg = Image.FromStream(new MemoryStream(pic.Data));
                    jpg.Save(string.Format("PictureTestResult\\pic{0}.jpg", i++));
                }
                else if (ext.Equals("png"))
                {
                    Image png = Image.FromStream(new MemoryStream(pic.Data));
                    png.Save(string.Format("PictureTestResult\\pic{0}.png", i++));
                }

            }
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void InsertPicturesInXls()
        {
            InitializeWorkbook();

            ISheet sheet1 = hssfworkbook.CreateSheet("PictureSheet");


            HSSFPatriarch patriarch = (HSSFPatriarch)sheet1.CreateDrawingPatriarch();
            //create the anchor
            HSSFClientAnchor anchor;
            anchor = new HSSFClientAnchor(500, 200, 0, 0, 2, 2, 4, 7);
            anchor.AnchorType = AnchorType.MoveDontResize;
            //load the picture and get the picture index in the workbook
            var imagePath = GetTestFile("HumpbackWhale.jpg");
            HSSFPicture picture = (HSSFPicture)patriarch.CreatePicture(anchor, LoadImage(imagePath, hssfworkbook));
            //Reset the image to the original size.
            //picture.Resize();   //Note: Resize will reset client anchor you set.
            picture.LineStyle = LineStyle.DashDotGel;

            WriteToFile("InsertPicturesInXls");
        }
        public static int LoadImage(string path, HSSFWorkbook wb)
        {
            FileStream file = new FileStream(path, FileMode.Open, FileAccess.Read);
            byte[] buffer = new byte[file.Length];
            file.Read(buffer, 0, (int)file.Length);
            return wb.AddPicture(buffer, PictureType.JPEG);

        }
    }
}
