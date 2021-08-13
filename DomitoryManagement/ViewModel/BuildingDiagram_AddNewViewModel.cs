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

    public class BuildingDiagram_AddNewViewModel : BaseViewModel
    {

        private ObservableCollection<TOA> _TOALIST;
        public ObservableCollection<TOA> TOALIST { get => _TOALIST; set { _TOALIST = value; OnPropertyChanged(); } }
        private int _IDTOA;
        public int IDTOA { get => _IDTOA; set { _IDTOA = value; OnPropertyChanged(); } }
        private string _TENTOA;
        public string TENTOA { get => _TENTOA; set { _TENTOA = value; OnPropertyChanged(); } }
        private string _LOAITOA;
        public string LOAITOA { get => _LOAITOA; set { _LOAITOA = value; OnPropertyChanged(); } }
        private string _SOLUONGPHONG;
        public string SOLUONGPHONG { get => _SOLUONGPHONG; set { _SOLUONGPHONG = value; OnPropertyChanged(); } }
        private bool _isDistinct;
        public bool isDistinct { get => _isDistinct; set { _isDistinct = value; OnPropertyChanged(); } }
        public ICommand AddBuildingCommand { get; set; }
        public BuildingDiagram_AddNewViewModel()
        {
            AddBuildingCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {

                CheckDistinct();
                
                if (isDistinct == true)
                {
                    TOA t = new TOA();

                    
                    t.TENTOA = TENTOA.ToString();
                    t.SOLUONGPHONG = SOLUONGPHONG.ToString();
                    t.TSGIUONG = 0;
                    t.TSGIUONGTRONG = 0;
                    t.TONGDATHUE = 0;
                    t.TOANAM = (bool)LOAITOA.Contains("Nam") ? true : false;
                    DataProvider.Ins.DB.TOAs.Add(t);
                    DataProvider.Ins.DB.SaveChanges();
                    MessageBox.Show("Đã thêm tòa " + TENTOA + " !");
                    //load lai //
                    BuildingDiagram bd = new BuildingDiagram();
                    var bdDT = bd.DataContext as BuildingDiagramViewModel;
                    bdDT.LoadToa();
                    MainWindow mw = new MainWindow();
                    var mwDT = mw.DataContext as MainViewModel;
                    mwDT.LoadStatis();
                    mw.Close();
                    bd.Close();
                    p.Close();
                }


            });
        }
        public void Load()
        {
            isDistinct = false;
            TENTOA = null;
            SOLUONGPHONG = null;
            LOAITOA = null;
            TOALIST = new ObservableCollection<TOA>(DataProvider.Ins.DB.TOAs);
     
           

        }
        void CheckDistinct()
        {   if (TENTOA == null || SOLUONGPHONG ==null || LOAITOA == null)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin !");
                return;
            }
            foreach (var item in TOALIST)
            {
                if (item.TENTOA == TENTOA)
                {
                    MessageBox.Show("Tên tòa đã tồn tại !");
                    return;
                }
                    
            }
            isDistinct = true;
        }
    }
}
