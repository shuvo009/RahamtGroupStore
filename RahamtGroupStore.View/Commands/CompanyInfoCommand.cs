using System;
using System.Windows.Controls;
using RahamtGroupStore.View.Views;
using System.Threading.Tasks;
namespace RahamtGroupStore.View.Commands
{
    public class CompanyInfoCommand : ICommandFactory, ICommand
    {
        #region ICommand Members

        public void Execute()
        {
            ContentPre.Content = new CompanyInformationView();
        }

        #endregion

        #region ICommandFactory Members

        public string CommandName
        {
            get { return "CompanyInfoSetup"; }
        }
        public ContentPresenter ContentPre { get; set; }

        public ICommand MakeCommand(ContentPresenter contentPresenter)
        {
            return new CompanyInfoCommand { ContentPre = contentPresenter };
        }

        #endregion
    }
}