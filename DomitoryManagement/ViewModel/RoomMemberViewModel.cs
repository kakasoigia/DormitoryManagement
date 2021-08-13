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
    public class RoomMemberViewModel:BaseViewModel
    {
        private int _SelectedIDPhongList;
        public int SelectedIDPhongList { get => _SelectedIDPhongList; set { _SelectedIDPhongList = value; OnPropertyChanged(); } }
        private string _TENPHONG;
        public string TENPHONG { get => _TENPHONG; set { _TENPHONG = value; OnPropertyChanged(); } }

        private ObservableCollection<SINHVIEN> _SINHVIENLIST;
        public ObservableCollection<SINHVIEN> SINHVIENLIST{ get => _SINHVIENLIST; set { _SINHVIENLIST = value; OnPropertyChanged(); } }
        private ObservableCollection<PHONG> _PHONGLIST;
        public ObservableCollection<PHONG> PHONGLIST { get => _PHONGLIST; set { _PHONGLIST = value; OnPropertyChanged(); } }

        private ObservableCollection<DANHSACHSV_PHONG> _SINHVIEN_PHONGLIST;
        public ObservableCollection<DANHSACHSV_PHONG> SINHVIEN_PHONGLIST { get => _SINHVIEN_PHONGLIST; set { _SINHVIEN_PHONGLIST = value; OnPropertyChanged(); } }
        public ICommand DeleteStudentCommand { get; set; }
        public ICommand DetailInfoCommand { get; set; }
        
        private int _SelectedIDSINHVIEN;
        public int SelectedIDSINHVIEN { get => _SelectedIDSINHVIEN; set { _SelectedIDSINHVIEN = value; OnPropertyChanged(); } }
        private SINHVIEN _SelectedSINHVIEN;
        public SINHVIEN SelectedSINHVIEN { get => _SelectedSINHVIEN; set { _SelectedSINHVIEN = value; OnPropertyChanged(); } }
        public RoomMemberViewModel()
        {

            //DeleteStudentCommand = new RelayCommand<object> ((p) => { return true; }, (p) => 
            //{
            //    SelectedIDSINHVIEN = (int)p;
            //    // xóa trong DS _P
            //    DANHSACHSV_PHONG sv = new DANHSACHSV_PHONG();
            //    sv = SINHVIEN_PHONGLIST.Where(x => x.IDPHONG == SelectedIDPhongList && x.IDSINHVIEN == SelectedIDSINHVIEN).Single();
            //    DataProvider.Ins.DB.DANHSACHSV_PHONG.Remove(sv);
            //    DataProvider.Ins.DB.SaveChanges();
            //    // sửa lại DATHUE
            //    var change = DataProvider.Ins.DB.SINHVIENs.Where(x => x.IDSINHVIEN == SelectedIDSINHVIEN).Single();
            //    change.DATHUE = false;
            //    DataProvider.Ins.DB.SaveChanges();
            //    // Chỉnh lại số người trong phòng
            //    var phong = (from up in DataProvider.Ins.DB.PHONGs where up.IDPHONG == SelectedIDPhongList select up).Single();
            //    phong.SOLUONGNGUOI--;
            //    phong.SOLUONGTRONG++;
            //    DataProvider.Ins.DB.SaveChanges();

            //    MessageBox.Show("Đã xóa thành công! ");
            //    LoadList(SelectedIDPhongList);
            //    RoomListInBuilding rl = new RoomListInBuilding();
            //    var rlDT = rl.DataContext as RoomListInBuildingViewModel;

            //    rlDT.LoadRoomList(rlDT.SelectedIDTOA);
            //    rl.Close();
            //    BuildingDiagram bd = new BuildingDiagram();
            //    var bdDT = bd.DataContext as BuildingDiagramViewModel;
            //    bdDT.LoadToa();
            //    bd.Close();
            //});
            DetailInfoCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {  
                //SelectedIDSINHVIEN = (int)p;
                StudentInfor si = new StudentInfor();
                var siDT = si.DataContext as StudentInforViewModel;
                //siDT.MSSVFindNumber = p.ToString();
                //siDT.LoadInfor( (int)p);
                siDT.LoadInfor((int)SelectedSINHVIEN.IDSINHVIEN);
                si.ShowDialog();
                si.Close();
            });


        }
        public void LoadList(int a)
        {
            //HiringRoom2 hr2 = new HiringRoom2();
            //var hr2DT = hr2.DataContext as HiringRoomViewModel2;

            //SelectedIDPhongList = hr2DT.SelectedIDPhongList;
            SelectedIDPhongList = a;
            

            //hr2.Close();
            HiringRoom hr1 = new HiringRoom();
            var hr1DT = hr1.DataContext as HiringRoomViewModel;
            hr1DT.LoadListChuaThue();
            hr1.Close();
            SINHVIENLIST = new ObservableCollection<SINHVIEN>(); /*DataProvider.Ins.DB.SINHVIENs*/
            SINHVIEN_PHONGLIST = new ObservableCollection<DANHSACHSV_PHONG>(DataProvider.Ins.DB.DANHSACHSV_PHONG);
            PHONGLIST = new ObservableCollection<PHONG>(DataProvider.Ins.DB.PHONGs);
            TENPHONG = DataProvider.Ins.DB.PHONGs.Where(x => x.IDPHONG == SelectedIDPhongList).Single().TENPHONG.ToString();
            
            foreach (var item in SINHVIEN_PHONGLIST)
            {
                if (item.IDPHONG == SelectedIDPhongList)
                {
                    SINHVIEN sv = new SINHVIEN();
                    sv = DataProvider.Ins.DB.SINHVIENs.Where(x => x.IDSINHVIEN == item.IDSINHVIEN).Single();
                    SINHVIENLIST.Add(sv);

                }
            }
           

        }
    }
}
