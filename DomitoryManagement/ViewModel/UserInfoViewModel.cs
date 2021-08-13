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

    public class UserInfoViewModel : BaseViewModel
    {
        public ICommand EditInfoCommand { get; set; }

        private ObservableCollection<CANBO> _CANBOLIST;
        public ObservableCollection<CANBO> CANBOLIST { get => _CANBOLIST; set { _CANBOLIST = value; OnPropertyChanged(); } }

        private ObservableCollection<User> _USERLIST;
        public ObservableCollection<User> USERLIST { get => _USERLIST; set { _USERLIST = value; OnPropertyChanged(); } }

        private string _MSCB;
        public string MSCB { get => _MSCB; set { _MSCB = value; OnPropertyChanged(); } }

        private string _HOTEN;
        public string HOTEN { get => _HOTEN; set { _HOTEN = value; OnPropertyChanged(); } }

        private string _NGAYSINH;
        public string NGAYSINH { get => _NGAYSINH; set { _NGAYSINH = value; OnPropertyChanged(); } }

        private string _GIOITINH;
        public string GIOITINH { get => _GIOITINH; set { _GIOITINH = value; OnPropertyChanged(); } }

        private string _SDT;
        public string SDT { get => _SDT; set { _SDT = value; OnPropertyChanged(); } }

        private string _CMND;
        public string CMND { get => _CMND; set { _CMND = value; OnPropertyChanged(); } }

        private string _CHUCVU;
        public string CHUCVU { get => _CHUCVU; set { _CHUCVU = value; OnPropertyChanged(); } }

        private string _NGAYVAOLAM;
        public string NGAYVAOLAM { get => _NGAYVAOLAM; set { _NGAYVAOLAM = value; OnPropertyChanged(); } }

        private string _DIACHI;
        public string DIACHI { get => _DIACHI; set { _DIACHI = value; OnPropertyChanged(); } }

        private string _DANTOC;
        public string DANTOC { get => _DANTOC; set { _DANTOC = value; OnPropertyChanged(); } }

        private string _QUOCTICH;
        public string QUOCTICH { get => _QUOCTICH; set { _QUOCTICH = value; OnPropertyChanged(); } }

        private int _IDCANBO;
        public int IDCANBO { get => _IDCANBO; set { _IDCANBO = value; OnPropertyChanged(); } }

        private string _SELECTEDUSERNAME;
        public string SELECTEDUSERNAME { get => _SELECTEDUSERNAME; set { _SELECTEDUSERNAME = value; OnPropertyChanged(); } }

        private string _SELECTEDIDUSER;
        public string SELECTEDIDUSER { get => _SELECTEDIDUSER; set { _SELECTEDIDUSER = value; OnPropertyChanged(); } }
        public UserInfoViewModel()
        {

        }
        public void LoadInfor()
        {
            LoginWindow lg = new LoginWindow();
            var Login = lg.DataContext as LoginViewModel;
            SELECTEDUSERNAME = Login.UserName;
            lg.Close();

            USERLIST = new ObservableCollection<User>(DataProvider.Ins.DB.Users);
            foreach(var item in USERLIST)
            {
                if(item.UserName == SELECTEDUSERNAME)
                {
                    SELECTEDIDUSER = item.Id.ToString();
                }
            }

            HOTEN = "";
            MSCB = "";
            NGAYSINH = "";
            GIOITINH = "";
            SDT = "";
            DANTOC = "";
            QUOCTICH = "";
            CMND = "";
            DIACHI = "";
            CHUCVU = "";
            NGAYVAOLAM = "";

            CANBOLIST = new ObservableCollection<CANBO>(DataProvider.Ins.DB.CANBOes);

            foreach (var item in CANBOLIST)
            {
                if (item.IDUSER.ToString() == SELECTEDIDUSER)
                {
                    HOTEN = item.HOTEN;
                    MSCB = item.MSCB.ToString();
                    NGAYSINH = item.NGAYSINH;
                    GIOITINH = ((bool)item.GIOITINH ? "Nam" : "Nữ");
                    SDT = item.SDT.ToString();
                    DANTOC = item.DANTOC.ToString();
                    QUOCTICH = item.QUOCTICH.ToString();
                    CMND = item.CMND.ToString();
                    DIACHI = item.DIACHI.ToString();
                    CHUCVU = item.CHUCVU;
                    NGAYVAOLAM = item.NGAYVAOLAM;
                    IDCANBO = item.IDCANBO;
                }
                OnPropertyChanged();
            }
        }
    }
}
