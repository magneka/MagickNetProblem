using ImageMagick;
using NUnit.Framework;
using System;

namespace ReproduceError
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }


        /// <summary>
        /// This test will fail with:
        /// -------------------------
        /// 
        /// Can not read TIFF directory count. 
        ///                
        /// </summary>
        [Test]
        public void LoadTiffWithDirCountError()
        {
            var image = new MagickImage();
            try
            {
                image.Warning += MagickImage_Warning;


                image.Read("../../../F_DirCountError.tiff");


                var newSize = new MagickGeometry(250, 500);
                newSize.IgnoreAspectRatio = false;
                image.Resize(newSize);

                image.Write("../../../F_DirCountError.jpg");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        /// <summary>
        /// This test will fail with:
        /// -------------------------
        /// 
        /// a Sanity check on directory count failed, 
        /// this is probably not a valid IFD offset. 
        ///         
        /// </summary>
        [Test]
        public void LoadTiffWithSanityError()
        {
            var image = new MagickImage();
            try
            {
                image.Warning += MagickImage_Warning;


                image.Read("../../../F_SanityCheckError.tiff");


                var newSize = new MagickGeometry(250, 500);
                newSize.IgnoreAspectRatio = false;
                image.Resize(newSize);

                image.Write("../../../F_SanityCheckError.jpg");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private static void MagickImage_Warning(object sender, WarningEventArgs arguments)
        {
            Console.WriteLine(arguments.Message);
        }
    }
}