using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;
using static System.Net.Mime.MediaTypeNames;

namespace rpg
{
    /// <summary>
    /// Page1.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Page1 : Page
    {
        private int att = 15;
        private int minhp = 0;
        private int maxhp = 100;
        private int count = 0;
        private int bossle = 1;
        private int num = 1;
        private int hpnum = 0;
        private int sleepco = 0;
        public Page1()
        {
            InitializeComponent();

            hpnum = (int)hp.Maximum;
            level.Text = bossle.ToString();
            attack.Text = att.ToString();
            if(count == 0)
            {
                tebl.Text = hp.Value + "/100(" + hp.Value + "%)";
            }
            hp.Minimum = minhp;
            hp.Maximum = maxhp;
            images.Source = new BitmapImage(new Uri("pack://application:,,,/img/몬스터1.png"));
        }
        void timeDelay02(int tDelaySecond)
        {
            DateTime dtStart = DateTime.Now;
            TimeSpan firstTime = new TimeSpan(DateTime.Now.Ticks);


            while (firstTime.Ticks + (tDelaySecond * 10000000) >= DateTime.Now.Ticks)
            {
                TimeSpan elapsedSpan = new TimeSpan(DateTime.Now.Ticks - firstTime.Ticks);
                
                this.Dispatcher.Invoke((ThreadStart)(() => { }), DispatcherPriority.Input);
            }
        }

        private void vi()
        {
            if(num > 3)
            {
                num = 1;
            }
            for(int i = 1; i<100; i++)
            {
                if(num == i)
                {
                    images.Source = new BitmapImage(new Uri("pack://application:,,,/img/몬스터"+i+".png"));
                }
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            count += 1;
            Random rand = new Random();
            int a = rand.Next(0, 10);
            Random ran4 = new Random();
            int d = ran4.Next(240, 490);
            Random ran5 = new Random();
            int j = ran5.Next(101, 256);
            Random ran6 = new Random();
            int h = ran6.Next(0, 2);
            string[] arr = new string[] { "금상자", "나무상자1", "동상자", "상자" };
            if (a > 2)
            {
                damagesc.Visibility = Visibility.Visible;
                if (h == 0)
                {
                    damagesc.Source = new BitmapImage(new Uri("pack://application:,,,/img/칼19.png"));
                    damage1.Margin = new Thickness { Left = d, Right = 16, Top = j, Bottom = 109 };
                    damage1.Text = att.ToString();
                }
                else
                {
                    damagesc.Source = new BitmapImage(new Uri("pack://application:,,,/img/칼20.png"));
                    damage1.Margin = new Thickness { Left = d, Right = 16, Top = j, Bottom = 109 };
                    damage1.Text = att.ToString();
                }
                this.Dispatcher.Invoke((ThreadStart)(() => { }), DispatcherPriority.ApplicationIdle);
                Thread.Sleep(500);
                damagesc.Visibility = Visibility.Hidden;
                damage1.Text = "";
                
                hpnum -= att;
                hp.Value = Math.Round(hpnum / hp.Maximum * hp.Maximum);
                double nu = Math.Round(hpnum / hp.Maximum * 100);
                tebl.Text = hpnum +"/"+ hp.Maximum +"("+nu+"%)";
                if(hp.Value == 0)
                {
                    Random im = new Random();
                    int m = im.Next(0, 4);
                    if (arr[m].Equals("나무상자1"))
                    {
                        images.Source = new BitmapImage(new Uri("pack://application:,,,/img/"+arr[m]+".jpg"));

                    }
                    else
                    {
                        images.Source = new BitmapImage(new Uri("pack://application:,,,/img/"+arr[m]+".png"));
                    }
                    damage1.Visibility = Visibility.Hidden;
                    level.Visibility = Visibility.Hidden;
                    qq.Visibility = Visibility.Hidden;
                    damage1.Text = "";
                    fight.Visibility = Visibility.Hidden;
                    hp.Visibility = Visibility.Hidden;
                    tebl.Visibility = Visibility.Hidden;

                    this.Dispatcher.Invoke((ThreadStart)(() => { }), DispatcherPriority.ApplicationIdle);
                    Thread.Sleep(1000);
                    open.Visibility = Visibility.Visible;
                }
            }
            else
            {
                damage1.Text = "miss";
                damage1.Margin = new Thickness { Left = d, Right = 16, Top = j, Bottom = 109 };
                this.Dispatcher.Invoke((ThreadStart)(() => { }), DispatcherPriority.ApplicationIdle);
                Thread.Sleep(500);
                damage1.Text = "";

            }
        }
        private void next1()
        {
            bossle += 1;
            num += 1;
            maxhp += 100;
        }
        private void sleep1()
        {
            Random ran = new Random();
            int a = ran.Next(1000, 3500);
            next1();
            hp.Maximum = maxhp;
            timeDelay02(2);
            con.Visibility = Visibility.Hidden;
            open.Visibility = Visibility.Hidden;
            images.Visibility = Visibility.Hidden;
            attack.Visibility = Visibility.Hidden;
            tex.Visibility = Visibility.Hidden;
            while (true)
            {
                search.Visibility = Visibility.Visible;
                this.Dispatcher.Invoke((ThreadStart)(() => { }), DispatcherPriority.ApplicationIdle);
                Thread.Sleep(500);
                sleepco += 500;
                if(sleepco >= a)
                {
                    mons();
                    search.Visibility = Visibility.Hidden;
                    dot1.Visibility = Visibility.Hidden;
                    dot2.Visibility = Visibility.Hidden;
                    dot3.Visibility = Visibility.Hidden;
                    sleepco = 0;
                    break;
                }
                dot1.Visibility = Visibility.Visible;
                dot3.Visibility = Visibility.Hidden;
                this.Dispatcher.Invoke((ThreadStart)(() => { }), DispatcherPriority.ApplicationIdle);
                Thread.Sleep(500);
                sleepco += 500;
                if (sleepco >= a)
                {
                    mons();
                    search.Visibility = Visibility.Hidden;
                    dot1.Visibility = Visibility.Hidden;
                    dot2.Visibility = Visibility.Hidden;
                    dot3.Visibility = Visibility.Hidden;
                    sleepco = 0;
                    break;
                }
                dot2.Visibility = Visibility.Visible;
                dot1.Visibility = Visibility.Hidden;
                this.Dispatcher.Invoke((ThreadStart)(() => { }), DispatcherPriority.ApplicationIdle);
                Thread.Sleep(500);
                sleepco += 500;
                if (sleepco >= a)
                {
                    mons();
                    search.Visibility = Visibility.Hidden;
                    dot1.Visibility = Visibility.Hidden;
                    dot2.Visibility = Visibility.Hidden;
                    dot3.Visibility = Visibility.Hidden;
                    sleepco = 0;
                    break;
                }
                dot3.Visibility = Visibility.Visible;
                dot2.Visibility = Visibility.Hidden;
            }
            timeDelay02(a);
        }
        private void mons()
        {
            images.Visibility = Visibility.Visible;
            tex.Visibility = Visibility.Visible;
            attack.Visibility = Visibility.Visible;
            vi();
            hp.Visibility = Visibility.Visible;
            tebl.Visibility = Visibility.Visible;
            damage1.Visibility = Visibility.Visible;
            qq.Visibility = Visibility.Visible;
            level.Visibility = Visibility.Visible;
            fight.Visibility = Visibility.Visible;
            level.Text = bossle.ToString();
            attack.Text = att.ToString();
            hpnum = (int)hp.Maximum;
            hp.Value = Math.Round(hpnum / hp.Maximum * hp.Maximum);
            double nu = Math.Round(hpnum / hp.Maximum * 100);
            tebl.Text = hpnum + "/" + hp.Maximum + "(" + nu + "%)";
        }
        private void open_Click(object sender, RoutedEventArgs e)
        {
            con.Visibility = Visibility.Visible;
            Random ran10 = new Random();
            int at = ran10.Next(0, 7);
            switch (at)
            {
                case 0:
                    con.Text = "꽝입니다";
                    sleep1();
                    break;
                case 1:
                case 2:
                case 3:
                    con.Text = "공격력이 4 증가하였습니다";
                    att += 4;
                    sleep1();
                    break;
                case 4:
                case 5:
                    con.Text = "공격력이 8 증가하였습니다";
                    att += 8;
                    sleep1();
                    break;
                case 6:
                    con.Text = "공격력이 15 증가하였습니다";
                    att += 15;
                    sleep1();
                    break;
            }
        }
    }
}
