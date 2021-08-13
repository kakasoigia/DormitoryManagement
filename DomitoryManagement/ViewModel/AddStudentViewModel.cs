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
    public class AddStudentViewModel: BaseViewModel
    {
        private string _MSSV;
        public string MSSV { get => _MSSV; set { _MSSV = value; OnPropertyChanged(); } }
        private string _Name;
        public string Name { get => _Name; set { _Name = value; OnPropertyChanged(); } }

        private string _MSSVFindNumber;
        public string MSSVFindNumber { get => _MSSVFindNumber; set { _MSSVFindNumber = value; OnPropertyChanged(); } }

        private DateTime _Birthday;
        public DateTime Birthday { get => _Birthday; set { _Birthday = value; OnPropertyChanged(); } }

        private string _Gender;
        public string Gender { get => _Gender; set { _Gender = value; OnPropertyChanged(); } }

        private string _PhoneNumber;
        public string PhoneNumber { get => _PhoneNumber; set { _PhoneNumber = value; OnPropertyChanged(); } }

        private string _LearningYear;
        public string LearningYear { get => _LearningYear; set { _LearningYear = value; OnPropertyChanged(); } }

        private string _School;
        public string School { get => _School; set { _School = value; OnPropertyChanged(); } }

        private string _Major;
        public string Major { get => _Major; set { _Major = value; OnPropertyChanged(); } }

        private string _Ethnic;
        public string Ethnic { get => _Ethnic; set { _Ethnic = value; OnPropertyChanged(); } }

        private string _Nationality;
        public string Nationality { get => _Nationality; set { _Nationality = value; OnPropertyChanged(); } }

        private string _Identity;
        public string Identity { get => _Identity; set { _Identity = value; OnPropertyChanged(); } }
        private int _IDKTX;
        public int IDKTX { get => _IDKTX; set { _IDKTX = value; OnPropertyChanged(); } }
        private string _HomeLand;
        public string HomeLand { get => _HomeLand; set { _HomeLand = value; OnPropertyChanged(); } }
        public ICommand AddStudent { get; set; }
        public AddStudentViewModel()
        {
             
           

            AddStudent = new RelayCommand<Window>((p) => { return true; }, (p) => 
            {
                
                SINHVIEN sv = new SINHVIEN();
                sv.NGAYSINH = Birthday.ToString("dd/MM/yyyy");



                sv.DANTOC = Ethnic.ToString();
                sv.DIACHI = HomeLand.ToString();
                if (Gender.Contains("Nam")) sv.GIOITINH = true;
                else sv.GIOITINH = false;
                sv.HOTEN = Name.ToString();
                sv.KHOA = Major.ToString();
                sv.MSSV = MSSV.ToString();
                sv.QUOCTICH = Nationality.ToString();
                sv.SDT = PhoneNumber.ToString();

                sv.SINHVIENNAM = LearningYear.ToString();
                sv.TENTRUONG = School.ToString();
                sv.IDSINHVIEN = IDKTX;
                sv.NGAYSINH = Birthday.ToString("dd/MM/yyyy");
                sv.DATHUE = false;
                sv.CMND = Identity;
                DataProvider.Ins.DB.SINHVIENs.Add(sv);
                DataProvider.Ins.DB.SaveChanges();

                MessageBox.Show("Đã thêm sinh viên "  + " vào danh sách");
                MainWindow mw = new MainWindow();
                var mwDTA = mw.DataContext as MainViewModel;
                mwDTA.LoadStatis();
                mw.Close();
                p.Close();

            });

           
        }
       public void LoadID()
        {
           
            MSSV = " ";
            Name = " ";
            
            Gender = " ";
            PhoneNumber = " ";
            School = " ";
            Ethnic = " ";
            Nationality = " ";
            Identity = " ";
            LearningYear = " ";
            Major = " ";
            HomeLand = " ";
            ObservableCollection<SINHVIEN> SINHVIENLIST = new ObservableCollection<SINHVIEN>(DataProvider.Ins.DB.SINHVIENs);
           
        }

    }
}
