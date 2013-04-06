using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using RahamtGroupStore.View.Views;
namespace RahamtGroupStore.View.Commands
{
   public class CreateUserAccountCommand : ICommand,ICommandFactory
    {
       public void Execute()
       {
           ContentPre.Content = new CreateUserAccountView();
       }

       public string CommandName
       {
           get { return "CreateUseAccount"; }
       }
       public ContentPresenter ContentPre { get; set; }
       public ICommand MakeCommand(ContentPresenter contentPresenter)
       {
          return new CreateUserAccountCommand
                     {
                         ContentPre = contentPresenter
                     };
       }
    }
}
