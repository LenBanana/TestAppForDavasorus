using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestAppForDavasorus
{
    public class FileSearcher
    {
        public List<TextBox> FileReader()
        {
            string[] states = { "AL", "AK", "AZ", "AR", "CA", "CO", "CT", "DE", "DC", "FL", "GA", "HI", "ID", "IL", "IN", "IA", "KS", "KY", "LA", "ME", "MD", "MA", "MI", "MN", "MS", "MO", "MT", "NB", "NV", "NH", "NJ", "NM", "NY", "NC", "ND", "OH", "OK", "OR", "PA", "RI", "SC", "SD", "TN", "TX", "UT", "VT", "VA", "WA", "WV", "WI", "WY" };
            List<TextBox> textBoxes = new List<TextBox>();
            int boxHeight = 25;
            int boxWidth = 75;
            int boxWidthDistance = 100;

            foreach (var dir in Directory.GetDirectories(@"E:\Allgemein\TestFolder"))
            {
                string dirLastPart = dir.Split('\\').Last();
                if (states.Contains(dirLastPart.ToUpper()))
                {
                    var formsFolderPath = $"{dir}\\Forms\\";
                    if (!Directory.Exists(formsFolderPath))
                        continue;
                    foreach (var file in Directory.GetFiles(formsFolderPath))
                    {
                        string fileLastPart = file.Split('\\').Last().Split(' ').First();
                        if (fileLastPart.Contains("PD") || fileLastPart.Contains("SO"))
                        {
                            TextBox box = new TextBox();
                            box.Location = new Point(textBoxes.Count % 2 == 0 ? 0 : boxWidthDistance, textBoxes.Count % 2 == 0 ? textBoxes.Count * boxHeight : (textBoxes.Count - 1) * boxHeight);
                            box.Width = boxWidth;
                            box.Text = textBoxes.Count % 2 == 0 ? dirLastPart : fileLastPart;
                            textBoxes.Add(box);
                        }
                    }
                }
            }
            return textBoxes;
        }
    }
}
