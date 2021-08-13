using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomitoryManagement.Model;
using System.Collections.ObjectModel;

namespace DomitoryManagement.ViewModel
{
    public class GIADIENCLASS : BaseViewModel
    {
        private int _IDMUCDIEN;
        public int IDMUCDIEN { get => _IDMUCDIEN; set { _IDMUCDIEN = value; OnPropertyChanged(); } }
        private string _GIADIEN;
        public string GIADIEN { get => _GIADIEN; set { _GIADIEN = value; OnPropertyChanged(); } }
        private string _CHITIETGIADIEN;
        public string CHITIETGIADIEN { get => _CHITIETGIADIEN; set { _CHITIETGIADIEN = value; OnPropertyChanged(); } }
    }
    public class GIANUOCCLASS : BaseViewModel
    {
        private int _IDMUCNUOC;
        public int IDMUCNUOC { get => _IDMUCNUOC; set { _IDMUCNUOC = value; OnPropertyChanged(); } }
        private string _GIANUOC;
        public string GIANUOC { get => _GIANUOC; set { _GIANUOC = value; OnPropertyChanged(); } }
        private string _CHITIETGIANUOC;
        public string CHITIETGIANUOC { get => _CHITIETGIANUOC; set { _CHITIETGIANUOC = value; OnPropertyChanged(); } }
    }
    public class EWCostListViewModel : BaseViewModel
    {
        private ObservableCollection<GIADIEN> _ECOST;
        public ObservableCollection<GIADIEN> ECOST { get => _ECOST; set { _ECOST = value; OnPropertyChanged(); } }

        private ObservableCollection<GIADIENCLASS> _ECOSTNEW;
        public ObservableCollection<GIADIENCLASS> ECOSTNEW { get => _ECOSTNEW; set { _ECOSTNEW = value; OnPropertyChanged(); } }

        private ObservableCollection<GIANUOC> _WCOST;
        public ObservableCollection<GIANUOC> WCOST { get => _WCOST; set { _WCOST = value; OnPropertyChanged(); } }

        private ObservableCollection<GIANUOCCLASS> _WCOSTNEW;
        public ObservableCollection<GIANUOCCLASS> WCOSTNEW { get => _WCOSTNEW; set { _WCOSTNEW = value; OnPropertyChanged(); } }

        public EWCostListViewModel()
        {
           
        }
        public void LoadCost()
        {
            ECOST = new ObservableCollection<GIADIEN>(DataProvider.Ins.DB.GIADIENs);
            WCOST = new ObservableCollection<GIANUOC>(DataProvider.Ins.DB.GIANUOCs);
            ECOSTNEW = new ObservableCollection<GIADIENCLASS>();
            WCOSTNEW = new ObservableCollection<GIANUOCCLASS>();
            var info1 = System.Globalization.CultureInfo.GetCultureInfo("vi-VN");
            foreach (var item in ECOST)
            {
                GIADIENCLASS gd = new GIADIENCLASS();
                gd.IDMUCDIEN = item.ID;
                gd.GIADIEN = string.Format(info1, "{0:c0}", item.GIADIEN1); 
                gd.CHITIETGIADIEN = item.CHITIETGIA;
                ECOSTNEW.Add(gd);
            }
            foreach (var item in WCOST)
            {
                GIANUOCCLASS gd = new GIANUOCCLASS();
                gd.IDMUCNUOC = item.ID;
                gd.GIANUOC = string.Format(info1, "{0:c0}", item.GIANUOC1);
                gd.CHITIETGIANUOC = item.CHITIETGIA;
                WCOSTNEW.Add(gd);
            }
        }
    }
}
