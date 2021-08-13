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
   public class SemesterAddViewModel:BaseViewModel
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
        public SemesterAddViewModel()
        {
            SaveCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                if (TENHOCKI != null && TENNAMHOC != null && NGAYBATDAU != null && NGAYKETTHUC != null)
                {
                    SINHVIEN sv = new SINHVIEN();
                    
                    HOCKI hk = new HOCKI();
                    hk.TENNAMHOC = TENNAMHOC;
                    hk.TENHOCKI = TENHOCKI;
                    hk.NGAYBATDAU = NGAYBATDAU.ToString("dd/MM/yyyy");
                    hk.NGAYKETHUC = NGAYKETTHUC.ToString("dd/MM/yyyy");
                    DataProvider.Ins.DB.HOCKIs.Add(hk);
                    DataProvider.Ins.DB.SaveChanges();
                    MessageBox.Show("Thêm học kì thành công !");
                    // load lại list//
                    SemesterList sl = new SemesterList();
                    var slDT = sl.DataContext as SemesterListViewModel;
                    slDT.LoadList();
                    sl.Close();
                    //end
                    p.Close();
                }
                else
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin !");    
               
            });
        }
        public void Reset()
        {
            TENHOCKI = null;
            TENNAMHOC = null;

        }
    }
}
