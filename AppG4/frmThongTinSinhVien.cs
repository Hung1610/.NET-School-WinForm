using AppG4.Models;
using AppG4.Services;
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

namespace AppG4
{
    public partial class frmThongTinSinhVien : Form
    {
        string anhDaiDienPathDirectory;
        string anhDaiDienPathFile;
        Student student;
        List<StudentHistory> listHistory;
        public frmThongTinSinhVien(string idStudent)
        {
            InitializeComponent();
            picAnhDaiDien.AllowDrop = true;
            anhDaiDienPathDirectory = Application.StartupPath + @"\AnhDaiDien";
            anhDaiDienPathFile = anhDaiDienPathDirectory + @"\avatar.png";
            if (File.Exists(anhDaiDienPathFile))
            {
                FileStream fileStream = new FileStream(anhDaiDienPathFile, FileMode.Open, FileAccess.Read);
                picAnhDaiDien.Image = Image.FromStream(fileStream);
                fileStream.Close();
            }

            student = StudentService.GetStudent(idStudent);
            if (student == null)
            {
                throw new Exception("Lỗi rồi. Sinh viên này không tồn tại.");
            }
            else
            {
                txtMaSinhVien.Text = student.ID;
                txtHoTen.Text = student.FullName;
                txtNoiSinh.Text = student.PlaceOfBirth;
                dtpNgaySinh.Value = student.Birthday;
                chkGioiTinh.Checked = student.Gender == Models.GENDER.Male;
            }

            listHistory = StudentHistoryService.GetStudentHistory(idStudent);
            if (student == null)
            {
                throw new Exception("Lỗi rồi. Sinh viên này không tồn tại.");
            }
            else
            {
                dgvQuaTrinhHocTap.AutoGenerateColumns = false;
                bdsQuaTrinhHocTap.DataSource = listHistory;
                dgvQuaTrinhHocTap.DataSource = bdsQuaTrinhHocTap;
                lblTongSoMuc.Text = string.Format("{0} mục",listHistory.Count());
            }
        }

        private void lnkChonAnhDaiDien_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "File ảnh(*.jpg, *.png)|*.png;*.jpg";
            fileDialog.Title = "Chọn ảnh đại diện";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                #region Hiển thị ảnh được chọn lên picture box
                var fileName = fileDialog.FileName;
                FileStream fileStream = new FileStream(anhDaiDienPathFile, FileMode.Open, FileAccess.Read);
                var anhDaiDien = Image.FromStream(fileStream);
                #endregion

                #region Lưu ảnh đại diện vào thư mục của chương trình
                if (!Directory.Exists(anhDaiDienPathDirectory))
                {
                    Directory.CreateDirectory(anhDaiDienPathDirectory);
                }
                anhDaiDien.Save(anhDaiDienPathFile);
                #endregion

                picAnhDaiDien.Image = anhDaiDien;
                fileStream.Close();
            }
        }

        private void picAnhDaiDien_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void picAnhDaiDien_DragDrop(object sender, DragEventArgs e)
        {
            var fileNameList = (string[])e.Data.GetData(DataFormats.FileDrop);
            FileStream fileStream = new FileStream(fileNameList.FirstOrDefault(), FileMode.Open, FileAccess.Read);
            var anhDaiDien = Image.FromStream(fileStream);

            #region Lưu ảnh đại diện vào thư mục của chương trình
            if (!Directory.Exists(anhDaiDienPathDirectory))
            {
                Directory.CreateDirectory(anhDaiDienPathDirectory);
            }
            anhDaiDien.Save(anhDaiDienPathFile);
            #endregion

            picAnhDaiDien.Image = anhDaiDien;
            fileStream.Close();
        }
    }
}
