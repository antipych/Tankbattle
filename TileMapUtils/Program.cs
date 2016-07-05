using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;
using System.Drawing;
using System.Xml.Linq;

namespace TileMapUtils
{
    class Program
    {
        static void Main(string[] args)
        {
#if DEBUG
            var dir = new DirectoryInfo(@"..\..\..\TileMapSource\src\Sprites");
#else
            var dir = new DirectoryInfo(@"src\Sprites");
#endif
            var doc = XDocument.Load(Path.Combine(dir.FullName, "tilemaps.xml"));

            foreach (var tm in doc.Root.Elements())
            {
                var s = int.Parse(tm.Attribute("size").Value);

                Bitmap map = new Bitmap(s * tm.Elements().Count(), s);
                Graphics g = Graphics.FromImage(map);

                int curX = 0;
                foreach (var tile in tm.Elements())
                {
                    var tf = new Bitmap(Path.Combine(dir.FullName, tile.Value));
                    g.DrawImage(tf, curX, 0, s, s);
                    curX += s;
                }
                g.Dispose();
                var n = Path.Combine(dir.FullName, @"..\..\build\tilemaps", tm.Attribute("name").Value) + ".png";
                map.Save(n);
                Console.WriteLine(new FileInfo(n).Name);
            }
            Console.ReadKey();
        }
    }
}
