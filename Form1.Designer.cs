using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Threading;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace basichack
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.checkUstalost = new System.Windows.Forms.CheckBox();
            this.checkOtdacha = new System.Windows.Forms.CheckBox();
            this.checkTrava = new System.Windows.Forms.CheckBox();
            this.viewDist = new System.Windows.Forms.TextBox();
            this.repair = new System.Windows.Forms.Button();
            this.refuel = new System.Windows.Forms.Button();
            this.visible = new System.Windows.Forms.Button();
            this.reammo = new System.Windows.Forms.Button();
            this.checkNvg = new System.Windows.Forms.CheckBox();
            this.copyright = new System.Windows.Forms.Label();
            this.build = new System.Windows.Forms.Label();
            this.checkThermal = new System.Windows.Forms.CheckBox();
            this.refTick = new System.Windows.Forms.CheckBox();
            this.refTimer = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // checkUstalost
            // 
            this.checkUstalost.AutoSize = true;
            this.checkUstalost.Location = new System.Drawing.Point(991, 44);
            this.checkUstalost.Name = "checkUstalost";
            this.checkUstalost.Size = new System.Drawing.Size(99, 17);
            this.checkUstalost.TabIndex = 0;
            this.checkUstalost.Text = "Нет усталости";
            this.checkUstalost.UseVisualStyleBackColor = true;
            this.checkUstalost.CheckedChanged += new System.EventHandler(this.checkUstalost_CheckedChanged);
            // 
            // checkOtdacha
            // 
            this.checkOtdacha.AutoSize = true;
            this.checkOtdacha.Location = new System.Drawing.Point(991, 67);
            this.checkOtdacha.Name = "checkOtdacha";
            this.checkOtdacha.Size = new System.Drawing.Size(82, 17);
            this.checkOtdacha.TabIndex = 1;
            this.checkOtdacha.Text = "Нет отдачи";
            this.checkOtdacha.UseVisualStyleBackColor = true;
            this.checkOtdacha.CheckedChanged += new System.EventHandler(this.checkOtdacha_CheckedChanged);
            // 
            // checkTrava
            // 
            this.checkTrava.AutoSize = true;
            this.checkTrava.Location = new System.Drawing.Point(991, 90);
            this.checkTrava.Name = "checkTrava";
            this.checkTrava.Size = new System.Drawing.Size(79, 17);
            this.checkTrava.TabIndex = 2;
            this.checkTrava.Text = "Нет травы";
            this.checkTrava.UseVisualStyleBackColor = true;
            this.checkTrava.CheckedChanged += new System.EventHandler(this.checkTrava_CheckedChanged);
            // 
            // viewDist
            // 
            this.viewDist.Location = new System.Drawing.Point(1093, 36);
            this.viewDist.Name = "viewDist";
            this.viewDist.Size = new System.Drawing.Size(100, 20);
            this.viewDist.TabIndex = 3;
            // 
            // repair
            // 
            this.repair.Location = new System.Drawing.Point(1092, 167);
            this.repair.Name = "repair";
            this.repair.Size = new System.Drawing.Size(99, 23);
            this.repair.TabIndex = 4;
            this.repair.Text = "Починка";
            this.repair.UseVisualStyleBackColor = true;
            this.repair.Click += new System.EventHandler(this.button1_Click);
            // 
            // refuel
            // 
            this.refuel.Location = new System.Drawing.Point(1092, 138);
            this.refuel.Name = "refuel";
            this.refuel.Size = new System.Drawing.Size(100, 23);
            this.refuel.TabIndex = 5;
            this.refuel.Text = "Заправка";
            this.refuel.UseVisualStyleBackColor = true;
            this.refuel.Click += new System.EventHandler(this.button2_Click);
            // 
            // visible
            // 
            this.visible.Location = new System.Drawing.Point(1092, 62);
            this.visible.Name = "visible";
            this.visible.Size = new System.Drawing.Size(101, 41);
            this.visible.TabIndex = 6;
            this.visible.Text = "Уст. дальность";
            this.visible.UseVisualStyleBackColor = true;
            this.visible.Click += new System.EventHandler(this.button3_Click);
            // 
            // reammo
            // 
            this.reammo.Location = new System.Drawing.Point(1092, 109);
            this.reammo.Name = "reammo";
            this.reammo.Size = new System.Drawing.Size(101, 23);
            this.reammo.TabIndex = 7;
            this.reammo.Text = "Патроны";
            this.reammo.UseVisualStyleBackColor = true;
            this.reammo.Click += new System.EventHandler(this.button4_Click);
            // 
            // checkNvg
            // 
            this.checkNvg.Location = new System.Drawing.Point(991, 109);
            this.checkNvg.Name = "checkNvg";
            this.checkNvg.Size = new System.Drawing.Size(99, 34);
            this.checkNvg.TabIndex = 0;
            this.checkNvg.Text = "Включить NVG (Буква N)";
            this.checkNvg.UseVisualStyleBackColor = true;
            this.checkNvg.CheckedChanged += new System.EventHandler(this.checkNvg_CheckedChanged);
            // 
            // copyright
            // 
            this.copyright.AutoSize = true;
            this.copyright.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.copyright.Location = new System.Drawing.Point(1096, 199);
            this.copyright.Name = "copyright";
            this.copyright.Size = new System.Drawing.Size(86, 15);
            this.copyright.TabIndex = 8;
            this.copyright.Text = "Селяша-чит ©";
            // 
            // build
            // 
            this.build.AutoSize = true;
            this.build.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.build.Location = new System.Drawing.Point(987, 214);
            this.build.Name = "build";
            this.build.Size = new System.Drawing.Size(204, 15);
            this.build.TabIndex = 9;
            this.build.Text = "build 0.0.7 (добавлена карта)";
            // 
            // checkThermal
            // 
            this.checkThermal.AutoSize = true;
            this.checkThermal.Location = new System.Drawing.Point(991, 149);
            this.checkThermal.Name = "checkThermal";
            this.checkThermal.Size = new System.Drawing.Size(100, 17);
            this.checkThermal.TabIndex = 10;
            this.checkThermal.Text = "Включить ТВП";
            this.checkThermal.UseVisualStyleBackColor = true;
            this.checkThermal.CheckedChanged += new System.EventHandler(this.checkThermal_CheckedChanged);
            // 
            // refTick
            // 
            this.refTick.AutoSize = true;
            this.refTick.Location = new System.Drawing.Point(1050, 12);
            this.refTick.Name = "refTick";
            this.refTick.Size = new System.Drawing.Size(63, 17);
            this.refTick.TabIndex = 11;
            this.refTick.Text = "Refresh";
            this.refTick.UseVisualStyleBackColor = true;
            this.refTick.CheckedChanged += new System.EventHandler(this.refTick_CheckedChanged);
            // 
            // refTimer
            // 
            this.refTimer.Location = new System.Drawing.Point(1119, 10);
            this.refTimer.Name = "refTimer";
            this.refTimer.Size = new System.Drawing.Size(35, 20);
            this.refTimer.TabIndex = 12;
            this.refTimer.Text = "100";
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Location = new System.Drawing.Point(1166, 9);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(25, 13);
            this.textBox1.TabIndex = 13;
            this.textBox1.Text = "ms";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1205, 821);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.refTimer);
            this.Controls.Add(this.refTick);
            this.Controls.Add(this.checkThermal);
            this.Controls.Add(this.build);
            this.Controls.Add(this.copyright);
            this.Controls.Add(this.checkNvg);
            this.Controls.Add(this.reammo);
            this.Controls.Add(this.visible);
            this.Controls.Add(this.refuel);
            this.Controls.Add(this.repair);
            this.Controls.Add(this.viewDist);
            this.Controls.Add(this.checkTrava);
            this.Controls.Add(this.checkOtdacha);
            this.Controls.Add(this.checkUstalost);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Basic";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkUstalost;
        private System.Windows.Forms.CheckBox checkOtdacha;
        private System.Windows.Forms.CheckBox checkTrava;
        private System.Windows.Forms.TextBox viewDist;
        private System.Windows.Forms.Button repair;
        private System.Windows.Forms.Button refuel;
        private System.Windows.Forms.Button visible;
        private System.Windows.Forms.Button reammo;
        private System.Windows.Forms.CheckBox checkNvg;
        private System.Windows.Forms.Label copyright;
        private System.Windows.Forms.Label build;
        private System.Windows.Forms.CheckBox checkThermal;
        private CheckBox refTick;
        private TextBox refTimer;
        private TextBox textBox1;
    }
}

