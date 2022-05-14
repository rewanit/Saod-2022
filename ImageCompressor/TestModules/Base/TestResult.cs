using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageCompressor.TestModules
{
    enum ImgType
    {
        PNG,
        GIF,
        TIFF,
        JPEG

    }
    internal class TestResult
    {
        private double speed;
        private double size;
        private double originSize;

        public TestResult(ImgType type,double speed, double size, double originSize)
        {
            this.speed = speed;
            this.size = size;
            this.originSize = originSize;
            Type = type;
        }

        public ImgType Type { get; private set; }
        public string Speed { get => speed.ToString() + " ms"; }
        public string Size { get => (size/1024).ToString("0.##")+" KB"; }
        public string OriginSize { get => (originSize / 1024).ToString("0.##") + " KB"; }
        public string Compression { get => (size / originSize).ToString("0.##"); }

    }
}
