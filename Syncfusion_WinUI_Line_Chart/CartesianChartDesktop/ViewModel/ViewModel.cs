using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartesianChartDesktop
{
    public class ViewModel
    {
        public ObservableCollection<Model> Data { get; set; }

        public ViewModel()
        {
            Data = new ObservableCollection<Model>()
            {
                new Model("1925", 415),
                new Model("1926", 408),
                new Model("1927", 415),
                new Model("1928", 350),
                new Model("1929", 375),
                new Model("1930", 500),
                new Model("1931", 390),
                new Model("1932", 450),

            };
        }
    }
}
