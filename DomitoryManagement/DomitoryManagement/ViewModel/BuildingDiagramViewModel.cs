using DomitoryManagement.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DomitoryManagement.ViewModel
{
   public class BuildingDiagramViewModel: BaseViewModel
    {
        private ObservableCollection<PHONG> _PHONGLIST;
        public ObservableCollection<PHONG> PHONGLIST { get => _PHONGLIST; set { _PHONGLIST = value; OnPropertyChanged(); } }
        private ObservableCollection<TOA> _TOALIST;
        public ObservableCollection<TOA> TOALIST { get => _TOALIST; set { _TOALIST = value; OnPropertyChanged(); } }
        private int _GiuongNumber;
        public int GiuongNumber { get => _GiuongNumber; set { _GiuongNumber = value; OnPropertyChanged(); } }
        private int _GiuongTrongNumber;
        public int GiuongTrongNumber { get => _GiuongTrongNumber; set { _GiuongTrongNumber = value; OnPropertyChanged(); } }
        private int _DaThueNumber;
        public int DaThueNumber { get => _DaThueNumber; set { _DaThueNumber = value; OnPropertyChanged(); } }
        public ICommand RoomListCommand { get; set; }
        public ICommand ModifyCommand { get; set; }
        public ICommand DeteleCommand { get; set; }
        public ICommand AddBuildingCommand { get; set; }
        private int _SelectedIDTOA;
        public int SelectedIDTOA { get => _SelectedIDTOA; set { _SelectedIDTOA = value; OnPropertyChanged(); } }
        public BuildingDiagramViewModel()
        {   
            PHONGLIST = new ObservableCollection<PHONG>(DataProvider.Ins.DB.PHONGs);
            TOALIST = new ObservableCollection<TOA>(DataProvider.Ins.DB.TOAs);
            LoadToa();
            RoomListCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
           {
               SelectedIDTOA =(int)p;
               RoomListInBuilding rl = new RoomListInBuilding();
               var rlDT = rl.DataContext as RoomListInBuildingViewModel;
               rlDT.LoadRoomList(SelectedIDTOA);
               rl.ShowDialog();
               rl.Close();
           });
            AddBuildingCommand =  new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                BuildingDiagram_AddNew bda = new BuildingDiagram_AddNew();
                var bdaDT = bda.DataContext as BuildingDiagram_AddNewViewModel;
                bdaDT.Load();
                bda.ShowDialog();
                bda.Close();
            });
            ModifyCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                int SelectedIDTOAtoMofidy = (int)p;
                BuildingDiagram_AlterBuildingInfo abi = new BuildingDiagram_AlterBuildingInfo();
                var abiDT = abi.DataContext as BuildingDiagram_AlterBuildingInfoViewModel;
                abiDT.Load(SelectedIDTOAtoMofidy);
                
                abi.ShowDialog();

                abi.Close();
            });

        }
        public  void LoadToa()
        {
            PHONGLIST = new ObservableCollection<PHONG>(DataProvider.Ins.DB.PHONGs);
            TOALIST = new ObservableCollection<TOA>(DataProvider.Ins.DB.TOAs);
            DaThueNumber = 0;
            GiuongNumber = 0;
            GiuongTrongNumber = 0;
            foreach (var item in TOALIST)
            {
               int TSGIUONGTRONG=0;int TSDATHUE=0; int TSGIUONG=0;

                foreach (var item2 in PHONGLIST)
                {
                    
                    if (item2.IDTOA == item.IDTOA)
                    {
                        
                        TSGIUONG = TSGIUONG+ (int)item2.LOAIPHONG;
                        TSGIUONGTRONG +=  (int)item2.SOLUONGTRONG;
                        TSDATHUE += (int)item2.SOLUONGNGUOI;
                    }
                }
                item.TSGIUONG = TSGIUONG;
                item.TONGDATHUE = TSDATHUE;
                item.TSGIUONGTRONG = TSGIUONGTRONG;
                DataProvider.Ins.DB.SaveChanges();
                DaThueNumber += TSDATHUE;
                GiuongNumber += TSGIUONG;
                GiuongTrongNumber += TSGIUONGTRONG;
            }
        }

    }
}
