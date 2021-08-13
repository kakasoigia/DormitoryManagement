using DomitoryManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Data.SqlClient;

namespace DomitoryManagement.ViewModel
{
   public class ChangePassWordViewModel :BaseViewModel
    {
        private string _OldPassword;
        public string OldPassword { get => _OldPassword; set { _OldPassword = value; OnPropertyChanged(); } }

        private string _NewPassword;
        public string NewPassword { get => _NewPassword; set { _NewPassword = value; OnPropertyChanged(); } }

        private string _NewPassword2;
        public string NewPassword2 { get => _NewPassword2; set { _NewPassword2 = value; OnPropertyChanged(); } }
        private string _UserName;
        public string UserName { get => _UserName; set { _UserName = value; OnPropertyChanged(); } }
        public ICommand OldPasswordChangedCommand { get; set; }
        public ICommand NewPasswordChangedCommand { get; set; }
        public ICommand NewPassword2ChangedCommand { get; set; }
        public ICommand ChangePassWordCommand { get; set; }
        public ChangePassWordViewModel()
        {
           
            OldPasswordChangedCommand = new RelayCommand<PasswordBox>((p) => { return true; }, (p) => { OldPassword = p.Password;  });
            NewPasswordChangedCommand = new RelayCommand<PasswordBox>((p) => { return true; }, (p) => { NewPassword = p.Password; });
            NewPassword2ChangedCommand = new RelayCommand<PasswordBox>((p) => { return true; }, (p) => { NewPassword2 = p.Password; });
            
            


            ChangePassWordCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                int isOldPassTrue = DataProvider.Ins.DB.Users.Where(x => x.UserName == UserName && x.Password == OldPassword).Count();

                int isNewPassMatch = String.Compare(NewPassword, NewPassword2, true);

               
                if (isOldPassTrue == 0) MessageBox.Show(" Mật khẩu cũ không đúng ! ");
                else if (isNewPassMatch < 0) MessageBox.Show(" Mật khẩu xác nhận không khớp !");
                else
                {

                    var update = (from up in DataProvider.Ins.DB.Users where up.UserName == UserName select up).Single();
                    update.Password = NewPassword;
                    DataProvider.Ins.DB.SaveChanges();


                            MessageBox.Show("Đổi mật khẩu thành công" );
                    p.Close();
                       
                 }
            });
             
        }
        public void Reset()
        {
            LoginWindow loginWindow = new LoginWindow();
            var loginVN = loginWindow.DataContext as LoginViewModel;
            UserName = loginVN.UserName;
            loginWindow.Close();
            var UserLIST = DataProvider.Ins.DB.Users;
            OldPassword = null;
            NewPassword = null;
            NewPassword2 = null;



        }
            
        
    }
}
