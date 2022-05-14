using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageCompressor.TestModules.Libs
{
    internal class SystemDrawingTest : TestBase<Image>
    {
        protected override void ClearTestJPEG(Image loadedFile, string savePath)
        {
            loadedFile.Save(savePath, ImageFormat.Jpeg);
        }

        protected override void ClearTestPNG(Image loadedFile, string savePath)
        {
            loadedFile.Save(savePath, ImageFormat.Png);

        }

        protected override void ClearTestTIFF(Image loadedFile, string savePath)
        {
            loadedFile.Save(savePath, ImageFormat.Tiff);

        }

        protected override Image Load(string path)
        {
            return Image.FromFile(path);
        }
    }
}
