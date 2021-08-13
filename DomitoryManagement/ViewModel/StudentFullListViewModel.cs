using DomitoryManagement.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DomitoryManagement.ViewModel
{   public class StudentInfo : BaseViewModel
    {
        private int _IDSINHVIEN;
        public int IDSINHVIEN { get => _IDSINHVIEN; set { _IDSINHVIEN = value; OnPropertyChanged(); } }
        private string _MSSV;
        public string MSSV
        {
            get => _MSSV; set { _MSSV = value; OnPropertyChanged(); }
        }
        private string _HOTEN;
        public string HOTEN { get => _HOTEN; set { _HOTEN = value; OnPropertyChanged(); } }
        private string _TENTOA;
        public string TENTOA { get => _TENTOA; set { _TENTOA = value; OnPropertyChanged(); } }
        private string _TENPHONG;
        public string TENPHONG { get => _TENPHONG; set { _TENPHONG = value; OnPropertyChanged(); } }
        private string _TENTRUONG;
        public string TENTRUONG { get => _TENTRUONG; set { _TENTRUONG = value; OnPropertyChanged(); } }
        private string _DIACHI;
        public string DIACHI { get => _DIACHI; set { _DIACHI = value; OnPropertyChanged(); } }
        private string _NGAYVAO;
        public string NGAYVAO { get => _NGAYVAO; set { _NGAYVAO = value; OnPropertyChanged(); } }
        private bool _DADONGBHYT;
        public bool DADONGBHYT { get => _DADONGBHYT; set { _DADONGBHYT = value; OnPropertyChanged(); } }
        private bool _DADONGBHTN;
        public bool DADONGBHTN { get => _DADONGBHTN; set { _DADONGBHTN = value; OnPropertyChanged(); } }
        private bool _DADONGTIENPHONG;
        public bool DADONGTIENPHONG { get => _DADONGTIENPHONG; set { _DADONGTIENPHONG = value; OnPropertyChanged(); } }

        public StudentInfo()
        { }
    }
    
    public class Temp :BaseViewModel
    {
        private int _IDSINHVIEN;
        public int IDSINHVIEN { get => _IDSINHVIEN; set { _IDSINHVIEN = value; OnPropertyChanged(); } }
       
        private string _TENTOA;
        public string TENTOA { get => _TENTOA; set { _TENTOA = value; OnPropertyChanged(); } }
        private string _TENPHONG;
        public string TENPHONG { get => _TENPHONG; set { _TENPHONG = value; OnPropertyChanged(); } }
        private bool _DADONGBHYT;
        public bool DADONGBHYT { get => _DADONGBHYT; set { _DADONGBHYT = value; OnPropertyChanged(); } }
        private bool _DADONGBHTN;
        public bool DADONGBHTN { get => _DADONGBHTN; set { _DADONGBHTN = value; OnPropertyChanged(); } }
        private bool _DADONGTIENPHONG;
        public bool DADONGTIENPHONG { get => _DADONGTIENPHONG; set { _DADONGTIENPHONG = value; OnPropertyChanged(); } }

        public Temp()
        { }
    }
        public class StudentFullListViewModel :BaseViewModel
    {
        private int _SelectedMSSV;
        public int SelectedMSSV { get => _SelectedMSSV; set { _SelectedMSSV = value; OnPropertyChanged(); } }
        private StudentInfo _SelectedSINHVIEN;
        public StudentInfo SelectedSINHVIEN { get => _SelectedSINHVIEN; set { _SelectedSINHVIEN = value; OnPropertyChanged(); } }
        private string _NameFind;
        public string NameFind { get => _NameFind; set { _NameFind = value; OnPropertyChanged(); } }
        private string _SchoolFind;
        public string SchoolFind { get => _SchoolFind; set { _SchoolFind = value; OnPropertyChanged(); } }
        private string _TenToaFind;
        public string TenToaFind { get => _TenToaFind; set { _TenToaFind = value; OnPropertyChanged(); } }
        private string _HomeLandFind;
        public string HomeLandFind { get => _HomeLandFind; set { _HomeLandFind = value; OnPropertyChanged(); } }
        private string _MSSVFindNumber;
        public string MSSVFindNumber { get => _MSSVFindNumber; set { _MSSVFindNumber = value; OnPropertyChanged(); } }
        private string _TenPhongFind;
        public string TenPhongFind { get => _TenPhongFind; set { _TenPhongFind = value; OnPropertyChanged(); } }

        private bool _isFilter;
        public bool isFilter { get => _isFilter; set { _isFilter = value; OnPropertyChanged(); } }

        public ICommand DetailCommand { get; set; }
        public ICommand FindBtn { get; set; }
        private ObservableCollection<SINHVIEN> _SINHVIENLIST;
        public ObservableCollection<SINHVIEN> SINHVIENLIST { get => _SINHVIENLIST; set { _SINHVIENLIST = value; OnPropertyChanged(); } }
        private ObservableCollection<DANHSACHSV_PHONG> _DSSV_PHONG;
        public ObservableCollection<DANHSACHSV_PHONG> DSSV_PHONG { get => _DSSV_PHONG; set { _DSSV_PHONG = value; OnPropertyChanged(); } }
        private ObservableCollection<PHONG> _PHONGLIST;
        public ObservableCollection<PHONG> PHONGLIST { get => _PHONGLIST; set { _PHONGLIST = value; OnPropertyChanged(); } }
        private ObservableCollection<TOA> _TOALIST;
        public ObservableCollection<TOA> TOALIST { get => _TOALIST; set { _TOALIST = value; OnPropertyChanged(); } }
        private IEnumerable<StudentInfo> _SINHVIENLISTNew;
        public IEnumerable<StudentInfo> SINHVIENLISTNew { get => _SINHVIENLISTNew; set { _SINHVIENLISTNew = value; OnPropertyChanged(); } }
        private IEnumerable<StudentInfo> _SINHVIENLISTNew2;
        public IEnumerable<StudentInfo> SINHVIENLISTNew2 { get => _SINHVIENLISTNew2; set { _SINHVIENLISTNew2 = value; OnPropertyChanged(); } }
        private IEnumerable<Temp> _DS_IDSV_TOAPHONG;
        public IEnumerable<Temp> DS_IDSV_TOAPHONG { get => _DS_IDSV_TOAPHONG; set { _DS_IDSV_TOAPHONG = value; OnPropertyChanged(); } }
        
        public StudentFullListViewModel()
        {
            //LoadSVList();
            DetailCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                StudentInfor si = new StudentInfor();
                var siDT = si.DataContext as StudentInforViewModel;
                //siDT.MSSVFindNumber = p.ToString();
                siDT.LoadInfor(SelectedSINHVIEN.IDSINHVIEN);
                si.ShowDialog();
                si.Close();
            });
            FindBtn = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                isFilter = true;
                SINHVIENLISTNew2 = SINHVIENLISTNew.Where(x =>  ((MSSVFindNumber != null  && MSSVFindNumber !="") ? x.MSSV.Contains(MSSVFindNumber): x.MSSV != null)
                                                             && ((NameFind != null && NameFind != "") ? x.HOTEN.Contains(NameFind) : x.HOTEN != null)
                                                             && ((HomeLandFind != null && HomeLandFind != "") ? x.DIACHI.Contains(HomeLandFind) : x.DIACHI != null)
                                                             && ((SchoolFind != null && SchoolFind != "") ? x.TENTRUONG.Contains(SchoolFind) : x.TENTRUONG != null  )
                                                             && ((TenToaFind != null && TenToaFind != "") ? x.TENTOA.Contains(TenToaFind) : x.TENTOA != null)
                                                             && ((TenPhongFind != null && TenPhongFind != "") ? x.TENPHONG.Contains(TenPhongFind) : x.TENPHONG != null));
            });

        }
         public void ResetBoLoc()
        {
            MSSVFindNumber = null;
            NameFind = null;
            HomeLandFind = null;
            SchoolFind = null;
            TenToaFind = null;
            TenPhongFind = null;

            

        }
        public void LoadSVList()
        {
            if (isFilter == false) ResetBoLoc();
            SINHVIENLIST = new ObservableCollection<SINHVIEN>(DataProvider.Ins.DB.SINHVIENs);
            TOALIST = new ObservableCollection<TOA>(DataProvider.Ins.DB.TOAs);
            PHONGLIST = new ObservableCollection<PHONG>(DataProvider.Ins.DB.PHONGs);
            DSSV_PHONG = new ObservableCollection<DANHSACHSV_PHONG>(DataProvider.Ins.DB.DANHSACHSV_PHONG);
            //SINHVIENLISTNew = (from sv in SINHVIENLIST
            //                   join sv_p in DSSV_PHONG.DefaultIfEmpty() on sv.IDSINHVIEN equals sv_p.IDSINHVIEN into dssv_phong

            //                   from svp_phong in dssv_phong
            //                   join phong in PHONGLIST on svp_phong.IDPHONG equals phong.IDPHONG into dssv_phong_idphong

            //                   from phong_tenphong in dssv_phong_idphong
            //                   join toa in TOALIST on phong_tenphong.IDTOA equals toa.IDTOA into lastlist

            //                   from endgame in lastlist.DefaultIfEmpty()
            //                   select new StudentInfo()
            //                   {
            //                       IDSINHVIEN = sv.IDSINHVIEN,
            //                       MSSV = sv.MSSV,
            //                       HOTEN = sv.HOTEN,
            //                       TENTRUONG = sv.TENTRUONG,
            //                       DIACHI = sv.DIACHI,
            //                       TENPHONG =  phong_tenphong.TENPHONG == null ? "dm" :phong_tenphong.TENPHONG,  
            //                       TENTOA = endgame.TENTOA== null? "đm" : endgame.TENTOA

            //                   });
            DS_IDSV_TOAPHONG = (from svp_phong in DSSV_PHONG
                                join phong in PHONGLIST on svp_phong.IDPHONG equals phong.IDPHONG into dssv_phong_idphong

                                from phong_tenphong in dssv_phong_idphong
                                join toa in TOALIST on phong_tenphong.IDTOA equals toa.IDTOA into lastlist

                                from endgame in lastlist
                                select new Temp()
                                {
                                    IDSINHVIEN = svp_phong.IDSINHVIEN,

                                    TENPHONG = phong_tenphong.TENPHONG == null ? "dm" : phong_tenphong.TENPHONG,
                                    TENTOA = endgame.TENTOA == null ? "đm" : endgame.TENTOA
                                    //MSSV = null,
                                    //HOTEN = null,
                                    //TENTRUONG = null,
                                    //DIACHI = null
                                    

                                        });
            SINHVIENLISTNew = (from sv in SINHVIENLIST
                               join sv_p in DS_IDSV_TOAPHONG on sv.IDSINHVIEN equals sv_p.IDSINHVIEN into lastlist
                               from endgame2 in lastlist.DefaultIfEmpty()
                               select new StudentInfo()
                               {
                                   IDSINHVIEN = sv.IDSINHVIEN,
                                   MSSV = sv.MSSV,
                                   HOTEN = sv.HOTEN,
                                   TENTRUONG = sv.TENTRUONG,
                                   DIACHI = sv.DIACHI,
                                   //TENPHONG = endgame2.TENPHONG == string.Empty ? "dm" : endgame2.TENPHONG,
                                   //TENTOA = endgame2.TENTOA == string.Empty ? "đm" : endgame2.TENTOA
                                   TENPHONG = endgame2?.TENPHONG ?? "___",
                                    TENTOA = endgame2?.TENTOA ?? "__"

                               });
            SINHVIENLISTNew2 = SINHVIENLISTNew;

        }
    }
}
