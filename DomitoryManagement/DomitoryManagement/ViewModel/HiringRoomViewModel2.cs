using DomitoryManagement.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
namespace DomitoryManagement.ViewModel
{
    public class NewPhong:BaseViewModel
    {
        private string _TENTOA;
        public string TENTOA { get => _TENTOA; set { _TENTOA = value; OnPropertyChanged(); } }

        private int _IDPHONG;
        public int IDPHONG { get => _IDPHONG; set { _IDPHONG = value; OnPropertyChanged(); } }

        private int _LOAIPHONG;
        public int LOAIPHONG { get => _LOAIPHONG; set { _LOAIPHONG = value; OnPropertyChanged(); } }

        private int _SOLUONGTRONG;

        public int SOLUONGTRONG { get => _SOLUONGTRONG; set { _SOLUONGTRONG = value; OnPropertyChanged(); } }

        private string _TENPHONG;
        public string TENPHONG { get => _TENPHONG; set { _TENPHONG = value; OnPropertyChanged(); } }
        //public NewPhong(int IDPHONG,string TENPHONG,int LOAIPHONG,int SOLUONGTRONG,string TENTOA)
        //{
        //   this.IDPHONG = IDPHONG;
        //    this.TENPHONG = TENPHONG;
        //    this.LOAIPHONG = (int)LOAIPHONG;
        //    this.SOLUONGTRONG = (int)SOLUONGTRONG;
        //    this.TENTOA = TENTOA;
        //}
        public NewPhong()
        {

        }

       

    }
    public class HiringRoomViewModel2 : BaseViewModel
    {
        private ObservableCollection<PHONG> _PHONGLIST;
        public ObservableCollection<PHONG> PHONGLIST { get => _PHONGLIST; set { _PHONGLIST = value; OnPropertyChanged(); } }
        private ObservableCollection<DANHSACHSV_TIENPHONG> _SV_TIENPHONGLIST;
        public ObservableCollection<DANHSACHSV_TIENPHONG> SV_TIENPHONGLIST { get => _SV_TIENPHONGLIST; set { _SV_TIENPHONGLIST = value; OnPropertyChanged(); } }


        private ObservableCollection<TOA> _TOALIST;
        public ObservableCollection<TOA> TOALIST { get => _TOALIST; set { _TOALIST = value; OnPropertyChanged(); } }
        private ObservableCollection<DANHSACHSV_PHONG> _SINHVIEN_PHONGLIST;
        public ObservableCollection<DANHSACHSV_PHONG> SINHVIEN_PHONGLIST { get => _SINHVIEN_PHONGLIST; set { _SINHVIEN_PHONGLIST = value; OnPropertyChanged(); } }

        private ObservableCollection<TOA> _TOALIST2;
        public ObservableCollection<TOA> TOALIST2 { get => _TOALIST2; set { _TOALIST2 = value; OnPropertyChanged(); } }
        private ObservableCollection<string> _TOALISTCBB;
        public ObservableCollection<string> TOALISTCBB { get => _TOALISTCBB; set { _TOALISTCBB = value; OnPropertyChanged(); } }
   
        private ObservableCollection<SINHVIEN> _SINHVIENLIST;
        public ObservableCollection<SINHVIEN> SINHVIENLIST { get => _SINHVIENLIST; set { _SINHVIENLIST = value; OnPropertyChanged(); } }
        private string _LOAIPHONG;
        public string LOAIPHONG { get => _LOAIPHONG; set { _LOAIPHONG = value; OnPropertyChanged(); } }
        private int _LOAIPHONGNumber;
        public int LOAIPHONGNumber { get => _LOAIPHONGNumber; set { _LOAIPHONGNumber = value; OnPropertyChanged(); } }
        private string _TENTOA;
        public string TENTOA { get => _TENTOA; set { _TENTOA = value; OnPropertyChanged(); } }
        private string _Default;
        public string Default { get => _Default; set { _Default = value; OnPropertyChanged(); } }
        private int _SelectedID;
        public int SelectedID { get => _SelectedID; set { _SelectedID = value; OnPropertyChanged(); } }
        private int _SelectedIDPhongList;
        public int SelectedIDPhongList { get => _SelectedIDPhongList; set { _SelectedIDPhongList = value; OnPropertyChanged(); } }
        private bool _isExistInSVTIENTHUE;
        public bool isExistInSVTIENTHUE { get => _isExistInSVTIENTHUE; set { _isExistInSVTIENTHUE = value; OnPropertyChanged(); } }
        private Window _ThisFrame;
        public Window ThisFrame { get => _ThisFrame; set { _ThisFrame = value; OnPropertyChanged(); } }

        public Nullable<bool> GIOITINH { get; set; }
        public ICommand FindRoomCommand { get; set; }
        public ICommand RoomMemberCommand { get; set; }
        public ICommand ArrangeCommand { get; set; }
        public ICommand LoadedWindowCommand { get; set; }

        private IEnumerable<NewPhong> _NEWPHONGLIST2;
        public IEnumerable<NewPhong> NEWPHONGLIST2 { get => _NEWPHONGLIST2; set { _NEWPHONGLIST2 = value; OnPropertyChanged(); } }
        private IEnumerable<NewPhong> _NEWPHONGLIST { get; set; }
        public IEnumerable<NewPhong> NEWPHONGLIST { get => _NEWPHONGLIST; set { _NEWPHONGLIST = value; OnPropertyChanged(); } }
        private ObservableCollection<HOCKI> _HOCKILIST;
        public ObservableCollection<HOCKI> HOCKILIST { get => _HOCKILIST; set { _HOCKILIST = value; OnPropertyChanged(); } }
        public HiringRoomViewModel2()
        {

            LoadedWindowCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                ThisFrame = p;
            });
                FindRoomCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                if (TENTOA == null) TENTOA = "Tất cả";
                if (LOAIPHONG.Contains ("Tất cả") ) LOAIPHONGNumber = -1;
                else if (LOAIPHONG.Contains("2 người")) LOAIPHONGNumber = 2;
                else if (LOAIPHONG.Contains("4 người")) LOAIPHONGNumber = 4;
                else if (LOAIPHONG.Contains("6 người")) LOAIPHONGNumber = 6;
                else if (LOAIPHONG.Contains("8 người")) LOAIPHONGNumber = 8;


                // lấy danh sách tòa sau khi tìm kiếm 
                //NEWPHONGLIST = new IEnumerable<NewPhong>();




                // Loc bang truong hop cua LOAIPHONGNumber va TenToa//
                NEWPHONGLIST = Enumerable.Empty<NewPhong>();
                if ( (TENTOA.Contains("Tất cả") == false )  && LOAIPHONGNumber != -1)
                {
                   
                    NEWPHONGLIST = NEWPHONGLIST2.Where(x => x.TENTOA == TENTOA && LOAIPHONGNumber == x.LOAIPHONG && x.SOLUONGTRONG != 0);
                }
                else if (TENTOA.Contains ("Tất cả")== true && LOAIPHONGNumber != -1)
                {
                    
                    NEWPHONGLIST = NEWPHONGLIST2.Where(x => LOAIPHONGNumber == x.LOAIPHONG && x.SOLUONGTRONG != 0);
                }
                else if ((TENTOA.Contains("Tất cả") == false ) && LOAIPHONGNumber == -1 )
                {
                   
                    NEWPHONGLIST = NEWPHONGLIST2.Where(x => x.TENTOA == TENTOA && x.SOLUONGTRONG != 0);
                }
                else if (TENTOA.Contains("Tất cả") == true && LOAIPHONGNumber == -1)
                {
                    
                    NEWPHONGLIST = NEWPHONGLIST2.Where(x =>  x.SOLUONGTRONG != 0);
                }

                // chuyen hoa sang dang NewPhong de xai Grid

                    //if (NEWPHONGLIST.Count() == 0) MessageBox.Show("Không còn phòng phù hợp !");

            });
            ArrangeCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                int IDPHONG = (int) p;
                int isExist = DataProvider.Ins.DB.DANHSACHSV_PHONG.Where(x => x.IDSINHVIEN == SelectedID).Count();
                if (isExist == 0)
                { // thêm vào DS_p
                    DANHSACHSV_PHONG svp = new DANHSACHSV_PHONG();
                    svp.IDPHONG = IDPHONG;
                    svp.IDSINHVIEN = SelectedID;
                    svp.NGAYVAO = DateTime.Now.ToShortDateString().ToString().Trim();

                    DataProvider.Ins.DB.DANHSACHSV_PHONG.Add(svp);
                    DataProvider.Ins.DB.SaveChanges();
                    // Đổi thành đã thuê
                    var sv = (from up in DataProvider.Ins.DB.SINHVIENs where up.IDSINHVIEN == SelectedID select up).Single();
                    sv.DATHUE = true;
                    DataProvider.Ins.DB.SaveChanges();
                    // thay đổi về lượng phòng trống của PHÒNG
                    var phong = (from up in DataProvider.Ins.DB.PHONGs where up.IDPHONG == IDPHONG select up).Single();
                    phong.SOLUONGNGUOI++;
                    phong.SOLUONGTRONG--;
                    DataProvider.Ins.DB.SaveChanges();
                    // thêm vào danh sách TIENPHONG
                    //kiểm tra đã tồn tại chưa //
                    //isExistInSVTIENTHUE = false;

                    //foreach ( var item in SV_TIENPHONGLIST)
                    //{
                    //    if (SelectedID == item.IDSINHVIEN)
                    //    {
                    //        isExistInSVTIENTHUE = true;
                    //        item.IDPHONG = IDPHONG;
                    //        break;
                    //    }    
                    //}
                    //foreach (var item in SV_TIENPHONGLIST)
                    //{
                    //    if (SelectedID == item.IDSINHVIEN)
                    //    {
                    //        isExistInSVTIENTHUE = true;
                    //        item.IDPHONG = IDPHONG;
                    //        break;
                    //    }
                    //}
                   // Thêm vào sv tiền phòng
                        DANHSACHSV_TIENPHONG svt = new DANHSACHSV_TIENPHONG();
                        svt.IDPHONG = IDPHONG;
                        svt.IDSINHVIEN = SelectedID;
                        svt.NGAYVAO = svp.NGAYVAO;
                        svt.DADONGBHTN = false;
                        svt.DADONGBHYT = false;
                        svt.DADONGTIENPHONG = false;
                        svt.TIENBHYT = 457380;
                        svt.TIENBHTN = 40000;
                        DataProvider.Ins.DB.DANHSACHSV_TIENPHONG.Add(svt);
                        svt.IDHOCKI = getIDHOCKI(svt.NGAYVAO);
                   
                   
                   
                    DataProvider.Ins.DB.SaveChanges();
                    // thêm vào BIENLAITHUEPHONG
                    ////check xem có sẵn chưa
                    //var check = (from up in DataProvider.Ins.DB.BIENLAITHUEPHONGs where up.IDSINHVIEN == SelectedID && up.IDPHONG == IDPHONG && up.IDHOCKI == getIDHOCKI(DateTime.Today.ToShortDateString()) select up);
                    //if (check.Count()== 0)
                    //// nếu đã tồn tại tạo mới hoàn toàn
                    //{
                    //    BIENLAITHUEPHONG bl = new BIENLAITHUEPHONG();
                    //    bl.IDSINHVIEN = SelectedID;
                    //    bl.IDPHONG = IDPHONG;
                    //    bl.TRANGTHAI = true;
                    //    bl.DADONGTIENPHONG = false;
                    //    var tempPHONG = (from up in PHONGLIST where up.IDPHONG == IDPHONG select up).Single();
                    //    // lấy tên tòa//
                    //    var tempTOA = (from up in DataProvider.Ins.DB.TOAs where up.IDTOA == tempPHONG.IDTOA select up).Single();
                    //    bl.TENNHAPHONG = tempTOA.TENTOA + " - " + tempPHONG.TENPHONG.ToString();
                    //    bl.LOAIPHONG = tempPHONG.LOAIPHONG;
                    //    bl.NGAYVAO = DateTime.Today.ToShortDateString();
                    //    bl.IDHOCKI = getIDHOCKI(DateTime.Today.ToShortDateString());
                    //    var HOCKI = (from up in HOCKILIST where up.IDHOCKI == bl.IDHOCKI select up).Single();
                    //    bl.TENHOCKI = HOCKI.TENHOCKI + "( " + HOCKI.TENNAMHOC + " )";
                    //    bl.NGAYTRAPHONG = null;
                    //    bl.GHICHU = null;
                    //    DataProvider.Ins.DB.BIENLAITHUEPHONGs.Add(bl);
                    //    DataProvider.Ins.DB.SaveChanges();
                    //    MessageBox.Show("Thêm thành công!");
                    //}
                    //// nếu đã tồn tại -> sửa thông tin
                    //else
                    //{
                        
                    //}
                   

                    // load list
                    HiringRoom hr = new HiringRoom();
                    var hrDT = hr.DataContext as HiringRoomViewModel;
                    hrDT.LoadListChuaThue();
                    hr.Close();

                    //load lai main
                    BuildingDiagram bd = new BuildingDiagram();
                    var bdDT = bd.DataContext as BuildingDiagramViewModel;
                    bdDT.LoadToa();
                    bd.Close();

                    // load main
                    MainWindow mw = new MainWindow();
                    var mwDT = mw.DataContext as MainViewModel;
                    mwDT.LoadStatis();
                    mwDT.LoadChartSV();
                    mw.Close();

                    //tắt window
                    ThisFrame.Close();
                }
                else MessageBox.Show("Sinh viên này đã tồn tại trong danh sách !");

            });

            RoomMemberCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                SelectedIDPhongList = (int)p;
                RoomMember rm = new RoomMember();
                var rmDT = rm.DataContext as RoomMemberViewModel;
                rmDT.LoadList(SelectedIDPhongList);
                rm.ShowDialog();
                rm.Close();
            });
        }
            public void LoadCbbTENTOA ()
        {
            
            SV_TIENPHONGLIST = new ObservableCollection<DANHSACHSV_TIENPHONG>(DataProvider.Ins.DB.DANHSACHSV_TIENPHONG);
            //NEWPHONGLIST2 = new IEnumerable<NewPhong>();
            TOALIST = new ObservableCollection<TOA>(DataProvider.Ins.DB.TOAs);
            PHONGLIST = new ObservableCollection<PHONG>(DataProvider.Ins.DB.PHONGs);
            SINHVIEN_PHONGLIST = new ObservableCollection<DANHSACHSV_PHONG>(DataProvider.Ins.DB.DANHSACHSV_PHONG);
            //lấy combobox Tòa //
            HiringRoom hr = new HiringRoom();
            var hrDT = hr.DataContext as HiringRoomViewModel;
            SelectedID = hrDT.SelectedID;
            hr.Close();

            SINHVIENLIST = new ObservableCollection<SINHVIEN>(DataProvider.Ins.DB.SINHVIENs);

            foreach (var item in SINHVIENLIST)
            {
                if (item.IDSINHVIEN == SelectedID)
                {
                    //GIOITINH = (bool)item.GIOITINH ? true : false;
                    GIOITINH = item.GIOITINH;


                }

            }
            TOALISTCBB = new ObservableCollection<string>();
            TOALIST2 = new ObservableCollection<TOA>(DataProvider.Ins.DB.TOAs.Where(x => x.TOANAM == GIOITINH));
            TOALISTCBB.Add("Tất cả");
            foreach (var item in TOALIST2)
            {
                TOALISTCBB.Add(item.TENTOA);
            }
            
            //het
            // mới vô load all
            // Data grid phép kết
            NEWPHONGLIST = TOALIST2.Join(
                     PHONGLIST,
                     b => b.IDTOA,
                     c => c.IDTOA,
                     (b, c) => new NewPhong()
                     {
                         TENTOA = b.TENTOA,
                         IDPHONG = c.IDPHONG,
                         LOAIPHONG = (int)c.LOAIPHONG,
                         TENPHONG = c.TENPHONG,
                         SOLUONGTRONG = (int)c.SOLUONGTRONG

                     }
                     );
            //NEWPHONGLIST = NEWPHONGLIST.Where(x => x.SOLUONGTRONG  !=0 );
            //foreach (var item in NEWPHONGLIST)
            //{
            //    bool isExist = false;
            //    foreach (var item2 in TOALIST2)
            //    {
            //        if (item.TENTOA == item2.TENTOA)
            //        {
            //            isExist = true;
            //            break;
            //        }
            //    }
            //    if (isExist == false)
            //    {
            //        NEWPHONGLIST = NEWPHONGLIST.Where(x => x.TENTOA != item.TENTOA);
            //        //TOALIST2 = (ObservableCollection<NewPhong>)NEWPHONGLIST;
            //    }
            //}
            // IEnumerable k thể bị biến đổi khi Where..Nên phải dùng kiểu khác để lưu lại 1 list phòng  dạng NEWPHONGLIST nhưng FULL Nam //
            // lúc kết ta cho kết vs mỗi tòa nam thôi//
            // Chọn tất cả vẫn không được 
            NEWPHONGLIST2 = NEWPHONGLIST;
            TENTOA = "Tất cả";
        }
        public  bool CheckNgay(string ngbd, string ngkt, string nght)
        {

            DateTime ngaybd = Convert.ToDateTime(ngbd);
            DateTime ngaykt = Convert.ToDateTime(ngkt);
            DateTime ngayht = Convert.ToDateTime(nght);
            TimeSpan check1 = ngayht - ngaybd;
            TimeSpan check2 = ngaykt - ngayht;
            if (check1.Days >= 0 && check2.Days >= 0)
                return true;
            else
                return false;

        }
        public  int getIDHOCKI(string Ngayvao)
        {
            HOCKILIST = new ObservableCollection<HOCKI>(DataProvider.Ins.DB.HOCKIs);
            foreach (HOCKI item in HOCKILIST)
            {
                if (CheckNgay(item.NGAYBATDAU, item.NGAYKETHUC, Ngayvao)) return item.IDHOCKI;
            }
            return 0;

        }



    }
}
 