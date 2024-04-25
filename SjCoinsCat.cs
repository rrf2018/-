using _03调用大漠插件;
using CShapDM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SjCoins撸猫
{

    public partial class SjCoinsCat : Form
    {

        static bool bfirst = true;

        static bool brun = true;

        CDmSoft dm = new CDmSoft();

        List<string> lcats = new List<string>();
        public SjCoinsCat()
        {
            InitializeComponent();
        }


        private void UpdateLogAsync(string text)
        {
            Console.WriteLine(text);
            //// 使用Invoke方法来确保在UI线程中更新RichTextBox
            //if (this.InvokeRequired)
            //{
            //    // 如果当前线程不是创建richTextBox1的线程（UI线程），则使用Invoke
            //    this.Invoke(new Action(() => rb.AppendText(text + Environment.NewLine)));
            //}
            //else
            //{
            //    // 如果已经在UI线程中，直接更新
            //    rb.AppendText(text + Environment.NewLine);
            //}
        }
        #region 绑定句柄
        private void button1_Click(object sender, EventArgs e)
        {

            ExtCore gxb = new ExtCore();


            int winNum = gxb.GetAllDesktopWindows();

            if (winNum == 0)
            {
                MessageBox.Show("游戏没有找到,确认是否已打开！", "Error");
                return;
            }

            int dm_ret = dm.BindWindow(winNum, "normal", "normal", "normal", 0);


            if (dm_ret == 1)
            {
                //button1.Enabled = false;
                if(bfirst==false)
                {
                    brun = true;
                }
            }
            else
            {
                if (bfirst == false)
                {
                    brun = false;
                }
                MessageBox.Show("绑定失败!");
                return;
            }

            if(bfirst)
            {
                bfirst = false;
                Task.Run(() =>
                {
                   

                    do
                    {
                        if (dm.WaitKey(18, 0) + dm.WaitKey(66, 0) == 2)
                        {
                            brun = !brun;

                            if (brun == false)
                            {
                                UpdateLogAsync($"暂停撸猫");
                            }
                            else
                            {
                                UpdateLogAsync($"继续撸猫");
                            }

                        }
                        Application.DoEvents();
                        Thread.Sleep(500);

                    } while (1 == 1);

                });


                btnPic_Click(null, null);
            }
            
        }
        #endregion

        #region 打字
        private void btnType_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region 找图
        bool formSearch = true;
        bool bshop = false;
        private void btnPic_Click(object sender, EventArgs e)
        {

            brun = true;
            int icat = 0;

            bool bfree = true;
            do
            {
                try
                {

                    Thread.Sleep(500);

                    if (brun == false)
                    {
                        //UpdateLogAsync($"brun为false");
                        Application.DoEvents();
                        Thread.Sleep(500);
                        continue;
                    }
                    else
                    {
                        //UpdateLogAsync("新的轮回开启");
                    }
                    object intX, intY;

                    int dm_ret = dm.FindPic(0, 0, 2000, 2000, @"C:\Users\Administrator\Pictures\LuckClick.bmp", "000000", 0.8, 0, out intX, out intY);
                    if (dm_ret != 0)
                    {

                    }
                    else
                    {
                        UpdateLogAsync($"1min");
                        dm.MoveTo((int)intX, (int)intY);
                        Thread.Sleep(500);
                        dm.LeftClick();
                    }

                    dm_ret = dm.FindPic(0, 0, 2000, 2000, @"C:\Users\Administrator\Pictures\ShopYm.bmp", "000000", 0.8, 0, out intX, out intY);
                    if (dm_ret != 0)
                    {
                        bshop = false;
                    }
                    else
                    {
                        UpdateLogAsync($"Shop页面");
                        bshop = true;
                    }



                    dm_ret = dm.FindPic(0, 0, 2000, 2000, @"C:\Users\Administrator\Pictures\4cats.bmp", "000000", 0.8, 0, out intX, out intY);
                    if (dm_ret != 0)
                    {
                        //UpdateLogAsync($"没有发现绿蛙");
                    }
                    else
                    {
                        UpdateLogAsync($"找到小黄鸭+4按钮");
                        dm.MoveTo((int)intX, (int)intY);
                        Thread.Sleep(100);
                        dm.LeftClick();
                        Thread.Sleep(500);
                    }

                    dm_ret = dm.FindPic(0, 0, 2000, 2000, @"C:\Users\Administrator\Pictures\close.bmp", "000000", 0.8, 0, out intX, out intY);
                    if (dm_ret != 0)
                    {

                    }
                    else
                    {
                        UpdateLogAsync($"找到关闭");
                        dm.MoveTo((int)intX, (int)intY);
                        Thread.Sleep(500);
                        dm.LeftClick();
                    }
                    #region 黄鸭

                    dm_ret = dm.FindPic(0, 0, 2000, 2000, @"C:\Users\Administrator\Pictures\黄鸭.bmp", "000000", 0.9, 0, out intX, out intY);
                    if (dm_ret != 0)
                    {
                        //UpdateLogAsync($"没有发现小黄鸭");
                    }
                    else
                    {
                        UpdateLogAsync($"找到小黄鸭,天降4猫");
                        dm.MoveTo((int)intX, (int)intY);
                        Thread.Sleep(100);
                        dm.LeftClick();
                        Thread.Sleep(500);
                        dm_ret = dm.FindPic(0, 0, 2000, 2000, @"C:\Users\Administrator\Pictures\LuckClick.bmp", "000000", 0.8, 0, out intX, out intY);
                        if (dm_ret != 0)
                        {
                            //UpdateLogAsync($"没有发现绿蛙");
                        }
                        else
                        {
                            UpdateLogAsync($"找到小黄鸭1min按钮");
                            dm.MoveTo((int)intX, (int)intY);
                            Thread.Sleep(100);
                            dm.LeftClick();
                            Thread.Sleep(500);
                        }

                        dm_ret = dm.FindPic(0, 0, 2000, 2000, @"C:\Users\Administrator\Pictures\4cats.bmp", "000000", 0.8, 0, out intX, out intY);
                        if (dm_ret != 0)
                        {
                            //UpdateLogAsync($"没有发现绿蛙");
                        }
                        else
                        {
                            UpdateLogAsync($"找到小黄鸭+4按钮");
                            dm.MoveTo((int)intX, (int)intY);
                            Thread.Sleep(100);
                            dm.LeftClick();
                            Thread.Sleep(500);
                        }
                        //dm.LeftClick();
                    }
                    #region 小狗
                    dm_ret = dm.FindPic(0, 0, 2000, 2000, @"C:\Users\Administrator\Pictures\小狗.bmp", "000000", 0.9, 0, out intX, out intY);
                    if (dm_ret != 0)
                    {
                        //UpdateLogAsync($"没有发现小黄鸭");
                    }
                    else
                    {
                        UpdateLogAsync($"找到小狗");
                        dm.MoveTo((int)intX, (int)intY);
                        Thread.Sleep(100);
                        dm.LeftClick();
                        Thread.Sleep(500);
                        dm_ret = dm.FindPic(0, 0, 2000, 2000, @"C:\Users\Administrator\Pictures\LuckClick.bmp", "000000", 0.8, 0, out intX, out intY);
                        if (dm_ret != 0)
                        {
                            //UpdateLogAsync($"没有发现绿蛙");
                        }
                        else
                        {
                            UpdateLogAsync($"找到小狗1min按钮");
                            dm.MoveTo((int)intX, (int)intY);
                            Thread.Sleep(100);
                            dm.LeftClick();
                            Thread.Sleep(500);
                        }

                        dm_ret = dm.FindPic(0, 0, 2000, 2000, @"C:\Users\Administrator\Pictures\4cats.bmp", "000000", 0.8, 0, out intX, out intY);
                        if (dm_ret != 0)
                        {

                        }
                        else
                        {
                            UpdateLogAsync($"找到小狗+4按钮");
                            dm.MoveTo((int)intX, (int)intY);
                            Thread.Sleep(100);
                            dm.LeftClick();
                            Thread.Sleep(500);
                        }
                        //dm.LeftClick();
                    }

                    #endregion

                    dm_ret = dm.FindPic(0, 0, 2000, 2000, @"C:\Users\Administrator\Pictures\绿蛙.bmp", "000000", 0.9, 0, out intX, out intY);
                    if (dm_ret != 0)
                    {
                        //UpdateLogAsync($"没有发现绿蛙");
                    }
                    else
                    {
                        UpdateLogAsync($"找到绿蛙");
                        dm.MoveTo((int)intX, (int)intY);
                        Thread.Sleep(100);
                        dm.LeftClick();
                        Thread.Sleep(500);

                        dm_ret = dm.FindPic(0, 0, 2000, 2000, @"C:\Users\Administrator\Pictures\LuckClick.bmp", "000000", 0.8, 0, out intX, out intY);
                        if (dm_ret != 0)
                        {
                            //UpdateLogAsync($"没有发现绿蛙");
                        }
                        else
                        {
                            UpdateLogAsync($"找到绿蛙1min按钮");
                            dm.MoveTo((int)intX, (int)intY);
                            Thread.Sleep(100);
                            dm.LeftClick();
                            Thread.Sleep(500);
                        }

                    }
                    #endregion

                    #region 检查是否有免费猫              

                    bfree = !bfree;
                    if (bfree)
                    {
                        dm_ret = dm.FindPic(0, 0, 2000, 2000, @"C:\Users\Administrator\Pictures\feed.bmp", "000000", 0.58, 0, out intX, out intY);
                        if (dm_ret != 0)
                        {
                            //UpdateLogAsync($"没有找到feed免费猫了");
                        }
                        else
                        {
                            dm.MoveTo((int)intX, (int)intY);
                            dm.LeftClick();
                            //UpdateLogAsync($"找到feed免费猫了");

                            Thread.Sleep(1000);
                            dm_ret = dm.FindPic(0, 0, 2000, 2000, @"C:\Users\Administrator\Pictures\free.bmp", "000000", 0.8, 0, out intX, out intY);
                            if (dm_ret != 0)
                            {
                                //UpdateLogAsync($"没有找到免费按钮");
                                Thread.Sleep(500);
                            }
                            else
                            {
                                Thread.Sleep(500);
                                dm.MoveTo((int)intX, (int)intY);
                                dm.LeftClick();

                                dm_ret = dm.FindPic(0, 0, 2000, 2000, @"C:\Users\Administrator\Pictures\close.bmp", "000000", 0.8, 0, out intX, out intY);
                                if (dm_ret != 0)
                                {

                                }
                                else
                                {
                                    UpdateLogAsync($"找到关闭");
                                    dm.MoveTo((int)intX, (int)intY);
                                    Thread.Sleep(500);
                                    dm.LeftClick();
                                }
                            }

                        }

                    }
                    #endregion

                    if (bshop)
                    {
                        dm_ret = dm.FindPic(0, 0, 2000, 2000, @"C:\Users\Administrator\Pictures\close.bmp", "000000", 0.8, 0, out intX, out intY);
                        if (dm_ret != 0)
                        {

                        }
                        else
                        {
                            UpdateLogAsync($"找到关闭");
                            dm.MoveTo((int)intX, (int)intY);
                            Thread.Sleep(500);
                            dm.LeftClick();
                        }
                    }

                    dm_ret = dm.FindPic(0, 0, 2000, 2000, @"C:\Users\Administrator\Pictures\1.bmp", "000000", 0.58, 0, out intX, out intY);
                    //int dm_ret = dm.FindPic(0, 0, 2000, 2000, @"C:\Users\Administrator\Pictures\merge.bmp", "000000", 0.58, 0, out intX, out intY);
                    if (dm_ret != 0)
                    {
                        //UpdateLogAsync($"找不到猫，准备读以前找到过的猫的位置");
                        try
                        {
                            if(lcats.Count==0)
                            {
                                UpdateLogAsync($"没有找到合猫记录，左上角的猫拖放到别的地方，作为空降猫的位置，alt+a暂停撸猫，参考软件使用说明");
                            }
                            foreach (string scat in lcats)
                            {
                                if (brun == false) break;

                                //UpdateLogAsync($"{scat} 坐标找猫");

                                intX = int.Parse(scat.Split('|')[0]);
                                intY = int.Parse(scat.Split('|')[1]);

                                dm.MoveTo((int)intX, (int)intY);
                                dm.LeftDown();
                                Thread.Sleep(500);
                                //UpdateLogAsync($"找到了{intX}  {intY}");

                                dm_ret = dm.FindPic(0, 0, 2000, 2000, @"C:\Users\Administrator\Pictures\merge.bmp", "000000", 0.58, 0, out intX, out intY);
                                if (dm_ret != 0)
                                {
                                    dm.LeftUp();
                                    //UpdateLogAsync($"没找到需要合成的猫");

                                }
                                else
                                {
                                    dm.MoveTo((int)intX, (int)intY);
                                    string tmpscat = $"{intX}|{intY}";
                                    bool badd = false;
                                    foreach (string cat in lcats)
                                    {
                                        //UpdateLogAsync($"{cat} 坐标找猫");

                                        int xx = int.Parse(scat.Split('|')[0]);
                                        int yy = int.Parse(scat.Split('|')[1]);
                                        if (Math.Abs((int)intX - xx) >= 20)
                                        {
                                            badd = true;
                                        }
                                        else if (Math.Abs((int)intY - yy) >= 20)
                                        {
                                            badd = true;
                                        }
                                        else
                                        {
                                            badd = false;
                                            break;
                                        }
                                    }
                                    if (badd && !lcats.Contains(tmpscat))
                                    {
                                        lcats.Add(tmpscat);
                                    }

                                    dm.LeftUp();
                                    icat++;

                                    UpdateLogAsync($"合成的猫的次数：{icat}    位置：{intX}  {intY}");
                                    Thread.Sleep(200);

                                }
                            }
                        }
                        catch
                        {

                        }

                    }
                    else
                    {
                        //UpdateLogAsync($"找到");
                        //continue;
                        dm.MoveTo((int)intX, (int)intY);
                        dm.LeftDown();
                        //UpdateLogAsync($"找到了{intX}  {intY}");
                        Thread.Sleep(100);
                        dm_ret = dm.FindPic(0, 0, 2000, 2000, @"C:\Users\Administrator\Pictures\merge.bmp", "000000", 0.58, 0, out intX, out intY);
                        if (dm_ret != 0)
                        {
                            dm.LeftUp();
                            //UpdateLogAsync($"没找到需要合成的猫");
                            try
                            {
                                if (lcats.Count == 0)
                                {
                                    UpdateLogAsync($"没有找到合猫记录，左上角的猫拖放到别的地方，作为空降猫的位置，alt+a暂停撸猫，参考软件使用说明");
                                }
                                //UpdateLogAsync($"找不到猫，准备读以前找到过的猫的位置");
                                foreach (string scat in lcats)
                                {
                                    if (brun == false) break;
                                    //UpdateLogAsync($"{scat} 坐标找猫");

                                    intX = int.Parse(scat.Split('|')[0]);
                                    intY = int.Parse(scat.Split('|')[1]);

                                    dm.MoveTo((int)intX, (int)intY);
                                    dm.LeftDown();
                                    Thread.Sleep(200);
                                    //UpdateLogAsync($"找到了{intX}  {intY}");

                                    dm_ret = dm.FindPic(0, 0, 2000, 2000, @"C:\Users\Administrator\Pictures\merge.bmp", "000000", 0.58, 0, out intX, out intY);
                                    if (dm_ret != 0)
                                    {
                                        dm.LeftUp();
                                        //UpdateLogAsync($"没找到需要合成的猫");

                                    }
                                    else
                                    {
                                        dm.MoveTo((int)intX, (int)intY);
                                        string tmpscat = $"{intX}|{intY}";
                                        bool badd = false;
                                        foreach (string cat in lcats)
                                        {
                                            // UpdateLogAsync($"{cat} 坐标找猫");

                                            int xx = int.Parse(scat.Split('|')[0]);
                                            int yy = int.Parse(scat.Split('|')[1]);
                                            if (Math.Abs((int)intX - xx) >= 20)
                                            {
                                                badd = true;
                                            }
                                            else if (Math.Abs((int)intY - yy) >= 20)
                                            {
                                                badd = true;
                                            }
                                            else
                                            {
                                                badd = false;
                                                break;
                                            }
                                        }
                                        if (badd && !lcats.Contains(tmpscat))
                                        {
                                            lcats.Add(tmpscat);
                                        }

                                        dm.LeftUp();
                                        icat++;
                                        //dm.LeftDown();
                                        UpdateLogAsync($"合成的猫的次数：{icat}    位置：{intX}  {intY}");
                                        Thread.Sleep(200);

                                    }
                                }
                            }
                            catch
                            {

                            }


                        }
                        else
                        {
                            dm.MoveTo((int)intX, (int)intY);
                            string scat = $"{intX}|{intY}";
                            if (!lcats.Contains(scat))
                            {
                                lcats.Add(scat);
                            }
                            dm.LeftUp();
                            icat++;
                            //dm.LeftDown();
                            UpdateLogAsync($"合成的猫的次数：{icat}    位置：{intX}  {intY}");

                        }
                        //string msg = String.Format("已发现！坐标是：{0},{1}", intX, intY);
                        //MessageBox.Show(msg);

                    }
                    //string ss = dm.FindPicEx(0, 0, 2000, 2000, @"C:\Users\Administrator\Pictures\1.bmp", "000000", 0.8, 0);
                    // MessageBox.Show(ss);
                }
                catch
                {
                 
                    button1.Enabled = true;
                   
                    MessageBox.Show("出现错误，请确认游戏是否已打开！", "提示");
                    break;
                }

            } while (1 == 1);



            //}

        }
        #endregion

        #region 找字
        bool formFont = true;
        private void btnWord_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region 截图
        private void btnScreenshot_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region 功能说明
        private void btnHelp_Click(object sender, EventArgs e)
        {

        }
        #endregion

        private void SjCoinsCat_Load(object sender, EventArgs e)
        {
            rb.AppendText($"开始撸猫------tg群：https://t.me/vsysmeme\r\n网站：https://www.sjcoins.com\r\n撸猫软件仅支持电脑端使用\r\n");
            rb.AppendText($"软件使用方法：\r\n1）首先打开TG电脑端的cat游戏\r\n2）首次运行的时候，需要手动将等级最高的猫放在右下角，\r\n左上角从左到右放等级最低的猫,最好空置\r\n");
            rb.AppendText("3.点击【开始撸猫】按钮，运行软件\r\n");
            rb.AppendText("提示：Alt+B 快捷键用来暂停撸猫和继续撸猫");
        }

        private void bt_start_Click(object sender, EventArgs e)
        {
            Process.Start("https://t.me/catizenbot/gameapp?startapp=r_1510_1532578");
        }
    }
}
