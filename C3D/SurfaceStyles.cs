using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.AutoCAD.DatabaseServices;
using ACDS = Autodesk.Civil.DatabaseServices.Styles;
using ACD = Autodesk.Civil.DatabaseServices;

namespace C3d23._2._1_CTest.C3D
{
    public class SurfaceStyles
    {
        public static ACDS.SurfaceStyleCollection GetListOfSurfaceStyles()
        {
            return Commands.CivilDoc.Styles.SurfaceStyles;
        }

        public static ACDS.SurfaceStyle GetSurfaceStyle(ObjectId surfStyleId)
        {
            ACDS.SurfaceStyle surfaceStyle = null;

            using (Transaction tr = Commands.db.TransactionManager.StartTransaction())
            {
                surfaceStyle = tr.GetObject(surfStyleId, OpenMode.ForRead) as ACDS.SurfaceStyle;
            }

            return surfaceStyle;
        }
    }
}
