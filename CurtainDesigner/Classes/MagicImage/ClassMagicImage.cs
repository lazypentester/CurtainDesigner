using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageMagick;
using ImageMagick.Configuration;
using ImageMagick.Defines;
using ImageMagick.ImageOptimizers;

namespace CurtainDesigner.Classes.MagicImage
{
    public class ClassMagicImage
    {
        public static Bitmap create_img(List<MagickImage> labels, List<int> coordinates, string input_img)
        {
            Bitmap res = null;
            int count = 0;
            MagickImage image = new MagickImage(input_img);

            foreach (MagickImage label in labels)
            {
                image.Composite(label, coordinates[count], coordinates[++count], CompositeOperator.Over);
                count++;
            }

            try
            {
                //if (!Directory.Exists(PathCombiner.join_combine("draw_images")))
                //    Directory.CreateDirectory(PathCombiner.join_combine("draw_images"));
                if (!Directory.Exists(PathCombiner.join_combine("\\draw_images\\fc")))
                    Directory.CreateDirectory(PathCombiner.join_combine("\\draw_images\\fc"));

                image.Write(PathCombiner.join_combine("\\draw_images\\fc\\draw.png"));

                res = new Bitmap(PathCombiner.join_combine("\\draw_images\\fc\\draw.png"));
            }
            catch(Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"Test \n{ex.Message}");
            }

            return res;
        }
    }
}
