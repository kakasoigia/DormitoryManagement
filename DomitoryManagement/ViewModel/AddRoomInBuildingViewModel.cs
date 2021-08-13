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
    public class AddRoomInBuildingViewModel : BaseViewModel

    {
        private ObservableCollection<TOA> _TOALIST;
        public ObservableCollection<TOA> TOALIST { get => _TOALIST; set { _TOALIST = value; OnPropertyChanged(); } }
        private ObservableCollection<PHONG> _PHONGLIST;
        public ObservableCollection<PHONG> PHONGLIST { get => _PHONGLIST; set { _PHONGLIST = value; OnPropertyChanged(); } }
        private int _IDTOA;
        public int IDTOA { get => _IDTOA; set { _IDTOA = value; OnPropertyChanged(); } }
        private int _IDPHONG;
        public int IDPHONG { get => _IDPHONG; set { _IDPHONG = value; OnPropertyChanged(); } }
        private string _TENPHONG;
        public string TENPHONG { get => _TENPHONG; set { _TENPHONG = value; OnPropertyChanged(); } }
        private string _LOAIPHONG;
        public string LOAIPHONG { get => _LOAIPHONG; set { _LOAIPHONG = value; OnPropertyChanged(); } }
        private int _SelectedIDTOA;
        public int SelectedIDTOA { get => _SelectedIDTOA; set { _SelectedIDTOA = value; OnPropertyChanged(); } }
        private bool _isDistinct;
        public bool isDistinct { get => _isDistinct; set { _isDistinct = value; OnPropertyChanged(); } }
        public ICommand  AddRoomCommand { get; set; }

        public AddRoomInBuildingViewModel()
        {
            AddRoomCommand = new RelayCommand<Window>((d) => { return true; }, (d) =>
            {
                Check();
                if (isDistinct)
                {
                    PHONG p = new PHONG();
                   
                    p.IDTOA = SelectedIDTOA;
                    p.SOLUONGNGUOI = 0;
                    p.TENPHONG = TENPHONG;
                    if (LOAIPHONG.Contains("Phòng 2")) p.LOAIPHONG = 2;
                    else if (LOAIPHONG.Contains("Phòng 4")) p.LOAIPHONG = 4;
                    else if (LOAIPHONG.Contains("Phòng 6")) p.LOAIPHONG = 6;
                    else if (LOAIPHONG.Contains("Phòng 8")) p.LOAIPHONG = 8;
                    p.SOLUONGTRONG = p.LOAIPHONG;
                    DataProvider.Ins.DB.PHONGs.Add (p);
                    DataProvider.Ins.DB.SaveChanges();
                    MessageBox.Show("Thêm phòng thành công! ");
                    BuildingDiagram bd = new BuildingDiagram();
                    var bdDT = bd.DataContext as BuildingDiagramViewModel;
                    bdDT.LoadToa();
                    bd.Close();
                    RoomListInBuilding rl = new RoomListInBuilding();
                    var rlDT = rl.DataContext as RoomListInBuildingViewModel;
                    rlDT.LoadRoomList(SelectedIDTOA);
                    rl.Close();
                    MainWindow mw = new MainWindow();
                    var mwDT = mw.DataContext as MainViewModel;
                    mwDT.LoadStatis();
                    mw.Close();
                    d.Close();
                }
                
            });
        }
        public void Load(int IDTOA)
        {
            
            isDistinct = false;
            SelectedIDTOA = IDTOA;
            TENPHONG = null;
            LOAIPHONG = null;
            TOALIST = new ObservableCollection<TOA>(DataProvider.Ins.DB.TOAs);
            PHONGLIST = new ObservableCollection<PHONG>(DataProvider.Ins.DB.PHONGs);
            

        }
        public void Check()
        {    if (TENPHONG != null && LOAIPHONG != null)
            {
                TENPHONG = TENPHONG.ToUpper();
                if (TENPHONG == null || LOAIPHONG == null)
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin !");
                    return;
                }
                foreach (var item in PHONGLIST)
                {
                    if (item.TENPHONG == TENPHONG)
                    {
                        MessageBox.Show("Tên phòng đã tồn tại !");
                        return;
                    }

                }
                isDistinct = true;
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin! ");
            }
        }
    }
       
              



        
}
