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
  public  class RoomChargeListViewModel:BaseViewModel
    {
       
            private int _SelectedMSSV;
            public int SelectedMSSV { get => _SelectedMSSV; set { _SelectedMSSV = value; OnPropertyChanged(); } }
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




            public ICommand FindBtn { get; set; }
             public ICommand RoomChargeCommand { get; set; }
             private ObservableCollection<SINHVIEN> _SINHVIENLIST;
            public ObservableCollection<SINHVIEN> SINHVIENLIST { get => _SINHVIENLIST; set { _SINHVIENLIST = value; OnPropertyChanged(); } }
            private ObservableCollection<DANHSACHSV_PHONG> _DSSV_PHONG;
            public ObservableCollection<DANHSACHSV_PHONG> DSSV_PHONG { get => _DSSV_PHONG; set { _DSSV_PHONG = value; OnPropertyChanged(); } }
            private ObservableCollection<DANHSACHSV_TIENPHONG> _DSSV_TIENPHONG;
            public ObservableCollection<DANHSACHSV_TIENPHONG> DSSV_TIENPHONG { get => _DSSV_TIENPHONG; set { _DSSV_TIENPHONG = value; OnPropertyChanged(); } }
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

            public RoomChargeListViewModel()
            {
                //LoadSVList();

                FindBtn = new RelayCommand<object>((p) => { return true; }, (p) =>
                {
                    SINHVIENLISTNew2 = SINHVIENLISTNew.Where(x => ((MSSVFindNumber != null && MSSVFindNumber != "") ? x.MSSV.Contains(MSSVFindNumber) : x.MSSV != null)
                                                                 && ((NameFind != null && NameFind != "") ? x.HOTEN.Contains(NameFind) : x.HOTEN != null)
                                                                 && ((HomeLandFind != null && HomeLandFind != "") ? x.DIACHI.Contains(HomeLandFind) : x.DIACHI != null)
                                                                 && ((SchoolFind != null && SchoolFind != "") ? x.TENTRUONG.Contains(SchoolFind) : x.TENTRUONG != null)
                                                                 && ((TenToaFind != null && TenToaFind != "") ? x.TENTOA.Contains(TenToaFind) : x.TENTOA != null)
                                                                 && ((TenPhongFind != null && TenPhongFind != "") ? x.TENPHONG.Contains(TenPhongFind) : x.TENPHONG != null));
                });
            RoomChargeCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                RoomCharge rc = new RoomCharge();
                var rcDT = rc.DataContext as RoomChargeViewModel;
                rcDT.MSSVFindNumber = p.ToString();
                
                
                rcDT.LoadMainView();
                rc.ShowDialog();

                rc.Close();
            });

        }
            public void LoadSVList()
            {
                SINHVIENLIST = new ObservableCollection<SINHVIEN>(DataProvider.Ins.DB.SINHVIENs);
                TOALIST = new ObservableCollection<TOA>(DataProvider.Ins.DB.TOAs);
                PHONGLIST = new ObservableCollection<PHONG>(DataProvider.Ins.DB.PHONGs);
                DSSV_PHONG = new ObservableCollection<DANHSACHSV_PHONG>(DataProvider.Ins.DB.DANHSACHSV_PHONG);
              DSSV_TIENPHONG = new ObservableCollection<DANHSACHSV_TIENPHONG>(DataProvider.Ins.DB.DANHSACHSV_TIENPHONG);
            /*x => x.DADONGBHTN == false || x.DADONGBHYT == false || x.DADONGTIENPHONG == false)*/
                DS_IDSV_TOAPHONG = (from svp_phong in DSSV_TIENPHONG
                                    join phong in PHONGLIST on svp_phong.IDPHONG equals phong.IDPHONG into dssv_phong_idphong

                                    from phong_tenphong in dssv_phong_idphong
                                    join toa in TOALIST on phong_tenphong.IDTOA equals toa.IDTOA into lastlist

                                    from endgame in lastlist
                                    select new Temp()
                                    {
                                        IDSINHVIEN =(int) svp_phong.IDSINHVIEN,

                                        TENPHONG =  phong_tenphong.TENPHONG,
                                        TENTOA =  endgame.TENTOA,
                                        DADONGBHTN = (bool)svp_phong.DADONGBHTN,
                                        DADONGBHYT = (bool)svp_phong.DADONGBHYT,
                                        DADONGTIENPHONG = (bool)svp_phong.DADONGTIENPHONG
                                    });
                SINHVIENLISTNew = (from sv in SINHVIENLIST
                                   join sv_p in DS_IDSV_TOAPHONG on sv.IDSINHVIEN equals sv_p.IDSINHVIEN 
                                 
                                   select new StudentInfo()
                                   {
                                       IDSINHVIEN = sv.IDSINHVIEN,
                                       MSSV = sv.MSSV,
                                       HOTEN = sv.HOTEN,
                                       TENTRUONG = sv.TENTRUONG,
                                       DIACHI = sv.DIACHI,
                                      
                                       TENPHONG = sv_p.TENPHONG ,
                                       TENTOA = sv_p.TENTOA,
                                       DADONGBHTN = sv_p.DADONGBHTN,
                                       DADONGTIENPHONG =sv_p.DADONGTIENPHONG,
                                       DADONGBHYT =sv_p.DADONGBHYT

                                   });
                SINHVIENLISTNew2 = SINHVIENLISTNew;

            }
        }
    }
