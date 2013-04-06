using System.Windows;
using GalaSoft.MvvmLight.Command;
using RahamtGroupStore.View.Commands;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using System.ComponentModel;
namespace RahamtGroupStore.View.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private readonly IEnumerable<ICommandFactory> _abilableCommands;
        private bool _isBusy;
        public MainWindow()
        {
            InitializeComponent();
            _abilableCommands = GetCommands();
            MenuCommand = new RelayCommand<string>(MenuCommandExecute);
            DataContext = this;
        }

        public RelayCommand<string> MenuCommand { get; private set; }

        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                OnPeroertyChange("IsBusy");
            }
        }

        private async void MenuCommandExecute(string commandName)
        {
            IsBusy = true;
            await Task.Factory.StartNew(() =>
                                            {
                                                
                                                try
                                                {
                                                    var parser = new CommandParser(_abilableCommands);
                                                    var command = parser.ParseCommand(commandName, MainContentPresenter);
                                                    Application.Current.Dispatcher.BeginInvoke(new Action(command.Execute));

                                                }
                                                catch (Exception exception)
                                                {
                                                    MessageBox.Show(exception.Message);
                                                }
                                                finally
                                                {
                                                    IsBusy = false;
                                                }
                                            });

        }


        IEnumerable<ICommandFactory> GetCommands()
        {
            return new ICommandFactory[]
                       {
                           new BreakdownCauseCommand(),
                           new BreakdownTypeCommand(),
                           new CompanyInfoCommand(), 
                           new OrdinaryTypeCommand(), 
                           new UnitCommand(), 
                           new SectionCommand(), 
                           new RepairComanyCommand(), 
                           new SupplierCommand(), 
                           new MachineInstallationCommand(), 
                           new MachineBreakdownCommand(), 
                           new SparesSetupCommand(), 
                           new PurchaseCommand(), 
                           new IssueGoodsCommand(), 
                           new SendForRepair(), 
                           new SpareReceiveCommand(), 
                           new CardSetupCommand(), 
                           new CardTransactionCommand(),
                           new MachineListCommand(), 
                           new SparesHistoryCommand(), 
                           new FaultyListCommand(), 
                           new SpareListCommand(), 
                           new CardListCommand(), 
                           new CardHistoryCommand(), 
                           new StockRegisterCommand(), 
                           new SupplierListCommand(), 
                           new RepairCompanyListCommand(), 
                           new LoginCommand(), 
                           new ChangePasswordCommand(), 
                           new BackupRestoreCommand(), 
                           new SectionWiseIssueCommand(), 
                           new MachineLegerCommand(), 
                           new FaultHistoryCommand(), 
                           new UnitTypeCommand(),
                           new CreateUserAccountCommand()
                       };
        }

        #region On Property Chnaged
        public event PropertyChangedEventHandler PropertyChanged;
        protected internal void OnPeroertyChange(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

    }
}