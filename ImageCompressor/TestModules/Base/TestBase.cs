using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageCompressor.TestModules
{
    internal abstract class TestBase <T>:ITestBase
    {

        

        private delegate void TestHandle (T loadedFile,string savePath);
        protected abstract void ClearTestTIFF(T loadedFile, string savePath);
        protected abstract void ClearTestJPEG(T loadedFile,string savePath);
        protected abstract  void ClearTestPNG(T loadedFile, string savePath);
        protected abstract T Load(string path);
        
        public List<TestResult> Test(string path)
        {
            Stopwatch stopwatch;
            var RezultList = new List<TestResult>();
            var DelegateList =new Dictionary<ImgType,TestHandle>()
            {
                { ImgType.JPEG,ClearTestJPEG },
                { ImgType.TIFF,ClearTestTIFF },
                { ImgType.PNG,ClearTestPNG },
             
                
            };
            T loaded = Load(path);
            
            foreach (var item in DelegateList)
            {
                stopwatch = Stopwatch.StartNew();
                var rezultpath = Path.Combine(Environment.CurrentDirectory,Path.GetFileNameWithoutExtension(path)+"."+item.Key);
                item.Value.Invoke(loaded,rezultpath);
                stopwatch.Stop();
                var rez = new TestResult(
                    item.Key,
                    stopwatch.ElapsedMilliseconds,
                    new FileInfo(rezultpath).Length,
                    new FileInfo(path).Length
                );
                RezultList.Add(rez);
            }


            return RezultList;


            
        }

    }
}
