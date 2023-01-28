using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Runtime;
using Autodesk.Civil.ApplicationServices;
using Autodesk.Civil.DatabaseServices.Styles;

namespace C3d23._2._1_CTest
{
    public class Commands
    {
        public static CivilDocument CivilDoc;
        public static Document doc;
        public static Editor ed;
        public static Database db;

        #region Commands
        [CommandMethod(@"TestPartsList")]
        public void IcmImport()
        {
            //Load the Civil Documents
            LoadDocument();

            TestMain dia = new TestMain();
            Application.ShowModalWindow(Application.MainWindow.Handle, dia, false);
        }
        #endregion

        #region Methods
        private void LoadDocument()
        {
            doc = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;
            ed = doc.Editor;
            db = doc.Database;
            CivilDoc = CivilApplication.ActiveDocument;
        }
        #endregion
    }
}
