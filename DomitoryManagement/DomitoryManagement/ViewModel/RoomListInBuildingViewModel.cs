using DomitoryManagement.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DomitoryManagement.ViewModel
{
    class RoomListInBuildingViewModel :BaseViewModel
    {
        private ObservableCollection<PHONG> _PHONGLIST;
        public ObservableCollection<PHONG> PHONGLIST { get => _PHONGLIST; set { _PHONGLIST = value; OnPropertyChanged(); } }
        private ObservableCollection<TOA> _TOALIST;
        public ObservableCollection<TOA> TOALIST { get => _TOALIST; set { _TOALIST = value; OnPropertyChanged(); } }
        private int _SelectedIDTOA;
        public int SelectedIDTOA { get => _SelectedIDTOA; set { _SelectedIDTOA = value; OnPropertyChanged(); } }
        private int _SelectedIDPHONG;
        public int SelectedIDPHONG { get => _SelectedIDPHONG; set { _SelectedIDPHONG = value; OnPropertyChanged(); } }
        private string _FindName;
        public string FindName { get => _FindName; set { _FindName = value; OnPropertyChanged(); } }
        private string _TENTOA;
        public string TENTOA { get => _TENTOA; set { _TENTOA = value; OnPropertyChanged(); } }
        private string _LOAIPHONG;
        public string LOAIPHONG { get => _LOAIPHONG; set { _LOAIPHONG = value; OnPropertyChanged(); } }
        private int _LOAIPHONGNumber;
        public int LOAIPHONGNumber { get => _LOAIPHONGNumber; set { _LOAIPHONGNumber = value; OnPropertyChanged(); } } 
        public ICommand FindBtn { get; set; }
        public ICommand FindRoomCommand { get; set; }
        public ICommand RoomMemberCommand { get; set; }
        public ICommand DeleteRoomCommand { get; set; }
        public ICommand AddRoomCommand { get; set; }
        public RoomListInBuildingViewModel()
        {    
            TOALIST = new ObservableCollection<TOA>(DataProvider.Ins.DB.TOAs);
            RoomMemberCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                SelectedIDPHONG = (int)p;
                RoomMember rm = new RoomMember();
                var rmDT = rm.DataContext as RoomMemberViewModel;
                rmDT.LoadList(SelectedIDPHONG);
                rm.ShowDialog();
                rm.Close();
            });
            //FindRoomCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            //{

            //    if (LOAIPHONG.Contains ("Tất cả")) LOAIPHONGNumber = -1;
            //    else if (LOAIPHONG.Contains("2 người")) LOAIPHONGNumber = 2;
            //    else if (LOAIPHONG.Contains("4 người")) LOAIPHONGNumber = 4;
            //    else if (LOAIPHONG.Contains("6 người")) LOAIPHONGNumber = 6;
            //    else if (LOAIPHONG.Contains("8 người")) LOAIPHONGNumber = 8;

            //    if (LOAIPHONGNumber == -1)
            //    {
            //        PHONGLIST.Clear();
            //        PHONGLIST = new ObservableCollection<PHONG>(DataProvider.Ins.DB.PHONGs.Where(x => x.IDTOA == SelectedIDTOA));
            //    }
            //    else if ( LOAIPHONGNumber != -1)
            //    {
            //        PHONGLIST.Clear();
            //        PHONGLIST = new ObservableCollection<PHONG>(DataProvider.Ins.DB.PHONGs.Where(x => x.IDTOA == SelectedIDTOA && x.LOAIPHONG == LOAIPHONGNumber));
            //    }


            //    // chuyen hoa sang dang NewPhong de xai Grid

            //    if (PHONGLIST.Count() == 0) MessageBox.Show("Không còn phòng phù hợp !");

            //});
            FindBtn = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                if (LOAIPHONG.Contains("Tất cả")) LOAIPHONGNumber = -1;
                else if (LOAIPHONG.Contains("2 người")) LOAIPHONGNumber = 2;
                else if (LOAIPHONG.Contains("4 người")) LOAIPHONGNumber = 4;
                else if (LOAIPHONG.Contains("6 người")) LOAIPHONGNumber = 6;
                else if (LOAIPHONG.Contains("8 người")) LOAIPHONGNumber = 8;
                if (FindName != null && FindName != "")
                {
                    PHONGLIST.Clear();
                    if (LOAIPHONGNumber == -1)
                    {
                        PHONGLIST = new ObservableCollection<PHONG>(DataProvider.Ins.DB.PHONGs.Where(x => x.IDTOA == SelectedIDTOA && x.TENPHONG.Contains(FindName)));
                    }
                    else PHONGLIST = new ObservableCollection<PHONG>(DataProvider.Ins.DB.PHONGs.Where(x => x.IDTOA == SelectedIDTOA && x.TENPHONG.Contains(FindName) && x.LOAIPHONG == LOAIPHONGNumber));

                    //if (PHONGLIST.Count == 0) MessageBox.Show("Không tìm thấy tên phòng!");
                }
                else 
                {   if (LOAIPHONGNumber == -1)
                    {
                        PHONGLIST = new ObservableCollection<PHONG>(DataProvider.Ins.DB.PHONGs.Where(x => x.IDTOA == SelectedIDTOA ));
                    }
                  else   PHONGLIST = new ObservableCollection<PHONG>(DataProvider.Ins.DB.PHONGs.Where(x => x.IDTOA == SelectedIDTOA && x.LOAIPHONG == LOAIPHONGNumber));
                }
            });
            DeleteRoomCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {


            });
            AddRoomCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                AddRoomInBuilding ar = new AddRoomInBuilding();
                var arDT = ar.DataContext as AddRoomInBuildingViewModel;
                arDT.Load(this.SelectedIDTOA);
                ar.ShowDialog();
                ar.Close();

            });
        }
            
        public void LoadRoomList(int SelectedIDTOA)
        {
            ////BuildingDiagram bd = new BuildingDiagram();
            ////var bdDT = bd.DataContext as BuildingDiagramViewModel;
            ////SelectedIDTOA = bdDT.SelectedIDTOA;
            //bd.Close();
            TOALIST = new ObservableCollection<TOA>(DataProvider.Ins.DB.TOAs);
            this.SelectedIDTOA = SelectedIDTOA;
            PHONGLIST = new ObservableCollection<PHONG>(DataProvider.Ins.DB.PHONGs.Where (x=> x.IDTOA == SelectedIDTOA));
            
            TENTOA = TOALIST.Where(x => x.IDTOA == SelectedIDTOA).Single().TENTOA;
            FindName = null;
        }
    }
}
