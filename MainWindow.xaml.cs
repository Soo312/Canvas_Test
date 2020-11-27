using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace Canvas_Test
{
	/// <summary>
	/// MainWindow.xaml에 대한 상호 작용 논리
	/// </summary>
	public partial class MainWindow : Window
	{
		private string IMAGEPATH = "D:\\Test\\ImageTest\\Metal_1_pix3.jpg";
		public MainWindow()
		{
			InitializeComponent();
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			//OpenCvSharp.Mat mat = new OpenCvSharp.Mat(IMAGEPATH , OpenCvSharp.ImreadModes.Color);
			//int width = mat.Width, height = mat.Height;
			//OpenCvSharp.Mat minimat1 = mat.SubMat(new OpenCvSharp.Rect(0, 0, width / 2, height / 2));
			//OpenCvSharp.Mat minimat2 = mat.SubMat(new OpenCvSharp.Rect(width / 2, 0, width/2, height / 2));
			//OpenCvSharp.Mat minimat3 = mat.SubMat(new OpenCvSharp.Rect(0, height/2, width/2, height/2));
			//OpenCvSharp.Mat minimat4 = mat.SubMat(new OpenCvSharp.Rect(width / 2, height / 2, width / 2, height / 2));


			//Bitmap bitmap1 = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(minimat1);
			//Bitmap bitmap2 = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(minimat2);
			////Bitmap bitmap3 = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(minimat3);
			////Bitmap bitmap4 = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(minimat4);

			//List<BitmapImage> bitmapImages = new List<BitmapImage>();
			//using (MemoryStream ms = new MemoryStream())
			//{
			//	var bi = new BitmapImage();
			//	bi.BeginInit();
			//	bitmap1.Save(ms, ImageFormat.Jpeg);
			//	ms.Seek(0, SeekOrigin.Begin);
			//	bi.StreamSource = ms;
			//	bi.CacheOption = BitmapCacheOption.OnLoad;

			//	bi.EndInit();
			//	bitmapImages.Add(bi);
			//}
			//using (MemoryStream ms = new MemoryStream())
			//{
			//	bitmap2.Save(ms, ImageFormat.Jpeg);

			//	var bi = new BitmapImage();
			//	bi.BeginInit();
			//	ms.Seek(0, SeekOrigin.Begin);

			//	bi.StreamSource = ms;
			//	bi.CacheOption = BitmapCacheOption.OnLoad;
			//	bi.EndInit();
			//	bitmapImages.Add(bi);
			//}
			////using (MemoryStream ms = new MemoryStream())
			////{
			////	bitmap3.Save(ms, ImageFormat.Jpeg);

			////	var bi = new BitmapImage();
			////	bi.BeginInit();
			////	bi.StreamSource = ms;
			////	bi.CacheOption = BitmapCacheOption.OnLoad;
			////	bi.EndInit();
			////	bitmapImages.Add(bi);
			////}
			////using (MemoryStream ms = new MemoryStream())
			////{
			////	bitmap4.Save(ms, ImageFormat.Jpeg);

			////	var bi = new BitmapImage();
			////	bi.BeginInit();
			////	bi.StreamSource = ms;
			////	bi.CacheOption = BitmapCacheOption.OnLoad;
			////	bi.EndInit();
			////	bitmapImages.Add(bi);
			////}
			//System.Windows.Controls.Image bg = new System.Windows.Controls.Image();
			//bg.Source = bitmapImages[0];


			//canvas.Children.Add(bg);
			//Canvas.SetLeft(bg, 100);
			//Canvas.SetTop(bg, 100);

			Bitmap bitmap = System.Drawing.Image.FromFile(IMAGEPATH) as Bitmap;
			Bitmap[] bitmaps = new Bitmap[4];
			bitmaps[0] = bitmap.Clone(new System.Drawing.Rectangle(0, 0, 10000, 10000), System.Drawing.Imaging.PixelFormat.Format24bppRgb);
			//bitmaps[1] = bitmap.Clone(new System.Drawing.Rectangle(bitmap.Width / 2 , 0, bitmap.Width / 2, bitmap.Height / 2), System.Drawing.Imaging.PixelFormat.Format32bppArgb);
			//bitmaps[2] = bitmap.Clone(new System.Drawing.Rectangle(0, bitmap.Height / 2, bitmap.Width / 2, bitmap.Height / 2), System.Drawing.Imaging.PixelFormat.Format32bppArgb);
			//bitmaps[3] = bitmap.Clone(new System.Drawing.Rectangle(bitmap.Width / 2 , bitmap.Height / 2, bitmap.Width / 2, bitmap.Height / 2), System.Drawing.Imaging.PixelFormat.Format32bppArgb);

			bitmap.Dispose();

			MemoryStream ms = new MemoryStream();
			bitmaps[0].Save(ms, System.Drawing.Imaging.ImageFormat.Png);
			ms.Position = 0;
			BitmapImage ObjBitmapImage = new BitmapImage();
			ObjBitmapImage.BeginInit();
			ObjBitmapImage.CacheOption = BitmapCacheOption.OnLoad;
			ObjBitmapImage.StreamSource = ms;
			ms.Dispose();
			ObjBitmapImage.EndInit();
			ObjBitmapImage.Freeze();

			System.Windows.Controls.Image image1 = new System.Windows.Controls.Image();
			image1.Source = ObjBitmapImage;

			Canvas.SetLeft(image1, 100);
			Canvas.SetTop(image1, 100);
			canvas.Children.Add(image1);
		}


	}
}
