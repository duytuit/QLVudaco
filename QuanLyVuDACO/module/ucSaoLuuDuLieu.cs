using DevExpress.XtraEditors;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Upload;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quản_lý_vudaco.module
{
    public partial class ucSaoLuuDuLieu : DevExpress.XtraEditors.XtraUserControl
    {
        static string[] Scopes = { DriveService.Scope.Drive };
        static string ApplicationName = "SQL Backup Uploader";
        private int _id = 0;
        public ucSaoLuuDuLieu()
        {
            InitializeComponent();
            colSTT.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
         
        }
        private void ucDanhSachTaiKhoan_Load(object sender, EventArgs e)
        {
        }
        private void repositoryItemHyperLinkSua_Click(object sender, EventArgs e)
        {
        }

        private void repositoryItemHyperLinkXoa_Click(object sender, EventArgs e)
        {
          
        }
      
        private async void btnLuu_Click(object sender, EventArgs e)
        {

            try
            {
                await BackupAndUploadAsync();
                //await LoadBackupListFromGoogleDrive();
                XtraMessageBox.Show("Backup & upload thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi: " + ex.Message, "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
          
        }

        private void gridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
           
        }
        #region Google Drive Service
        private static DriveService GetService()
        {
            UserCredential credential;
            using (var stream = new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
            {
                string credPath = "token.json";
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.FromStream(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
            }

            return new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });
        }

        private static async Task UploadFileAsync(string filePath, string folderId = null)
        {
            var service = GetService();
            var fileMetadata = new Google.Apis.Drive.v3.Data.File
            {
                Name = Path.GetFileName(filePath)
            };

            if (!string.IsNullOrEmpty(folderId))
            {
                fileMetadata.Parents = new[] { folderId };
            }

            using (var stream = new FileStream(filePath, FileMode.Open))
            {
                var request = service.Files.Create(fileMetadata, stream, "application/octet-stream");
                request.Fields = "id";
                await request.UploadAsync();
            }
        }

        private async Task<List<BackupFileInfo>> GetBacpacFilesFromDrive()
        {
            var service = GetService();
            var request = service.Files.List();
            request.Q = "mimeType != 'application/vnd.google-apps.folder' and name contains '.bacpac'";
            request.Fields = "files(id, name, size, createdTime)";
            request.PageSize = 100;

            var result = await request.ExecuteAsync();

            return result.Files.Select(f => new BackupFileInfo
            {
                FileName = f.Name,
                FileId = f.Id,
                SizeKB = f.Size.HasValue ? (long)f.Size.Value / 1024 : 0,
                CreatedDate = f.CreatedTime.HasValue ? f.CreatedTime.Value : DateTime.MinValue
            }).OrderByDescending(x => x.CreatedDate).ToList();
        }
        #endregion

        #region Backup + Upload
        private async Task BackupAndUploadAsync()
        {
            string sqlPackagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "sqlpackage/SqlPackage.exe");

            string server = @"103.226.249.227\sqlexpress";
            string database = "vua45987_vudaco";
            string user = "vua45987_vudaco";
            string password = "0l7w7fJ*7"; 

            string backupFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Backup");
            Directory.CreateDirectory(backupFolder);

            string bacpacFile = Path.Combine(backupFolder, $"{database}_{DateTime.Now:yyyyMMdd_HHmmss}.bacpac");

            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = sqlPackagePath,
                    Arguments =
                    $"/Action:Export " +
                    $"/SourceServerName:\"{server}\" " +
                    $"/SourceDatabaseName:\"{database}\" " +
                    $"/SourceUser:\"{user}\" " +
                    $"/SourcePassword:\"{password}\" " +
                    $"/SourceTrustServerCertificate:True " +  // Bỏ qua SSL
                    $"/TargetFile:\"{bacpacFile}\"",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true
                }
            };

            process.Start();
            string output = process.StandardOutput.ReadToEnd();
            string error = process.StandardError.ReadToEnd();
            process.WaitForExit();

            if (process.ExitCode != 0)
            {
                throw new Exception("Lỗi export: " + error);
            }

            await UploadFileAsync(bacpacFile, null);
        }
        #endregion

        #region Load GridControl
        private async Task LoadBackupListFromGoogleDrive()
        {
            var data = await GetBacpacFilesFromDrive();
            gridControl1.DataSource = data;

            gridView1.Columns["FileName"].Caption = "Tên File";
            gridView1.Columns["FileId"].Caption = "Google Drive File ID";
            gridView1.Columns["SizeKB"].Caption = "Dung lượng (KB)";
            gridView1.Columns["CreatedDate"].Caption = "Ngày tạo";
        }
        #endregion
    }

    public class BackupFileInfo
    {
        public string FileName { get; set; }
        public string FileId { get; set; }
        public long SizeKB { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
