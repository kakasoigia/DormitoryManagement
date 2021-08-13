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
    public class SemesterListViewModel: BaseViewModel
    {
        private int _SelectedIDHOCKI;
        public int SelectedIDHOCKI { get => _SelectedIDHOCKI; set { _SelectedIDHOCKI = value; OnPropertyChanged(); } }
        private ObservableCollection<HOCKI> _HOCKILIST;
        public ObservableCollection<HOCKI> HOCKILIST { get => _HOCKILIST; set { _HOCKILIST = value; OnPropertyChanged(); } }
        public ICommand EditCommand { get; set; }
        public ICommand AddSemesterCommand { get; set; }
        public SemesterListViewModel()
        {
            
            EditCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                SemesterEdit se = new SemesterEdit();
                var seDT = se.DataContext as SemesterEditViewModel;
                seDT.SelectedIDHOCKI = (int)p;
                seDT.LoadList();
                
                se.ShowDialog();
                
                se.Close();
            });
            AddSemesterCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                SemesterAdd se = new SemesterAdd();
                var seDT = se.DataContext as SemesterAddViewModel;
                seDT.Reset();

                se.ShowDialog();

                se.Close();
            });
           
        }
        public void LoadList()
        {
            HOCKILIST = new ObservableCollection<HOCKI>(DataProvider.Ins.DB.HOCKIs);

        }
    }
}
