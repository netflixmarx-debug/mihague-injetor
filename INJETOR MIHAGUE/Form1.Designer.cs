using System;
using System.Drawing;
 
namespace INJETOR_MIHAGUE
{  
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose(); 
            base.Dispose(disposing);
        } 

        #region Codigo gerado pelo Windows Form Designer

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.panelHeader    = new System.Windows.Forms.Panel();
            this.lblTitle       = new System.Windows.Forms.Label();
            this.panelSep       = new System.Windows.Forms.Panel();
            this.panelContent   = new System.Windows.Forms.Panel();
            this.panelBottomSep = new System.Windows.Forms.Panel();
            this.panelBottom    = new System.Windows.Forms.Panel();
            this.status         = new System.Windows.Forms.Label();
            this.lblVersion     = new System.Windows.Forms.Label();

            this.lblSectionPlayer = new System.Windows.Forms.Label();

            this.lblRow1    = new System.Windows.Forms.Label();
            this.lblRow1Sub = new System.Windows.Forms.Label();
            this.toggle1    = new Guna.UI2.WinForms.Guna2ToggleSwitch();
            this.panelDiv1  = new System.Windows.Forms.Panel();

            this.btnTabEye      = new Guna.UI2.WinForms.Guna2Button();
            this.btnTabSettings = new Guna.UI2.WinForms.Guna2Button();

            this.panelHeader.SuspendLayout();
            this.panelContent.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();

            // ── BorderlessForm ───────────────────────────────────────────────
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;

            // ── panelHeader ──────────────────────────────────────────────────
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(18, 18, 18);
            this.panelHeader.Location  = new System.Drawing.Point(0, 0);
            this.panelHeader.Name      = "panelHeader";
            this.panelHeader.Size      = new System.Drawing.Size(340, 52);
            this.panelHeader.TabIndex  = 0;
            this.panelHeader.Controls.Add(this.lblTitle);

            // ── lblTitle — "BigZin Store" 3D paint ──────────────────────────
            this.lblTitle.BackColor  = System.Drawing.Color.FromArgb(18, 18, 18);
            this.lblTitle.Font       = new System.Drawing.Font("Arial Black", 15F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor  = System.Drawing.Color.White;
            this.lblTitle.Text       = "";
            this.lblTitle.TextAlign  = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitle.Dock       = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Name       = "lblTitle";
            this.lblTitle.TabIndex   = 0;
            this.lblTitle.Paint     += new System.Windows.Forms.PaintEventHandler(this.lblTitle_Paint);

            // ── panelSep ─────────────────────────────────────────────────────
            this.panelSep.BackColor = System.Drawing.Color.FromArgb(180, 0, 0);
            this.panelSep.Location  = new System.Drawing.Point(0, 52);
            this.panelSep.Name      = "panelSep";
            this.panelSep.Size      = new System.Drawing.Size(340, 2);
            this.panelSep.TabIndex  = 1;

            // ── panelContent ─────────────────────────────────────────────────
            this.panelContent.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
            this.panelContent.Location  = new System.Drawing.Point(0, 54);
            this.panelContent.Name      = "panelContent";
            this.panelContent.Size      = new System.Drawing.Size(340, 100);
            this.panelContent.TabIndex  = 2;

            // ── lblSectionPlayer ─────────────────────────────────────────────
            this.lblSectionPlayer.BackColor  = System.Drawing.Color.FromArgb(30, 30, 30);
            this.lblSectionPlayer.Font       = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSectionPlayer.ForeColor  = System.Drawing.Color.FromArgb(170, 170, 170);
            this.lblSectionPlayer.Location   = new System.Drawing.Point(0, 0);
            this.lblSectionPlayer.Name       = "lblSectionPlayer";
            this.lblSectionPlayer.Size       = new System.Drawing.Size(340, 30);
            this.lblSectionPlayer.TabIndex   = 0;
            this.lblSectionPlayer.Text       = "   Player ESP";
            this.lblSectionPlayer.TextAlign  = System.Drawing.ContentAlignment.MiddleLeft;

            // ── ROW 1 ────────────────────────────────────────────────────────
            this.lblRow1.BackColor  = System.Drawing.Color.Transparent;
            this.lblRow1.Font       = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblRow1.ForeColor  = System.Drawing.Color.White;
            this.lblRow1.Location   = new System.Drawing.Point(14, 38);
            this.lblRow1.Name       = "lblRow1";
            this.lblRow1.Size       = new System.Drawing.Size(260, 18);
            this.lblRow1.TabIndex   = 10;
            this.lblRow1.Text       = "Enable ESP Line";

            this.lblRow1Sub.BackColor = System.Drawing.Color.Transparent;
            this.lblRow1Sub.Font      = new System.Drawing.Font("Segoe UI", 7.5F);
            this.lblRow1Sub.ForeColor = System.Drawing.Color.FromArgb(110, 110, 110);
            this.lblRow1Sub.Location  = new System.Drawing.Point(14, 58);
            this.lblRow1Sub.Name      = "lblRow1Sub";
            this.lblRow1Sub.Size      = new System.Drawing.Size(260, 16);
            this.lblRow1Sub.TabIndex  = 11;
            this.lblRow1Sub.Text      = "Injeta a DLL no emulador ativo";

            this.toggle1.BackColor = System.Drawing.Color.Transparent;
            this.toggle1.CheckedState.BorderColor      = System.Drawing.Color.FromArgb(200, 0, 0);
            this.toggle1.CheckedState.FillColor        = System.Drawing.Color.FromArgb(180, 0, 0);
            this.toggle1.CheckedState.InnerBorderColor = System.Drawing.Color.White;
            this.toggle1.CheckedState.InnerColor       = System.Drawing.Color.White;
            this.toggle1.UncheckedState.BorderColor    = System.Drawing.Color.FromArgb(60, 60, 60);
            this.toggle1.UncheckedState.FillColor      = System.Drawing.Color.FromArgb(40, 40, 40);
            this.toggle1.UncheckedState.InnerBorderColor = System.Drawing.Color.FromArgb(90, 90, 90);
            this.toggle1.UncheckedState.InnerColor     = System.Drawing.Color.FromArgb(90, 90, 90);
            this.toggle1.Location       = new System.Drawing.Point(292, 47);
            this.toggle1.Name           = "toggle1";
            this.toggle1.Size           = new System.Drawing.Size(40, 20);
            this.toggle1.TabIndex       = 12;
            this.toggle1.CheckedChanged += new System.EventHandler(this.toggle1_CheckedChanged);

            this.panelDiv1.BackColor = System.Drawing.Color.FromArgb(38, 38, 38);
            this.panelDiv1.Location  = new System.Drawing.Point(0, 86);
            this.panelDiv1.Name      = "panelDiv1";
            this.panelDiv1.Size      = new System.Drawing.Size(340, 1);
            this.panelDiv1.TabIndex  = 13;

            // ── Adiciona controles ao panelContent ───────────────────────────
            this.panelContent.Controls.Add(this.lblSectionPlayer);
            this.panelContent.Controls.Add(this.lblRow1);
            this.panelContent.Controls.Add(this.lblRow1Sub);
            this.panelContent.Controls.Add(this.toggle1);
            this.panelContent.Controls.Add(this.panelDiv1);

            // ── panelBottomSep ───────────────────────────────────────────────
            this.panelBottomSep.BackColor = System.Drawing.Color.FromArgb(180, 0, 0);
            this.panelBottomSep.Location  = new System.Drawing.Point(0, 154);
            this.panelBottomSep.Name      = "panelBottomSep";
            this.panelBottomSep.Size      = new System.Drawing.Size(340, 2);
            this.panelBottomSep.TabIndex  = 3;

            // ── panelBottom ──────────────────────────────────────────────────
            this.panelBottom.BackColor = System.Drawing.Color.FromArgb(18, 18, 18);
            this.panelBottom.Controls.Add(this.btnTabEye);
            this.panelBottom.Controls.Add(this.btnTabSettings);
            this.panelBottom.Location  = new System.Drawing.Point(0, 156);
            this.panelBottom.Name      = "panelBottom";
            this.panelBottom.Size      = new System.Drawing.Size(340, 50);
            this.panelBottom.TabIndex  = 4;

            // ── btnTabEye ────────────────────────────────────────────────────
            this.btnTabEye.FillColor            = System.Drawing.Color.FromArgb(180, 0, 0);
            this.btnTabEye.BorderRadius         = 0;
            this.btnTabEye.BorderThickness      = 0;
            this.btnTabEye.Font                 = new System.Drawing.Font("Segoe UI", 16F);
            this.btnTabEye.ForeColor            = System.Drawing.Color.White;
            this.btnTabEye.HoverState.FillColor = System.Drawing.Color.FromArgb(210, 20, 20);
            this.btnTabEye.Location             = new System.Drawing.Point(0, 0);
            this.btnTabEye.Name                 = "btnTabEye";
            this.btnTabEye.Size                 = new System.Drawing.Size(170, 50);
            this.btnTabEye.TabIndex             = 0;
            this.btnTabEye.Text                 = "o";

            // ── btnTabSettings ───────────────────────────────────────────────
            this.btnTabSettings.FillColor            = System.Drawing.Color.FromArgb(30, 30, 30);
            this.btnTabSettings.BorderRadius         = 0;
            this.btnTabSettings.BorderThickness      = 0;
            this.btnTabSettings.Font                 = new System.Drawing.Font("Segoe UI", 16F);
            this.btnTabSettings.ForeColor            = System.Drawing.Color.FromArgb(180, 180, 180);
            this.btnTabSettings.HoverState.FillColor = System.Drawing.Color.FromArgb(50, 50, 50);
            this.btnTabSettings.Location             = new System.Drawing.Point(170, 0);
            this.btnTabSettings.Name                 = "btnTabSettings";
            this.btnTabSettings.Size                 = new System.Drawing.Size(170, 50);
            this.btnTabSettings.TabIndex             = 1;
            this.btnTabSettings.Text                 = "#";

            // ── status ───────────────────────────────────────────────────────
            this.status.BackColor  = System.Drawing.Color.FromArgb(22, 22, 22);
            this.status.Font       = new System.Drawing.Font("Segoe UI", 8F);
            this.status.ForeColor  = System.Drawing.Color.FromArgb(160, 160, 160);
            this.status.Location   = new System.Drawing.Point(0, 206);
            this.status.Name       = "status";
            this.status.Size       = new System.Drawing.Size(220, 20);
            this.status.TabIndex   = 5;
            this.status.Text       = "  Aguardando...";
            this.status.TextAlign  = System.Drawing.ContentAlignment.MiddleLeft;

            // ── lblVersion ───────────────────────────────────────────────────
            this.lblVersion.BackColor  = System.Drawing.Color.FromArgb(22, 22, 22);
            this.lblVersion.Font       = new System.Drawing.Font("Segoe UI", 7.5F);
            this.lblVersion.ForeColor  = System.Drawing.Color.FromArgb(80, 80, 80);
            this.lblVersion.Location   = new System.Drawing.Point(220, 206);
            this.lblVersion.Name       = "lblVersion";
            this.lblVersion.Size       = new System.Drawing.Size(120, 20);
            this.lblVersion.TabIndex   = 6;
            this.lblVersion.Text       = "v1.0.1";
            this.lblVersion.TextAlign  = System.Drawing.ContentAlignment.MiddleRight;

            // ── Form1 ────────────────────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor           = System.Drawing.Color.FromArgb(22, 22, 22);
            this.ClientSize          = new System.Drawing.Size(340, 226);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.panelSep);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelBottomSep);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.status);
            this.Controls.Add(this.lblVersion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name            = "Form1";
            this.Text            = "MIHAGUE INJECTOR";
            this.StartPosition   = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load  += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);

            this.panelHeader.ResumeLayout(false);
            this.panelContent.ResumeLayout(false);
            this.panelBottom.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private void Form1_Load(object sender, EventArgs e) { }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm  guna2BorderlessForm1;
        private System.Windows.Forms.Panel             panelHeader;
        private System.Windows.Forms.Label             lblTitle;
        private System.Windows.Forms.Panel             panelSep;
        private System.Windows.Forms.Panel             panelContent;
        private System.Windows.Forms.Label             lblSectionPlayer;
        private System.Windows.Forms.Label             lblRow1;
        private System.Windows.Forms.Label             lblRow1Sub;
        private Guna.UI2.WinForms.Guna2ToggleSwitch    toggle1;
        private System.Windows.Forms.Panel             panelDiv1;
        private System.Windows.Forms.Panel             panelBottomSep;
        private System.Windows.Forms.Panel             panelBottom;
        private Guna.UI2.WinForms.Guna2Button          btnTabEye;
        private Guna.UI2.WinForms.Guna2Button          btnTabSettings;
        private System.Windows.Forms.Label             status;
        private System.Windows.Forms.Label             lblVersion;
    }
}
