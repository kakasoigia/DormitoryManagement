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
   public class ReceiptDetailViewModel :BaseViewModel
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
        private IEnumerable<BIENLAIFULL> _BIENLAIFULLLIST;
        public IEnumerable<BIENLAIFULL> BIENLAIFULLLIST { get => _BIENLAIFULLLIST; set { _BIENLAIFULLLIST = value; OnPropertyChanged(); } }
        public ICommand DeleteReceiptCommand { get; set; }
        public ICommand LoadedWindowCommand { get; set; }
        private Window _Frame;
        public Window Frame { get => _Frame; set { _Frame = value; OnPropertyChanged(); } }
        public ReceiptDetailViewModel()
        {
            LoadedWindowCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                Frame = p;

            });
            DeleteReceiptCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                int SelectedDLBL = (int)p;
                int SelectedIDSINHVIEN = (int)DataProvider.Ins.DB.BIENLAITIENPHONGs.Where(x => x.IDBL == SelectedDLBL).Single().IDSINHVIEN;

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
                    if (BIENLAITHUE.Count() !=0)
                    BIENLAITHUE.Single().DADONGTIENPHONG = false;
                }
                //
                DataProvider.Ins.DB.BIENLAITIENPHONGs.Remove(bl);
                DataProvider.Ins.DB.SaveChanges();
                MessageBox.Show("Đã hủy thành công biên lai!");
                //load lại màn hình chính//
                ReceiptList rl = new ReceiptList();
                var rlDT = rl.DataContext as ReceiptListViewModel;
                rlDT.LoadMainView();
                rl.Close();
                // load lại 
                //load lai main
                BuildingDiagram bd = new BuildingDiagram();
                var bdDT = bd.DataContext as BuildingDiagramViewModel;
                bdDT.LoadToa();
                MainWindow mw = new MainWindow();
                var mwDT = mw.DataContext as MainViewModel;
                mwDT.LoadChartSV();
                mw.Close();
                Frame.Close();
               
            });
        }
        public void ResetAll()
        {
            SV_TIENPHONGLIST = new ObservableCollection<DANHSACHSV_TIENPHONG>(DataProvider.Ins.DB.DANHSACHSV_TIENPHONG);
            PHONGLIST = new ObservableCollection<PHONG>(DataProvider.Ins.DB.PHONGs);
            TIENTHUEPHONGLIST = new ObservableCollection<TIENTHUEPHONG>(DataProvider.Ins.DB.TIENTHUEPHONGs);
            SINHVIENLIST = new ObservableCollection<SINHVIEN>(DataProvider.Ins.DB.SINHVIENs);
            TOALIST = new ObservableCollection<TOA>(DataProvider.Ins.DB.TOAs);
            HOCKILIST = new ObservableCollection<HOCKI>(DataProvider.Ins.DB.HOCKIs);
            BIENLAILIST = new ObservableCollection<BIENLAITIENPHONG>(DataProvider.Ins.DB.BIENLAITIENPHONGs);
            BIENLAIFULLLIST = Enumerable.Empty<BIENLAIFULL>();
        }
        public void LoadMainView(int selectedIDBL)
        {
            //reset các bảng

            ResetAll();
            


            var info1 = System.Globalization.CultureInfo.GetCultureInfo("vi-VN");
            //TIENPHONGPHAIDONG = string.Format(info1, "{0:c0}", (NumberOfMonthLiving * TIENTHUE));

            // load Biên lai 

            // join thêm mssv
            BIENLAIFULLLIST = (from bll in BIENLAILIST.Where (x=> x.IDBL == selectedIDBL)
                               join hkl in HOCKILIST on bll.IDHOCKI equals hkl.IDHOCKI

                               join stl in SINHVIENLIST on bll.IDSINHVIEN equals stl.IDSINHVIEN
                               //join sv_phong in SV_TIENPHONGLIST on stl.IDSINHVIEN equals sv_phong.IDSINHVIEN
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
                                   //NGAYVAO = sv_phong.NGAYVAO
                               }
                     );




        }
    }
}
