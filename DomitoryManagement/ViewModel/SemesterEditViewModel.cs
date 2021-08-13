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
  public  class SemesterEditViewModel:BaseViewModel
    {
        private int _SelectedIDHOCKI;
        public int SelectedIDHOCKI { get => _SelectedIDHOCKI; set { _SelectedIDHOCKI = value; OnPropertyChanged(); } }
        private string _TENHOCKI;
        public string TENHOCKI { get => _TENHOCKI; set { _TENHOCKI = value; OnPropertyChanged(); } }
        private string _TENNAMHOC;
        public string TENNAMHOC { get => _TENNAMHOC; set { _TENNAMHOC = value; OnPropertyChanged(); } }
        private DateTime _NGAYBATDAU;
        public DateTime NGAYBATDAU { get => _NGAYBATDAU; set { _NGAYBATDAU = value; OnPropertyChanged(); } }

        private DateTime _NGAYKETTHUC;
        public DateTime NGAYKETTHUC { get => _NGAYKETTHUC; set { _NGAYKETTHUC = value; OnPropertyChanged(); } }
        private ObservableCollection<HOCKI> _HOCKILIST;
        public ObservableCollection<HOCKI> HOCKILIST { get => _HOCKILIST; set { _HOCKILIST = value; OnPropertyChanged(); } }
        public ICommand SaveCommand { get; set; }
        public SemesterEditViewModel()
        {
            SaveCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                var show = (from up in DataProvider.Ins.DB.HOCKIs where up.IDHOCKI == SelectedIDHOCKI select up).Single();
                show.TENHOCKI = TENHOCKI;
                show.TENNAMHOC = TENNAMHOC;
                show.NGAYBATDAU = NGAYBATDAU.ToString("dd/MM/yyyy");
                show.NGAYKETHUC = NGAYKETTHUC.ToString("dd/MM/yyyy");
                DataProvider.Ins.DB.SaveChanges();
                MessageBox.Show("Đổi thông tin thành công !");
                // load lại list//
                SemesterList sl = new SemesterList();
                var slDT = sl.DataContext as SemesterListViewModel;
                slDT.LoadList();
                sl.Close();
                //end
                p.Close();
            });
        }
        public void LoadList()
        {
            var show = (from up in DataProvider.Ins.DB.HOCKIs where up.IDHOCKI == SelectedIDHOCKI select up).Single();
           
            TENHOCKI = show.TENHOCKI ;
            TENNAMHOC = show.TENNAMHOC ;
            NGAYBATDAU = Convert.ToDateTime(show.NGAYBATDAU);
            NGAYKETTHUC = Convert.ToDateTime(show.NGAYKETHUC);
        }
    }
}
