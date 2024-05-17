using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
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

namespace Generator_ID
{
    public partial class MainWindow : Window
    {
        public int symbols_lenght;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.IsEnabled = false;
            if (count_symbols.Text != "")
            {
                try
                {
                    symbols_lenght = Convert.ToInt32(count_symbols.Text);
                    result_ID.Text = Receive_String(symbols_lenght);
                    Clipboard.SetText(result_ID.Text);
                    this.IsEnabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    this.IsEnabled = true;
                }
            }
            else
            {
                MessageBox.Show("Введите кол-во символов!");
                this.IsEnabled = true;
            }
        }
        public string Receive_String(int a)
        {
            Random rnd = new Random();

            string symbols = "AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz0123456789"; // 
            int i = 0;
            string result = "";
            while (i < a)
            {
                char c = symbols[rnd.Next(symbols.Length)];
                result += "" + c;
                i++;
            }
            return result;
        }
        private void Focused_On(object sender, RoutedEventArgs e)
        {
            count_symbols.Text = string.Empty;
        }
    }
}