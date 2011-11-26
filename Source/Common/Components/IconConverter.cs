using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using stdole;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;

namespace WordCAB.Common.Components
{
    /// <summary>
    /// Класс, инкапсулирующий логику преобразования изображений для COM и ActiveX приложений.
    /// </summary>
    public sealed class AxIconConverter : AxHost
    {
        #region Statics
        public static readonly AxIconConverter Instance = new AxIconConverter(); 
        #endregion

        #region Ctor
        public AxIconConverter()
            : base("A9D9FE18-89C4-4cf2-884C-AD692CF5F268")
        { } 
        #endregion

        #region Public Methods
        public IPictureDisp Convert<T>(T image)
            where T : Image
        {
            return GetIPictureFromPicture(image) as IPictureDisp;
        }

        public IPictureDisp Convert(Icon icon)
        {
            return Convert<Image>(icon.ToBitmap());
        }

        public IPictureDisp CreateMask(Image image)
        {
            return Convert<Image>(createMask(image));
        } 
        #endregion

        #region Private Methods
        private Image createMask(Image sourceImage)
        {
            Guard.ArgumentNotNull(sourceImage, "sourceImage");

            Bitmap resultBitmap = new Bitmap(sourceImage.Width, sourceImage.Height, PixelFormat.Format24bppRgb);

            using ( Bitmap sourceBitmap = new Bitmap(sourceImage.Width, sourceImage.Height, PixelFormat.Format32bppArgb) )
            {
                using ( Graphics graphics = Graphics.FromImage(sourceBitmap) )
                    graphics.DrawImage(sourceImage, new Rectangle(0, 0, sourceImage.Width, sourceImage.Height), 0, 0, sourceImage.Width, sourceImage.Height, GraphicsUnit.Pixel);

                BitmapData sourceData = sourceBitmap.LockBits(new Rectangle(0, 0, sourceBitmap.Width, sourceBitmap.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
                BitmapData resultData = resultBitmap.LockBits(new Rectangle(0, 0, resultBitmap.Width, resultBitmap.Height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);

                for ( int y = 0; y < sourceData.Height; y++ )
                {
                    for ( int x = 0; x < sourceData.Width; x++ )
                    {
                        int pixel = y * sourceData.Stride + x * 4;

                        byte alpha = Marshal.ReadByte(sourceData.Scan0, pixel + 3);

                        if ( alpha == 0 )
                        {
                            Marshal.WriteByte(resultData.Scan0, ( y * resultData.Stride + x * 3 ), 255);
                            Marshal.WriteByte(resultData.Scan0, ( y * resultData.Stride + x * 3 ) + 1, 255);
                            Marshal.WriteByte(resultData.Scan0, ( y * resultData.Stride + x * 3 ) + 2, 255);
                        }
                    }
                }

                sourceBitmap.UnlockBits(sourceData);
                resultBitmap.UnlockBits(resultData);
            }

            return resultBitmap;
        } 
        #endregion
	}
}
