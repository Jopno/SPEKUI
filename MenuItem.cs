using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Speku
{
    public class MenuItem
    {
        public MenuItem()
        {
            this.Items = new ObservableCollection<Henkilo>();
        }

        public string Title { get; set; }

        public ObservableCollection<Henkilo> Items { get; set; }

    }
}
