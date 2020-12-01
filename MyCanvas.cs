using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Canvas_Test
{
	class MyCanvas : System.Windows.Controls.Canvas
	{
		protected override void OnRender(DrawingContext dc)
		{
			string IMAGEPATH = "D:\\Test\\ImageTest\\1233.jpg";
			OpenCvSharp.Mat mat = new OpenCvSharp.Mat(IMAGEPATH);

			int i;
			int j;

			int subwidth, subheight;

			int subnum = 4;
			subwidth = mat.Width / subnum;
			subheight = mat.Height / subnum;
			BitmapImage[] biarray = new BitmapImage[subnum * subnum];
			try
			{

				for (i = 0; i < subnum; i++)
				{
					for (j = 0; j < subnum; j++)
					{
						int index = i * subnum + j;

						if (biarray[index] == null)
							biarray[index] = new BitmapImage();



						OpenCvSharp.Mat submat = mat.SubMat(new OpenCvSharp.Rect((subwidth * j),
																				 (subheight * i),
																				 subwidth,
																				 subheight));

						//OpenCvSharp.Mat submat = mat.SubMat(subheight * i, subheight * i + subheight, subwidth * j, subwidth * j +subwidth); ;
						Bitmap bitmap = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(submat);


						using (MemoryStream ms = new MemoryStream())
						{
							bitmap.Save(ms, ImageFormat.Jpeg);
							ms.Position = 0;

							biarray[index].BeginInit();
							biarray[index].CacheOption = BitmapCacheOption.OnLoad;
							biarray[index].StreamSource = ms;
							biarray[index].EndInit();

						}
						submat.Dispose();

						if (biarray[index] != null)
						{
							dc.DrawImage(biarray[index], new System.Windows.Rect((mat.Width / 10 + 10) * j, (mat.Height / 10 + 10) * i, mat.Width / 10, mat.Height / 10)); ;
						}

					}
				}
				mat.Dispose();
			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.Print(ex.ToString());
			}


		}
	}
}
