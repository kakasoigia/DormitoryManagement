using DomitoryManagement.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomitoryManagement.ViewModel
{
        public class EWCostSettingViewModel : BaseViewModel
        {
            private ObservableCollection<GIADIEN> _ECOST;
            public ObservableCollection<GIADIEN> ECOST { get => _ECOST; set { _ECOST = value; OnPropertyChanged(); } }

            private ObservableCollection<GIADIENCLASS> _ECOSTNEW;
            public ObservableCollection<GIADIENCLASS> ECOSTNEW { get => _ECOSTNEW; set { _ECOSTNEW = value; OnPropertyChanged(); } }

            private ObservableCollection<GIANUOC> _WCOST;
            public ObservableCollection<GIANUOC> WCOST { get => _WCOST; set { _WCOST = value; OnPropertyChanged(); } }

            private ObservableCollection<GIANUOCCLASS> _WCOSTNEW;
            public ObservableCollection<GIANUOCCLASS> WCOSTNEW { get => _WCOSTNEW; set { _WCOSTNEW = value; OnPropertyChanged(); } }

            public EWCostSettingViewModel()
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
                    gd.GIADIEN = item.GIADIEN1.ToString();
                    gd.CHITIETGIADIEN = item.CHITIETGIA;
                    ECOSTNEW.Add(gd);
                }
                foreach (var item in WCOST)
                {
                GIANUOCCLASS gd = new GIANUOCCLASS();
                    gd.IDMUCNUOC = item.ID;
                    gd.GIANUOC = item.GIANUOC1.ToString();
                    gd.CHITIETGIANUOC = item.CHITIETGIA;
                    WCOSTNEW.Add(gd);
                }
        }
        }
}
