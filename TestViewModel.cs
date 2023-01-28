using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Autodesk.AutoCAD.DatabaseServices;
using ACD = Autodesk.Civil.DatabaseServices;
using ACDS = Autodesk.Civil.DatabaseServices.Styles;

namespace C3d23._2._1_CTest
{
    class TestViewModel
    {
        #region Properties
        private ACDS.SurfaceStyle _selectedSurfStyle;

        /// <summary>
        /// Used for storing the selected parts list
        /// </summary>
        public ACDS.SurfaceStyle SelectedSurfStyle
        {
            get => _selectedSurfStyle;
            set
            {
                _selectedSurfStyle = value;
                OnPropertyChanged(nameof(SelectedPartsList));
            }
        }

        private ObservableCollection<ACDS.SurfaceStyle> _surfStyles;
        public ObservableCollection<ACDS.SurfaceStyle> SurfStyles
        {
            get => _surfStyles;
            set
            {
                _surfStyles = value;
                OnPropertyChanged(nameof(SurfStyles));
            }
        }

        private ACDS.PartsList _selectedPartsList;

        /// <summary>
        /// Used for storing the selected parts list
        /// </summary>
        public ACDS.PartsList SelectedPartsList
        {
            get => _selectedPartsList;
            set
            {
                _selectedPartsList = value;
                OnPropertyChanged(nameof(SelectedPartsList));
            }
        }

        private ObservableCollection<ACDS.PartsList> _partsLists;

        /// <summary>
        /// List of Parts Lists
        /// </summary>
        public ObservableCollection<ACDS.PartsList> PartsLists
        {
            get => _partsLists;
            set
            {
                _partsLists = value;
                OnPropertyChanged(nameof(PartsLists));
            }
        }
        #endregion

        #region
        public TestViewModel()
        {
            SurfStyles = new ObservableCollection<ACDS.SurfaceStyle>();

            foreach (ObjectId surfStyleId in C3D.SurfaceStyles.GetListOfSurfaceStyles())
            {
                try
                {
                    ACD.Styles.SurfaceStyle surfStyle = C3D.SurfaceStyles.GetSurfaceStyle(surfStyleId);
                    //IcmNetworkItem icmNetworkItem = new IcmNetworkItem(partList.Name, partList.Name,
                    //    partList.Handle.ToString(), ErrorCodeEnums.IcmNetworkItemError.None);

                    SurfStyles.Add(surfStyle);
                }
                catch (Exception e)
                {
                    //Console.WriteLine(e);
                    //throw;
                }
            }



            PartsLists = new ObservableCollection<ACDS.PartsList>();

            foreach (ObjectId partListId in C3D.PartsList.GetListOfPartsLists())
            {
                try
                {
                    ACD.Styles.PartsList partList = C3D.PartsList.GetPartsList(partListId);
                    //IcmNetworkItem icmNetworkItem = new IcmNetworkItem(partList.Name, partList.Name,
                    //    partList.Handle.ToString(), ErrorCodeEnums.IcmNetworkItemError.None);
                    
                    PartsLists.Add(partList);
                }
                catch (Exception e)
                {
                    //Console.WriteLine(e);
                    //throw;
                }
            }

            SelectedPartsList = PartsLists[0];
        }
        #endregion
        
        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void TriggerChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}
