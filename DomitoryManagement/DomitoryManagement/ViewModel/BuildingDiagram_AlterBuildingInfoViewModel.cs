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
     public class BuildingDiagram_AlterBuildingInfoViewModel :BaseViewModel
    {
        private ObservableCollection<TOA> _TOALIST;
        public ObservableCollection<TOA> TOALIST { get => _TOALIST; set { _TOALIST = value; OnPropertyChanged(); } }
        private ObservableCollection<TOA> _TOALIST2;
        public ObservableCollection<TOA> TOALIST2 { get => _TOALIST; set { _TOALIST = value; OnPropertyChanged(); } }
        private int _SelectedIDTOA;
        public int SelectedIDTOA { get => _SelectedIDTOA; set { _SelectedIDTOA = value; OnPropertyChanged(); } }

        private string _TENTOA;
        public string TENTOA { get => _TENTOA; set { _TENTOA = value; OnPropertyChanged(); } }
        private string _LOAITOA;
        public string LOAITOA { get => _LOAITOA; set { _LOAITOA = value; OnPropertyChanged(); } }
        private string _SOLUONGPHONG;
        public string SOLUONGPHONG { get => _SOLUONGPHONG; set { _SOLUONGPHONG = value; OnPropertyChanged(); } }
        private bool _isDistinct;
        public bool isDistinct { get => _isDistinct; set { _isDistinct = value; OnPropertyChanged(); } }
        private bool _TOANAM;
        public bool TOANAM { get => _TOANAM; set { _TOANAM = value; OnPropertyChanged(); } }
        public ICommand AlterBuildingCommand { get; set; }
        public BuildingDiagram_AlterBuildingInfoViewModel()
        {
            AlterBuildingCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                CheckDistinct();
                if (isDistinct == true)
                {
                    var update = (from up in DataProvider.Ins.DB.TOAs where up.IDTOA == SelectedIDTOA select up).Single();
                    update.TENTOA = TENTOA;
                    update.SOLUONGPHONG = SOLUONGPHONG;
                    update.TOANAM = (bool) (LOAITOA.Contains ("Nam")) ? true : false;
                    DataProvider.Ins.DB.SaveChanges();
                    MessageBox.Show("Đổi thông tin thành công!");

                    BuildingDiagram bd = new BuildingDiagram();
                    var bdDTt = bd.DataContext as BuildingDiagramViewModel;
                    bdDTt.LoadToa();
                    bd.Close();
                    p.Close();
                }

                

            });
        }
        public void Load(int SelectedIDTOA)
        {
            this.SelectedIDTOA = SelectedIDTOA;
            isDistinct = false;
           
            TOALIST = new ObservableCollection<TOA>(DataProvider.Ins.DB.TOAs.Where (x=> x.IDTOA ==SelectedIDTOA ) );
            TENTOA = TOALIST.Single().TENTOA;
            TOANAM =(bool) TOALIST.Single().TOANAM;
            SOLUONGPHONG = TOALIST.Single().SOLUONGPHONG;




        }
        void CheckDistinct()
        {   //ten toa k đổi//
            if (TENTOA == TOALIST.Single().TENTOA)
            {
                isDistinct = true;
                return;
            }
            if (TENTOA == null || SOLUONGPHONG == null || LOAITOA == null || TENTOA == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin !");
                return;
            }
            TOALIST2 = new ObservableCollection<TOA>(DataProvider.Ins.DB.TOAs);
            foreach (var item in TOALIST2)
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

