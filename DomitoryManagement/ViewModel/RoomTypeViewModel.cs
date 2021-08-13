using DomitoryManagement.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomitoryManagement.ViewModel
{       public class LOAIPHONGClass :BaseViewModel
        {
        private int _LOAIPHONG;
        public int LOAIPHONG { get => _LOAIPHONG; set { _LOAIPHONG = value; OnPropertyChanged(); } }
        private int _SOGIUONG;
        public int SOGIUONG { get => _SOGIUONG; set { _SOGIUONG = value; OnPropertyChanged(); } }
        private string _TIENTHUE;
        public string TIENTHUE { get => _TIENTHUE; set { _TIENTHUE = value; OnPropertyChanged(); } }
    }
     public class RoomTypeViewModel : BaseViewModel
    {
        private int _LOAIPHONG;
        public int LOAIPHONG { get => _LOAIPHONG; set { _LOAIPHONG = value; OnPropertyChanged(); } }
       

        private ObservableCollection<TIENTHUEPHONG> _ROOMTYPELIST;
        public ObservableCollection<TIENTHUEPHONG> ROOMTYPELIST { get => _ROOMTYPELIST; set { _ROOMTYPELIST = value; OnPropertyChanged(); } }
        private ObservableCollection<LOAIPHONGClass> _ROOMTYPELISTNew;
        public ObservableCollection<LOAIPHONGClass> ROOMTYPELISTNew { get => _ROOMTYPELISTNew; set { _ROOMTYPELISTNew = value; OnPropertyChanged(); } }
        public RoomTypeViewModel()
        {
            ROOMTYPELIST = new ObservableCollection<TIENTHUEPHONG>(DataProvider.Ins.DB.TIENTHUEPHONGs);
            ROOMTYPELISTNew = new ObservableCollection<LOAIPHONGClass>();
            var info1 = System.Globalization.CultureInfo.GetCultureInfo("vi-VN");
            
            foreach (var item in ROOMTYPELIST)
            {
                LOAIPHONGClass lp = new LOAIPHONGClass();
                lp.LOAIPHONG = item.LOAIPHONG;
                lp.SOGIUONG =  (int) item.SOGIUONG;
                lp.TIENTHUE = string.Format(info1, "{0:c0}", item.TIENTHUE);
                ROOMTYPELISTNew.Add(lp);
            }
        }
    }
}
