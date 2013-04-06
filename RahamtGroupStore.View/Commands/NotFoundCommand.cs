using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
namespace RahamtGroupStore.View.Commands
{
    class NotFoundCommand :ICommand
    {
        public string Name { get; set; }
        public void Execute()
        {
            MessageBox.Show(string.Format("Couldn`t find command {0}", Name));
        }
    }
}
