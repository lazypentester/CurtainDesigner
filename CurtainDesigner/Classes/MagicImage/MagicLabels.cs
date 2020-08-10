using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageMagick;
using ImageMagick.Configuration;
using ImageMagick.Defines;
using ImageMagick.ImageOptimizers;

namespace CurtainDesigner.Classes.MagicImage
{
    public class MagicLabels
    {
        private List<MagickImage> list;

        public MagicLabels()
        {
            list = new List<MagickImage>();
        }

        public void add_label(MagickColor font_color, MagickColor back_color, string font, int width, int height, string text)
        {
            var setting_label = new MagickReadSettings
            {
                FillColor = font_color,
                BackgroundColor = back_color,
                Font = font,
                Width = width,
                Height = height
            };

            MagickImage img = new MagickImage(text, setting_label);
            if (list != null)
                list.Add(img);
        }

        public List<MagickImage> getList
        {
            private set { }
            get
            {
                return list;
            }
        }
    }
}
