using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HashChecker
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// A value to save which item should be done. 
        /// </summary>
        option opt = new option()
        {
            size = false,
            date = false,
            md5 = false,
            sha1 = false,
            sha256 = false,
            sha384 = false,
            sha512 = false,
            crc32 = false,
            crc64 = false
        };
        /// <summary>
        /// A value to save all the items' results. 
        /// </summary>
        result re;

        public MainWindow()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Browse files in your computer after click. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_browse_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new Microsoft.Win32.OpenFileDialog()
            {
                Filter = "All Files (*.*)|*.*"
            };
            var result = openFileDialog.ShowDialog();
            if (result == true)
            {
                textBox_FileName.Text = openFileDialog.FileName;
            }
        }

        private void button_CaculateFileHash_Click(object sender, RoutedEventArgs e)
        {
            getOpt();
            re = new result()
            {
                size = -1,
                date = DateTime.MinValue,
                md5 = null,
                sha1 = null,
                sha256 = null,
                sha384 = null,
                sha512 = null,
                crc32 = null,
                crc64 = null
            };
            if (!string.IsNullOrEmpty(textBox_FileName.Text) && System.IO.File.Exists(textBox_FileName.Text))
            {
                byte[] bts = System.IO.File.ReadAllBytes(textBox_FileName.Text);
                re = CommenFunction.GetResult(bts, opt);
            }
            if(opt.size && !string.IsNullOrEmpty(textBox_FileName.Text))
            {
                re.size = CommenFunction.GetFileSize(textBox_FileName.Text);
            }
            if(opt.date && !string.IsNullOrEmpty(textBox_FileName.Text))
            {
                re.date = CommenFunction.GetFileCreationTime(textBox_FileName.Text);
            }
            textBox_OutputResult.Text += "\nFile Name: " + textBox_FileName.Text + "\n";
            ShowResult(re,opt);
        }

        private void button_CaculateTextHash_Click(object sender, RoutedEventArgs e)
        {
            getOpt();
            re = new result()
            {
                size = -1,
                date = DateTime.MinValue,
                md5 = null,
                sha1 = null,
                sha256 = null,
                sha384 = null,
                sha512 = null,
                crc32 = null,
                crc64 = null
            };
            if (!string.IsNullOrEmpty(textBox_InputText.Text))
            {
                byte[] bts = System.Text.Encoding.Default.GetBytes(textBox_InputText.Text);
                re = CommenFunction.GetResult(bts, opt);
            }
            textBox_OutputResult.Text += "\nText Hash is : \n";
            re.size = -1;
            re.date = DateTime.MinValue;
            ShowResult(re, opt);
        }
        /// <summary>
        /// Get all checkBox check status. 
        /// </summary>
        private void getOpt()
        {
            opt.date = checkBox_creationtime.IsChecked.Value;
            opt.size = checkBox_filesize.IsChecked.Value;
            opt.md5 = checkBox_md5.IsChecked.Value;
            opt.sha1 = checkBox_sha1.IsChecked.Value;
            opt.sha256 = checkBox_sha256.IsChecked.Value;
            opt.sha384 = checkBox_sha384.IsChecked.Value;
            opt.sha512 = checkBox_sha512.IsChecked.Value;
            opt.crc32 = checkBox_crc32.IsChecked.Value;
            opt.crc64 = checkBox_crc64.IsChecked.Value;
        }
        /// <summary>
        /// Show textBox_OutputResult the hash result. 
        /// </summary>
        /// <param name="r"></param>
        /// <param name="op"></param>
        private void ShowResult(result r,option op)
        {
            if (op.size==true && r.size!=-1)
            {
                textBox_OutputResult.Text += "File Size: " + r.size.ToString() + " Bytes \n";
            }
            if (op.date == true && r.date != DateTime.MinValue)
            {
                textBox_OutputResult.Text += "File Creation Time: " + r.date.ToString() + "\n";
            }
            if (op.md5 == true && r.md5 != null)
            {
                textBox_OutputResult.Text += "MD5: " + r.md5 + "\n";
            }
            if (op.sha1 == true && r.sha1 != null)
            {
                textBox_OutputResult.Text += "SHA1: " + r.sha1 + "\n";
            }
            if (op.sha256 == true && r.sha256 != null)
            {
                textBox_OutputResult.Text += "SHA256: " + r.sha256 + "\n";
            }
            if (op.sha384 == true && r.sha384 != null)
            {
                textBox_OutputResult.Text += "SHA384: " + r.sha384 + "\n";
            }
            if (op.sha512 == true && r.sha512 != null)
            {
                textBox_OutputResult.Text += "SHA512: " + r.sha512 + "\n";
            }
            if (op.crc32 == true && r.crc32 != null)
            {
                textBox_OutputResult.Text += "CRC32: " + r.crc32 + "\n";
            }
            if (op.crc64 == true && r.crc64 != null)
            {
                textBox_OutputResult.Text += "CRC64: " + r.crc64 + "\n";
            }
            textBox_OutputResult.Text += "====================\n";
        }

        private void textBox_statement_Loaded(object sender, RoutedEventArgs e)
        {
            textBox_statement.Text = "Statement: \nThis is an open source project "
                + "to facilitates people to check files. "
                + "Please look at \" https://github.com/nl8590687/HashChecker \" for more information. ";
        }
    }
}
