using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperHowToData
{
    public class DBCleanUpHack
    {
        private const string STR_Dapperdatasdf = "Dapperdata.sdf";
        private const string STR_ConstantDBFormat = @"{0}\{1}";
        private const string STR_WinFormDapperHowTo = "WinFormDapperHowTo";
        private const string STR_DapperHowToData = "DapperHowToData";
        public static void CopyDBBackToSourceCodeLocation()
        {
            /*
             * This is a hack and I'd like some one to explain 
             * to me how to setup my project so that this isn't necessary.
             * I want the data that is added while the project is running,
             * to be visible in the Server Explorer's Data connections
             * after the debug/release run is complete.
             * */
            string currentlocation = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string curdirname = System.IO.Path.GetDirectoryName(currentlocation);
            string dbpath = string.Format(STR_ConstantDBFormat, curdirname, STR_Dapperdatasdf);
            System.IO.DirectoryInfo exedir = new System.IO.DirectoryInfo(curdirname);
            System.IO.DirectoryInfo codedir = exedir.Parent.Parent;
            string targetpath = string.Format(STR_ConstantDBFormat, codedir.FullName.Replace(STR_WinFormDapperHowTo, STR_DapperHowToData), STR_Dapperdatasdf);
            System.IO.File.Copy(dbpath, targetpath, true);
        }
    }
}
