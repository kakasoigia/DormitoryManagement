using DomitoryManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DomitoryManagement.ViewModel
{
   public class EWAddFigureViewModel:BaseViewModel
    {
        private int _SelectedIDBIENLAI;
        public int SelectedIDBIENLAI { get => _SelectedIDBIENLAI; set { _SelectedIDBIENLAI = value; OnPropertyChanged(); } }
        private string _CHISODIEN;
        public string CHISODIEN { get => _CHISODIEN; set { _CHISODIEN = value; OnPropertyChanged(); } }
        private string _CHISONUOC;
        public string CHISONUOC { get => _CHISONUOC; set { _CHISONUOC = value; OnPropertyChanged(); } }
        public ICommand SaveCommand { get; set; }
        public EWAddFigureViewModel()
        {
            SaveCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                var update = (from up in DataProvider.Ins.DB.TIENDIENNUOCs where up.IDBL == SelectedIDBIENLAI select up).Single();
                int temp,temp2;
                bool isNumeric = int.TryParse(CHISODIEN, out temp);
                bool isNumeric2 = int.TryParse(CHISONUOC, out temp2);
                if (isNumeric == true && isNumeric2 == true)
                {
                    update.CHISODIEN = temp;
                    update.CHISONUOC = temp2;
                    DataProvider.Ins.DB.SaveChanges();
                    MessageBox.Show("Lưu thành công!");
                    EWReceiptList ew = new EWReceiptList();
                    var ewDT = ew.DataContext as EWReceiptViewModel;
                    ewDT.LoadListEW();
                    ew.Close();
                    p.Close();
                }

                else
                    MessageBox.Show("Lỗi ! Vui lòng nhập số");


                
              
                

            });
        }
        public void Reset()
        {
            var update = (from up in DataProvider.Ins.DB.TIENDIENNUOCs where up.IDBL == SelectedIDBIENLAI select up).Single();
            CHISODIEN = update.CHISODIEN.ToString();
            CHISONUOC = update.CHISONUOC.ToString();
        }
    }
}
