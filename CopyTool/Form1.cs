using Peter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static CopyTool.DebugHelper;

namespace CopyTool
{
    public partial class Form1 : Form
    {
        public string[] FileNames;
        public static ImageList imageList; //for listview
        public Form1()
        {
            InitializeComponent();
            imageList = imageListForm;

            //Initialize console, so we can use it everywhere
            DebugHelper.InitializeDebugHelperTools(ref ConsoleMessage);
        }

        //starting function:
        private void Form1_Load(object sender, EventArgs e)
        {
            CheckSettings();
            DosyaListView.Clear();
            this.DragDrop += Form1_DragDrop;
            this.DragEnter += Form1_DragEnter;
            DosyaListView.LargeImageList = imageList;
            DosyaListView.SmallImageList = imageList;
        }
        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        /// <summary>
        /// drag items from listview to windows explorer
        /// </summary>
        private void DosyaListView_ItemDrag(object sender, ItemDragEventArgs e)
        {
            List<string> selection = new List<string>();

            foreach (ListViewItem item in DosyaListView.SelectedItems)
            {
                selection.Add((item.Tag as MHTFile).Path);
            }

            DataObject data = new DataObject(DataFormats.FileDrop, selection.ToArray());

            if (Settings.CutOrCopySetting == CutOrCopySetting.Copy)
                DosyaListView.DoDragDrop(data, DragDropEffects.Copy);
            else if (Settings.CutOrCopySetting == CutOrCopySetting.Cut)
            {
                DosyaListView.DoDragDrop(data, DragDropEffects.Move);

                foreach (ListViewItem item in DosyaListView.SelectedItems)
                {
                    item.Remove();
                }
            }
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                // step: get file paths and create mhtfile objects
                FileNames = e.Data.GetData(DataFormats.FileDrop) as string[];
                MHTFile[] files = MHTFile.CreateFileArray(FileNames);

                // step: check all added files if they are already added in the listview
                // and remove added files so we change them with new ones
                foreach (var file in files)
                {
                    foreach (ListViewItem item in DosyaListView.Items)
                    {
                        MHTFile itemAsFile = item.Tag as MHTFile;
                        if (file.Path == itemAsFile.Path)
                        {
                            item.Remove();
                            itemAsFile = null; // save system memory :)
                        }
                    }
                }

                // step: add all files to listview and assign some necessary variables
                foreach (var item in files)
                {
                    var _addedItem = DosyaListView.Items.Add(item.ToString());
                    _addedItem.Tag = item;
                    item.ListViewItemMHTFile = _addedItem;
                    item.SetItem();
                }
                // result: all files added to listview box
            }
            catch (Exception)
            {
                cm("Error: Form1_DragDrop");
            }
        }
        #region Check settings functions
        private void CheckSettings()
        {
            checkCutCopyRadioButtons();
        }

        private void radioButtons_CheckedChanged(object sender, EventArgs e)
        { checkCutCopyRadioButtons(); }

        void checkCutCopyRadioButtons()
        {
            if (CopyRB.Checked)
            {
                Settings.CutOrCopySetting = CutOrCopySetting.Copy;
            }
            else if (CutRB.Checked)
            {
                Settings.CutOrCopySetting = CutOrCopySetting.Cut;
            }
        }
        #endregion

        private void DosyaListView_MouseUp(object sender, MouseEventArgs e)
        {
            #region windows context menu strip
            if (e.Button == MouseButtons.Right)
            {
                if (DosyaListView.SelectedItems.Count > 0)
                {
                    ShellContextMenu ctxMnu = new ShellContextMenu();
                    List<FileInfo> _files = new List<FileInfo>();
                    foreach (ListViewItem item in DosyaListView.SelectedItems)
                    { _files.Add((item.Tag as MHTFile).fileInfo); }

                    ctxMnu.ShowContextMenu(_files.ToArray(), e.Location);
                }
                else
                {
                    //TODO: complete creating context menu for listview
                    //ListviewContextMenuStrip.Show(DosyaListView, e.Location);
                }

            }
            #endregion
            foreach (ListViewItem item in DosyaListView.SelectedItems)
            {
                item.Text = (item.Tag as MHTFile).FullGivenName;
            }
        }

        private void DosyaListView_MouseDown(object sender, MouseEventArgs e)
        {
            foreach (ListViewItem item in DosyaListView.Items)
            {
                item.Text = (item.Tag as MHTFile).ShortedGivenName;
            }
        }
        private void AddToClipboardButton_Click(object sender, EventArgs e)
        {
            if (Settings.CutOrCopySetting == CutOrCopySetting.Cut)
            {
                cutAllFilesToClipboard();
            }
            else if (Settings.CutOrCopySetting == CutOrCopySetting.Copy)
            {
                copyAllFilesToClipboard();
            }
        }
        void cutAllFilesToClipboard(bool add = false)
        {
            if (!add) { Clipboard.Clear(); }

            foreach (ListViewItem item in DosyaListView.Items)
            {
                MHTFile MHTitem = item.Tag as MHTFile;
                if (MHTitem.fileInfo.Exists || Directory.Exists(MHTitem.Path))
                    MHTitem.cutToClipboard(true);
                MHTitem.Remove();
            }
            cm("all files added to clipboard");
        }
        void copyAllFilesToClipboard(bool add = false)
        {
            if (!add) { Clipboard.Clear(); }

            foreach (ListViewItem item in DosyaListView.Items)
            {
                MHTFile MHTitem = item.Tag as MHTFile;
                if (MHTitem.fileInfo.Exists || Directory.Exists(MHTitem.Path))
                    MHTitem.CopyToClipBoard(true);

                cm("all files cutted and added to clipboard");
            }
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in DosyaListView.SelectedItems)
            {
                item.Remove();
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete all \"selected\" files from disk?", "Delete Files", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                foreach (ListViewItem item in DosyaListView.SelectedItems)
                {
                    (item.Tag as MHTFile).DeleteFile();
                }
                cm("All selected items are deleted!");
            }
        }

        private void SelectAllButton_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in DosyaListView.Items)
            {
                item.Selected = true;
            }
        }

        private void DeselectAllButton_Click(object sender, EventArgs e)
        {
            DosyaListView.SelectedItems.Clear();
        }
    }
}
