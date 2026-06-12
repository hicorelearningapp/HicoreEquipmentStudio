using HicoreEquipmentStudio.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HicoreEquipmentStudio.View
{
    /// <summary>
    /// Interaction logic for EquipmentInformation.xaml
    /// </summary>
    public partial class EquipmentInformation : UserControl
    {
        public EquipmentInformation()
        {
            InitializeComponent();
            DataContext = ViewModelStore.Instance.EquipmentInfoViewModel;
        }
    }
}
