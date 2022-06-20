using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestFramework.Tools
{
    public class CSVReader : AExternalReader
    {
        private const char CSV_SPLIT_BY = ';';
        //public string Filename { get; private set; }
        //public string Path { get; private set; }

        public CSVReader(string filename) : base(filename)
        {
            //Filename = filename;
            //Path = System.IO.Path.GetDirectoryName(Assembly.GetAssembly(typeof(CSVReader)).CodeBase)
            //        .Substring(PATH_PREFIX);
            //Path = Path.Remove(Path.IndexOf(FOLDER_BIN)) + FOLDER_DATA + PATH_SEPARATOR + filename;
            //MessageBox.Show("Path.GetDirectoryName(Assembly.GetAssembly(typeof(CSVReader)).CodeBase): "
            //    + System.IO.Path.GetDirectoryName(Assembly.GetAssembly(typeof(CSVReader)).CodeBase),
            //    "Full PATH ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public override IList<IList<string>> GetAllCells()
        {
            return GetAllCells(Path);
        }

        public override IList<IList<string>> GetAllCells(string path)
        {
            Path = path;
            IList<IList<string>> allCells = new List<IList<string>>();
            string row;
            //
            using (StreamReader streamReader = new StreamReader(path))
            {
                while ((row = streamReader.ReadLine()) != null)
                {
                    allCells.Add(row.Split(CSV_SPLIT_BY).ToList());
                }
            }
            return allCells;
        }

        public override string GetConnection()
        {
            return Path;
        }
    }

}
