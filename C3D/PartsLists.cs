using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.AutoCAD.DatabaseServices;
using ACDS = Autodesk.Civil.DatabaseServices.Styles;
using ACD = Autodesk.Civil.DatabaseServices;

namespace C3d23._2._1_CTest.C3D
{
    public class PartsList
    {
        public static ACDS.PartsListCollection GetListOfPartsLists()
        {
            return Commands.CivilDoc.Styles.PartsListSet;
        }

        public static ACDS.PartsList GetPartsList(ObjectId partsListId)
        {
            ACDS.PartsList partsList = null;

            using (Transaction tr = Commands.db.TransactionManager.StartTransaction())
            {
                partsList = tr.GetObject(partsListId, OpenMode.ForRead) as ACDS.PartsList;
            }

            return partsList;
        }
    }
}
