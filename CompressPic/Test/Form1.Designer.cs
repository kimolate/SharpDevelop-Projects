/*
 * 由SharpDevelop创建。
 * 用户： ki
 * 日期: 2016/5/9
 * 时间: 23:42
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
namespace CompressPic
{
    partial class Form1
    {
        /// <summary>
        /// Designer variable used to keep track of non-visual components.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Disposes resources used by the form.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// This method is required for Windows Forms designer support.
        /// Do not change the method contents inside the source code editor. The Forms designer might
        /// not be able to load this method if it was changed manually.
        /// </summary>
        private void InitializeComponent()
        {
            this.CompressBn = new System.Windows.Forms.Button();
            this.ComprePathTB = new System.Windows.Forms.TextBox();
            this.ComprePatnLb = new System.Windows.Forms.Label();
            this.SavePatnLb = new System.Windows.Forms.Label();
            this.SavePathTB = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // CompressBn
            // 
            this.CompressBn.Location = new System.Drawing.Point(197, 13);
            this.CompressBn.Name = "CompressBn";
            this.CompressBn.Size = new System.Drawing.Size(75, 23);
            this.CompressBn.TabIndex = 0;
            this.CompressBn.Text = "压缩";
            this.CompressBn.UseVisualStyleBackColor = true;
            this.CompressBn.Click += new System.EventHandler(this.Button1Click);
            // 
            // ComprePathTB
            // 
            this.ComprePathTB.Location = new System.Drawing.Point(91, 15);
            this.ComprePathTB.Name = "ComprePathTB";
            this.ComprePathTB.Size = new System.Drawing.Size(100, 21);
            this.ComprePathTB.TabIndex = 1;
            // 
            // ComprePatnLb
            // 
            this.ComprePatnLb.Location = new System.Drawing.Point(13, 18);
            this.ComprePatnLb.Name = "ComprePatnLb";
            this.ComprePatnLb.Size = new System.Drawing.Size(72, 18);
            this.ComprePatnLb.TabIndex = 2;
            this.ComprePatnLb.Text = "压缩路径：";
            // 
            // SavePatnLb
            // 
            this.SavePatnLb.Location = new System.Drawing.Point(13, 40);
            this.SavePatnLb.Name = "SavePatnLb";
            this.SavePatnLb.Size = new System.Drawing.Size(72, 17);
            this.SavePatnLb.TabIndex = 3;
            this.SavePatnLb.Text = "存储路径：";
            // 
            // SavePathTB
            // 
            this.SavePathTB.Location = new System.Drawing.Point(91, 37);
            this.SavePathTB.Name = "SavePathTB";
            this.SavePathTB.Size = new System.Drawing.Size(99, 21);
            this.SavePathTB.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.SavePathTB);
            this.Controls.Add(this.SavePatnLb);
            this.Controls.Add(this.ComprePatnLb);
            this.Controls.Add(this.ComprePathTB);
            this.Controls.Add(this.CompressBn);
            this.Name = "Form1";
            this.Text = "每隔100图片压缩";
            this.Load += new System.EventHandler(this.Form1Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        private System.Windows.Forms.TextBox SavePathTB;
        private System.Windows.Forms.Label SavePatnLb;
        private System.Windows.Forms.Label ComprePatnLb;
        private System.Windows.Forms.TextBox ComprePathTB;
        private System.Windows.Forms.Button CompressBn;
    }
}
