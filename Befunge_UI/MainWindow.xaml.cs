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

namespace Befunge_UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.codeArea.Text.Length % 80 == 0)
            {
                this.codeArea.Text += "\n";
                this.codeArea.SelectionStart = this.codeArea.Text.Length - 1;
            }
        }

        private void codeArea_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (this.codeArea.Text.Length != 0 && this.codeArea.Text.Length % 81 == 0)
            {
                for (int i = 1; i < this.codeArea.Text.Length; i++)
                {
                    if (i % 80 == 0)
                    {
                        this.codeArea.TextChanged -= this.codeArea_TextChanged;
                        this.codeArea.Text += "\n";
                        this.codeArea.SelectionStart = this.codeArea.Text.Length - 1;
                        this.codeArea.TextChanged += this.codeArea_TextChanged;
                    }
                }
            }
        }
    }
}
