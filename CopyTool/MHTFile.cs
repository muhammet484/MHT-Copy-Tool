using System;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;
using System.Drawing;
using static CopyTool.DebugHelper;

namespace CopyTool
{
    /*TODO: add these functions and variables:
     * +string path, name, extension
     * +long byteSize
     * +float GBSize,MBSize,KBSize
     * remove, delete, cutPaste, copyPaste, addToClipboard, cuttoClipboard
     */
    public class MHTFile
    {
        public FileInfo fileInfo;
        public FileAttributes ThePathAttributes;
        public ListViewItem ListViewItemMHTFile;
        public string Path, Name, Extension, FullGivenName, ShortedGivenName, SizeDisplay;
        public long ByteSize;
        public float GBSize, MBSize, KBSize;
        bool IsFile;

        /// <summary>
        /// Max character number for displayed name of file. If file name is more than this number, it doesn't be displayed fully and be putted 3 dot at the end of name
        /// </summary>
        private const int maxCharacterName = 14;

        #region Static Functions
        /// <summary>
        /// Convert path to a simple file name
        /// </summary>
        /// <param name="addFileExtension">for example if it's true, 
        /// it writes "file.exe" if false: "file"</param>
        public static string GetFileName(string path, bool addFileExtension = true)
        {
            if (!addFileExtension)
            {
                return System.IO.Path.GetFileNameWithoutExtension(path);
            }
            return System.IO.Path.GetFileName(path);
        }

        /// <summary>
        /// Returns the file extension. Don't use with folders.
        /// </summary>
        public static string GetFileExtension(string path)
        {
            return System.IO.Path.GetExtension(path);
        }

        /// <summary>
        /// returns true if the "FileAttributes" is a file
        /// returns false if the "FileAttributes" is a folder
        /// </summary>
        public static bool GetIsFile(String TheFile)
        {
            if (File.Exists(TheFile) && !Directory.Exists(TheFile))
                return true;
            else
                return false;
        }

        /// <summary>
        /// returns -1 if the file is not exist in the path
        /// </summary>
        public static long getByteSize(string path)
        {
            FileInfo _fileInfo = new FileInfo(path);
            if (_fileInfo.Exists)
                return _fileInfo.Length;
            return -1;
        }

        public static MHTFile[] CreateFileArray(string[] paths)
        {
            if (paths[0] == null)
                return null;
            else
            {
                List<MHTFile> mhtFiles = new List<MHTFile>();
                for (int i = 0; i < paths.Length; i++)
                {
                    mhtFiles.Add(new MHTFile(paths[i]));
                }
                return mhtFiles.ToArray();
            }
        }
        #endregion

        public override string ToString()
        {
            return assignGivenName();
        }

        string assignGivenName()
        {
            if (Settings.fileNameSetting == FileNameSetting.ShowFullPath)
                FullGivenName = Path;
            else if (Settings.fileNameSetting == FileNameSetting.ShowNameWithExtension)
                FullGivenName = Name + Extension;
            else if (Settings.fileNameSetting == FileNameSetting.ShowNameOnly)
                FullGivenName = Name;

            if (FullGivenName.Length >= maxCharacterName)
            {
                ShortedGivenName =
                    FullGivenName.Substring(0, maxCharacterName - 3) + "...";
            }
            else
            {
                ShortedGivenName = FullGivenName;
            }
            return ShortedGivenName;
        }

        public MHTFile(String path)
        {
            this.Path = path;
            fileInfo = new FileInfo(path);
            ThePathAttributes = File.GetAttributes(@path);
            IsFile = GetIsFile(path);

            Name = GetFileName(path, false);
            Extension = GetFileExtension(path);

            this.ByteSize = getByteSize(path);
            float byteSizeFloat = ByteSize;
            KBSize = byteSizeFloat / 1024;
            MBSize = KBSize / 1024;
            GBSize = MBSize / 1024;
            setSizeDisplay();
        }

        public void SetItem()
        {
            SetListViewImage();
            setToolTipText();
        }

        public void CopyToClipBoard(bool add = false)
        {
            StringCollection path = new StringCollection();
            if (add) path = Clipboard.GetFileDropList();
            path.Add(this.Path);
            Clipboard.SetFileDropList(path);
        }

        public void cutToClipboard(bool add = false)
        {
            byte[] moveEffect = new byte[] { 2, 0, 0, 0 };
            MemoryStream dropEffect = new MemoryStream();
            dropEffect.Write(moveEffect, 0, moveEffect.Length);
            DataObject data = new DataObject();
            StringCollection path = new StringCollection();
            if (add) path = Clipboard.GetFileDropList();
            path.Add(this.Path);
            data.SetFileDropList(path);
            data.SetData("Preferred DropEffect", dropEffect);

            Clipboard.Clear();
            Clipboard.SetDataObject(data, true);
        }

        public MHTFile Remove()
        {
            ListViewItemMHTFile.Remove();
            return this;
        }

        public void SetListViewImage()
        {
            // Set a default icon for the file.
            Icon iconForFile = SystemIcons.Application;
            if (IsFile) //if is not file, it can't assing an icon and get error
            {
                if (fileInfo.Extension != ".lnk")
                {
                    // Check to see if the image collection contains an image
                    // for this extension, using the extension as a key.
                    if (!Form1.imageList.Images.ContainsKey(fileInfo.Extension))
                    {
                        // If not, add the image to the image list.
                        iconForFile = System.Drawing.Icon.ExtractAssociatedIcon(Path);
                        Form1.imageList.Images.Add(fileInfo.Extension, iconForFile);
                    }
                    try
                    {
                        ListViewItemMHTFile.ImageKey = fileInfo.Extension;
                    }
                    catch (Exception)
                    {
                        cm("Error: ListViewItemMHTFile.ImageKey = fileInfo.Extension");
                    }
                }
                else
                    ListViewItemMHTFile.ImageIndex = 1; //1 is .lnk icon
            }
            else
                ListViewItemMHTFile.ImageIndex = 0; // 0 is a folder icon (windows11 style icon)
        }

        public void DeleteFile()
        {
            try
            {
                if (IsFile)
                {
                    File.SetAttributes(Path, FileAttributes.Normal);
                    File.Delete(Path);
                }
                else
                {
                    Directory.Delete(Path);
                }
                Remove();
            }
            catch (Exception)
            {
                MessageBox.Show("Deleting error!");
            }
        }

        public void setToolTipText(string OptionalText = "")
        {
            ListViewItemMHTFile.ToolTipText = Path + "\n" + SizeDisplay;
        }

        public void setSizeDisplay()
        {
            if (IsFile)
            {
                if (ByteSize < 1024) { SizeDisplay = ByteSize + " byte"; }
                if (ByteSize > 1024)
                { SizeDisplay = String.Format("{0:0.00}", KBSize) + " KB"; }
                if (ByteSize > 1024 * 1024)
                { SizeDisplay = String.Format("{0:0.00}", MBSize) + " MB"; }
                if (ByteSize > 1024 * 1024 * 1024)
                { SizeDisplay = String.Format("{0:0.00}", GBSize) + " GB"; }
            }
        }
    }
}
