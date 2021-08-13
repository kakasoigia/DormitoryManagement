using DomitoryManagement.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DomitoryManagement.ViewModel
{   public class FULLLISTDIENNUOC :BaseViewModel
    {
        private int _IDPHONG;
        public int IDPHONG { get => _IDPHONG; set { _IDPHONG = value; OnPropertyChanged(); } }
        private int _IDBL;
        public int IDBL { get => _IDBL; set { _IDBL = value; OnPropertyChanged(); } }
        private string _TENPHONG;
        public string TENPHONG { get => _TENPHONG; set { _TENPHONG = value; OnPropertyChanged(); } }

        private string _TENTOA;
        public string TENTOA { get => _TENTOA; set { _TENTOA = value; OnPropertyChanged(); } }

        private string _THANGNAM;
        public string THANGNAM { get => _THANGNAM; set { _THANGNAM = value; OnPropertyChanged(); } }
        private int _CHISODIEN;
        public int CHISODIEN { get => _CHISODIEN; set { _CHISODIEN = value; OnPropertyChanged(); } }

        private string _TIENDIEN;
        public string TIENDIEN { get => _TIENDIEN; set { _TIENDIEN = value; OnPropertyChanged(); } }
        private int _intTIENDIEN;
        public int intTIENDIEN { get => _intTIENDIEN; set { _intTIENDIEN = value; OnPropertyChanged(); } }
        private int _intTIENNUOC;
        public int intTIENNUOC { get => _intTIENNUOC; set { _intTIENNUOC = value; OnPropertyChanged(); } }

        private int _CHISONUOC;
        public int CHISONUOC { get => _CHISONUOC; set { _CHISONUOC = value; OnPropertyChanged(); } }

        private string _TIENNUOC;
        public string TIENNUOC { get => _TIENNUOC; set { _TIENNUOC = value; OnPropertyChanged(); } }

        private string _TONGCONG;
        public string TONGCONG { get => _TONGCONG; set { _TONGCONG = value; OnPropertyChanged(); } }

        private string _THONGTINTHANHTOAN;
        public string THONGTINTHANHTOAN { get => _THONGTINTHANHTOAN; set { _THONGTINTHANHTOAN = value; OnPropertyChanged(); } }

        private string _GHICHU;
        public string GHICHU { get => _GHICHU; set { _GHICHU = value; OnPropertyChanged(); } }
        private bool _TINHTRANG;
        public bool TINHTRANG { get => _TINHTRANG; set { _TINHTRANG = value; OnPropertyChanged(); } }
        public FULLLISTDIENNUOC()
        {

        }
    }
    public class EWReceiptViewModel : BaseViewModel
    {
        private FULLLISTDIENNUOC _SelectedBIENLAI;
        public FULLLISTDIENNUOC SelectedBIENLAI { get => _SelectedBIENLAI; set { _SelectedBIENLAI = value; OnPropertyChanged(); } }
        private IEnumerable<FULLLISTDIENNUOC> _BLDIENNUOCFULLLISTRoot;
        public IEnumerable<FULLLISTDIENNUOC> BLDIENNUOCFULLLISTRoot { get => _BLDIENNUOCFULLLISTRoot; set { _BLDIENNUOCFULLLISTRoot = value; OnPropertyChanged(); } }
        private List<FULLLISTDIENNUOC> _BLDIENNUOCFULLLIST;
        public List<FULLLISTDIENNUOC> BLDIENNUOCFULLLIST { get => _BLDIENNUOCFULLLIST; set { _BLDIENNUOCFULLLIST = value; OnPropertyChanged(); } }
        private ObservableCollection<TOA> _TOALIST;
        public ObservableCollection<TOA> TOALIST { get => _TOALIST; set { _TOALIST = value; OnPropertyChanged(); } }

        private ObservableCollection<PHONG> _PHONGLIST;
        public ObservableCollection<PHONG> PHONGLIST { get => _PHONGLIST; set { _PHONGLIST = value; OnPropertyChanged(); } }
        private ObservableCollection<TIENDIENNUOC> _TIENDIENUOCLIST;
        public ObservableCollection<TIENDIENNUOC> TIENDIENUOCLIST { get => _TIENDIENUOCLIST; set { _TIENDIENUOCLIST = value; OnPropertyChanged(); } }
        public ICommand AddInfoCommand { get; set; }
        public ICommand ChargeCommand { get; set; }
        public ICommand DeleteBLCommand { get; set; }

        private bool _isFilter;
        public bool isFilter { get => _isFilter; set { _isFilter = value; OnPropertyChanged(); } }

        public EWReceiptViewModel()
        {
            AddInfoCommand =new RelayCommand<FULLLISTDIENNUOC>((p) => { return true; }, (p) =>
            {

                EWAddFigures ea = new EWAddFigures();
                var eaDT = ea.DataContext as EWAddFigureViewModel;
                eaDT.SelectedIDBIENLAI = p.IDBL;
                eaDT.Reset();
                ea.ShowDialog();
                ea.Close();

            });
            ChargeCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                string MessageReceipt = "Vui lòng xác nhận hóa đơn trị giá " + BLDIENNUOCFULLLIST.Where(x => x.IDBL == (int)p).Single().TONGCONG + " !";
                MessageBoxResult result = MessageBox.Show(MessageReceipt, "Hóa đơn điện nước", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    var update = (from up in DataProvider.Ins.DB.TIENDIENNUOCs where up.IDBL == (int)p select up).Single();
                    update.TINHTRANG = true;
                    DataProvider.Ins.DB.SaveChanges();
                    // load lại EWReceipt

                    LoadListEW();
                    // //load lai main
                    BuildingDiagram bd = new BuildingDiagram();
                    var bdDT = bd.DataContext as BuildingDiagramViewModel;
                    bdDT.LoadToa();
                    MainWindow mw = new MainWindow();
                    var mwDT = mw.DataContext as MainViewModel;
                    mwDT.LoadChartPhong();
                    mw.Close();
                    bd.Close();
                }
                

            });
            DeleteBLCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                
                MessageBoxResult result = MessageBox.Show("Bạn có chắc muốn hủy hóa đơn", "Hủy hóa đơn điện nước", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    var update = (from up in DataProvider.Ins.DB.TIENDIENNUOCs where up.IDBL == (int)p select up).Single();
                    update.TINHTRANG = false;
                    DataProvider.Ins.DB.SaveChanges();
                    // load lại EWReceipt

                    LoadListEW();
                    //load lai main
                    BuildingDiagram bd = new BuildingDiagram();
                    var bdDT = bd.DataContext as BuildingDiagramViewModel;
                    bdDT.LoadToa();
                    MainWindow mw = new MainWindow();
                    var mwDT = mw.DataContext as MainViewModel;
                    mwDT.LoadChartPhong();
                    mw.Close();
                    bd.Close();
                }


            });

        }
        public void LoadListEW()
        {
            var info1 = System.Globalization.CultureInfo.GetCultureInfo("vi-VN");

            TIENDIENUOCLIST = new ObservableCollection<TIENDIENNUOC>(DataProvider.Ins.DB.TIENDIENNUOCs);
            PHONGLIST = new ObservableCollection<PHONG>(DataProvider.Ins.DB.PHONGs);
            TOALIST = new ObservableCollection<TOA>(DataProvider.Ins.DB.TOAs);
            BLDIENNUOCFULLLISTRoot = (from tiendiennuoc in TIENDIENUOCLIST
                                  join phong in PHONGLIST on tiendiennuoc.IDPHONG equals phong.IDPHONG into TIENDIENNUOC_PHONG
                                  from tiendc_phong in TIENDIENNUOC_PHONG
                                  join toa in TOALIST on tiendc_phong.IDTOA equals toa.IDTOA into lastlist
                                  from endgame in lastlist
                                  select new FULLLISTDIENNUOC()
                                  {
                                      IDPHONG = tiendiennuoc.IDPHONG,
                                      TENPHONG = tiendc_phong.TENPHONG,
                                      TENTOA = endgame.TENTOA,
                                      CHISODIEN = tiendiennuoc.CHISODIEN,
                                      CHISONUOC = tiendiennuoc.CHISONUOC,
                                      GHICHU = null,
                                      TINHTRANG =(bool) tiendiennuoc.TINHTRANG,
                                      intTIENDIEN = (int)CalculateCostE(tiendiennuoc.CHISODIEN),
                                      intTIENNUOC = (int)CalculateCostW(tiendiennuoc.CHISONUOC),
                                      TIENDIEN = string.Format(info1, "{0:c0}", (int)CalculateCostE(tiendiennuoc.CHISODIEN)),
                                      TIENNUOC = string.Format(info1, "{0:c0}", (int)CalculateCostW(tiendiennuoc.CHISONUOC)),
                                      TONGCONG = string.Format(info1, "{0:c0}", (int)CalculateCostE(tiendiennuoc.CHISODIEN) + (int)CalculateCostW(tiendiennuoc.CHISONUOC)),
                                      THANGNAM = tiendiennuoc.THOIGIAN.ToString("MM/yyyy"),
                                      IDBL = tiendiennuoc.IDBL
                                  }
                );
            BLDIENNUOCFULLLIST = BLDIENNUOCFULLLISTRoot.ToList();

            
        }
        public decimal CalculateCostE(int CHISODIEN)
        {
            decimal giadien1 = (from get in DataProvider.Ins.DB.GIADIENs where get.ID == 1 select get).Single().GIADIEN1;
            decimal giadien2 = (from get in DataProvider.Ins.DB.GIADIENs where get.ID == 2 select get).Single().GIADIEN1;
            decimal giadien3 = (from get in DataProvider.Ins.DB.GIADIENs where get.ID == 3 select get).Single().GIADIEN1;
            decimal giadien4 = (from get in DataProvider.Ins.DB.GIADIENs where get.ID == 4 select get).Single().GIADIEN1;
            decimal giadien5 = (from get in DataProvider.Ins.DB.GIADIENs where get.ID == 5 select get).Single().GIADIEN1;
            decimal giadien6 = (from get in DataProvider.Ins.DB.GIADIENs where get.ID == 6 select get).Single().GIADIEN1;
            if (CHISODIEN <= 0)
            {
                return 0;
            }
            if (0 < CHISODIEN && CHISODIEN <= 50)
            {
                return CHISODIEN * giadien1;
            }
            else if (50 < CHISODIEN && CHISODIEN <= 100)
            {
                return (50 * giadien1 + (CHISODIEN - 50) * giadien2);
            }
            else if (100 < CHISODIEN && CHISODIEN <= 200)
            {
                return (50 * giadien1 + 50 * giadien2 + (CHISODIEN - 100) * giadien3);
            }
            else if (200 < CHISODIEN && CHISODIEN <= 300)
            {
                return (50 * giadien1 + 50 * giadien2 + 100 * giadien3 + (CHISODIEN - 200) * giadien4);
            }
            else if (300 < CHISODIEN && CHISODIEN <= 400)
            {
                return (50 * giadien1 + 50 * giadien2 + 100 * giadien3 + 100 * giadien4 + (CHISODIEN - 300) * giadien5);
            }
            else
            {
                return (50 * giadien1 + 50 * giadien2 + 100 * giadien3 + 100 * giadien4 + 100 * giadien5 + (CHISODIEN - 400) * giadien6);
            }
        }
        public decimal CalculateCostW(int CHISONUOC)
        {
            decimal gianuoc1 = (from get in DataProvider.Ins.DB.GIANUOCs where get.ID == 1 select get).Single().GIANUOC1;
            decimal gianuoc2 = (from get in DataProvider.Ins.DB.GIANUOCs where get.ID == 2 select get).Single().GIANUOC1;
            decimal gianuoc3 = (from get in DataProvider.Ins.DB.GIANUOCs where get.ID == 3 select get).Single().GIANUOC1;
            decimal gianuoc4 = (from get in DataProvider.Ins.DB.GIANUOCs where get.ID == 4 select get).Single().GIANUOC1;

            if (CHISONUOC <= 0)
                return 0;
            else if (CHISONUOC > 0 && CHISONUOC <= 10)
                return (CHISONUOC * gianuoc1);
            else if (CHISONUOC > 10 && CHISONUOC <= 20)
                return (10 * gianuoc1 + (CHISONUOC - 10) * gianuoc2);
            else if (CHISONUOC > 20 && CHISONUOC <= 30)
                return (10 * (gianuoc1 + gianuoc2) + (CHISONUOC - 20) * gianuoc3);
            else
                return (10 * (gianuoc1 + gianuoc2 + gianuoc3) + (CHISONUOC - 30) * gianuoc4);
        }
    }
}
