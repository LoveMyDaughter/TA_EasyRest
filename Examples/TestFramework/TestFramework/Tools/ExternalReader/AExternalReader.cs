using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestFramework.Tools
{
    public abstract class AExternalReader
    {
        public const int PATH_PREFIX = 6;
        public const string PATH_SEPARATOR = "\\";
        protected const string FOLDER_DATA = "Data";
        protected const string FOLDER_RESOURCES = "Resources";
        protected const string FOLDER_BIN = "bin";

        public string Filename { get; private set; }
        public string Path { get; protected set; }

        protected AExternalReader(string filename)
        {
            Filename = filename;
            Path = System.IO.Path.GetDirectoryName(Assembly.GetAssembly(typeof(AExternalReader)).CodeBase)
                    .Substring(PATH_PREFIX);
            Path = Path.Remove(Path.IndexOf(FOLDER_BIN)) + PATH_SEPARATOR + FOLDER_DATA + PATH_SEPARATOR + FOLDER_RESOURCES + PATH_SEPARATOR + filename;
            //MessageBox.Show("Path.GetDirectoryName(Assembly.GetAssembly(typeof(AExternalReader)).CodeBase):\n"
            //    + System.IO.Path.GetDirectoryName(Assembly.GetAssembly(typeof(AExternalReader)).CodeBase),
            //    "Full PATH ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public abstract IList<IList<string>> GetAllCells();

        public abstract IList<IList<string>> GetAllCells(string path);

        public abstract string GetConnection();
    }
}
