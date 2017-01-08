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

namespace MCustomControls
{
    /// <summary>
    /// Interaction logic for ModernPasswordField.xaml
    /// </summary>
    public partial class ModernPasswordField : UserControl
    {
        public ModernPasswordField()
        {
            InitializeComponent();
        }

        private void Field_OnGotFocus(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Field_OnLostFocus(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
