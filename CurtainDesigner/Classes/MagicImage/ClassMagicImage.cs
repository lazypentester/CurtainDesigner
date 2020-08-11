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
        public static Bitmap create_img(List<MagickImage> labels, List<int> coordinates, string input_img, double rotate_secondNum, double rotate_thirdNum)
        {
            Bitmap res = null;
            int count = 0;
            MagickImage image = null;

            if (File.Exists(input_img))
            {
                image = new MagickImage(input_img);

                foreach(MagickImage label in labels)
                {
                    if (count > 1 && count < 4)
                        label.Rotate(rotate_secondNum);
                    else if (count > 3)
                        label.Rotate(rotate_thirdNum);

                    image.Composite(label, coordinates[count], coordinates[++count], CompositeOperator.Over);
                    count++;
                }

                try
                {
                    if (File.Exists(PathCombiner.join_combine("\\draw_images\\fc\\draw.png")))
                        File.Delete(PathCombiner.join_combine("\\draw_images\\fc\\draw.png"));

                    if (image != null)
                    {
                        image.Write(PathCombiner.join_combine("\\draw_images\\fc\\draw.png"));
                        image.Dispose();
                    }

                    if (File.Exists(PathCombiner.join_combine("\\draw_images\\fc\\draw.png")))
                    {
                        using (FileStream fileStream = new FileStream(PathCombiner.join_combine("\\draw_images\\fc\\draw.png"), FileMode.Open))
                        {
                            res = new Bitmap(fileStream);
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show($"Помилка при спробі завантажити малюнок. \n{ex.Message}", "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                }
            }   

            return res;
        }
    }
}
