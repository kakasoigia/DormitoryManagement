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
{     public class SINHVIENTHUEPHONG :BaseViewModel
    {
        private string _MSSV;
        public string MSSV { get => _MSSV; set { _MSSV = value; OnPropertyChanged(); } }
        private int _IDBL;
        public int IDBL { get => _IDBL; set { _IDBL = value; OnPropertyChanged(); } }
        private string _HOTEN;
        public string HOTEN { get => _HOTEN; set { _HOTEN = value; OnPropertyChanged(); } }
        private string _TENTRUONG;
        public string TENTRUONG { get => _TENTRUONG; set { _TENTRUONG = value; OnPropertyChanged(); } }
        private string _TENNHAPHONG;
        public string TENNHAPHONG { get => _TENNHAPHONG; set { _TENNHAPHONG = value; OnPropertyChanged(); } }
        private string _NGAYVAO;
        public string NGAYVAO { get => _NGAYVAO; set { _NGAYVAO = value; OnPropertyChanged(); } }
        private string _TENHOCKI;
        public string TENHOCKI { get => _TENHOCKI; set { _TENHOCKI = value; OnPropertyChanged(); } }
        private string _GHICHU;
        public string GHICHU { get => _GHICHU; set { _GHICHU = value; OnPropertyChanged(); } }

    }
   public class HiringRoomViewModel: BaseViewModel

    {
        private ObservableCollection<SINHVIEN> _SINHVIENLIST;
        public ObservableCollection<SINHVIEN> SINHVIENLIST { get => _SINHVIENLIST; set { _SINHVIENLIST = value; OnPropertyChanged(); } }

        private IEnumerable<SINHVIENTHUEPHONG>  _BIENLAITHUEPHONGFULLLIST;
        public IEnumerable<SINHVIENTHUEPHONG> BIENLAITHUEPHONGFULLLIST { get => _BIENLAITHUEPHONGFULLLIST; set { _BIENLAITHUEPHONGFULLLIST = value; OnPropertyChanged(); } }

        private ObservableCollection<BIENLAITHUEPHONG>  _BIENLAITHUEPHONGLIST;
        public ObservableCollection<BIENLAITHUEPHONG> BIENLAITHUEPHONGLIST { get => _BIENLAITHUEPHONGLIST; set { _BIENLAITHUEPHONGLIST = value; OnPropertyChanged(); } }

        private string _MSSV;
        public string MSSV { get => _MSSV; set { _MSSV = value; OnPropertyChanged(); } }
        private string _Name;
        public string Name { get => _Name; set { _Name = value; OnPropertyChanged(); } }

        private string _SchoolFind;
        public string SchoolFind { get => _SchoolFind; set { _SchoolFind = value; OnPropertyChanged(); } }
        private string _NameFind;
        public string NameFind { get => _NameFind; set { _NameFind = value; OnPropertyChanged(); } }

        private string _Birthday;
        public string Birthday { get => _Birthday; set { _Birthday = value; OnPropertyChanged(); } }

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
        private int _SelectedID;
        public int SelectedID { get => _SelectedID; set { _SelectedID = value; OnPropertyChanged(); } }
        
        public ICommand FindBtn { get; set; }
        public ICommand HireRoomCommand { get; set; }
        private bool _isFilter;
        public bool isFilter { get => _isFilter; set { _isFilter = value; OnPropertyChanged(); } }

        
        public HiringRoomViewModel()
        {
           

           
            
            HireRoomCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                SelectedID =(int) p;
                //SINHVIEN sv = p.SelectedItems as SINHVIEN;
                //string ten = sv.HOTEN;
                
                HiringRoom2 hr2 = new HiringRoom2();
                var hr2DT = hr2.DataContext as HiringRoomViewModel2;
                hr2DT.LoadCbbTENTOA();
                hr2.ShowDialog();
                hr2.Close();
            });
            FindBtn = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                isFilter = true;
                if (NameFind != null && SchoolFind != null)
                {
                    SINHVIENLIST = new ObservableCollection<SINHVIEN>(DataProvider.Ins.DB.SINHVIENs.Where(x => x.DATHUE == false && x.TENTRUONG.Contains (SchoolFind) && x.HOTEN.Contains(NameFind)));
                }
                else if (NameFind == null && SchoolFind != null)
                {
                    SINHVIENLIST = new ObservableCollection<SINHVIEN>(DataProvider.Ins.DB.SINHVIENs.Where(x => x.DATHUE == false && x.TENTRUONG.Contains(SchoolFind)));
                }
                else if (NameFind != null && SchoolFind == null)
                {
                    SINHVIENLIST = new ObservableCollection<SINHVIEN>(DataProvider.Ins.DB.SINHVIENs.Where(x => x.DATHUE == false && x.HOTEN.Contains(NameFind)));
                }
                else
                {
                    SINHVIENLIST = new ObservableCollection<SINHVIEN>(DataProvider.Ins.DB.SINHVIENs.Where(x => x.DATHUE == false));
                }
            });

            }
        public void LoadListChuaThue()
        {
            BIENLAITHUEPHONGLIST = new ObservableCollection<BIENLAITHUEPHONG>(DataProvider.Ins.DB.BIENLAITHUEPHONGs);
            if (isFilter == false)
            {
                SINHVIENLIST = new ObservableCollection<SINHVIEN>(DataProvider.Ins.DB.SINHVIENs.Where(x => x.DATHUE == false));

            }

           
            else
            {
                if (NameFind != null && SchoolFind != null)
                {
                    SINHVIENLIST = new ObservableCollection<SINHVIEN>(DataProvider.Ins.DB.SINHVIENs.Where(x => x.DATHUE == false && x.TENTRUONG.Contains(SchoolFind) && x.HOTEN.Contains(NameFind)));
                }
                else if (NameFind == null && SchoolFind != null)
                {
                    SINHVIENLIST = new ObservableCollection<SINHVIEN>(DataProvider.Ins.DB.SINHVIENs.Where(x => x.DATHUE == false && x.TENTRUONG.Contains(SchoolFind)));
                }
                else if (NameFind != null && SchoolFind == null)
                {
                    SINHVIENLIST = new ObservableCollection<SINHVIEN>(DataProvider.Ins.DB.SINHVIENs.Where(x => x.DATHUE == false && x.HOTEN.Contains(NameFind)));
                }
                else
                {
                    SINHVIENLIST = new ObservableCollection<SINHVIEN>(DataProvider.Ins.DB.SINHVIENs.Where(x => x.DATHUE == false));
                }
            }
            // Load BIENLAITHUEPHONG gần nhất
            BIENLAITHUEPHONGFULLLIST = (from bienlai in BIENLAITHUEPHONGLIST 
                                        join sv in DataProvider.Ins.DB.SINHVIENs on bienlai.IDSINHVIEN equals sv.IDSINHVIEN
                                        select new SINHVIENTHUEPHONG()
                                        {
                                            IDBL = bienlai.IDVL,
                                            GHICHU = bienlai.GHICHU,
                                            HOTEN = sv.HOTEN,
                                            MSSV = sv.MSSV,
                                            TENTRUONG = sv.TENTRUONG,
                                            TENHOCKI = bienlai.TENHOCKI,
                                            TENNHAPHONG = bienlai.TENNHAPHONG,
                                            NGAYVAO = bienlai.NGAYVAO
                                        });
            //MessageBox.Show(BIENLAITHUEPHONGFULLLIST.Count().ToString());
        }
        public void Load()
        {
            SchoolFind = null;
            NameFind = null;
        }
    }
    
}
