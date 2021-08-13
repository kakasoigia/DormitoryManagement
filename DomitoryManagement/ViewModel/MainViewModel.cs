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
    public class MainViewModel : BaseViewModel
    {
        
        private int _NumberOfToa;
        public int NumberOfToa { get => _NumberOfToa; set { _NumberOfToa = value; OnPropertyChanged(); } }

        private int _NumberOfRoom;
        public int NumberOfRoom { get => _NumberOfRoom; set { _NumberOfRoom = value; OnPropertyChanged(); } }
        private int _NumberOfStudent;
        public int NumberOfStudent { get => _NumberOfStudent; set { _NumberOfStudent = value; OnPropertyChanged(); } }
        private string _TENHOCKI;
        public string TENHOCKI { get => _TENHOCKI; set { _TENHOCKI = value; OnPropertyChanged(); } }
        private int _sumSVCHUADONG;
        public int sumSVCHUADONG { get => _sumSVCHUADONG; set { _sumSVCHUADONG = value; OnPropertyChanged(); } }
        private int _sumSVDADONG;
        public int sumSVDADONG { get => _sumSVDADONG; set { _sumSVDADONG = value; OnPropertyChanged(); } }
        private string _THANGNAM;
        public string THANGNAM { get => _THANGNAM; set { _THANGNAM = value; OnPropertyChanged(); } }
        private int _sumPHONGDADONG;
        public int sumPHONGDADONG { get => _sumPHONGDADONG; set { _sumPHONGDADONG = value; OnPropertyChanged(); } }
        private int _sumPHONGCHUADONG;
        public int sumPHONGCHUADONG { get => _sumPHONGCHUADONG; set { _sumPHONGCHUADONG = value; OnPropertyChanged(); } }
        private int _SLPHONGDATHUE;
        public int SLPHONGDATHUE { get => _SLPHONGDATHUE; set { _SLPHONGDATHUE = value; OnPropertyChanged(); } }
        private ObservableCollection<Consumo> _DONGPHICHART;
        public ObservableCollection<Consumo> DONGPHICHART { get => _DONGPHICHART; set { _DONGPHICHART = value; OnPropertyChanged(); } }

        private ObservableCollection<Consumo> _DIENNUOCCHART;
        public ObservableCollection<Consumo> DIENNUOCCHART { get => _DIENNUOCCHART; set { _DIENNUOCCHART = value; OnPropertyChanged(); } }




        //public ICommand ChangePasswordCommand { get; set; }
        public bool IsLoadeddd = false;
        public ICommand LoadedWindowCommand { get; set; }
        public ICommand ChangePasswordCommand { get; set; }
        public ICommand StudentInforCommand { get; set; }
        public ICommand UserInfoCommand { get; set; }
        public ICommand AddStudentCommand { get; set; }
        public ICommand HiringRoomCommand { get; set; }
        public ICommand BuildingDiagramCommand { get; set; }
        public ICommand RoomChargeCommand { get; set; }
        public ICommand LogOutCommand { get; set; }
        public ICommand RoomTypeCommand { get; set; }
        public ICommand ReceiptListCommand { get; set; }
        public ICommand SemesterSettingCommand { get; set; }
        public ICommand CheckOutCommand { get; set; }
        public ICommand RefundCommand { get; set; }
        public ICommand EWReceiptListCommand { get; set; }
        public ICommand EWListCostCommand { get; set; }
        public ICommand SettingCostEWCommand { get; set; }
        public MainViewModel()
        {   // LOgin
            LoadedWindowCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                LoadWindowCommandVoid(p);
                LoadBLEWTuSinh();
                LoadQuaKiMoi();
                isEmptyDTB();

            });
            //Change Password
            ChangePasswordCommand = new RelayCommand<object>((p) => { return true; }, (p) => { ChangePassword cp = new ChangePassword(); var cpDT = cp.DataContext as ChangePassWordViewModel;cpDT.Reset(); cp.ShowDialog(); cp.Close(); });
            StudentInforCommand = new RelayCommand<object>((p) => { return true; }, (p) => 
            {
                StudentFullList si = new StudentFullList();
                var siDT = si.DataContext as StudentFullListViewModel;
                
                siDT.isFilter = false;
                siDT.LoadSVList();
                si.ShowDialog();
                si.Close();
            });
            UserInfoCommand = new RelayCommand<object>((p) => { return true; }, (p) => 
            {
                UserInfo ui = new UserInfo();
                var uiDT = ui.DataContext as UserInfoViewModel;
                uiDT.LoadInfor();
                ui.ShowDialog();
                ui.Close();
            });
            AddStudentCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                AddStudent ui = new AddStudent();
                var uiDC = ui.DataContext as AddStudentViewModel;
                uiDC.LoadID();
                ui.ShowDialog();
                ui.Close();
            });
            HiringRoomCommand = new RelayCommand<object>((p) => { return true; }, (p) => 
            {
                HiringRoom ui = new HiringRoom();
                var uiDT = ui.DataContext as HiringRoomViewModel;
                uiDT.isFilter = false;
                uiDT.Load();
                uiDT.LoadListChuaThue();
                ui.ShowDialog(); ui.Close();
            });
            BuildingDiagramCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                BuildingDiagram bd = new BuildingDiagram();
                var bdDT = bd.DataContext as BuildingDiagramViewModel;
                bdDT.LoadToa();
                bd.ShowDialog();
                bd.Close();

            });
            RoomChargeCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                RoomChargeList rc = new RoomChargeList();
                var rcDT = rc.DataContext as RoomChargeListViewModel;
                rcDT.LoadSVList();
                rc.ShowDialog();

                rc.Close();
            });
            LogOutCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
               
                MessageBoxResult result = MessageBox.Show("Bạn có chắc muốn đăng xuất !" ,"Log Out", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    LoadWindowCommandVoid( p);
                }

            });
            RoomTypeCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {

                Roomtype rt = new Roomtype();
                rt.ShowDialog();
                rt.Close();

            });
            ReceiptListCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {

                ReceiptList rl = new ReceiptList();
                var rlDT = rl.DataContext as ReceiptListViewModel;
                rlDT.isFilter = false;
                rlDT.LoadMainView();
               
                rl.ShowDialog();
                rl.Close();

            });
            SemesterSettingCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                SemesterList sl = new SemesterList();
                var slDT = sl.DataContext as SemesterListViewModel;
                slDT.LoadList();
                sl.ShowDialog();
                sl.Close();
            });
            CheckOutCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                CheckOutList col = new CheckOutList();
                var colDT = col.DataContext as CheckOutListViewModel;
                colDT.isFilter = false;
                colDT.LoadSVList();
                col.ShowDialog();
                col.Close();
            });
            RefundCommand =   new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                Refund rf = new Refund();
                var rfDT = rf.DataContext as RefundViewModel;
                rfDT.LoadBL();
                rf.ShowDialog();
                rf.Close();
            });
            EWReceiptListCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                EWReceiptList rf = new EWReceiptList();
                var rfDT = rf.DataContext as EWReceiptViewModel;
                rfDT.LoadListEW();
                rf.ShowDialog();
                rf.Close();
            });
            EWListCostCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                EWCostList rf = new EWCostList();
                var rfDT = rf.DataContext as EWCostListViewModel;
                rfDT.LoadCost();
                rf.ShowDialog();
                rf.Close();
            });
        }
       public void LoadStatis()
        {
            
            // Load góc trên//
            NumberOfToa = DataProvider.Ins.DB.TOAs.Count();
            NumberOfRoom = DataProvider.Ins.DB.PHONGs.Count();
            NumberOfStudent = DataProvider.Ins.DB.DANHSACHSV_TIENPHONG.Count();
            //lấy tháng năm hiện tại



            // Load  DONGPHICHART
            //lay hoc ki
            ObservableCollection<HOCKI> HOCKILIST = new ObservableCollection<HOCKI>(DataProvider.Ins.DB.HOCKIs);
           
            int IDHOCKI = getIDHOCKI(DateTime.Today.ToShortDateString().ToString());
            
            foreach (var item in HOCKILIST)
            {
                if (item.IDHOCKI == IDHOCKI)
                {
                    
                    TENHOCKI = item.TENHOCKI + "( " + item.TENNAMHOC + " )";
                }
            }
            
            //set thuộc tính chart 2
            
           
           

        }
        public void LoadChartSV()
        {
            sumSVCHUADONG = (from up in DataProvider.Ins.DB.DANHSACHSV_TIENPHONG where up.DADONGTIENPHONG == false select up).Count();
            sumSVDADONG = (from up in DataProvider.Ins.DB.DANHSACHSV_TIENPHONG where up.DADONGTIENPHONG == true select up).Count();
            DONGPHICHART = new ObservableCollection<Consumo>();
            // nạp dữ liệu vào Chart1
            Consumo csm1 = new Consumo();
            csm1.Percentage = Convert.ToDouble(String.Format("{0:0.##}", CalPercentage(sumSVDADONG, NumberOfStudent)));
            csm1.Titile = "Đã đóng";
            DONGPHICHART.Add(csm1);

            Consumo csm2 = new Consumo();
            csm2.Percentage = 100 - csm1.Percentage;
            csm2.Titile = "Chưa đóng";
            DONGPHICHART.Add(csm2);
        }
        public void LoadChartPhong()
        {
            ObservableCollection<TIENDIENNUOC> TIENDIENNUOCLIST = new ObservableCollection<TIENDIENNUOC>(DataProvider.Ins.DB.TIENDIENNUOCs);
            sumPHONGDADONG = TIENDIENNUOCLIST.Where(x => CompareMonth(x.THOIGIAN) == 1 && x.TINHTRANG == true).Count();
            sumPHONGCHUADONG = TIENDIENNUOCLIST.Where(x => CompareMonth(x.THOIGIAN) == 1 && x.TINHTRANG == false).Count();
            SLPHONGDATHUE = sumPHONGDADONG + sumPHONGCHUADONG;
            THANGNAM = DateTime.Today.AddMonths(-1).ToString("MM/yyyy");
            //nạp dữ liệu vào CHart2

            DIENNUOCCHART = new ObservableCollection<Consumo>();
            Consumo csm3 = new Consumo();
            csm3.Percentage = Convert.ToDouble(String.Format("{0:0.##}", CalPercentage(sumPHONGDADONG, SLPHONGDATHUE)));
            csm3.Titile = "Đã đóng";
            DIENNUOCCHART.Add(csm3);

            Consumo csm4 = new Consumo();
            csm4.Percentage = 100 - csm3.Percentage;
            csm4.Titile = "Chưa đóng";
            DIENNUOCCHART.Add(csm4);
        }
        public void LoadWindowCommandVoid ( Window p)
        {
            //load ham MAIN
            IsLoadeddd = true;
            if (p == null)
                return;
            p.Hide();
            LoginWindow lg = new LoginWindow();
           
            var Login = lg.DataContext as LoginViewModel;
            Login.ResetPass();
            lg.ShowDialog();
            lg.Close();
            //test null
            if (lg.DataContext == null)
                return;
            // test dang nhap thanh cong?
         


            if (Login.IsLogin)

            {

                p.Show();
                LoadStatis();
                LoadChartSV();
                LoadChartPhong();


            }
            else

            {
                p.Close();
            }

        }
        public void LoadBLEWTuSinh()
        {
            bool isCreate = false;
            ObservableCollection<TIENDIENNUOC> TIENDIENNUOCLIST = new ObservableCollection<TIENDIENNUOC>(DataProvider.Ins.DB.TIENDIENNUOCs);
            ObservableCollection<DANHSACHSV_PHONG> DDSV_PHONGLIST = new ObservableCollection<DANHSACHSV_PHONG>(DataProvider.Ins.DB.DANHSACHSV_PHONG);
            DateTime today = DateTime.Today;
            if (DDSV_PHONGLIST.Count() != 0)
            {
                if (TIENDIENNUOCLIST.Count() == 0) isCreate = true;
                else
                {
                    DateTime lastmonth = DataProvider.Ins.DB.TIENDIENNUOCs.ToList().Last().THOIGIAN;
                    if (CompareMonth(lastmonth) == 2) isCreate = true;
                    //if (today.Month - lastmonth.Month) isCreate = true;
                }
                // nếu qua tháng mới (tháng hiện tại khác tháng cũ ) 
                if (isCreate == true)
                {
                    // thêm tiền điện nc
                    foreach (var phong in DDSV_PHONGLIST)
                    {
                        TIENDIENNUOC td = new TIENDIENNUOC();
                        td.IDPHONG = phong.IDPHONG;
                        td.THOIGIAN = DateTime.Today.AddMonths(-1);
                        td.CHISODIEN = 0;
                        td.CHISONUOC = 0;
                        td.TINHTRANG = false;
                        td.NGAYTHU = null;
                        td.THANHTIEN = 0;
                        DataProvider.Ins.DB.TIENDIENNUOCs.Add(td);
                        DataProvider.Ins.DB.SaveChanges();
                    }
                    MessageBox.Show("Hiện đã qua tháng mới ! \n Xin vui lòng cập nhật thông tin điện nước cho các phòng!");
                }
           
            }
        }
        public void LoadQuaKiMoi()
        {
        }
        public void isEmptyDTB()
        {   // check HOCKI null hay k 
            var HOCKILIST = DataProvider.Ins.DB.HOCKIs;
            if (HOCKILIST.Count() == 0)
            {  
                HOCKI hk = new HOCKI() { TENHOCKI = "HK1" , TENNAMHOC = "2017-2018", NGAYBATDAU  = "1/7/2017",NGAYKETHUC= "31/12/2017" };
                DataProvider.Ins.DB.HOCKIs.Add(hk);
                DataProvider.Ins.DB.SaveChanges();
                hk = new HOCKI() { TENHOCKI = "HK2", TENNAMHOC = "2017-2018", NGAYBATDAU = "1/1/2018", NGAYKETHUC = "30/6/2018" };
                DataProvider.Ins.DB.HOCKIs.Add(hk);
                DataProvider.Ins.DB.SaveChanges();
                hk = new HOCKI() { TENHOCKI = "HK1", TENNAMHOC = "2018-2019", NGAYBATDAU = "1/7/2018", NGAYKETHUC = "31/12/2018" };
                DataProvider.Ins.DB.HOCKIs.Add(hk);
                DataProvider.Ins.DB.SaveChanges();
                hk = new HOCKI() { TENHOCKI = "HK2", TENNAMHOC = "2018-2019", NGAYBATDAU = "1/1/2019", NGAYKETHUC = "30/6/2019" };
                DataProvider.Ins.DB.HOCKIs.Add(hk);
                DataProvider.Ins.DB.SaveChanges();
                hk = new HOCKI() { TENHOCKI = "HK1", TENNAMHOC = "2019-2020", NGAYBATDAU = "1/7/2019", NGAYKETHUC = "31/12/2019" };
                DataProvider.Ins.DB.HOCKIs.Add(hk);
                DataProvider.Ins.DB.SaveChanges();
                hk = new HOCKI() { TENHOCKI = "HK2", TENNAMHOC = "2019-2020", NGAYBATDAU = "1/1/2020", NGAYKETHUC = "30/6/2020" };
                DataProvider.Ins.DB.HOCKIs.Add(hk);
                DataProvider.Ins.DB.SaveChanges();
            }
            // check loai phong 
            var LOAIPHONGLIST = DataProvider.Ins.DB.TIENTHUEPHONGs;
            if (LOAIPHONGLIST.Count()== 0)
            {
                TIENTHUEPHONG loaiphong = new TIENTHUEPHONG() { LOAIPHONG = 2, TIENTHUE = 600000, SOGIUONG = 2 };
                DataProvider.Ins.DB.TIENTHUEPHONGs.Add(loaiphong);
                DataProvider.Ins.DB.SaveChanges();
                 loaiphong = new TIENTHUEPHONG() { LOAIPHONG = 4, TIENTHUE = 400000, SOGIUONG = 4 };
                DataProvider.Ins.DB.TIENTHUEPHONGs.Add(loaiphong);
                DataProvider.Ins.DB.SaveChanges();
                loaiphong = new TIENTHUEPHONG() { LOAIPHONG = 6, TIENTHUE = 200000, SOGIUONG = 3 };
                DataProvider.Ins.DB.TIENTHUEPHONGs.Add(loaiphong);
                DataProvider.Ins.DB.SaveChanges();
                loaiphong = new TIENTHUEPHONG() { LOAIPHONG = 8, TIENTHUE = 150000, SOGIUONG = 4 };
                DataProvider.Ins.DB.TIENTHUEPHONGs.Add(loaiphong);
                DataProvider.Ins.DB.SaveChanges();
            }
            // check GIADIEN
            var GIADIENLIST = DataProvider.Ins.DB.GIADIENs;
            if (GIADIENLIST.Count() ==0)
            {
                GIADIEN dien = new GIADIEN() {ID= 1, GIADIEN1 =1678, CHITIETGIA = "Cho kWh từ 0 - 50" };
                DataProvider.Ins.DB.GIADIENs.Add(dien);
                DataProvider.Ins.DB.SaveChanges();
                 dien = new GIADIEN() { ID = 2, GIADIEN1 = 1734, CHITIETGIA = "Cho kWh từ 51 - 100" };
                DataProvider.Ins.DB.GIADIENs.Add(dien);
                DataProvider.Ins.DB.SaveChanges();
                 dien = new GIADIEN() { ID = 3, GIADIEN1 = 2014, CHITIETGIA = "Cho kWh từ 101 - 200" };
                DataProvider.Ins.DB.GIADIENs.Add(dien);
                DataProvider.Ins.DB.SaveChanges();
                dien = new GIADIEN() { ID = 4, GIADIEN1 = 2536, CHITIETGIA = "Cho kWh từ 201 - 300" };
                DataProvider.Ins.DB.GIADIENs.Add(dien);
                DataProvider.Ins.DB.SaveChanges();
                dien = new GIADIEN() { ID = 5, GIADIEN1 = 2834, CHITIETGIA = "Cho kWh từ 301 - 400" };
                DataProvider.Ins.DB.GIADIENs.Add(dien);
                DataProvider.Ins.DB.SaveChanges();
                dien = new GIADIEN() { ID = 6, GIADIEN1 = 2927, CHITIETGIA = "Cho kWh từ 401 trở lên" };
                DataProvider.Ins.DB.GIADIENs.Add(dien);
                DataProvider.Ins.DB.SaveChanges();
            }
            var GIANUOCLIST = DataProvider.Ins.DB.GIANUOCs;
            if (GIANUOCLIST.Count()==0)
            {
                GIANUOC nuoc = new GIANUOC() { ID = 1, GIANUOC1 = 6869, CHITIETGIA = "10m3 đầu tiên" };
                DataProvider.Ins.DB.GIANUOCs.Add(nuoc);
                DataProvider.Ins.DB.SaveChanges();
                 nuoc = new GIANUOC() { ID = 2, GIANUOC1 = 8110, CHITIETGIA = "Từ 10m3 đến 20m3" };
                DataProvider.Ins.DB.GIANUOCs.Add(nuoc);
                DataProvider.Ins.DB.SaveChanges();
                 nuoc = new GIANUOC() { ID = 3, GIANUOC1 = 9969, CHITIETGIA = "Từ 21m3 đến 30m3" };
                DataProvider.Ins.DB.GIANUOCs.Add(nuoc);
                DataProvider.Ins.DB.SaveChanges();
                 nuoc = new GIANUOC() { ID = 4, GIANUOC1 = 18318, CHITIETGIA = "Trên 31m3" };
                DataProvider.Ins.DB.GIANUOCs.Add(nuoc);
                DataProvider.Ins.DB.SaveChanges();
            }
        }
        public class Consumo
        {
            public string Titile { get; set; }
            public double Percentage { get; set; }
            public Consumo()
            {
            }
        }
        public float CalPercentage(float SLDANOP, float SLTONG)
        {
            return ((SLDANOP / SLTONG) * 100);
        }
        public int CompareMonth(DateTime ngayblcuoicung)
        {
            DateTime today = DateTime.Today;

            if ((today.Year > ngayblcuoicung.Year))
            {
                return ((today.Year - ngayblcuoicung.Year) * 12 + today.Month - ngayblcuoicung.Month);
            }
            else if (today.Year == ngayblcuoicung.Year)
            {
                if (today.Month > ngayblcuoicung.Month)
                {
                    return today.Month - ngayblcuoicung.Month;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }
        public bool CheckNgay(string ngbd, string ngkt, string nght)
        {

            DateTime ngaybd = Convert.ToDateTime(ngbd);
            DateTime ngaykt = Convert.ToDateTime(ngkt);
            DateTime ngayht = Convert.ToDateTime(nght);
            TimeSpan check1 = ngayht - ngaybd;
            TimeSpan check2 = ngaykt - ngayht;
            if (check1.Days >= 0 && check2.Days >= 0)
                return true;
            else
                return false;

        }
        public int getIDHOCKI(string Ngayvao)
        {
            ObservableCollection<HOCKI> HOCKILIST = new ObservableCollection<HOCKI>(DataProvider.Ins.DB.HOCKIs);
            HOCKILIST = new ObservableCollection<HOCKI>(DataProvider.Ins.DB.HOCKIs);
            foreach (HOCKI item in HOCKILIST)
            {
                if (CheckNgay(item.NGAYBATDAU, item.NGAYKETHUC, Ngayvao)) return item.IDHOCKI;
            }
            return 0;

        }

    }

}
