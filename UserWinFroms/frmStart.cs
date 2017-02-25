using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserWinFroms
{
    public partial class frmStart : Form
    {
        private Boolean isShowing = true;//是否正在显示

        public frmStart()
        {
            InitializeComponent();

            this.Opacity = 0.0;//完全透明

            this.fadeTimer.Start();//启动定时器
        }

        /// <summary>
        /// 定时器触发事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fadeTimer_Tick(object sender, EventArgs e)
        {
            const double step = 0.1;

            if (isShowing)
            {
                if (Opacity + step >= 1.0)
                {
                    fadeTimer.Stop();
                    Opacity = 1.0;
                }
                else
                {
                    Opacity += step;
                }
            }
            else
            {
                if (Opacity - step <= 0.0)
                {
                    Opacity = 0.0;
                    fadeTimer.Stop();
                }
                else
                {
                    Opacity -= step;
                }
            }
        }

        /// <summary>
        /// 按钮触发事件
        /// 启动调试器 并创建回调关闭主线程委托
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnApollo_Click(object sender, EventArgs e)
        {
            this.Visible = false;;

            Action callback = () => {
                this.Close();
            };

            new frmMain(callback).Show();
        }
    }
}
