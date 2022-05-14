using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SixLabors.ImageSharp;
namespace ImageCompressor.TestModules.Libs
{
    internal class ImageSharpTest : TestBase<SixLabors.ImageSharp.Image>
    {
        

        protected override void ClearTestJPEG(SixLabors.ImageSharp.Image loadedFile, string path)
        {
            loadedFile.SaveAsJpeg(path);
        }

        protected override void ClearTestPNG(SixLabors.ImageSharp.Image loadedFile,string path)
        {
            loadedFile.SaveAsPng(path);

        }

        protected override void ClearTestTIFF(SixLabors.ImageSharp.Image loadedFile, string path)
        {
            loadedFile.SaveAsTiff(path);

        }

        protected override SixLabors.ImageSharp.Image Load(string path)
        {
            return SixLabors.ImageSharp.Image.Load(path);
        }
    }
}
