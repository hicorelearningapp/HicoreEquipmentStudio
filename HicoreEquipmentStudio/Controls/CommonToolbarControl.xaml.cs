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

namespace HicoreEquipmentStudio.Controls
{
    /// <summary>
    /// Interaction logic for CommonToolbarControl.xaml
    /// </summary>
    public partial class CommonToolbarControl : UserControl
    {
        public CommonToolbarControl()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty AddCommandProperty =
     DependencyProperty.Register(
         nameof(AddCommand),
         typeof(ICommand),
         typeof(CommonToolbarControl));

        public ICommand AddCommand
        {
            get => (ICommand)GetValue(AddCommandProperty);
            set => SetValue(AddCommandProperty, value);
        }

        public static readonly DependencyProperty EditCommandProperty =
            DependencyProperty.Register(
                nameof(EditCommand),
                typeof(ICommand),
                typeof(CommonToolbarControl));

        public ICommand EditCommand
        {
            get => (ICommand)GetValue(EditCommandProperty);
            set => SetValue(EditCommandProperty, value);
        }

        public static readonly DependencyProperty DeleteCommandProperty =
            DependencyProperty.Register(
                nameof(DeleteCommand),
                typeof(ICommand),
                typeof(CommonToolbarControl));

        public ICommand DeleteCommand
        {
            get => (ICommand)GetValue(DeleteCommandProperty);
            set => SetValue(DeleteCommandProperty, value);
        }

        public static readonly DependencyProperty ImportCommandProperty =
    DependencyProperty.Register(
        nameof(ImportCommand),
        typeof(ICommand),
        typeof(CommonToolbarControl));

        public ICommand ImportCommand
        {
            get => (ICommand)GetValue(ImportCommandProperty);
            set => SetValue(ImportCommandProperty, value);
        }

        public static readonly DependencyProperty ExportCommandProperty =
            DependencyProperty.Register(
                nameof(ExportCommand),
                typeof(ICommand),
                typeof(CommonToolbarControl));

        public ICommand ExportCommand
        {
            get => (ICommand)GetValue(ExportCommandProperty);
            set => SetValue(ExportCommandProperty, value);
        }

        public static readonly DependencyProperty ValidateCommandProperty =
            DependencyProperty.Register(
                nameof(ValidateCommand),
                typeof(ICommand),
                typeof(CommonToolbarControl));

        public ICommand ValidateCommand
        {
            get => (ICommand)GetValue(ValidateCommandProperty);
            set => SetValue(ValidateCommandProperty, value);
        }
    }
}
