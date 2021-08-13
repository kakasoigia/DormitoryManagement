using DomitoryManagement.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DomitoryManagement.ViewModel
{
   public class  BIENLAIFULL :BaseViewModel
    {
        public int IDBL { get; set; }
        public int IDSINHVIEN { get; set; }
        
        public int IDHOCKI { get; set; }
        public int IDPHONG { get; set; }
        public string NGAYINBL { get; set; }
        public string TENNGUOITHU { get; set; }
        public Nullable<bool> DONGTIENPHONG { get; set; }
        public Nullable<bool> DONGTIENBHYT { get; set; }
        public Nullable<bool> DONGTIENBHTN { get; set; }
        public int TONGTIEN { get; set; }
        public string TENHOCKI { get; set; }
        
        public string NGAYBATDAU { get; set; }
        public string NGAYKETHUC { get; set; }
        public string TENNAMHOC { get; set; }
        public string stringTONGTIEN { get; set; }
        public string stringTIENPHONG { get; set; }
        public string TIENPHONGDADONG { get; set; }
        public string HOTEN { get; set; }
        public string MSSV { get; set; }
        public string NGAYVAO { get; set; }
        public BIENLAIFULL()
        {

        }
    }
    
    public class RoomChargeViewModel :BaseViewModel
    {
        private string _MSSVFindNumber;
        public string MSSVFindNumber { get => _MSSVFindNumber; set { _MSSVFindNumber = value; OnPropertyChanged(); } }
        private string _Name;
        public string Name { get => _Name; set { _Name = value; OnPropertyChanged(); } }
        private string _Birthday;
        public string Birthday { get => _Birthday; set { _Birthday = value; OnPropertyChanged(); } }
        private string _Sex;
        public string Sex { get => _Sex; set { _Sex = value; OnPropertyChanged(); } }
        private string _SchoolName;
        public string SchoolName { get => _SchoolName; set { _SchoolName = value; OnPropertyChanged(); } }
        private string _LearningYear;
        public string LearningYear { get => _LearningYear; set { _LearningYear = value; OnPropertyChanged(); } }
        private string _NhaPhong;
        public string NhaPhong { get => _NhaPhong; set { _NhaPhong = value; OnPropertyChanged(); } }
        private string _TENPHONG;
        public string TENPHONG { get => _TENPHONG; set { _TENPHONG = value; OnPropertyChanged(); } }
        private string _TENNHA;
        public string TENNHA { get => _TENNHA; set { _TENNHA = value; OnPropertyChanged(); } }
        private string _TENHOCKI;
        public string TENHOCKI { get => _TENHOCKI; set { _TENHOCKI = value; OnPropertyChanged(); } }
        private string _TENNAMHOC;
        public string TENNAMHOC { get => _TENNAMHOC; set { _TENNAMHOC = value; OnPropertyChanged(); } }
        private string _LOAIPHONG;
        public string LOAIPHONG { get => _LOAIPHONG; set { _LOAIPHONG = value; OnPropertyChanged(); } }


        private string _NGAYINBL;
        public string NGAYINBL { get => _NGAYINBL; set { _NGAYINBL = value; OnPropertyChanged(); } }
        private string _NGAYVAO;
        public string NGAYVAO { get => _NGAYVAO; set { _NGAYVAO = value; OnPropertyChanged(); } }

        private string _TENTIENTHUE;
        public string TENTIENTHUE { get => _TENTIENTHUE; set { _TENTIENTHUE = value; OnPropertyChanged(); } }
        private string _TENTIENBHYT;
        public string TENTIENBHYT { get => _TENTIENBHYT; set { _TENTIENBHYT = value; OnPropertyChanged(); } }
        private string _TENTIENBHTN;
        public string TENTIENBHTN { get => _TENTIENBHTN; set { _TENTIENBHTN = value; OnPropertyChanged(); } }
        private int _TIENTHUE;
        public int TIENTHUE { get => _TIENTHUE; set { _TIENTHUE = value; OnPropertyChanged(); } }
        private int _TIENBHYT;
        public int TIENBHYT { get => _TIENBHYT; set { _TIENBHYT = value; OnPropertyChanged(); } }
        private int _TIENBHTN;
        public int TIENBHTN { get => _TIENBHTN; set { _TIENBHTN = value; OnPropertyChanged(); } }


        private string _stringTIENTHUE;
        public string stringTIENTHUE { get => _stringTIENTHUE; set { _stringTIENTHUE = value; OnPropertyChanged(); } }
        private string _TIENPHONGPHAIDONG;
        public string TIENPHONGPHAIDONG { get => _TIENPHONGPHAIDONG; set { _TIENPHONGPHAIDONG = value; OnPropertyChanged(); } }
        private string _stringTIENBHYT;
        public string stringTIENBHYT { get => _stringTIENBHYT; set { _stringTIENBHYT = value; OnPropertyChanged(); } }
        private string _stringTIENBHTN;
        public string stringTIENBHTN { get => _stringTIENBHTN; set { _stringTIENBHTN = value; OnPropertyChanged(); } }


        private string _SUMMONEY;
        public string SUMMONEY { get => _SUMMONEY; set { _SUMMONEY = value; OnPropertyChanged(); } }
        private string _SUMTIENTHUE;
        public string SUMTIENTHUE { get => _SUMTIENTHUE; set { _SUMTIENTHUE = value; OnPropertyChanged(); } }
        private string _SUMTIENBHTN;
        public string SUMTIENBHTN { get => _SUMTIENBHTN; set { _SUMTIENBHTN = value; OnPropertyChanged(); } }
        private string _SUMTIENBHYT;
        public string SUMTIENBHYT { get => _SUMTIENBHYT; set { _SUMTIENBHYT = value; OnPropertyChanged(); } }

        private int _intSUMMONEY;
        public int intSUMMONEY { get => _intSUMMONEY; set { _intSUMMONEY = value; OnPropertyChanged(); } }
        private int _intSUMTIENTHUE;
        public int intSUMTIENTHUE { get => _intSUMTIENTHUE; set { _intSUMTIENTHUE = value; OnPropertyChanged(); } }
        private int _intSUMTIENBHTN;
        public int intSUMTIENBHTN { get => _intSUMTIENBHTN; set { _intSUMTIENBHTN = value; OnPropertyChanged(); } }
        private int _intSUMTIENBHYT;
        public int intSUMTIENBHYT { get => _intSUMTIENBHYT; set { _intSUMTIENBHYT = value; OnPropertyChanged(); } }
        private int _SelectedRoom;
        public int SelectedRoom { get => _SelectedRoom; set { _SelectedRoom = value; OnPropertyChanged(); } }
        private int _SelectedIDTOA;
        public int SelectedIDTOA { get => _SelectedIDTOA; set { _SelectedIDTOA = value; OnPropertyChanged(); } }
        private int _SelectedIDSINHVIEN;
        public int SelectedIDSINHVIEN { get => _SelectedIDSINHVIEN; set { _SelectedIDSINHVIEN = value; OnPropertyChanged(); } }
        private int _SelectedIDHOCKI;
        public int SelectedIDHOCKI { get => _SelectedIDHOCKI; set { _SelectedIDHOCKI = value; OnPropertyChanged(); } }
        private int _SelectedIDBIENLAI;
        public int SelectedIDBIENLAI { get => _SelectedIDBIENLAI; set { _SelectedIDBIENLAI = value; OnPropertyChanged(); } }
        private int _NumberOfDayLiving;
        public int NumberOfDayLiving { get => _NumberOfDayLiving; set { _NumberOfDayLiving = value; OnPropertyChanged(); } }
        private float _NumberOfMonthLiving;
        public float NumberOfMonthLiving { get => _NumberOfMonthLiving; set { _NumberOfMonthLiving = value; OnPropertyChanged(); } }
        private string _NGAYKETTHUC;
        public string NGAYKETTHUC { get => _NGAYKETTHUC; set { _NGAYKETTHUC = value; OnPropertyChanged(); } }
        private bool _isExistInSVTIENPHONG;
        public bool isExistInSVTIENPHONG { get => _isExistInSVTIENPHONG; set { _isExistInSVTIENPHONG = value; OnPropertyChanged(); } }
        private bool _isExistInSINHVIENLIST;
        public bool isExistInSINHVIENLIST { get => _isExistInSINHVIENLIST; set { _isExistInSINHVIENLIST = value; OnPropertyChanged(); } }
        private bool _DADONGTIENPHONG;
        public bool DADONGTIENPHONG { get => _DADONGTIENPHONG; set { _DADONGTIENPHONG = value; OnPropertyChanged(); } }
        private bool _DADONGTIENBHYT;
        public bool DADONGTIENBHYT { get => _DADONGTIENBHYT; set { _DADONGTIENBHYT = value; OnPropertyChanged(); } }
        private bool _DADONGTIENBHTN;
        public bool DADONGTIENBHTN { get => _DADONGTIENBHTN; set { _DADONGTIENBHTN = value; OnPropertyChanged(); } }
        private bool _isCheckTIENTHUE;
        public bool isCheckTIENTHUE { get => _isCheckTIENTHUE; set { _isCheckTIENTHUE = value; OnPropertyChanged(); } }
        private bool _isCheckTIENBHYT;
        public bool isCheckTIENBHYT { get => _isCheckTIENBHYT; set { _isCheckTIENBHYT = value; OnPropertyChanged(); } }
        private bool _isCheckTIENBHTN;
        public bool isCheckTIENBHTN { get => _isCheckTIENBHTN; set { _isCheckTIENBHTN = value; OnPropertyChanged(); } }
        private bool _isAlterNGBD;
        public bool isAlterNGBD { get => _isAlterNGBD; set { _isAlterNGBD = value; OnPropertyChanged(); } }

        
        public ICommand FindMSSV { get; set; }
        public ICommand SAVEBL { get; set; }
        public ICommand CheckTIENTHUE { get; set; }
        public ICommand UncheckTIENTHUE { get; set; }
        public ICommand CheckTIENBHYT { get; set; }
        public ICommand UncheckTIENBHYT { get; set; }
        public ICommand CheckTIENBHTN { get; set; }
        public ICommand UncheckTIENBHTN { get; set; }
        public ICommand DeleteBL { get; set; }
        public ICommand GetDateCommand { get; set; }
        public ICommand AlterNGBDCommand { get; set; }
        public ICommand SAVENGBDCommand { get; set; }


        private ObservableCollection<DANHSACHSV_TIENPHONG> _SV_TIENPHONGLIST;
        public ObservableCollection<DANHSACHSV_TIENPHONG> SV_TIENPHONGLIST { get => _SV_TIENPHONGLIST; set { _SV_TIENPHONGLIST = value; OnPropertyChanged(); } }
        private ObservableCollection<SINHVIEN> _SINHVIENLIST;
        public ObservableCollection<SINHVIEN> SINHVIENLIST { get => _SINHVIENLIST; set { _SINHVIENLIST = value; OnPropertyChanged(); } }
        private ObservableCollection<TIENTHUEPHONG> _TIENTHUEPHONGLIST;
        public ObservableCollection<TIENTHUEPHONG> TIENTHUEPHONGLIST { get => _TIENTHUEPHONGLIST; set { _TIENTHUEPHONGLIST = value; OnPropertyChanged(); } }
        private ObservableCollection<PHONG> _PHONGLIST;
        public ObservableCollection<PHONG> PHONGLIST { get => _PHONGLIST; set { _PHONGLIST = value; OnPropertyChanged(); } }
        private ObservableCollection<TOA> _TOALIST;
        public ObservableCollection<TOA> TOALIST { get => _TOALIST; set { _TOALIST = value; OnPropertyChanged(); } }
        private ObservableCollection<HOCKI> _HOCKILIST;
        public ObservableCollection<HOCKI> HOCKILIST { get => _HOCKILIST; set { _HOCKILIST = value; OnPropertyChanged(); } }
        private ObservableCollection<BIENLAITIENPHONG> _BIENLAILIST;
        public ObservableCollection<BIENLAITIENPHONG> BIENLAILIST { get => _BIENLAILIST; set { _BIENLAILIST = value; OnPropertyChanged(); } }
        private ObservableCollection<User> _USERLIST;
        public ObservableCollection<User> USERLIST { get => _USERLIST; set { _USERLIST = value; OnPropertyChanged(); } }
        private IEnumerable<BIENLAIFULL> _BIENLAIFULLLIST;
        public IEnumerable<BIENLAIFULL> BIENLAIFULLLIST { get => _BIENLAIFULLLIST; set { _BIENLAIFULLLIST = value; OnPropertyChanged(); } }



        public RoomChargeViewModel()
        { // tìm coi MSSV có thật không // 
            FindMSSV = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                LoadMainView();
            });
            var info = System.Globalization.CultureInfo.GetCultureInfo("vi-VN");
            CheckTIENTHUE = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                intSUMTIENTHUE = (int) (NumberOfMonthLiving * TIENTHUE);

                SUMTIENTHUE = string.Format(info, "{0:c0}", intSUMTIENTHUE);
                intSUMMONEY = (intSUMTIENTHUE + intSUMTIENBHYT + intSUMTIENBHTN);

                SUMMONEY = string.Format(info, "{0:c0}", intSUMMONEY);
                isCheckTIENTHUE = true;


            });
            UncheckTIENTHUE = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                intSUMTIENTHUE = 0;
                SUMTIENTHUE = string.Format(info, "{0:c0}", intSUMTIENTHUE);
                intSUMMONEY = (intSUMTIENTHUE + intSUMTIENBHYT + intSUMTIENBHTN);

                SUMMONEY = string.Format(info, "{0:c0}", intSUMMONEY);
                isCheckTIENTHUE = false;
            });
            CheckTIENBHYT = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                intSUMTIENBHYT = TIENBHYT;
                SUMTIENBHYT = string.Format(info, "{0:c0}", intSUMTIENBHYT);
                intSUMMONEY = (intSUMTIENTHUE + intSUMTIENBHYT + intSUMTIENBHTN);

                SUMMONEY = string.Format(info, "{0:c0}", intSUMMONEY);
                isCheckTIENBHYT = true;
            });
            UncheckTIENBHYT = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                intSUMTIENBHYT = 0;
                SUMTIENBHYT = string.Format(info, "{0:c0}", intSUMTIENBHYT);
                intSUMMONEY = (intSUMTIENTHUE + intSUMTIENBHYT + intSUMTIENBHTN);

                SUMMONEY = string.Format(info, "{0:c0}", intSUMMONEY);
                isCheckTIENBHYT = false;

            });
            CheckTIENBHTN = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                intSUMTIENBHTN = TIENBHTN;
                SUMTIENBHTN = string.Format(info, "{0:c0}", intSUMTIENBHTN);
                intSUMMONEY = (intSUMTIENTHUE + intSUMTIENBHYT + intSUMTIENBHTN);

                SUMMONEY = string.Format(info, "{0:c0}", intSUMMONEY);
                isCheckTIENBHTN = true;
            });
            UncheckTIENBHTN = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                intSUMTIENBHTN = 0;
                SUMTIENBHTN = string.Format(info, "{0:c0}", intSUMTIENBHTN);
                intSUMMONEY = (intSUMTIENTHUE + intSUMTIENBHYT + intSUMTIENBHTN);

                SUMMONEY = string.Format(info, "{0:c0}", intSUMMONEY);
                isCheckTIENBHTN = false;

            });
            SAVEBL = new RelayCommand<object>((p) => { return true; }, (p) =>
            {   //đổi thuộc tính
                foreach (var item in SV_TIENPHONGLIST)
                {
                    if (item.IDSINHVIEN == SelectedIDSINHVIEN)
                    {   if (isCheckTIENBHTN) item.DADONGBHTN = true;
                        if (isCheckTIENBHYT) item.DADONGBHYT = true;
                        if (isCheckTIENTHUE) item.DADONGTIENPHONG = true;
                        
                        break;
                    }
                }
                DataProvider.Ins.DB.SaveChanges();
                if (isCheckTIENBHTN ==false && isCheckTIENBHYT==false && isCheckTIENTHUE==false)
                {
                    MessageBox.Show("Vui lòng chọn vào loại tiền cần đóng! ");

                }
                else
                {   // tạo biên lai
                    BIENLAITIENPHONG bl = new BIENLAITIENPHONG();
                    bl.IDSINHVIEN = SelectedIDSINHVIEN;
                    bl.IDHOCKI = SelectedIDHOCKI;
                    bl.IDPHONG = SelectedRoom;
                    bl.NGAYINBL = NGAYINBL;
                    bl.TIENPHONGDADONG = intSUMTIENTHUE;
                    if (isCheckTIENBHTN) bl.DONGTIENBHTN = true; else bl.DONGTIENBHTN = false;
                    if (isCheckTIENBHYT) bl.DONGTIENBHYT = true; else bl.DONGTIENBHYT = false;

                    if (isCheckTIENTHUE) bl.DONGTIENPHONG = true; else bl.DONGTIENPHONG = false;
                    bl.TONGTIEN = intSUMMONEY;
                    LoginWindow lg = new LoginWindow();
                    var lgDT = lg.DataContext as LoginViewModel;
                    string UserName = lgDT.UserName;
                    USERLIST = new ObservableCollection<User>(DataProvider.Ins.DB.Users);
                    bl.TENNGUOITHU = (from up in USERLIST where up.UserName == UserName select up).Single().TENUSER.ToString();
                    lg.Close();
                    DataProvider.Ins.DB.BIENLAITIENPHONGs.Add(bl);
                    DataProvider.Ins.DB.SaveChanges();
                    MessageBox.Show("Lưu biên lai thành công!");
                    // load lại roomcharge list
                    RoomChargeList rcl = new RoomChargeList();
                    var rclDT = rcl.DataContext as RoomChargeListViewModel;
                    rclDT.LoadSVList();
                    rcl.Close();
                    // load main
                    MainWindow main = new MainWindow();
                    var mainDT = main.DataContext as MainViewModel;
                    mainDT.LoadChartSV();
                    main.Close();
                    // sửa BIENLAITHUEPHONG
                   if (isCheckTIENTHUE)
                    {
                        var BIENLAITHUE = (from up in DataProvider.Ins.DB.BIENLAITHUEPHONGs where up.IDSINHVIEN == SelectedIDSINHVIEN && up.IDPHONG == SelectedRoom && up.IDHOCKI == SelectedIDHOCKI select up).Single();
                        BIENLAITHUE.DADONGTIENPHONG = true;
                    }
                }
               
               LoadMainView();
            });
            //hủy biên lai
            DeleteBL = new RelayCommand<object>((p) => { return true; }, (p) =>
                 {      int SelectedDLBL = (int)p;
                     
                     BIENLAITIENPHONG bl = new BIENLAITIENPHONG();
                     bl = DataProvider.Ins.DB.BIENLAITIENPHONGs.Where(x => x.IDBL == SelectedDLBL).Single();
                     var svtp = DataProvider.Ins.DB.DANHSACHSV_TIENPHONG.Where(x => x.IDSINHVIEN == SelectedIDSINHVIEN);
                     if (svtp.Count() != 0)
                     {
                         if (bl.DONGTIENBHTN == true) svtp.Single().DADONGBHTN = false;
                         if (bl.DONGTIENBHYT == true) svtp.Single().DADONGBHYT = false;
                         if (bl.DONGTIENPHONG == true) svtp.Single().DADONGTIENPHONG = false;
                     }

                     // sửa lại BIENLAITHUE//
                     if (bl.DONGTIENPHONG == true)
                     {
                         var BIENLAITHUE = (from up in DataProvider.Ins.DB.BIENLAITHUEPHONGs where up.IDSINHVIEN == SelectedIDSINHVIEN && up.IDPHONG == bl.IDPHONG && up.IDHOCKI == bl.IDHOCKI select up);
                         if (BIENLAITHUE.Count() != 0)
                             BIENLAITHUE.Single().DADONGTIENPHONG = false;
                     }
                     //
                     DataProvider.Ins.DB.BIENLAITIENPHONGs.Remove(bl);
                     DataProvider.Ins.DB.SaveChanges();
                     MessageBox.Show("Đã hủy thành công biên lai!");
                     LoadMainView();
                     // load main
                     MainWindow main = new MainWindow();
                     var mainDT = main.DataContext as MainViewModel;
                     mainDT.LoadChartSV();
                     main.Close();
                     // load lại roomchargelist
                     RoomChargeList rcl = new RoomChargeList();
                     var rclDT = rcl.DataContext as RoomChargeListViewModel;
                     rclDT.LoadSVList();
                     rcl.Close();

                 });
            AlterNGBDCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                isAlterNGBD = true;
            });
            SAVENGBDCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                
                var update = (from up in DataProvider.Ins.DB.DANHSACHSV_PHONG where  up.IDSINHVIEN ==(int)SelectedIDSINHVIEN  select up).Single();
                update.NGAYVAO = NGAYVAO;
                var update2 = (from up in DataProvider.Ins.DB.DANHSACHSV_TIENPHONG where  up.IDSINHVIEN == (int)SelectedIDSINHVIEN select up).Single();
                update2.NGAYVAO = NGAYVAO;
                DataProvider.Ins.DB.SaveChanges();
                MessageBox.Show("Lưu thành công!");
                LoadMainView();
                isAlterNGBD = false;
                // load lại main
                //load lai main
                BuildingDiagram bd = new BuildingDiagram();
                var bdDT = bd.DataContext as BuildingDiagramViewModel;
                bdDT.LoadToa();
                MainWindow mw = new MainWindow();
                var mwDT = mw.DataContext as MainViewModel;
                mwDT.LoadChartSV();
                mw.Close();
            });
            GetDateCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                isAlterNGBD = true;
                NGAYVAO = NGAYINBL;
            });
        }
        public void Load()
        {   
           
            //MSSVFindNumber = "" ;
           

            ResetAll();
            


        }
        public  int CalculateDay(string ngayvao, string ngaytraphong)
        {
            DateTime ngvao = Convert.ToDateTime(ngayvao);
            DateTime ngtraphong = Convert.ToDateTime(ngaytraphong);
            TimeSpan Time = ngtraphong - ngvao;
            return Time.Days;
        }
        public  bool CheckNgay(string ngbd, string ngkt, string nght)
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
        public  void ResetAll ()
        {
            TENHOCKI = "";
            LOAIPHONG = "";
            SV_TIENPHONGLIST = new ObservableCollection<DANHSACHSV_TIENPHONG>(DataProvider.Ins.DB.DANHSACHSV_TIENPHONG);
            PHONGLIST = new ObservableCollection<PHONG>(DataProvider.Ins.DB.PHONGs);
            TIENTHUEPHONGLIST = new ObservableCollection<TIENTHUEPHONG>(DataProvider.Ins.DB.TIENTHUEPHONGs);
            SINHVIENLIST = new ObservableCollection<SINHVIEN>(DataProvider.Ins.DB.SINHVIENs);
            TOALIST = new ObservableCollection<TOA>(DataProvider.Ins.DB.TOAs);
            HOCKILIST = new ObservableCollection<HOCKI>(DataProvider.Ins.DB.HOCKIs);
            BIENLAILIST = new ObservableCollection<BIENLAITIENPHONG>(DataProvider.Ins.DB.BIENLAITIENPHONGs);
            BIENLAIFULLLIST = Enumerable.Empty<BIENLAIFULL>();
            //reset các thuộc tính
            isExistInSINHVIENLIST = false;
            isExistInSVTIENPHONG = false;
            DADONGTIENBHTN = false;
            DADONGTIENBHYT = false;
            DADONGTIENPHONG = false;
            isCheckTIENBHTN = false;
            isCheckTIENBHYT = false;
            isCheckTIENTHUE = false;
            intSUMTIENTHUE = 0;
            intSUMTIENBHYT = 0;
            intSUMTIENBHTN = 0;
            SUMTIENBHTN = null;
            SUMMONEY = null;
            SUMTIENBHYT = null;
            SUMTIENTHUE = null;
            intSUMMONEY = 0;
            SUMMONEY = null;
            isAlterNGBD = false;

            //SelectedIDSINHVIEN = SelectedIDSINHVIEN;
            SelectedRoom = 0;
            TIENBHTN = 0;
            TIENBHYT = 0;
            SelectedIDHOCKI = 0;
            NGAYVAO = null;
            DADONGTIENPHONG = false;
            DADONGTIENBHYT = false;
            DADONGTIENBHTN = false;

            Name = null;
            Birthday = null;
            LearningYear = null;
            SchoolName = null;
            Sex = null;

            NGAYKETTHUC = null;
            TENHOCKI = null;

            TENTIENBHTN = null;
            TENTIENBHYT = null;
            TENTIENTHUE = null;
            stringTIENBHTN = null;
            stringTIENBHYT = null;
            stringTIENTHUE = null;

            NhaPhong = null;
        }
        public void LoadMainView()
        {
            //reset các bảng

            ResetAll();
            NGAYINBL = DateTime.Now.ToShortDateString().ToString().Trim();
            // kiem tra su ton tai //
            foreach (var item in SINHVIENLIST)
            {
                if (item.MSSV == MSSVFindNumber.ToString())
                {
                    isExistInSINHVIENLIST = true;
                    SelectedIDSINHVIEN = item.IDSINHVIEN;

                    break;

                }
            }
            // nếu không tồn tại 
            if (isExistInSINHVIENLIST == false)
            {
                MessageBox.Show("MSSV không tồn tại!");

            }
            else // nếu có tồn tại MSSV thì thực hiện 
            {
                foreach (var item in SV_TIENPHONGLIST)
                {
                    if (item.IDSINHVIEN == (int)SelectedIDSINHVIEN)
                    {
                        isExistInSVTIENPHONG = true;  // có tồn tại//
                        SelectedIDSINHVIEN = SelectedIDSINHVIEN;
                        SelectedRoom = (int)item.IDPHONG;
                        TIENBHTN = (int)item.TIENBHTN;
                        TIENBHYT = (int)item.TIENBHYT;
                        SelectedIDHOCKI = (int)item.IDHOCKI;
                        NGAYVAO = item.NGAYVAO;
                        DADONGTIENPHONG = (bool)item.DADONGTIENPHONG;
                        DADONGTIENBHYT = (bool)item.DADONGBHYT;
                        DADONGTIENBHTN = (bool)item.DADONGBHTN;

                        break;
                    }
                }
                // nếu có tồn tại trong LIST thì thực hiện lệnh , k thì bỏ
                if (isExistInSVTIENPHONG == false)
                {
                    MessageBox.Show("Không tìm thấy sinh viên");
                }
                else // nếu có sinh viên trong danh sách 
                {
                    // hiện giá phòng
                    foreach (var item in PHONGLIST)
                    {
                        if (item.IDPHONG == SelectedRoom)
                        {
                            SelectedIDTOA = item.IDTOA;
                            TENPHONG = item.TENPHONG;
                            foreach (var item2 in TIENTHUEPHONGLIST)
                            {
                                item.LOAIPHONG = (int)item2.LOAIPHONG;
                                TIENTHUE = (int)item2.TIENTHUE;
                                LOAIPHONG = " , Phòng " + item.LOAIPHONG.ToString() + " giường";

                            }
                        }
                    }
                    // lấy info sinh viên
                    foreach (var item in SINHVIENLIST)
                    {
                        if (item.IDSINHVIEN == SelectedIDSINHVIEN)
                        {
                            Name = item.HOTEN;
                            Birthday = item.NGAYSINH;
                            LearningYear = item.SINHVIENNAM;
                            SchoolName = item.TENTRUONG;
                            Sex = (bool)item.GIOITINH == true ? "Nam" : "Nữ";
                            break;

                        }
                    }
                    // lấy thông tin tòa
                    foreach (var item in TOALIST)
                    {
                        if (item.IDTOA == SelectedIDTOA)
                        {
                            TENNHA = item.TENTOA;
                            break;
                        }

                    }
                    // làm tên NHAPHONG
                    NhaPhong = string.Concat(TENNHA, " - ", TENPHONG);
                    //lấy ngày kết thúc học kì//
                    foreach (var item in HOCKILIST)
                    {
                        if (item.IDHOCKI == SelectedIDHOCKI)
                        {
                            NGAYKETTHUC = item.NGAYKETHUC;
                            TENHOCKI = item.TENHOCKI + "( "+ item.TENNAMHOC +" )";
                        }
                    }
                    // tính tiền phòng phải đóng

                    NumberOfDayLiving = CalculateDay(NGAYVAO, NGAYKETTHUC);
                    //if (NumberOfDayLiving % 30 < 7) NumberOfMonthLiving = (int)NumberOfDayLiving / 30;

                    //else NumberOfMonthLiving = NumberOfDayLiving / 30 + 1;
                    NumberOfMonthLiving = (float)NumberOfDayLiving / 30;
                    //hết

                    // load tên  tiền thuê 
                    var info1 = System.Globalization.CultureInfo.GetCultureInfo("vi-VN");
                    stringTIENBHTN = string.Format(info1, "{0:c0}", TIENBHTN);
                    stringTIENTHUE = string.Format(info1, "{0:c0}", TIENTHUE);
                    stringTIENBHYT = string.Format(info1, "{0:c0}", TIENBHYT);

                    TENTIENTHUE = "Tiền LPNT " + TENHOCKI + " \n(Từ " + NGAYVAO + " đến " + NGAYKETTHUC + ")";
                    TENTIENBHYT = "BHYT( 1 tháng x 38.115)";
                    TENTIENBHTN = "BHTN 40.000đ ";

                    if (DADONGTIENBHTN == true) SUMTIENBHTN = "Đã đóng ";
                    if (DADONGTIENPHONG == true) SUMTIENTHUE = "Đã đóng ";
                    if (DADONGTIENBHYT == true) SUMTIENBHYT = "Đã đóng ";
                    // lấy số biên lai
                    int count = BIENLAILIST.Count();
                    if (count == 0)
                    {
                        SelectedIDBIENLAI = 1;
                    }
                    else
                    {
                        SelectedIDBIENLAI = BIENLAILIST.ToList().Last().IDBL + 1;
                    }
                    // load Biên lai 
                    
                    TIENPHONGPHAIDONG = string.Format(info1, "{0:c0}", (NumberOfMonthLiving * TIENTHUE));


                    BIENLAIFULLLIST = BIENLAILIST.Where(x=> x.IDSINHVIEN ==SelectedIDSINHVIEN ).Join(
                     HOCKILIST,
                     b => b.IDHOCKI,
                     c => c.IDHOCKI,

                     (b, c) => new BIENLAIFULL()
                     {

                         IDBL = b.IDBL,
                         IDSINHVIEN = (int)b.IDSINHVIEN,

                         IDPHONG = (int)b.IDPHONG,
                         NGAYINBL = b.NGAYINBL,
                         TENNGUOITHU = b.TENNGUOITHU,
                         DONGTIENPHONG = (bool)b.DONGTIENPHONG,
                         DONGTIENBHTN = (bool)b.DONGTIENBHTN,
                         DONGTIENBHYT = (bool)b.DONGTIENBHYT,
                         TONGTIEN = (int)b.TONGTIEN,
                         TENHOCKI = c.TENHOCKI,
                         TENNAMHOC = c.TENNAMHOC,
                         IDHOCKI = c.IDHOCKI,
                         NGAYBATDAU = c.NGAYBATDAU,
                         NGAYKETHUC = c.NGAYKETHUC,
                         stringTONGTIEN = string.Format(info1, "{0:c0}", b.TONGTIEN),
                         TIENPHONGDADONG = string.Format(info1, "{0:c0}", b.TIENPHONGDADONG),
                         NGAYVAO = this.NGAYVAO

                     }
                     );



                }
            }

        }
    }
    
}


