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
            this.components           = new System.ComponentModel.Container();
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.panelHeader          = new System.Windows.Forms.Panel();
            this.panelAccent          = new System.Windows.Forms.Panel();
            this.panelContent         = new System.Windows.Forms.Panel();
            this.lblSectionPlayer     = new System.Windows.Forms.Label();
            this.panelSectionBar      = new System.Windows.Forms.Panel();
            this.lblRow1              = new System.Windows.Forms.Label();
            this.lblRow1Sub           = new System.Windows.Forms.Label();
            this.toggle1              = new Guna.UI2.WinForms.Guna2ToggleSwitch();
            this.panelDiv1            = new System.Windows.Forms.Panel();
            this.panelButtons         = new System.Windows.Forms.Panel();
            this.btnTabDiscord        = new Guna.UI2.WinForms.Guna2Button();
            this.btnTabYoutube        = new Guna.UI2.WinForms.Guna2Button();
            this.panelStatusBar       = new System.Windows.Forms.Panel();
            this.status               = new System.Windows.Forms.Label();
            this.lblVersion           = new System.Windows.Forms.Label();

            this.panelContent.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.panelStatusBar.SuspendLayout();
            this.SuspendLayout();

            // ── BorderlessForm ───────────────────────────────────────────────
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;

            // ── panelHeader — sem filhos, pintado pelo evento Paint ──────────
            this.panelHeader.BackColor = Color.FromArgb(10, 12, 16);
            this.panelHeader.Location  = new Point(0, 0);
            this.panelHeader.Name      = "panelHeader";
            this.panelHeader.Size      = new Size(360, 68);
            this.panelHeader.TabIndex  = 0;
            this.panelHeader.Paint    += new System.Windows.Forms.PaintEventHandler(this.panelHeader_Paint);

            // ── Linha ciano sob o header ─────────────────────────────────────
            this.panelAccent.BackColor = Color.FromArgb(0, 200, 200);
            this.panelAccent.Location  = new Point(0, 68);
            this.panelAccent.Name      = "panelAccent";
            this.panelAccent.Size      = new Size(360, 2);
            this.panelAccent.TabIndex  = 1;

            // ── panelContent — área principal ────────────────────────────────
            this.panelContent.BackColor = Color.FromArgb(22, 25, 32);
            this.panelContent.Location  = new Point(0, 70);
            this.panelContent.Name      = "panelContent";
            this.panelContent.Size      = new Size(360, 112);
            this.panelContent.TabIndex  = 2;

            // Cabeçalho da seção
            this.lblSectionPlayer.BackColor = Color.FromArgb(16, 18, 24);
            this.lblSectionPlayer.Font      = new Font("Segoe UI", 8F, FontStyle.Bold);
            this.lblSectionPlayer.ForeColor = Color.FromArgb(0, 200, 200);
            this.lblSectionPlayer.Location  = new Point(0, 0);
            this.lblSectionPlayer.Name      = "lblSectionPlayer";
            this.lblSectionPlayer.Size      = new Size(360, 26);
            this.lblSectionPlayer.TabIndex  = 0;
            this.lblSectionPlayer.Text      = "   ◈  PAINEL MIHAGUE MODS";
            this.lblSectionPlayer.TextAlign = ContentAlignment.MiddleLeft;

            // Barra vertical ciano na seção
            this.panelSectionBar.BackColor = Color.FromArgb(0, 200, 200);
            this.panelSectionBar.Location  = new Point(0, 0);
            this.panelSectionBar.Name      = "panelSectionBar";
            this.panelSectionBar.Size      = new Size(3, 26);
            this.panelSectionBar.TabIndex  = 1;

            // Linha Enable Painel
            this.lblRow1.BackColor = Color.Transparent;
            this.lblRow1.Font      = new Font("Segoe UI", 10F);
            this.lblRow1.ForeColor = Color.FromArgb(230, 230, 230);
            this.lblRow1.Location  = new Point(18, 38);
            this.lblRow1.Name      = "lblRow1";
            this.lblRow1.Size      = new Size(240, 20);
            this.lblRow1.TabIndex  = 10;
            this.lblRow1.Text      = "Enable Painel";

            this.lblRow1Sub.BackColor = Color.Transparent;
            this.lblRow1Sub.Font      = new Font("Segoe UI", 7.5F);
            this.lblRow1Sub.ForeColor = Color.FromArgb(90, 95, 110);
            this.lblRow1Sub.Location  = new Point(18, 60);
            this.lblRow1Sub.Name      = "lblRow1Sub";
            this.lblRow1Sub.Size      = new Size(260, 16);
            this.lblRow1Sub.TabIndex  = 11;
            this.lblRow1Sub.Text      = "Injeta a DLL no emulador ativo";

            // Toggle ciano
            this.toggle1.BackColor = Color.Transparent;
            this.toggle1.CheckedState.BorderColor      = Color.FromArgb(0, 180, 180);
            this.toggle1.CheckedState.FillColor        = Color.FromArgb(0, 200, 200);
            this.toggle1.CheckedState.InnerBorderColor = Color.White;
            this.toggle1.CheckedState.InnerColor       = Color.White;
            this.toggle1.UncheckedState.BorderColor    = Color.FromArgb(50, 55, 68);
            this.toggle1.UncheckedState.FillColor      = Color.FromArgb(32, 36, 46);
            this.toggle1.UncheckedState.InnerBorderColor = Color.FromArgb(80, 85, 100);
            this.toggle1.UncheckedState.InnerColor     = Color.FromArgb(80, 85, 100);
            this.toggle1.Location       = new Point(308, 50);
            this.toggle1.Name           = "toggle1";
            this.toggle1.Size           = new Size(40, 20);
            this.toggle1.TabIndex       = 12;
            this.toggle1.CheckedChanged += new System.EventHandler(this.toggle1_CheckedChanged);

            // Divisor
            this.panelDiv1.BackColor = Color.FromArgb(32, 36, 46);
            this.panelDiv1.Location  = new Point(0, 94);
            this.panelDiv1.Name      = "panelDiv1";
            this.panelDiv1.Size      = new Size(360, 1);
            this.panelDiv1.TabIndex  = 13;

            this.panelContent.Controls.Add(this.lblSectionPlayer);
            this.panelContent.Controls.Add(this.panelSectionBar);
            this.panelContent.Controls.Add(this.lblRow1);
            this.panelContent.Controls.Add(this.lblRow1Sub);
            this.panelContent.Controls.Add(this.toggle1);
            this.panelContent.Controls.Add(this.panelDiv1);

            // ── panelButtons — Discord / YouTube ─────────────────────────────
            this.panelButtons.BackColor = Color.FromArgb(10, 12, 16);
            this.panelButtons.Controls.Add(this.btnTabDiscord);
            this.panelButtons.Controls.Add(this.btnTabYoutube);
            this.panelButtons.Location  = new Point(0, 182);
            this.panelButtons.Name      = "panelButtons";
            this.panelButtons.Size      = new Size(360, 52);
            this.panelButtons.TabIndex  = 3;

            this.btnTabDiscord.FillColor            = Color.FromArgb(88, 101, 242);
            this.btnTabDiscord.BorderRadius         = 6;
            this.btnTabDiscord.BorderThickness      = 0;
            this.btnTabDiscord.Font                 = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.btnTabDiscord.ForeColor            = Color.White;
            this.btnTabDiscord.HoverState.FillColor = Color.FromArgb(110, 122, 255);
            this.btnTabDiscord.Location             = new Point(10, 8);
            this.btnTabDiscord.Name                 = "btnTabDiscord";
            this.btnTabDiscord.Size                 = new Size(163, 36);
            this.btnTabDiscord.TabIndex             = 0;
            this.btnTabDiscord.Text                 = "Discord";
            this.btnTabDiscord.Click               += new System.EventHandler(this.btnTabDiscord_Click);

            this.btnTabYoutube.FillColor            = Color.FromArgb(200, 30, 30);
            this.btnTabYoutube.BorderRadius         = 6;
            this.btnTabYoutube.BorderThickness      = 0;
            this.btnTabYoutube.Font                 = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.btnTabYoutube.ForeColor            = Color.White;
            this.btnTabYoutube.HoverState.FillColor = Color.FromArgb(230, 50, 50);
            this.btnTabYoutube.Location             = new Point(187, 8);
            this.btnTabYoutube.Name                 = "btnTabYoutube";
            this.btnTabYoutube.Size                 = new Size(163, 36);
            this.btnTabYoutube.TabIndex             = 1;
            this.btnTabYoutube.Text                 = "YouTube";
            this.btnTabYoutube.Click               += new System.EventHandler(this.btnTabYoutube_Click);

            // ── panelStatusBar — rodapé ──────────────────────────────────────
            this.panelStatusBar.BackColor = Color.FromArgb(10, 12, 16);
            this.panelStatusBar.Controls.Add(this.status);
            this.panelStatusBar.Controls.Add(this.lblVersion);
            this.panelStatusBar.Location  = new Point(0, 234);
            this.panelStatusBar.Name      = "panelStatusBar";
            this.panelStatusBar.Size      = new Size(360, 26);
            this.panelStatusBar.TabIndex  = 4;

            this.status.BackColor  = Color.Transparent;
            this.status.Font       = new Font("Segoe UI", 8F);
            this.status.ForeColor  = Color.FromArgb(140, 145, 160);
            this.status.Location   = new Point(10, 0);
            this.status.Name       = "status";
            this.status.Size       = new Size(220, 26);
            this.status.TabIndex   = 0;
            this.status.Text       = "  Aguardando...";
            this.status.TextAlign  = ContentAlignment.MiddleLeft;

            this.lblVersion.BackColor  = Color.Transparent;
            this.lblVersion.Font       = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            this.lblVersion.ForeColor  = Color.FromArgb(0, 200, 200);
            this.lblVersion.Location   = new Point(210, 0);
            this.lblVersion.Name       = "lblVersion";
            this.lblVersion.Size       = new Size(145, 26);
            this.lblVersion.TabIndex   = 1;
            this.lblVersion.Text       = "v1.0.1";
            this.lblVersion.TextAlign  = ContentAlignment.MiddleRight;

            // ── Form ─────────────────────────────────────────────────────────
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor           = Color.FromArgb(15, 17, 23);
            this.ClientSize          = new Size(360, 260);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.panelAccent);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.panelStatusBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name            = "Form1";
            this.Text            = "MIHAGUE INJECTOR";
            this.StartPosition   = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load  += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);

            this.panelContent.ResumeLayout(false);
            this.panelButtons.ResumeLayout(false);
            this.panelStatusBar.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private void Form1_Load(object sender, EventArgs e) { }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm  guna2BorderlessForm1;
        private System.Windows.Forms.Panel             panelHeader;
        private System.Windows.Forms.Panel             panelAccent;
        private System.Windows.Forms.Panel             panelContent;
        private System.Windows.Forms.Label             lblSectionPlayer;
        private System.Windows.Forms.Panel             panelSectionBar;
        private System.Windows.Forms.Label             lblRow1;
        private System.Windows.Forms.Label             lblRow1Sub;
        private Guna.UI2.WinForms.Guna2ToggleSwitch    toggle1;
        private System.Windows.Forms.Panel             panelDiv1;
        private System.Windows.Forms.Panel             panelButtons;
        private Guna.UI2.WinForms.Guna2Button          btnTabDiscord;
        private Guna.UI2.WinForms.Guna2Button          btnTabYoutube;
        private System.Windows.Forms.Panel             panelStatusBar;
        private System.Windows.Forms.Label             status;
        private System.Windows.Forms.Label             lblVersion;
    }
}
