using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;

namespace Nagybead
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //kattintott-e a felh már ilyen gombokra
        bool tipus;
        bool nem;

        bool[] választott; //[0]-->felső [1]-->nadrág [2]-->cipő
        string[] vál_ruhák; //[0]-->felső [1]-->nadrág [2]-->cipő
        int akt_választás; //hanyadik választott sort írja épp

        int n; // 1=ffi 2=női
        int tip; // 1=felső 2=nadrág 3=cipő
        string[] ffif; string[] noif; //képnevek
        string[] ffin; string[] noin;
        string[] ffic; string[] noic;

        Image[] imImages;
        Image[,] imVálasztottak; //jobboldali képek
        Button[] btnTorol;

        beadando.cnbeadando cn;
        
        private void initDB()
        {
            //cn = new beadando.cnbeadando();
            cn.Database.EnsureCreated();
            if (!cn.ruháks.Any())
            {
                foreach(var akt in ffif) 
                {
                    var sor = new beadando.ruhák { ruha = akt, jelleg = 1 };
                    cn.ruháks.Add(sor);
                }
                foreach (var akt in noif)
                {
                    var sor = new beadando.ruhák { ruha = akt, jelleg = 2 };
                    cn.ruháks.Add(sor);
                }
                foreach (var akt in ffin)
                {
                    var sor = new beadando.ruhák { ruha = akt, jelleg = 3 };
                    cn.ruháks.Add(sor);
                }
                foreach (var akt in noin)
                {
                    var sor = new beadando.ruhák { ruha = akt, jelleg = 4 };
                    cn.ruháks.Add(sor);
                }
                foreach (var akt in ffic)
                {
                    var sor = new beadando.ruhák { ruha = akt, jelleg = 5 };
                    cn.ruháks.Add(sor);
                }
                foreach (var akt in noic)
                {
                    var sor = new beadando.ruhák { ruha = akt, jelleg = 6 };
                    cn.ruháks.Add(sor);
                }
            }
            if (!cn.tipus.Any())
            {
                beadando.tipus sor;
                sor = new beadando.tipus { id = 1, nem = "ffi", típus = 1 }; cn.tipus.Add(sor);
                sor = new beadando.tipus { id = 2, nem = "noi", típus = 1 }; cn.tipus.Add(sor);
                sor = new beadando.tipus { id = 3, nem = "ffi", típus = 2 }; cn.tipus.Add(sor);
                sor = new beadando.tipus { id = 4, nem = "noi", típus = 2 }; cn.tipus.Add(sor);
                sor = new beadando.tipus { id = 5, nem = "ffi", típus = 3 }; cn.tipus.Add(sor);
                sor = new beadando.tipus { id = 6, nem = "noi", típus = 3 }; cn.tipus.Add(sor);
            }
            cn.választotts.RemoveRange(cn.választotts);
            cn.SaveChanges();
        }

        public MainWindow()
        {
            InitializeComponent();
            
            tipus = false; nem = false;
            n = -1; tip = -1;
            választott = new bool[3] { false, false, false };
            vál_ruhák = new string[3];
            akt_választás = 1;
            ffif = new string[]
            {
                "ffif1.jpg",
                "ffif2.jpg",
                "ffif3.jpg",
                "ffif4.jpg",
                "ffif5.jpg",
                "ffif6.jpg",
                "ffif7.jpg",
                "ffif8.jpg",
                "ffif9.jpg",
                "ffif10.jpg",
                "ffif11.jpg", 
                "ffif12.jpg"
            };
            ffin = new string[] { "ffin1.jpg", "ffin2.jpg", "ffin3.jpg", "ffin4.jpg", "ffin5.jpg", "ffin6.gif", 
                "ffin7.gif", "ffin8.gif", "ffin9.gif", "ffin10.gif", "ffin11.gif", "ffin12.gif" };
            ffic = new string[] {"ffc1.jpg", "ffc2.jpg", "ffc3.jpg", "ffc4.jpg", "ffc5.jpg", "ffc6.jpg",
                "ffc7.jpg", "ffc8.jpg", "ffc9.jpg", "ffc10.jpg", "ffc11.jpg", "ffc12.jpg" };
            noif = new string[] {"noif1.jpg", "noif2.jpg", "noif3.jpg", "noif4.jpg", "noif5.jpg", "noif6.jpg",
            "noif7.jpg", "noif8.jpg", "noif9.jpg", "noif10.jpg", "noif11.jpg", "noif12.jpg"};
            noin = new string[] {"noin1.jpg", "noin2.jpg", "noin3.jpg", "noin4.jpg", "noin5.jpg", "noin6.jpg",
            "noin7.gif", "noin8.gif", "noin9.gif","noin10.gif", "noin11.gif", "noin12.gif"};
            noic = new string[] {"noic1.jpg", "noic2.jpg", "noic3.jpg", "noic4.jpg", "noic5.jpg", "noic6.jpg",
            "noic7.jpg", "noic8.jpg", "noic9.jpg", "noic10.jpg", "noic11.jpg", "noic12.jpg"};

            imImages = new Image[12]
            { im10, im11, im12, im13,
              im20, im21, im22, im23,
              im30, im31, im32, im33};
            imVálasztottak = new Image[3, 3]
            {
                {v1f, v1n, v1c },
                {v2f, v2n, v2c },
                {v3f, v3n, v3c }
            };
            btnTorol =new Button[]{ btntorol1,btntorol2,btntorol3};
            cn = new beadando.cnbeadando();
            initDB();
;        }

       

        private void btnoi_Click(object sender, RoutedEventArgs e)
        {
            n = 2;
            nem = true;
            if (nem && tipus) frissit();
        }

        private void btcipo_Click(object sender, RoutedEventArgs e)
        {
            tip = 3;
            tipus = true;
            if (nem && tipus) frissit();
        }

        private void btnadrag_Click(object sender, RoutedEventArgs e)
        {
            tip = 2;
            tipus = true;
            if (nem && tipus) frissit();
        }

        private void btfelso_Click(object sender, RoutedEventArgs e)
        {
            tip = 1;
            tipus = true;
            if (nem && tipus) frissit();
        }

        private void btferfi_Click(object sender, RoutedEventArgs e)
        {
            n = 1;
            nem = true;
            if (nem && tipus) frissit();
        }

        private void frissit() //a választékot (nagy képeket) frissíti
        {
            int i = 0;
            if (n == 2) //női
            {
                if (tip == 1) //felső
                {   //betölt
                    foreach(var akt in cn.ruháks.Where(a => a.jelleg==2).ToList())
                    {
                        imImages[i++].Source = new BitmapImage(new Uri(@"noif/" + akt.ruha, UriKind.Relative));
                    }
                    
                }
                if (tip == 2) //nadrág
                {
                    foreach (var akt in cn.ruháks.Where(a => a.jelleg == 4).ToList())
                    {
                        imImages[i++].Source = new BitmapImage(new Uri(@"noin/" + akt.ruha, UriKind.Relative));
                    }
                }
                if (tip == 3) //cipő
                {
                    foreach (var akt in cn.ruháks.Where(a => a.jelleg == 6).ToList())
                    {
                        imImages[i++].Source = new BitmapImage(new Uri(@"noic/" + akt.ruha, UriKind.Relative));
                    }
                }

            }
            else if(n==1) //férfi
            {
                if (tip == 1) //felső
                {
                    foreach (var akt in cn.ruháks.Where(a => a.jelleg == 1).ToList())
                    {
                        imImages[i++].Source = new BitmapImage(new Uri(@"ferfif/" + akt.ruha, UriKind.Relative));
                    }

                }
                if (tip == 2) //nadrág
                {
                    foreach (var akt in cn.ruháks.Where(a => a.jelleg == 3).ToList())
                    {
                        imImages[i++].Source = new BitmapImage(new Uri(@"ferfin/" + akt.ruha, UriKind.Relative));
                    }
                }
                if (tip == 3) //cipő
                {
                    foreach (var akt in cn.ruháks.Where(a => a.jelleg == 5).ToList())
                    {
                        imImages[i++].Source = new BitmapImage(new Uri(@"ferfic/" + akt.ruha, UriKind.Relative));
                    }
                }
            }
        }


        //amikor képet választ a felhasználó
        private void katt(object sender, MouseButtonEventArgs e)
        {
            if (cn.választotts.Count() > 2)
            {
                MessageBox.Show("Új összeállítás hozzáadásához törölj egy meglévőt", "Hiba", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            Image selectedImage = sender as Image;
            string képnév;
            //bool[] eredeti = választott; //ha betelik a 3 sor, a catch-ben vissza tudjuk állítani
            if (n == 1)//férfi
            {
                switch (tip)
                {
                    case 1:
                        imVálasztottak[akt_választás - 1,0].Source = selectedImage.Source;
                        //képnév = "ffif";
                        választott[0] = true;
                        break;
                    case 2:
                        imVálasztottak[akt_választás - 1, 1].Source = selectedImage.Source;
                        //képnév = "ffin";
                        választott[1] = true;
                        break;
                    case 3:
                        imVálasztottak[akt_választás - 1, 2].Source = selectedImage.Source;
                        //képnév = "ffc";
                        választott[2] = true;
                        break;
                }
            }
            else if(n==2)//női
            {
                switch (tip)
                {
                    case 1:
                        imVálasztottak[akt_választás - 1, 0].Source = selectedImage.Source;
                        //képnév = "noif";
                        választott[0] = true;
                        break;
                    case 2:
                        imVálasztottak[akt_választás - 1, 1].Source = selectedImage.Source;
                        //képnév = "noin";
                        választott[1] = true;
                        break;
                    case 3:
                        imVálasztottak[akt_választás - 1, 2].Source = selectedImage.Source;
                        //képnév = "noic";
                        választott[2] = true;
                        break;
                }
            }
            
            
            képnév = selectedImage.Source.ToString();
            string[] reszek = képnév.Split("/");
            képnév = reszek[reszek.Length - 1];
            
            MessageBox.Show(képnév, "Ruha kiválasztva", MessageBoxButton.OK, MessageBoxImage.Information);
            vál_ruhák[tip - 1] = képnév;
            //ha kész egy sor baloldalt (egy összeállítás)
            if (választott[0] && választott[1] && választott[2])
            {
                btnTorol[akt_választás-1].Visibility = Visibility.Visible;
                try { 
                        cn.választotts.Add(new beadando.választott { id = akt_választás, felső = vál_ruhák[0], nadrág = vál_ruhák[1], cipő = vál_ruhák[2] });
                        cn.SaveChanges();
                }
                catch {
                    MessageBox.Show("Új összeállítás hozzáadásához törölj egy meglévőt", "Hiba", MessageBoxButton.OK, MessageBoxImage.Warning);
                    választott[0] = false; választott[1] = false; választott[2] = false;
                    return;
                }
                MessageBox.Show("Ezt az outfitet állítottad össze:\n"+cn.választotts.Find(akt_választás).felső+"\n"+cn.választotts.Find(akt_választás).nadrág + "\n"+ cn.választotts.Find(akt_választás).cipő, "Siker", MessageBoxButton.OK, MessageBoxImage.Information);
                if(akt_választás<3)akt_választás++;
                választott[0] = false; választott[1] = false; választott[2] = false;
            }
        }

        private void btntorol_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            //hanyadik sort akarja törölni; ez ugyanaz mint az id a választott táblában
            int sor = Convert.ToInt32(b.Name.Split("l")[1]); //mert btntorol és az l után van a száma
            MessageBox.Show("A(z) " + sor + ". összeállítás lesz törölve", "Törlés...", MessageBoxButton.OK);
            cn.választotts.Remove(cn.választotts.Find(sor));

            switch (sor)
            {
                case 1:
                    v1f.Source = null; v1n.Source = null; v1c.Source = null;
                    btntorol1.Visibility = Visibility.Hidden;
                    break;
                case 2:
                    v2f.Source = null; v2n.Source = null; v2c.Source = null;
                    btntorol2.Visibility = Visibility.Hidden;
                    break;
                case 3:
                    v3f.Source = null; v3n.Source = null; v3c.Source = null;
                    btntorol3.Visibility = Visibility.Hidden;
                    break;
            }

            cn.SaveChanges();
            MessageBox.Show("A(z) " + sor + ". összeállítás törölve", "Törlés történt", MessageBoxButton.OK);

            akt_választás = sor;
        }

        ~MainWindow()
        {
            cn.választotts.RemoveRange(cn.választotts);
            cn.SaveChanges();
        }
    }
}
