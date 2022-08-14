
namespace CopyTool
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "dasdsa"}, -1, System.Drawing.Color.Empty, System.Drawing.SystemColors.Highlight, null);
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem(new string[] {
            "adssdadsa"}, -1, System.Drawing.Color.Empty, System.Drawing.SystemColors.MenuText, null);
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem(new string[] {
            "dasdsadsa"}, -1, System.Drawing.Color.Empty, System.Drawing.SystemColors.InfoText, null);
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem(new string[] {
            "dasdsadsa"}, -1, System.Drawing.Color.Empty, System.Drawing.SystemColors.WindowFrame, null);
            System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem(new string[] {
            "asdsdadsa"}, -1, System.Drawing.Color.Empty, System.Drawing.SystemColors.MenuHighlight, null);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.DosyaListView = new System.Windows.Forms.ListView();
            this.ConsoleMessage = new System.Windows.Forms.TextBox();
            this.ConsoleName = new System.Windows.Forms.Label();
            this.CutRB = new System.Windows.Forms.RadioButton();
            this.CopyRB = new System.Windows.Forms.RadioButton();
            this.imageListForm = new System.Windows.Forms.ImageList(this.components);
            this.ListviewContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.asdfdfsaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fdasdfsaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddToClipboardButton = new System.Windows.Forms.Button();
            this.RemoveButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.SelectAllButton = new System.Windows.Forms.Button();
            this.DeselectAllButton = new System.Windows.Forms.Button();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.ListviewContextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // DosyaListView
            // 
            this.DosyaListView.AllowDrop = true;
            this.DosyaListView.HideSelection = false;
            listViewItem1.StateImageIndex = 0;
            listViewItem1.Tag = "dsadas";
            listViewItem1.ToolTipText = "asddasdsa";
            listViewItem2.StateImageIndex = 0;
            listViewItem3.StateImageIndex = 0;
            listViewItem4.StateImageIndex = 0;
            listViewItem5.StateImageIndex = 0;
            this.DosyaListView.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4,
            listViewItem5});
            this.DosyaListView.Location = new System.Drawing.Point(12, 12);
            this.DosyaListView.Name = "DosyaListView";
            this.DosyaListView.ShowItemToolTips = true;
            this.DosyaListView.Size = new System.Drawing.Size(661, 398);
            this.DosyaListView.TabIndex = 3;
            this.DosyaListView.UseCompatibleStateImageBehavior = false;
            this.DosyaListView.View = System.Windows.Forms.View.SmallIcon;
            this.DosyaListView.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.DosyaListView_ItemDrag);
            this.DosyaListView.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.DosyaListView.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            this.DosyaListView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DosyaListView_MouseDown);
            this.DosyaListView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DosyaListView_MouseUp);
            // 
            // ConsoleMessage
            // 
            this.ConsoleMessage.Location = new System.Drawing.Point(86, 416);
            this.ConsoleMessage.Name = "ConsoleMessage";
            this.ConsoleMessage.ReadOnly = true;
            this.ConsoleMessage.Size = new System.Drawing.Size(587, 22);
            this.ConsoleMessage.TabIndex = 4;
            // 
            // ConsoleName
            // 
            this.ConsoleName.AutoSize = true;
            this.ConsoleName.Location = new System.Drawing.Point(12, 424);
            this.ConsoleName.Name = "ConsoleName";
            this.ConsoleName.Size = new System.Drawing.Size(60, 16);
            this.ConsoleName.TabIndex = 5;
            this.ConsoleName.Text = "Console:";
            // 
            // CutRB
            // 
            this.CutRB.AutoSize = true;
            this.CutRB.Location = new System.Drawing.Point(680, 13);
            this.CutRB.Name = "CutRB";
            this.CutRB.Size = new System.Drawing.Size(47, 20);
            this.CutRB.TabIndex = 6;
            this.CutRB.Text = "Cut";
            this.CutRB.UseVisualStyleBackColor = true;
            this.CutRB.CheckedChanged += new System.EventHandler(this.radioButtons_CheckedChanged);
            // 
            // CopyRB
            // 
            this.CopyRB.AutoSize = true;
            this.CopyRB.Checked = true;
            this.CopyRB.Location = new System.Drawing.Point(680, 40);
            this.CopyRB.Name = "CopyRB";
            this.CopyRB.Size = new System.Drawing.Size(60, 20);
            this.CopyRB.TabIndex = 7;
            this.CopyRB.TabStop = true;
            this.CopyRB.Text = "Copy";
            this.CopyRB.UseVisualStyleBackColor = true;
            this.CopyRB.CheckedChanged += new System.EventHandler(this.radioButtons_CheckedChanged);
            // 
            // imageListForm
            // 
            this.imageListForm.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListForm.ImageStream")));
            this.imageListForm.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListForm.Images.SetKeyName(0, "folder.ico");
            this.imageListForm.Images.SetKeyName(1, "url.ico");
            // 
            // ListviewContextMenuStrip
            // 
            this.ListviewContextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ListviewContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.asdfdfsaToolStripMenuItem,
            this.fdasdfsaToolStripMenuItem});
            this.ListviewContextMenuStrip.Name = "ListviewContextMenuStrip";
            this.ListviewContextMenuStrip.Size = new System.Drawing.Size(135, 52);
            // 
            // asdfdfsaToolStripMenuItem
            // 
            this.asdfdfsaToolStripMenuItem.Name = "asdfdfsaToolStripMenuItem";
            this.asdfdfsaToolStripMenuItem.Size = new System.Drawing.Size(134, 24);
            this.asdfdfsaToolStripMenuItem.Text = "asdfdfsa";
            // 
            // fdasdfsaToolStripMenuItem
            // 
            this.fdasdfsaToolStripMenuItem.Name = "fdasdfsaToolStripMenuItem";
            this.fdasdfsaToolStripMenuItem.Size = new System.Drawing.Size(134, 24);
            this.fdasdfsaToolStripMenuItem.Text = "fdasdfsa";
            // 
            // AddToClipboardButton
            // 
            this.AddToClipboardButton.Location = new System.Drawing.Point(680, 67);
            this.AddToClipboardButton.Name = "AddToClipboardButton";
            this.AddToClipboardButton.Size = new System.Drawing.Size(108, 46);
            this.AddToClipboardButton.TabIndex = 11;
            this.AddToClipboardButton.Text = "Add To Clipboard";
            this.AddToClipboardButton.UseVisualStyleBackColor = true;
            this.AddToClipboardButton.Click += new System.EventHandler(this.AddToClipboardButton_Click);
            // 
            // RemoveButton
            // 
            this.RemoveButton.Location = new System.Drawing.Point(680, 265);
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Size = new System.Drawing.Size(108, 46);
            this.RemoveButton.TabIndex = 12;
            this.RemoveButton.Text = "Remove From List";
            this.RemoveButton.UseVisualStyleBackColor = true;
            this.RemoveButton.Click += new System.EventHandler(this.RemoveButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(680, 364);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(108, 46);
            this.DeleteButton.TabIndex = 13;
            this.DeleteButton.Text = "Delete Files!";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // SelectAllButton
            // 
            this.SelectAllButton.Location = new System.Drawing.Point(680, 159);
            this.SelectAllButton.Name = "SelectAllButton";
            this.SelectAllButton.Size = new System.Drawing.Size(108, 23);
            this.SelectAllButton.TabIndex = 15;
            this.SelectAllButton.Text = "Select All";
            this.SelectAllButton.UseVisualStyleBackColor = true;
            this.SelectAllButton.Click += new System.EventHandler(this.SelectAllButton_Click);
            // 
            // DeselectAllButton
            // 
            this.DeselectAllButton.Location = new System.Drawing.Point(680, 188);
            this.DeselectAllButton.Name = "DeselectAllButton";
            this.DeselectAllButton.Size = new System.Drawing.Size(108, 23);
            this.DeselectAllButton.TabIndex = 16;
            this.DeselectAllButton.Text = "Deselect All";
            this.DeselectAllButton.UseVisualStyleBackColor = true;
            this.DeselectAllButton.Click += new System.EventHandler(this.DeselectAllButton_Click);
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.Filter = "sb.txt";
            this.fileSystemWatcher1.NotifyFilter = ((System.IO.NotifyFilters)((((System.IO.NotifyFilters.FileName | System.IO.NotifyFilters.DirectoryName) 
            | System.IO.NotifyFilters.Attributes) 
            | System.IO.NotifyFilters.LastWrite)));
            this.fileSystemWatcher1.Path = "D:\\";
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.DeselectAllButton);
            this.Controls.Add(this.SelectAllButton);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.RemoveButton);
            this.Controls.Add(this.AddToClipboardButton);
            this.Controls.Add(this.CopyRB);
            this.Controls.Add(this.CutRB);
            this.Controls.Add(this.ConsoleName);
            this.Controls.Add(this.ConsoleMessage);
            this.Controls.Add(this.DosyaListView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "MHT Copy Tool";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ListviewContextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListView DosyaListView;
        private System.Windows.Forms.Label ConsoleName;
        private System.Windows.Forms.RadioButton CutRB;
        private System.Windows.Forms.RadioButton CopyRB;
        public System.Windows.Forms.TextBox ConsoleMessage;
        private System.Windows.Forms.ImageList imageListForm;
        private System.Windows.Forms.ContextMenuStrip ListviewContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem asdfdfsaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fdasdfsaToolStripMenuItem;
        private System.Windows.Forms.Button AddToClipboardButton;
        private System.Windows.Forms.Button RemoveButton;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button SelectAllButton;
        private System.Windows.Forms.Button DeselectAllButton;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
    }
}

