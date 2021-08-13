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
    class ChangeInfoViewModel : BaseViewModel
    {
        private string _MSSV;
        public string MSSV { get => _MSSV; set { _MSSV = value; OnPropertyChanged(); } }
        private string _Name;
        public string Name { get => _Name; set { _Name = value; OnPropertyChanged(); } }

        private string _MSSVFindNumber;
        public string MSSVFindNumber { get => _MSSVFindNumber; set { _MSSVFindNumber = value; OnPropertyChanged(); } }
        private int _SelectedIDSINHVIEN;
        public int SelectedIDSINHVIEN { get => _SelectedIDSINHVIEN; set { _SelectedIDSINHVIEN = value; OnPropertyChanged(); } }

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
        private string _UserName;
        public string UserName { get => _UserName; set { _UserName = value; OnPropertyChanged(); } }
        private string _HomeLand;
        public string HomeLand { get => _HomeLand; set { _HomeLand = value; OnPropertyChanged(); } }
        public ICommand SaveChange { get; set; }
        public ChangeInfoViewModel()
        {       
                SaveChange = new RelayCommand<Window>((p) => { return true; }, (p) =>
                {
                   
                    StudentInfor studentInfor = new StudentInfor();
                    var studentIF = studentInfor.DataContext as StudentInforViewModel;
                    
                    ObservableCollection<SINHVIEN> SINHVIENLIST = new ObservableCollection<SINHVIEN>(DataProvider.Ins.DB.SINHVIENs);
                    
                        var updatestudent = (from up in DataProvider.Ins.DB.SINHVIENs where up.IDSINHVIEN == studentIF.SelectedIDSINHVIEN select up).Single();
                {
                    updatestudent.HOTEN = Name;
                    updatestudent.MSSV = MSSV;
                    updatestudent.NGAYSINH = Birthday.ToString("dd/MM/yyyy");
                        if (Gender != null)
                        {
                            if (Gender.Contains("Nam") == true) updatestudent.GIOITINH = true;
                            else if (Gender.Contains("Nữ")) updatestudent.GIOITINH = false;
                            
                        }
                        updatestudent.SDT = PhoneNumber;
                        updatestudent.TENTRUONG = School;
                        updatestudent.DANTOC = Ethnic;
                        updatestudent.QUOCTICH = Nationality;
                        updatestudent.CMND = Identity;
                        updatestudent.SINHVIENNAM = LearningYear.ToString();
                        updatestudent.KHOA = Major;
                        updatestudent.DIACHI = HomeLand;
                    }
                    
                    DataProvider.Ins.DB.SaveChanges();
                        MessageBox.Show("Đổi thông tin thành công!");
                    studentIF.LoadInfor(studentIF.SelectedIDSINHVIEN);
                    studentInfor.Close();
                    //load lại list
                    StudentFullList stl = new StudentFullList();
                    var stlDT = stl.DataContext as StudentFullListViewModel;
                    stlDT.LoadSVList();
                    stl.Close();
                    //StudentInfor stf = new StudentInfor();
                    //    var stfDT = stf.DataContext as StudentInforViewModel;
                   
                    //    stfDT.LoadInfor(stfDT.SelectedIDSINHVIEN);
                    //      stf.Close();
                          p.Close();








                });
            }
         public void LoadDefault()
            {
            
            StudentInfor studentInfor2 = new StudentInfor();
            var studentIF2 = studentInfor2.DataContext as StudentInforViewModel;
           
            var SINHVIENLIST = new ObservableCollection<SINHVIEN>(DataProvider.Ins.DB.SINHVIENs);
            foreach (var item in SINHVIENLIST)
            {
                if (item.IDSINHVIEN == studentIF2.SelectedIDSINHVIEN)
                {
                    Name = item.HOTEN;
                    MSSV = item.MSSV;
                    Birthday = Convert.ToDateTime( item.NGAYSINH);

                    Gender = (bool)item.GIOITINH ? "Nam" : "Nữ";
                    PhoneNumber = item.SDT.ToString();
                    School = item.TENTRUONG.ToString();
                    Ethnic = item.DANTOC.ToString();
                    Nationality = item.QUOCTICH.ToString();
                    Identity = item.CMND.ToString();
                    LearningYear = item.SINHVIENNAM.ToString();
                    Major = item.KHOA;
                    HomeLand = item.DIACHI;
                    
                    IDKTX = item.IDSINHVIEN;
                }
            }
            studentInfor2.Close();
        }
        
        
    }
}
