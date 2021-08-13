using DomitoryManagement.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DomitoryManagement.ViewModel
{
    public class CheckOutListViewModel : BaseViewModel
    {
        private int _SelectedIDHOCKI;
        public int SelectedIDHOCKI { get => _SelectedIDHOCKI; set { _SelectedIDHOCKI = value; OnPropertyChanged(); } }
        private string _NameFind;
        public string NameFind { get => _NameFind; set { _NameFind = value; OnPropertyChanged(); } }
        private string _MSSVFindNumber;
        public string MSSVFindNumber { get => _MSSVFindNumber; set { _MSSVFindNumber = value; OnPropertyChanged(); } }
        private bool _isFilter;
        public bool isFilter { get => _isFilter; set { _isFilter = value; OnPropertyChanged(); } }
        private ObservableCollection<HOCKI> _HOCKILIST;
        public ObservableCollection<HOCKI> HOCKILIST { get => _HOCKILIST; set { _HOCKILIST = value; OnPropertyChanged(); } }
        public ICommand CheckOutCommand { get; set; }
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
        private IEnumerable<StudentInfo> _SV_ROOMLIST;
        public IEnumerable<StudentInfo> SV_ROOMLIST { get => _SV_ROOMLIST; set { _SV_ROOMLIST = value; OnPropertyChanged(); } }
        private IEnumerable<StudentInfo> _SV_ROOMLISTRoot;
        public IEnumerable<StudentInfo> SV_ROOMLISTRoot { get => _SV_ROOMLISTRoot; set { _SV_ROOMLISTRoot = value; OnPropertyChanged(); } }
        private IEnumerable<Temp> _DS_IDSV_TOAPHONG;
        public IEnumerable<Temp> DS_IDSV_TOAPHONG { get => _DS_IDSV_TOAPHONG; set { _DS_IDSV_TOAPHONG = value; OnPropertyChanged(); } }
        public CheckOutListViewModel()
        {
            CheckOutCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                CheckOutReceipt col = new CheckOutReceipt();
                var colDT = col.DataContext as CheckOutReceiptViewModel;
                colDT.SelectedIDSINHVIEN = (int)p;
                colDT.Load();
                col.ShowDialog();
                col.Close();
            });
            FindBtn = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                FindInfo();
            });

        }
        public void FindInfo()
        {
            isFilter = true;

            SV_ROOMLIST = SV_ROOMLISTRoot
            .Where(x =>
                                                      ((MSSVFindNumber != null && MSSVFindNumber != "") ? x.MSSV.Contains(MSSVFindNumber) : x.MSSV != null)
                                                       && ((NameFind != null && NameFind != "") ? x.HOTEN.Contains(NameFind) : x.HOTEN != null)                        
                                                        );
        }
        public void ResetBoLoc()
        {
            MSSVFindNumber = null;
            NameFind = null;
        }
        public void LoadSVList()
        {
            if (isFilter == false) ResetBoLoc();
            SINHVIENLIST = new ObservableCollection<SINHVIEN>(DataProvider.Ins.DB.SINHVIENs);
            TOALIST = new ObservableCollection<TOA>(DataProvider.Ins.DB.TOAs);
            PHONGLIST = new ObservableCollection<PHONG>(DataProvider.Ins.DB.PHONGs);
            DSSV_PHONG = new ObservableCollection<DANHSACHSV_PHONG>(DataProvider.Ins.DB.DANHSACHSV_PHONG);
            
            SV_ROOMLISTRoot = (from sv in SINHVIENLIST
                           join dssv_phong in DSSV_PHONG on sv.IDSINHVIEN equals dssv_phong.IDSINHVIEN into sv_dssv_phong
                           from svdssvphong in sv_dssv_phong
                           join phong in PHONGLIST on svdssvphong.IDPHONG equals phong.IDPHONG into sv_dssv_phong_tenphong
                           from svphong in sv_dssv_phong_tenphong
                           join toa in TOALIST on svphong.IDTOA equals toa.IDTOA into lastlist
                           from endgame in lastlist
                           select new StudentInfo()
                           {
                               IDSINHVIEN = sv.IDSINHVIEN,
                               MSSV = sv.MSSV,
                               HOTEN = sv.HOTEN,
                               TENTRUONG = sv.TENTRUONG,
                               DIACHI = sv.DIACHI,
                               TENPHONG = svphong.TENPHONG,
                               TENTOA = endgame.TENTOA,
                               NGAYVAO = svdssvphong.NGAYVAO

                           }
                                );
            FindInfo();




         

        }
    }
}
