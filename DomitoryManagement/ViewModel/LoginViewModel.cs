using DomitoryManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DomitoryManagement.ViewModel
{

    public class LoginViewModel : BaseViewModel
    {
        public ICommand LoginCommand { get; set; }
        public bool IsLogin { get; set; } 
        
        private string _UserName;
        public  string UserName { get => _UserName; set { _UserName = value; OnPropertyChanged(); } }
        private string _Password;
        public string Password { get => _Password; set { _Password = value; OnPropertyChanged(); } }
        public ICommand PasswordChangedCommand { get; set; }
        public LoginViewModel()
        {
            
            LoginCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>{ Login(p);} );
            PasswordChangedCommand = new RelayCommand<PasswordBox>((p) => { return true; }, (p) => { Password = p.Password; });
        }  
        
        public void Login(Window p)
        {
            
            if (p == null) return;
           var acc= DataProvider.Ins.DB.Users.Where(x => x.UserName == UserName && x.Password == Password).Count();
            
          
            if (acc>0)
            {
                IsLogin = true;
                p.Close();
            }
            else
            {
                IsLogin = false;
                MessageBox.Show("Wrong username or password !");


            }
            
            
        }
        public void ResetPass()
        {
            IsLogin = false;
            UserName = null;
            Password = null;
        }
    }
}
