
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace CLOTHESAPP
{
    partial class VIBOR
    {
        string connectionstring = "Data Source=UBER-MASHINA;Initial Catalog=APPDB;Integrated Security=True";
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // VIBOR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 436);
            this.Name = "VIBOR";
            this.Text = "VIBOR";
            this.ResumeLayout(false);

        }

        #endregion
    }
}