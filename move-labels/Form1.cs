using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace move_labels
{
    public partial class Form1 : Form
    {
        int vx = rand.Next(50);
        int vy = rand.Next(50);
        int iTime = 0;
        private static Random rand = new Random();

        public Form1()
        {
            InitializeComponent();

            // vx,vyに乱数を求める
            vx = rand.Next(-20,50);
            vy = rand.Next(-20,50);
            // ラベルのLeftとTopに乱数を入れる
            label1.Left = rand.Next(ClientSize.Width - label1.Width);
            label1.Top = rand.Next(ClientSize.Height - label1.Height);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            iTime++;
            label5.Text = "" + iTime;

            // 2次元クラスPoint型の変数cposを宣言
            Point cpos;

            // cposに、マウスのフォーム座標を取り出す。
            //// MousePositionにマウス座標のスクリーン左上からのX、Yが入っている。
            //// PointToClient()を使うと、スクリーン座標を、フォーム座標に変換できる。
            cpos = PointToClient(MousePosition);

            // ラベルに座標を表示
            //// 変換したフォーム座標は、cpos.X、cpos.Yで取り出せる。
            label2.Text = "" + cpos.X + "," + cpos.Y;
            label3.Text = "" + MousePosition.X + "," + MousePosition.Y;

            //新しく作ったラベルをマウスカーソルの場所に移動
            //それができたら、マウスカーソルがそのラベルの中心を指すようにする
            label4.Left = cpos.X-label4.Width/2;
            label4.Top = cpos.Y-label4.Height/2;
            


            if((label1.Left < cpos.X) && (label1.Top < cpos.Y) &&
                (label1.Right > cpos.X) && (label1.Bottom > cpos.Y)){
                    timer1.Enabled = false;
                    //vx = 0;
                    //vy = 0;
                    label1.Text = "(・ω・)";
                    //label1.visible = false;
            }


            label1.Left += vx;
            label1.Top += vy;

            if(label1.Left<=0)
            {
                vx = Math.Abs(vx);
            }
            if(label1.Left > ClientSize.Width-label1.Width)
            {
                vx = -Math.Abs(vx);
               
            }

            if(label1.Top<=0)
            {
                vy = Math.Abs(vy);
            }
            if(label1.Top > ClientSize.Height-label1.Height)
            {
                vy = -Math.Abs(vy);
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 0以上、intの範囲内の乱数
            Text = "" + rand.Next();
            // さいころの目の例(実用ではないが、知識として知っておくこと)
            Text += "," + ((rand.Next() % 6) + 1);

            // 0以上、指定の値「未満」の乱数
            // 以下は、0～5までの乱数
            Text += "/" + rand.Next(6);

            // 指定の値以上、指定の値「未満」の乱数
            // 以下は、1～6までも乱数
            Text += "/" + rand.Next(1, 7);

            // Oから1未満の乱数
            Text += "/" + rand.NextDouble();
            // NextDoubleを使って、1～6の乱数を算出するには？
            // NextDouble()の最小値=0
            // NextDouble()の最大値=0.999999・・・
            Text += "/" + (int)(rand.NextDouble() * 6 + 1);
        }
    }
}
