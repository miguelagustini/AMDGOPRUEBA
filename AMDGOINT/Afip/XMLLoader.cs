using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace AmdgoInterno.Afip
{
    class XMLLoader
    {
        public static void load(XmlDocument doc, string file)
        {
            doc.Load(Path.GetFullPath(Application.StartupPath + @"\" + file + ".xml"));
        }
        public static void loadTemplate(XmlDocument doc, string file)
        {
            load(doc, @"Afip\" + file);
        }
    }
}
