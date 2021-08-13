using DomitoryManagement.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomitoryManagement.ViewModel
{
   public class RefundViewModel :BaseViewModel
    {
        private ObservableCollection<BIENLAIHOANTRAPHONG> _BIENLAITPLIST;
        public ObservableCollection<BIENLAIHOANTRAPHONG> BIENLAITPLIST { get => _BIENLAITPLIST; set { _BIENLAITPLIST = value; OnPropertyChanged(); } }
        private int _SelectedIDSINHVIEN;
        public int SelectedIDSINHVIEN { get => _SelectedIDSINHVIEN; set { _SelectedIDSINHVIEN = value; OnPropertyChanged(); } }
        public RefundViewModel()
        {

        }
        public void LoadBL()
        {
            BIENLAITPLIST = new ObservableCollection<BIENLAIHOANTRAPHONG>(DataProvider.Ins.DB.BIENLAIHOANTRAPHONGs);

        }
    }
}
