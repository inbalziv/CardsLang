using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace CardsLang
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        // public Dictionary<string, List<Card>> _dictList { get; set; }
        public AddLists _addLists;
        public void CloseAllWindows()
        {
            for (int intCounter = App.Current.Windows.Count - 1; intCounter > 0; intCounter--)
                App.Current.Windows[intCounter].Close();
        }
    }
}
