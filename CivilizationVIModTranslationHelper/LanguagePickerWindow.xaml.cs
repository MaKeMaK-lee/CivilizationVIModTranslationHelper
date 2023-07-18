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
using System.Windows.Shapes;

namespace CivilizationVIModTranslationHelper
{
    /// <summary>
    /// Логика взаимодействия для LanguagePickerWindow.xaml
    /// </summary>
    public partial class LanguagePickerWindow : Window
    {
        public LanguagePickerWindow(Window owner)
        {
            InitializeComponent();

            Owner = owner;
        }

        private void CustomLangClick(object sender, RoutedEventArgs e)
        {
            (Owner as MainWindow).PickedLanguage = textBoxPickLang.Text;
            DialogResult = true;
            Close();
        }

        private void Button_Click_e(object sender, RoutedEventArgs e)
        {
            (Owner as MainWindow).PickedLanguage = "en_US";
            DialogResult = true;
            Close();
        }

        private void Button_Click_r(object sender, RoutedEventArgs e)
        {
            (Owner as MainWindow).PickedLanguage = "ru_RU";
            DialogResult = true;
            Close();
        }

        private void Button_Click_c(object sender, RoutedEventArgs e)
        {
            (Owner as MainWindow).PickedLanguage = "zh_Hans_CN";
            DialogResult = true;
            Close();
        }

        private void Button_Click_k(object sender, RoutedEventArgs e)
        {
            (Owner as MainWindow).PickedLanguage = "ko_KR";
            DialogResult = true;
            Close();
        }

        private void Button_Click_j(object sender, RoutedEventArgs e)
        {
            (Owner as MainWindow).PickedLanguage = "ja_JP";
            DialogResult = true;
            Close();
        }
    }
}
