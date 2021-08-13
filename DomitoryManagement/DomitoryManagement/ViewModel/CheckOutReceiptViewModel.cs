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
   public class CheckOutReceiptViewModel :BaseViewModel
    {
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
        private ObservableCollection<DANHSACHSV_PHONG> _DANHSACHSV_PHONG;
        public ObservableCollection<DANHSACHSV_PHONG> DANHSACHSV_PHONG { get => _DANHSACHSV_PHONG; set { _DANHSACHSV_PHONG = value; OnPropertyChanged(); } }
        private IEnumerable<BIENLAIFULL> _BIENLAIFULLLIST;
        public IEnumerable<BIENLAIFULL> BIENLAIFULLLIST { get => _BIENLAIFULLLIST; set { _BIENLAIFULLLIST = value; OnPropertyChanged(); } }
        private int _SelectedIDSINHVIEN;
        public int SelectedIDSINHVIEN { get => _SelectedIDSINHVIEN; set { _SelectedIDSINHVIEN = value; OnPropertyChanged(); } }
        private string _TENHOCKI;
        public string TENHOCKI { get => _TENHOCKI; set { _TENHOCKI = value; OnPropertyChanged(); } }
        private string _TENNAMHOC;
        public string TENNAMHOC { get => _TENNAMHOC; set { _TENNAMHOC = value; OnPropertyChanged(); } }
        private string _NGAYBATDAU;
        public string NGAYBATDAU { get => _NGAYBATDAU; set { _NGAYBATDAU = value; OnPropertyChanged(); } }

        private string _NGAYKETTHUC;
        public string NGAYKETTHUC { get => _NGAYKETTHUC; set { _NGAYKETTHUC = value; OnPropertyChanged(); } }
        private string _NGAYHIENTAI;
        public string NGAYHIENTAI { get => _NGAYHIENTAI; set { _NGAYHIENTAI = value; OnPropertyChanged(); } }
        private string _TONGCONG;
        public string TONGCONG { get => _TONGCONG; set { _TONGCONG = value; OnPropertyChanged(); } }
        private int _intTONGCONG;
        public int intTONGCONG { get => _intTONGCONG; set { _intTONGCONG = value; OnPropertyChanged(); } }
        private string _TIENDADONG;
        public string TIENDADONG { get => _TIENDADONG; set { _TIENDADONG = value; OnPropertyChanged(); } }
        private int _intTIENDADONG;
        public int intTIENDADONG { get => _intTIENDADONG; set { _intTIENDADONG = value; OnPropertyChanged(); } }
        private int _TIENLOAIPHONG;
        public int TIENLOAIPHONG { get => _TIENLOAIPHONG; set { _TIENLOAIPHONG = value; OnPropertyChanged(); } }
        private string _TIENDAO;
        public string TIENDAO { get => _TIENDAO; set { _TIENDAO = value; OnPropertyChanged(); } }
        private int _intTIENDAO;
        public int intTIENDAO { get => _intTIENDAO; set { _intTIENDAO = value; OnPropertyChanged(); } }
        private int _IDHOCKI;
        public int IDHOCKI { get => _IDHOCKI; set { _IDHOCKI = value; OnPropertyChanged(); } }
        private string _NGUOITHUNGAN;
        public string NGUOITHUNGAN { get => _NGUOITHUNGAN; set { _NGUOITHUNGAN = value; OnPropertyChanged(); } }
        private string _TENSINHVIEN;
        public string TENSINHVIEN { get => _TENSINHVIEN; set { _TENSINHVIEN = value; OnPropertyChanged(); } }


        public ICommand SaveCommand { get; set; }
        public ICommand LoadedWindowCommand { get; set; }
        private Window _Frame;
        public Window Frame { get => _Frame; set { _Frame = value; OnPropertyChanged(); } }
        public CheckOutReceiptViewModel()
        {
            SaveCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
           {
                // lấy tên user
                LoginWindow lg = new LoginWindow();
               var lgDT = lg.DataContext as LoginViewModel;
               string UserName = lgDT.UserName;
               lg.Close();
                // tạo biên lai
                BIENLAIHOANTRAPHONG bl = new BIENLAIHOANTRAPHONG();
               bl.IDSINHVIEN = SelectedIDSINHVIEN;
               bl.IDHOCKI = IDHOCKI;
               bl.NGAYTRAPHONG = NGAYHIENTAI;
               bl.TIENHOANTRA = intTONGCONG;
               bl.NGUOITHUNGAN = (from up in DataProvider.Ins.DB.Users where up.UserName == UserName select up).Single().TENUSER.ToString();
               bl.TENSINHVIEN = TENSINHVIEN;
               DataProvider.Ins.DB.BIENLAIHOANTRAPHONGs.Add(bl);
               DataProvider.Ins.DB.SaveChanges();
               int SelectedPhong = 0; ;
               //set TINHTRANG cho BIENLAITHUEPHONG
               var BIENLAITHUEPHONG = (from up in DataProvider.Ins.DB.BIENLAITHUEPHONGs where up.IDSINHVIEN == SelectedIDSINHVIEN && up.IDHOCKI == bl.IDHOCKI select up);
               if (BIENLAITHUEPHONG.Count() ==1)
               {
                   SelectedPhong = (int) BIENLAITHUEPHONG.Single().IDPHONG;
                   BIENLAITHUEPHONG.Single().TRANGTHAI = false;
                   BIENLAITHUEPHONG.Single().NGAYTRAPHONG = DateTime.Today.ToShortDateString();
               }
              

                // set lại tình trạng của SINHVIEN
                var SINHVIEN = (from up in DataProvider.Ins.DB.SINHVIENs where up.IDSINHVIEN == SelectedIDSINHVIEN select up).Single();
               SINHVIEN.DATHUE = false;

                // xóa khỏi DS SV_P và SV_TP
                var sv_phong = (from up in DataProvider.Ins.DB.DANHSACHSV_PHONG where up.IDSINHVIEN == SelectedIDSINHVIEN select up).Single();
               DataProvider.Ins.DB.DANHSACHSV_PHONG.Remove(sv_phong);
               DataProvider.Ins.DB.SaveChanges();
               var sv_tienphong = (from up in DataProvider.Ins.DB.DANHSACHSV_TIENPHONG where up.IDSINHVIEN == SelectedIDSINHVIEN select up).Single();
               DataProvider.Ins.DB.DANHSACHSV_TIENPHONG.Remove(sv_tienphong);
               DataProvider.Ins.DB.SaveChanges();
               MessageBox.Show("Trả phòng thành công !");
           //set lại phòng
                 if (SelectedPhong != 0)
               {
                   var PHONG = (from up in DataProvider.Ins.DB.PHONGs where up.IDPHONG == SelectedPhong select up).Single();
                   PHONG.SOLUONGNGUOI--;
                   PHONG.SOLUONGTRONG++;
                   DataProvider.Ins.DB.SaveChanges();
               }
              
               
                //load lại CheckOutList//
                CheckOutList col = new CheckOutList();
               var colDT = col.DataContext as CheckOutListViewModel;
               colDT.LoadSVList();
               col.Close();
               // load lại PHÒNG
               
                //load lai tòa
                //BuildingDiagram bd = new BuildingDiagram();
                //var bdDT = bd.DataContext as BuildingDiagramViewModel;
                //bdDT.LoadToa();
                //bd.Close();
                //load main
                MainWindow mw = new MainWindow();
               var mwDT = mw.DataContext as MainViewModel;
               mwDT.LoadChartSV();
               mwDT.LoadStatis();
               mw.Close();
                //
                p.Close();
           });
        }
        public void Load()
        {
            DANHSACHSV_PHONG = new ObservableCollection<DANHSACHSV_PHONG>(DataProvider.Ins.DB.DANHSACHSV_PHONG);
            var sv_phong = (from up in DataProvider.Ins.DB.DANHSACHSV_TIENPHONG where up.IDSINHVIEN == SelectedIDSINHVIEN select up).Single();
            var hocki = (from hk in DataProvider.Ins.DB.HOCKIs where hk.IDHOCKI == sv_phong.IDHOCKI select hk).Single();
            IDHOCKI = hocki.IDHOCKI;
            TENHOCKI = hocki.TENHOCKI;
            TENNAMHOC = hocki.TENNAMHOC;
            NGAYBATDAU = sv_phong.NGAYVAO;
            NGAYHIENTAI = DateTime.Now.ToShortDateString().ToString().Trim();
            TENSINHVIEN = (from up in DataProvider.Ins.DB.SINHVIENs where up.IDSINHVIEN == SelectedIDSINHVIEN select up).Single().HOTEN.ToString();
            var tienphongdadong = (from money in DataProvider.Ins.DB.BIENLAITIENPHONGs where money.IDSINHVIEN == SelectedIDSINHVIEN && money.IDHOCKI == hocki.IDHOCKI && money.TIENPHONGDADONG!=0 select money);
            if (tienphongdadong.Count() == 0) intTIENDADONG = 0;
            else intTIENDADONG = (int) tienphongdadong.Single().TIENPHONGDADONG;
            int songaydao = CalculateDay(NGAYBATDAU, NGAYHIENTAI);
            var loaiphong = (from phong in DataProvider.Ins.DB.PHONGs where phong.IDPHONG == sv_phong.IDPHONG select phong).Single().LOAIPHONG;
            var tienloaiphong = (from money in DataProvider.Ins.DB.TIENTHUEPHONGs where money.LOAIPHONG == (int)loaiphong select money).Single().TIENTHUE;
            TIENLOAIPHONG = (int)tienloaiphong;
            intTIENDAO = songaydao * TIENLOAIPHONG / 30;
            intTONGCONG = intTIENDADONG - intTIENDAO;
            if (intTONGCONG < 0) intTONGCONG = 0;
            var info1 = System.Globalization.CultureInfo.GetCultureInfo("vi-VN");
            TIENDADONG = string.Format(info1, "{0:c0}", intTIENDADONG);
            TIENDAO = string.Format(info1, "{0:c0}", intTIENDAO);
            TONGCONG = string.Format(info1, "{0:c0}", intTONGCONG);



        }
        public int CalculateDay(string ngayvao, string ngaytraphong)
        {
            DateTime ngvao = Convert.ToDateTime(ngayvao);
            DateTime ngtraphong = Convert.ToDateTime(ngaytraphong);
            TimeSpan Time = ngtraphong - ngvao;
            return Time.Days;
        }

    }
}
