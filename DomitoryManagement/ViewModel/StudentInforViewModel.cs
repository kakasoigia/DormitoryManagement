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
   public class LICHSUTHUEPHONG :BaseViewModel
    {
        private bool _TRANGTHAI;
        public bool TRANGTHAI { get => _TRANGTHAI; set { _TRANGTHAI = value; OnPropertyChanged(); } }
        private string _KHUNHAPHONG;
        public string KHUNHAPHONG { get => _KHUNHAPHONG; set { _KHUNHAPHONG = value; OnPropertyChanged(); } }
        private string _LOAIPHONG;
        public string LOAIPHONG { get => _LOAIPHONG; set { _LOAIPHONG = value; OnPropertyChanged(); } }
        private bool _DADONGTIENPHONG;
        public bool DADONGTIENPHONG { get => _DADONGTIENPHONG; set { _DADONGTIENPHONG = value; OnPropertyChanged(); } }
        private bool _DADONGBHYT;
        public bool DADONGBHYT { get => _DADONGBHYT; set { _DADONGBHYT = value; OnPropertyChanged(); } }
        private bool _DADONGBHTN;
        public bool DADONGBHTN { get => _DADONGBHTN; set { _DADONGBHTN = value; OnPropertyChanged(); } }
        private string _NGAYVAO;
        public string NGAYVAO { get => _NGAYVAO; set { _NGAYVAO = value; OnPropertyChanged(); } }
        private string _GHICHU;
        public string GHICHU { get => _GHICHU; set { _GHICHU = value; OnPropertyChanged(); } }




    }
    public class StudentInforViewModel : BaseViewModel
    {
        public ICommand FindMSSV { get; set; }

        private ObservableCollection<SINHVIEN> _SINHVIENLIST;
        public ObservableCollection<SINHVIEN> SINHVIENLIST { get => _SINHVIENLIST; set { _SINHVIENLIST = value; OnPropertyChanged(); } }
        private IEnumerable<BIENLAIFULL> _BIENLAIFULLLIST;
        public IEnumerable<BIENLAIFULL> BIENLAIFULLLIST { get => _BIENLAIFULLLIST; set { _BIENLAIFULLLIST = value; OnPropertyChanged(); } }
        private ObservableCollection<BIENLAITIENPHONG> _BIENLAILIST;
        public ObservableCollection<BIENLAITIENPHONG> BIENLAILIST { get => _BIENLAILIST; set { _BIENLAILIST = value; OnPropertyChanged(); } }
        private ObservableCollection<HOCKI> _HOCKILIST;
        public ObservableCollection<HOCKI> HOCKILIST { get => _HOCKILIST; set { _HOCKILIST = value; OnPropertyChanged(); } }
        private ObservableCollection<BIENLAITHUEPHONG> _BIENLAITHUEPHONGLIST;
        public ObservableCollection<BIENLAITHUEPHONG> BIENLAITHUEPHONGLIST { get => _BIENLAITHUEPHONGLIST; set { _BIENLAITHUEPHONGLIST = value; OnPropertyChanged(); } }

        private string _MSSV;
        public string MSSV { get =>_MSSV; set { _MSSV = value; OnPropertyChanged(); } }
        private string _Name;
        public string Name { get => _Name; set { _Name = value; OnPropertyChanged(); } }

        private string _MSSVFindNumber;
        public string MSSVFindNumber { get => _MSSVFindNumber; set { _MSSVFindNumber = value; OnPropertyChanged(); } }
        private int _SelectedIDSINHVIEN;
        public int SelectedIDSINHVIEN { get => _SelectedIDSINHVIEN; set { _SelectedIDSINHVIEN = value; OnPropertyChanged(); } }

        private string _Birthday;
        public string Birthday { get => _Birthday; set { _Birthday = value; OnPropertyChanged(); } }

        private string _Gender;
        public string Gender { get => _Gender; set { _Gender = value; OnPropertyChanged(); } }

        private string _PhoneNumber;
        public string PhoneNumber { get => _PhoneNumber; set { _PhoneNumber = value; OnPropertyChanged(); } }

        private string _LearningYear;
        public string LearningYear { get => _LearningYear; set { _LearningYear = value; OnPropertyChanged(); } }

        private string _School;
        public string School { get => _School; set { _School = value; OnPropertyChanged(); } }

        private string _Major;
        public string Major { get => _Major; set { _Major = value; OnPropertyChanged(); } }

        private string _Ethnic;
        public string Ethnic { get => _Ethnic; set { _Ethnic = value; OnPropertyChanged(); } }

        private string _Nationality;
        public string Nationality { get => _Nationality; set { _Nationality = value; OnPropertyChanged(); } }

        private string _Identity;
        public string Identity { get => _Identity; set { _Identity = value; OnPropertyChanged(); } }
        private int _IDKTX;
        public int IDKTX { get => _IDKTX; set { _IDKTX = value; OnPropertyChanged(); } }
        private string _HomeLand;
        public string HomeLand { get => _HomeLand; set { _HomeLand = value; OnPropertyChanged(); } }
        private bool _Exist;
        public bool Exist { get => _Exist; set { _Exist = value; OnPropertyChanged(); } }
        public ICommand ChangeInfo { get; set; }
        public  StudentInforViewModel()
        {
            ChangeInfo = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {   if (Exist == true)
                {
                    ChangeInfoStudent ci = new ChangeInfoStudent();
                    var change = ci.DataContext as ChangeInfoViewModel;
                    change.LoadDefault();
                    ci.ShowDialog();
                    ci.Close();
                }
               
            });
           
        }
        public void LoadInfor( int IDSINHVIEN)
        {
            SelectedIDSINHVIEN = IDSINHVIEN;
            MSSV = "";
            Name = "";
            Birthday = "";
            Gender = "";
            PhoneNumber = "";
            School = "";
            Ethnic = "";
            Nationality = "";
            Identity = "";
           
            LearningYear = "";
            Major = "";
            HomeLand = "";
            SINHVIENLIST = new ObservableCollection<SINHVIEN>(DataProvider.Ins.DB.SINHVIENs);
            Exist = false;
            foreach (var item in SINHVIENLIST)
            {
                if (item.IDSINHVIEN == SelectedIDSINHVIEN)
                {
                    Exist = true;
                    Name = item.HOTEN;
                    MSSV = item.MSSV;
                    Birthday = item.NGAYSINH;

                    Gender = (bool)item.GIOITINH ? "Nam" : "Nữ";
                    PhoneNumber = item.SDT.ToString();
                    School = item.TENTRUONG.ToString();
                    Ethnic = item.DANTOC.ToString();
                    Nationality = item.QUOCTICH.ToString();
                    Identity = item.CMND.ToString();
                    LearningYear = item.SINHVIENNAM.ToString();
                    Major = item.KHOA;
                    IDKTX =  (int)item.IDSINHVIEN;
                    HomeLand = item.DIACHI.ToString();

                }
               
                OnPropertyChanged();
            }
            if (Exist==false)
              MessageBox.Show("Mã số sinh viên không tồn tại ! ");
            // load lịch sử thu phí
            BIENLAILIST = new ObservableCollection<BIENLAITIENPHONG>(DataProvider.Ins.DB.BIENLAITIENPHONGs);
            HOCKILIST = new ObservableCollection<HOCKI>(DataProvider.Ins.DB.HOCKIs);
            var info1 = System.Globalization.CultureInfo.GetCultureInfo("vi-VN");
            BIENLAIFULLLIST = BIENLAILIST.Where(x => x.IDSINHVIEN == SelectedIDSINHVIEN).Join(
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
                        NGAYVAO = null

                    }
                    );
            // load Lịch sử thuê phòng
            BIENLAITHUEPHONGLIST = new ObservableCollection<BIENLAITHUEPHONG>(DataProvider.Ins.DB.BIENLAITHUEPHONGs.Where(x => x.IDSINHVIEN == SelectedIDSINHVIEN));


        }
    }
}
