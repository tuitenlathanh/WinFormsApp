using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        // private static Label? Label1; // Label để hiển thị trạng thái
        private void DocFile_Click(object sender, EventArgs e)
        {
            // Tạo một OpenFileDialog để cho phép người dùng chọn thư mục
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Chọn thư mục";
                openFileDialog.CheckFileExists = false;
                openFileDialog.CheckPathExists = true;
                openFileDialog.FileName = "Thư mục";
                openFileDialog.ValidateNames = false;
                openFileDialog.FileName = "Thư mục";
                openFileDialog.Filter = "Thư mục|*.";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string folderPath = Path.GetDirectoryName(openFileDialog.FileName);

                    // Hiển thị trạng thái và bắt đầu quá trình tính toán trong luồng mới
                    label1.Visible = true;
                    Task.Run(() => CalculateHashesAndSaveToFile(folderPath));
                }
            }
        }

        private void CalculateHashesAndSaveToFile(string folderPath)
        {
            try
            {
                // Tạo tên file .txt và đường dẫn đến file
                string txtFilePath = Path.Combine(folderPath, "file_list.txt");

                // Lấy danh sách các file trong thư mục
                string[] files = Directory.GetFiles(folderPath);

                // Tạo một StringBuilder để xây dựng nội dung file .txt
                StringBuilder sb = new StringBuilder();

                // Tạo MD5 hash cho từng file và ghi vào StringBuilder
                foreach (string file in files)
                {
                    string fileName = Path.GetFileName(file);
                    string hash = CalculateMD5(file);
                    sb.AppendLine($"{fileName} - {hash}");
                }

                // Ghi nội dung StringBuilder vào file .txt
                File.WriteAllText(txtFilePath, sb.ToString());

                // Hiển thị thông báo hoàn thành trên giao diện người dùng
                label1.BeginInvoke((Action)(() =>
                {
                    label1.Text = "Hoàn thành!";
                }));
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
            }
        }



        private static string CalculateMD5(string filePath)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(filePath))
                {
                    byte[] hashBytes = md5.ComputeHash(stream);
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < hashBytes.Length; i++)
                    {
                        sb.Append(hashBytes[i].ToString("x2"));
                    }
                    return sb.ToString();
                }
            }
        }

        private void GhiFile_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Chọn file văn bản";
                openFileDialog.Filter = "Text Files|*.txt";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;

                    try
                    {
                        string content = File.ReadAllText(filePath);
                        //textBoxContent.Text = content;
                        label1.Text = content;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
                    }
                }
            }
        }
    }
}