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
{     public class Group
    {
        public string Name;
    }
     public class ReceiptListViewModel:BaseViewModel
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
        private IEnumerable<string> _HOCKILISTDistinct;
        public IEnumerable<string> HOCKILISTDistinct { get => _HOCKILISTDistinct; set { _HOCKILISTDistinct = value; OnPropertyChanged(); } }
        private ObservableCollection<HOCKI> _HOCKILIST;
        public ObservableCollection<HOCKI> HOCKILIST { get => _HOCKILIST; set { _HOCKILIST = value; OnPropertyChanged(); } }
        private ObservableCollection<BIENLAITIENPHONG> _BIENLAILIST;
        public ObservableCollection<BIENLAITIENPHONG> BIENLAILIST { get => _BIENLAILIST; set { _BIENLAILIST = value; OnPropertyChanged(); } }
        private ObservableCollection<User> _USERLIST;
        public ObservableCollection<User> USERLIST { get => _USERLIST; set { _USERLIST = value; OnPropertyChanged(); } }
        private IEnumerable<BIENLAIFULL> _BIENLAIFULLLIST;
        public IEnumerable<BIENLAIFULL> BIENLAIFULLLIST { get => _BIENLAIFULLLIST; set { _BIENLAIFULLLIST = value; OnPropertyChanged(); } }
        private IEnumerable<BIENLAIFULL> _BIENLAIFULLLISTRoot;
        public IEnumerable<BIENLAIFULL> BIENLAIFULLLISTRoot { get => _BIENLAIFULLLISTRoot; set { _BIENLAIFULLLISTRoot = value; OnPropertyChanged(); } }
        private List<string> _HOCKILISTCbb;
        public List<string> HOCKILISTCbb { get => _HOCKILISTCbb; set { _HOCKILISTCbb = value; OnPropertyChanged(); } }
        private List<string> _NAMHOCLISTCbb;
        public List<string> NAMHOCLISTCbb { get => _NAMHOCLISTCbb; set { _NAMHOCLISTCbb = value; OnPropertyChanged(); } }
        private string _SchoolFind;
        public string SchoolFind { get => _SchoolFind; set { _SchoolFind = value; OnPropertyChanged(); } }
        private string _HocKiFind;
        public string HocKiFind { get => _HocKiFind; set { _HocKiFind = value; OnPropertyChanged(); } }
        private string _NamHocFind;
        public string NamHocFind { get => _NamHocFind; set { _NamHocFind = value; OnPropertyChanged(); } }
        private string _NgayInBLFind;
        public string NgayInBLFind { get => _NgayInBLFind; set { _NgayInBLFind = value; OnPropertyChanged(); } }
        private string _NameFind;
        public string NameFind { get => _NameFind; set { _NameFind = value; OnPropertyChanged(); } }
        private string _NameFindOldStt;
        public string NameFindOldStt { get => _NameFindOldStt; set { _NameFindOldStt = value; OnPropertyChanged(); } }
        private string _HocKiFindOldStt;
        public string HocKiFindOldStt { get => _HocKiFindOldStt; set { _HocKiFindOldStt = value; OnPropertyChanged(); } }


        private string _MSSVFindNumber;
        public string MSSVFindNumber { get => _MSSVFindNumber; set { _MSSVFindNumber = value; OnPropertyChanged(); } }

        private bool _isFilter;
        public bool isFilter { get => _isFilter; set { _isFilter = value; OnPropertyChanged(); } }

        public ICommand  ReceiptDetailCommand { get; set; }
        public ICommand FindBtn { get; set; }
        public ICommand DeleteReceiptCommand { get; set; }
        public ReceiptListViewModel()
        {
            //LoadMainView();
            ReceiptDetailCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                ReceiptDetail rd = new ReceiptDetail();
                var rdDT = rd.DataContext as ReceiptDetailViewModel;
                rdDT.LoadMainView( (int)p );
                rd.ShowDialog();
                rd.Close();
            });
            DeleteReceiptCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                int SelectedDLBL = (int)p;
                int SelectedIDSINHVIEN = (int) DataProvider.Ins.DB.BIENLAITIENPHONGs.Where(x => x.IDBL == SelectedDLBL).Single().IDSINHVIEN;

                BIENLAITIENPHONG bl = new BIENLAITIENPHONG();
                bl = DataProvider.Ins.DB.BIENLAITIENPHONGs.Where(x => x.IDBL == SelectedDLBL).Single();
                //DANHSACHSV_TIENPHONG svtp = new DANHSACHSV_TIENPHONG();
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
               
                //load lai main
                BuildingDiagram bd = new BuildingDiagram();
                var bdDT = bd.DataContext as BuildingDiagramViewModel;
                bdDT.LoadToa();
                MainWindow mw = new MainWindow();
                var mwDT = mw.DataContext as MainViewModel;
                mwDT.LoadChartSV();
                mw.Close();
            });
            FindBtn = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                FindInfo();
            });
        }
        public void FindInfo()
        {
            isFilter = true;
            if (NamHocFind == null) NamHocFind = "Tất cả";
            if (HocKiFind == null) HocKiFind = "Tất cả";
            BIENLAIFULLLIST = BIENLAIFULLLISTRoot
            .Where(x =>
                                                      ((MSSVFindNumber != null && MSSVFindNumber != "") ? x.MSSV.Contains(MSSVFindNumber) : x.MSSV != null)
                                                       && ((NameFind != null && NameFind != "") ? x.HOTEN.Contains(NameFind) : x.HOTEN != null)
                                                       && ((NgayInBLFind != null && NgayInBLFind != "") ? x.NGAYINBL.Contains(NgayInBLFind) : x.NGAYINBL != null)
                                                       && ((NamHocFind.Contains("Tất cả") == false) ? x.TENNAMHOC.Contains(NamHocFind) : x.TENNAMHOC != null)
                                                       && ((HocKiFind.Contains("Tất cả") == false ) ? x.TENHOCKI.Contains(HocKiFind) : x.TENHOCKI != null)
                                                        );
            HocKiFindOldStt = HocKiFind;
            NameFindOldStt = NamHocFind;
        }
        public void ResetBang()
        {
            SV_TIENPHONGLIST = new ObservableCollection<DANHSACHSV_TIENPHONG>(DataProvider.Ins.DB.DANHSACHSV_TIENPHONG);
            PHONGLIST = new ObservableCollection<PHONG>(DataProvider.Ins.DB.PHONGs);
            TIENTHUEPHONGLIST = new ObservableCollection<TIENTHUEPHONG>(DataProvider.Ins.DB.TIENTHUEPHONGs);
            SINHVIENLIST = new ObservableCollection<SINHVIEN>(DataProvider.Ins.DB.SINHVIENs);
            TOALIST = new ObservableCollection<TOA>(DataProvider.Ins.DB.TOAs);
            HOCKILIST = new ObservableCollection<HOCKI>(DataProvider.Ins.DB.HOCKIs);
            BIENLAILIST = new ObservableCollection<BIENLAITIENPHONG>(DataProvider.Ins.DB.BIENLAITIENPHONGs);
            BIENLAIFULLLISTRoot=Enumerable.Empty<BIENLAIFULL>();
            BIENLAIFULLLIST = Enumerable.Empty<BIENLAIFULL>();
            HOCKILISTCbb = new List<string>();
            HOCKILISTCbb.Add("Tất cả");
            NAMHOCLISTCbb = new List<string>();
            NAMHOCLISTCbb.Add("Tất cả");
            HOCKILISTDistinct = HOCKILIST.Select(s => s.TENNAMHOC).Distinct();
            foreach (var item in HOCKILISTDistinct)
            {

                NAMHOCLISTCbb.Add(item.TrimStart());
            }
            HOCKILISTDistinct = HOCKILIST.Select(s => s.TENHOCKI).Distinct();
            foreach (var item in HOCKILISTDistinct)
            {

                HOCKILISTCbb.Add(item.TrimStart());
            }
            HocKiFind = HocKiFindOldStt;
            NamHocFind = NameFindOldStt;
            //HocKiFind = "Tất cả";
            //NamHocFind = "Tất cả";
        }
      
        public void ResetBoLoc()
        {
            MSSVFindNumber = null;
            NameFind = null;
            NgayInBLFind = null;
            //NamHocFind = "Tất cả";
            //HocKiFind = "Tất cả";
            HocKiFindOldStt = null;
            NameFindOldStt = null;
        }

        public void LoadMainView()
        {
            //reset các bảng
            if (isFilter == false) ResetBoLoc();
            ResetBang();


            

                var info1 = System.Globalization.CultureInfo.GetCultureInfo("vi-VN");
            //TIENPHONGPHAIDONG = string.Format(info1, "{0:c0}", (NumberOfMonthLiving * TIENTHUE));

            // load Biên lai 

            // join thêm mssv

            BIENLAIFULLLISTRoot = (from bll in BIENLAILIST
                               join hkl in HOCKILIST on bll.IDHOCKI equals hkl.IDHOCKI 
                              
                               join stl in SINHVIENLIST on bll.IDSINHVIEN equals stl.IDSINHVIEN
                              
                               select new BIENLAIFULL()
                               {

                                   IDBL = bll.IDBL,
                                   IDSINHVIEN = (int)bll.IDSINHVIEN,

                                   IDPHONG = (int)bll.IDPHONG,
                                   NGAYINBL = bll.NGAYINBL,
                                   TENNGUOITHU = bll.TENNGUOITHU,
                                   DONGTIENPHONG = (bool)bll.DONGTIENPHONG,
                                   DONGTIENBHTN = (bool)bll.DONGTIENBHTN,
                                   DONGTIENBHYT = (bool)bll.DONGTIENBHYT,
                                   TONGTIEN = (int)bll.TONGTIEN,
                                   TENHOCKI = hkl.TENHOCKI,
                                   TENNAMHOC = hkl.TENNAMHOC,
                                   IDHOCKI = hkl.IDHOCKI,
                                   NGAYBATDAU = hkl.NGAYBATDAU,
                                   NGAYKETHUC = hkl.NGAYKETHUC,
                                   stringTONGTIEN = string.Format(info1, "{0:c0}", bll.TONGTIEN),
                                   TIENPHONGDADONG = string.Format(info1, "{0:c0}", bll.TIENPHONGDADONG),
                                   HOTEN = stl.HOTEN,
                                   MSSV = stl.MSSV,
                                   
                               }
                     );


           
            //BIENLAIFULLLIST = BIENLAIFULLLISTRoot;
            FindInfo();
        }
    }
   
        
}

