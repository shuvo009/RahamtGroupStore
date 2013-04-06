using System;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using AppLimit.CloudComputing.SharpBox;
using GalaSoft.MvvmLight.Command;
using NLog;
using RahamtGroupStore.Model.DatabaseModels;
using SharpCompress.Archive;
using SharpCompress.Common;
using SharpCompress.Writer;
using Application = System.Windows.Application;
using MessageBox = System.Windows.MessageBox;

namespace RahamtGroupStore.ViewModel.ViewModel
{
    public class DatabaseRestoreBackupVm : ModelBase
    {
        private const string SoftwareName = "Rahamat Group Store 1.0";
        private const string CatalogName = "RaGrStoreDatabase";
        public static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private string _backupLocation;
        private double _downloadProgress;
        private CloudStorage _dropBoxStorage;
        private ObservableCollection<FileInformation> _fileInformations;
        private bool _isBusy;
        private bool _isEnable = true;
        private bool _isIndeterminate;
        private string _restoreLocation;
        private double _uploadProgress;

        public DatabaseRestoreBackupVm()
        {
            BackupButtonContext = "Backup";
            RestoreButtonContext = "Restore";
            BrowseButtonContext = "Browse";
            CancelButtonContext = "Cancel";
            RefreshButtonContent = "Refrersh";
            BackupCommand = new RelayCommand<string>(BackupCommnadExecute, BackupCommandCanExecute);
            RestoreCommand = new RelayCommand<string>(RestoreCommnadExecute, RestoreCommandCanExecute);
            BackupBrowserCommand = new RelayCommand<string>(BackupBrowserExecute);
            RestoreBrowseCommand = new RelayCommand<string>(RestoreBrowseExecute);
            OnlineBackupCommand = new RelayCommand<string>(OnlineBackupExecute);
            OnlineRestoreCommand = new RelayCommand<string>(OnlineRestoreExecute, OnlineRestoreCanExecute);
            OnlineBackupRestoreCancelCommand = new RelayCommand(OnlineBackupRestoreCancelExecute, OnlineBackupRestoreCancelCanExecute);
            OnlineBackupListRefresh = new RelayCommand(OnlineBackupListRefreshExecute);
            GetBackupFiles();
        }

        public string BackupLocation
        {
            get { return _backupLocation; }
            set
            {
                _backupLocation = value;
                OnPeroertyChange("BackupLocation");
            }
        }

        public string RestoreLocation
        {
            get { return _restoreLocation; }
            set
            {
                _restoreLocation = value;
                OnPeroertyChange("RestoreLocation");
            }
        }

        public double DownloadProgress
        {
            get { return _downloadProgress; }
            set
            {
                _downloadProgress = value;
                OnPeroertyChange("DownloadProgress");
            }
        }

        public double UploadProgress
        {
            get { return _uploadProgress; }
            set
            {
                _uploadProgress = value;
                OnPeroertyChange("UploadProgress");
            }
        }

        public bool IsEnable
        {
            get { return _isEnable; }
            set
            {
                _isEnable = value;
                OnPeroertyChange("IsEnable");
            }
        }

        public bool IsIndeterminate
        {
            get { return _isIndeterminate; }
            set
            {
                _isIndeterminate = value;
                OnPeroertyChange("IsIndeterminate");
            }
        }

        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                OnPeroertyChange("IsBusy");
            }
        }

        public bool IsCancel { get; set; }

        public ObservableCollection<FileInformation> FileInformationses
        {
            get { return _fileInformations; }
            set
            {
                _fileInformations = value;
                OnPeroertyChange("FileInformationses");
            }
        }

        public string BackupButtonContext { get; private set; }
        public string RestoreButtonContext { get; private set; }
        public string BrowseButtonContext { get; private set; }
        public string CancelButtonContext { get; private set; }
        public string RefreshButtonContent { get; set; }

        public RelayCommand<string> BackupCommand { get; private set; }
        public RelayCommand<string> RestoreCommand { get; private set; }
        public RelayCommand<string> BackupBrowserCommand { get; private set; }
        public RelayCommand<string> RestoreBrowseCommand { get; private set; }
        public RelayCommand<string> OnlineBackupCommand { get; private set; }
        public RelayCommand<string> OnlineRestoreCommand { get; private set; }
        public RelayCommand OnlineBackupRestoreCancelCommand { get; private set; }
        public RelayCommand OnlineBackupListRefresh { get; private set; }


        private void BackupBrowserExecute(string path)
        {
            try
            {
                var backupPathDialog = new FolderBrowserDialog
                                           {
                                               Description = "Please Select a folder for backup file",
                                               ShowNewFolderButton = true
                                           };
                if (backupPathDialog.ShowDialog().Equals(DialogResult.OK))
                {
                    BackupLocation = backupPathDialog.SelectedPath;
                }
            }
            catch (Exception exception)
            {
                Logger.Error(exception.Message);
                MessageBox.Show("Unable to get location", SoftwareName, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void BackupCommnadExecute(string path)
        {
            await Task.Factory.StartNew(() =>
                                            {
                                                IsIndeterminate = true;
                                                IsEnable = false;
                                                DatabaseBackup(path);
                                                IsEnable = true;
                                                IsIndeterminate = false;
                                                MessageBox.Show("Database Backup Successfully.", SoftwareName, MessageBoxButton.OK, MessageBoxImage.Information);
                                            });
        }

        private bool BackupCommandCanExecute(string path)
        {
            try
            {
                return !String.IsNullOrEmpty(path);
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void RestoreBrowseExecute(string path)
        {
            try
            {
                var restorePathDialog = new OpenFileDialog
                                            {
                                                InitialDirectory =
                                                    Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                                                Filter = "SQL Backup file (*.bak)|*.bak"
                                            };
                if (restorePathDialog.ShowDialog().Equals(DialogResult.OK))
                {
                    RestoreLocation = restorePathDialog.FileName;
                }
            }
            catch (Exception exception)
            {
                Logger.Error(exception.Message);
                MessageBox.Show("Unable to get location", SoftwareName, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void RestoreCommnadExecute(string path)
        {
            await Task.Factory.StartNew(() =>
                                            {
                                                IsIndeterminate = true;
                                                IsEnable = false;
                                                DatabaseRestore(path);
                                                IsEnable = true;
                                                IsIndeterminate = false;
                                                MessageBox.Show("Database Restore Successfully", SoftwareName, MessageBoxButton.OK, MessageBoxImage.Information);
                                            });
        }

        private bool RestoreCommandCanExecute(string path)
        {
            try
            {
                return !String.IsNullOrEmpty(path);
            }
            catch (Exception)
            {
                return false;
            }
        }

        private async void OnlineBackupExecute(string path)
        {
            await Task.Factory.StartNew(() =>
                                            {
                                                var zipFilePath = string.Empty;
                                                try
                                                {
                                                    IsEnable = false;
                                                    IsIndeterminate = true;
                                                    path = DatabaseBackup();
                                                    zipFilePath = path.Replace("bak", "zip");
                                                    var info = new CompressionInfo {Type = CompressionType.Deflate};
                                                    using (FileStream zip = File.OpenWrite(zipFilePath))
                                                    using (IWriter zipwriter = WriterFactory.Open(zip, ArchiveType.Zip, info))
                                                    {
                                                        zipwriter.Write(Path.GetFileName(path), path);
                                                    }

                                                    GetDropBoxAccess();
                                                    IsIndeterminate = false;
                                                    ICloudDirectoryEntry uploadFolder = _dropBoxStorage.GetFolder("/DatabaseTransfar");
                                                    _dropBoxStorage.UploadFile(zipFilePath, uploadFolder, UploadProgressChange);
                                                    MessageBox.Show("Online Database Backup Successfully", SoftwareName, MessageBoxButton.OK,
                                                                    MessageBoxImage.Information);
                                                }
                                                catch (Exception)
                                                {
                                                    MessageBox.Show("Online Database Backup is canceled", SoftwareName, MessageBoxButton.OK, MessageBoxImage.Exclamation);
                                                    ResetData();
                                                }
                                                finally
                                                {
                                                    IsIndeterminate = true;
                                                    if (_dropBoxStorage.IsOpened)
                                                        _dropBoxStorage.Close();
                                                    if (File.Exists(path))
                                                        File.Delete(path);
                                                    if(!String.IsNullOrEmpty(zipFilePath) && File.Exists(zipFilePath))
                                                        File.Delete(zipFilePath);
                                                    IsEnable = true;
                                                    IsIndeterminate = false;
                                                }
                                            });
        }

        private async void OnlineRestoreExecute(string databaseName)
        {
            await Task.Factory.StartNew(() =>
                                            {
                                                var backupFilePath = string.Empty;
                                                var downloadedBackupFilePath = string.Empty;
                                                IsEnable = false;
                                                try
                                                {
                                                    IsIndeterminate = true;
                                                    GetDropBoxAccess();
                                                    IsIndeterminate = false;
                                                    var onlineFolder = _dropBoxStorage.GetFolder("/DatabaseTransfar");
                                                    var tempFolder = GetTempFolder();
                                                    _dropBoxStorage.DownloadFile(onlineFolder, databaseName, tempFolder, DownloadProcessChnage);
                                                    IsIndeterminate = true;
                                                    downloadedBackupFilePath = Path.Combine(tempFolder, databaseName);
                                                    var systemTempFolder = Environment.ExpandEnvironmentVariables("%temp%");
                                                    using (var archive = ArchiveFactory.Open(downloadedBackupFilePath))
                                                    {
                                                        foreach (var entry in archive.Entries.Where(entry => !entry.IsDirectory))
                                                        {
                                                            entry.WriteToDirectory(systemTempFolder, ExtractOptions.ExtractFullPath | ExtractOptions.Overwrite);
                                                        }
                                                    }
                                                    string fileName = Path.GetFileName(downloadedBackupFilePath);
                                                    if (fileName != null)
                                                    {
                                                        backupFilePath = Path.Combine(systemTempFolder, fileName.Replace("zip", "bak"));
                                                        DatabaseRestore(backupFilePath);
                                                        _dropBoxStorage.DeleteFileSystemEntry(string.Format("/DatabaseTransfar/{0}", databaseName));
                                                        GetBackupFiles();
                                                    }
                                                    IsEnable = true;
                                                    MessageBox.Show("Database Restore Successfully", SoftwareName, MessageBoxButton.OK, MessageBoxImage.Information);
                                                }
                                                catch (Exception)
                                                {
                                                    MessageBox.Show("Online Database Restore is canceled", SoftwareName, MessageBoxButton.OK, MessageBoxImage.Exclamation);
                                                    ResetData();
                                                }
                                                finally
                                                {
                                                    if (_dropBoxStorage.IsOpened)
                                                        _dropBoxStorage.Close();
                                                    if (!String.IsNullOrEmpty(downloadedBackupFilePath) && File.Exists(downloadedBackupFilePath))
                                                        File.Delete(downloadedBackupFilePath);
                                                    if(!String.IsNullOrEmpty(backupFilePath) && File.Exists(backupFilePath))
                                                        File.Delete(backupFilePath);
                                                    IsIndeterminate = false;
                                                }
                                            });
        }

        private bool OnlineRestoreCanExecute(string databaseName)
        {
            return !String.IsNullOrEmpty(databaseName);
        }

        private void OnlineBackupRestoreCancelExecute()
        {
            IsCancel = true;
            IsEnable = true;
        }

        private bool OnlineBackupRestoreCancelCanExecute()
        {
            return !IsEnable;
        }

        private void OnlineBackupListRefreshExecute()
        {
            GetBackupFiles();
        }

        private async void GetBackupFiles()
        {
            await Task.Factory.StartNew(() =>
                                            {
                                                try
                                                {
                                                    IsBusy = true;
                                                    FileInformationses = new ObservableCollection<FileInformation>();
                                                    GetDropBoxAccess();
                                                    var onlineFolder = _dropBoxStorage.GetFolder("/DatabaseTransfar");
                                                    foreach (var file in onlineFolder)
                                                    {
                                                        var file1 = file;
                                                        Application.Current.Dispatcher.BeginInvoke(new Action(() => FileInformationses.Add(new FileInformation
                                                                                                                                               {
                                                                                                                                                   FileActualName = Regex.Replace(file1.Name, @"(\d{2})(\d{2})(\d{4})(\d{2})(\d{2})(\w{2}).((\w{3}))", "$1-$2-$3 $4:$5$6"),
                                                                                                                                                   FileName = file1.Name
                                                                                                                                               })));
                                                    }
                                                }
                                                catch (Exception)
                                                {
                                                     MessageBox.Show("An Error Occurs.\nPlease Check your Internet Connection", SoftwareName, MessageBoxButton.OK, MessageBoxImage.Exclamation);
                                                }
                                                finally
                                                {
                                                    if(_dropBoxStorage.IsOpened)
                                                       _dropBoxStorage.Close();
                                                    IsBusy = false;
                                                }
                                            });
        }

        private void GetDropBoxAccess()
        {
            _dropBoxStorage = new CloudStorage();
            var dropBoxConfig = CloudStorage.GetCloudConfigurationEasy(nSupportedCloudConfigurations.DropBox);
            ICloudStorageAccessToken accessToken;
            using (var fs = File.Open("Accesstoken.txt", FileMode.Open, FileAccess.Read, FileShare.None))
            {
                accessToken = _dropBoxStorage.DeserializeSecurityToken(fs);
            }
            _dropBoxStorage.Open(dropBoxConfig, accessToken);
        }

        private void UploadProgressChange(Object sender, FileDataTransferEventArgs e)
        {
            e.Cancel = IsCancel;
            UploadProgress = e.PercentageProgress;
        }

        private void DownloadProcessChnage(Object sender, FileDataTransferEventArgs e)
        {
            e.Cancel = IsCancel;
            DownloadProgress = e.PercentageProgress;
        }

        #region SharpBox

        #endregion

        #region Helper

        private string DatabaseBackup(string path = null)
        {
            try
            {
                if (String.IsNullOrEmpty(path))
                {
                    path = GetTempFolder();
                }

                using (
                    var backupConnection =
                        new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=master;Integrated Security=True"))
                {
                    backupConnection.Open();
                    var useMasterCommand = new SqlCommand("USE master", backupConnection);
                    useMasterCommand.ExecuteNonQuery();
                    string backupPath = Path.Combine(path, GetBackupFileName());
                    string alter1 = string.Format(@"BACKUP DATABASE {0} TO DISK = '{1}'",
                                                  CatalogName, backupPath);
                    var alter1Cmd = new SqlCommand(alter1, backupConnection);
                    alter1Cmd.ExecuteNonQuery();
                    alter1Cmd.Dispose();
                    return backupPath;
                }
            }
            catch (Exception exception)
            {
                Logger.Error(exception.Message);
                MessageBox.Show("Unable to database backup.", SoftwareName, MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }

        private void DatabaseRestore(string path)
        {
            try
            {
                using (
                    var restoreConnection =
                        new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=master;Integrated Security=True"))
                {
                    restoreConnection.Open();
                    var useMasterCommand = new SqlCommand("USE master", restoreConnection);
                    useMasterCommand.ExecuteNonQuery();
                    string alter1 = string.Format(@"ALTER DATABASE [{0}] SET Single_User WITH Rollback Immediate",
                                                  CatalogName);
                    var alter1Cmd = new SqlCommand(alter1, restoreConnection);
                    alter1Cmd.ExecuteNonQuery();
                    alter1Cmd.Dispose();
                    string restore = string.Format(@"RESTORE DATABASE [{0}] FROM DISK = N'{1}' WITH REPLACE",
                                                   CatalogName, path);
                    var restoreCmd = new SqlCommand(restore, restoreConnection);
                    restoreCmd.ExecuteNonQuery();
                    restoreCmd.Dispose();
                    string alter2 = string.Format(@"ALTER DATABASE [{0}] SET Multi_User", CatalogName);
                    var alter2Cmd = new SqlCommand(alter2, restoreConnection);
                    alter2Cmd.ExecuteNonQuery();
                    alter2Cmd.Dispose();
                }
            }
            catch (Exception exception)
            {
                Logger.Error(exception.Message);
                MessageBox.Show("Unable to restore Database", SoftwareName, MessageBoxButton.OK, MessageBoxImage.Error);
                try
                {
                    using (
                        var restoreConnection =
                            new SqlConnection(
                                @"Data Source=.\SQLEXPRESS;Initial Catalog=master;Integrated Security=True"))
                    {
                        restoreConnection.Open();
                        string alter2 = string.Format(@"ALTER DATABASE [{0}] SET Multi_User",
                                                      CatalogName);
                        var alter2Cmd = new SqlCommand(alter2, restoreConnection);
                        alter2Cmd.ExecuteNonQuery();
                        alter2Cmd.Dispose();
                    }
                }
                catch (Exception exc)
                {
                    MessageBox.Show("Serious error ! Contract admin.\n" + exc.Message, SoftwareName, MessageBoxButton.OK,
                                    MessageBoxImage.Error);
                }
            }
        }

        private string GetBackupFileName()
        {
            return string.Format("{0}.bak", DateTime.Now.ToString("ddMMyyyyhhsstt"));
        }

        private string GetTempFolder()
        {
            string tempFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            tempFolder = Path.Combine(tempFolder, "RhGDatabaseBackupRestore");
            if (!Directory.Exists(tempFolder))
                Directory.CreateDirectory(tempFolder);
            return tempFolder;
        }

        private void ResetData()
        {
            IsEnable = true;
            IsCancel = false;
            UploadProgress = 0;
            DownloadProgress = 0;
            if (_dropBoxStorage.IsOpened)
                _dropBoxStorage.Close();
        }

        #endregion

         ~DatabaseRestoreBackupVm()
        {
            if (_dropBoxStorage.IsOpened)
                _dropBoxStorage.Close();
        }
    }

    public class FileInformation
    {
        public string FileName { get; set; }
        public string FileActualName { get; set; }
    }
}