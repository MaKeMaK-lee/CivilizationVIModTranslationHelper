using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Xml;

namespace CivilizationVIModTranslationHelper
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool isLoagingXML = false;
        bool isSomethingTriggered = false;


        private Brush tmpBackground;
        private string choosedFileName = "";
        private string choosedFilePath = "";
        private string pickedLanguage = "";
        private string exampleLanguage = "";
        private string status = "";




        public string Status
        {
            get => status;
            set
            {
                status = value;
                RefreshInfo();
            }
        }
        public string ChoosedFileName
        {
            get => choosedFileName;
            set
            {
                choosedFileName = value;
                RefreshInfo();
            }
        }
        public string ExampleLanguage
        {
            get => exampleLanguage;
            set
            {
                exampleLanguage = value;
                RefreshInfo();
            }
        }
        public string PickedLanguage
        {
            get => pickedLanguage;
            set
            {
                pickedLanguage = value;
                RefreshInfo();
            }
        }


        public readonly string HowTo = "Карач.\n" +
            "1. Выбрать файл.\n" +
            "2. Переводить из левого окна с любого языка, НО! На случай если кто-то набил в файл неполный перевод ранее, выбирается в качестве образца язык с наибольшим кол-вом строк (первый из них если их несколько). В окне информации показано какой именно.\n" +
            "3. Кнопка замены тупо заменит записи выбранного языка и сохранит в новый файл добавив в начало его названия тэг языка... Да, по сути это скорее копия а не замена. Да поебать мне.\n" +
            "4. Кнопка добавления добавит записи в файл.\n" +
            "5. Гц.\n" +
            "\n\n\n ВНИМАНИЕ! Багов может быть вагон :)), сохраняйте резервные копии файлов перед использованием! По крайней мере при использовании Add.";



        public MainWindow()
        {
            InitializeComponent();





            textBoxInfo.ToolTip = HowTo;


        }


        public void RefreshInfo()
        {
            textBoxInfo.Text = "";

            textBoxInfo.Text += $"Left: {textBoxLeft.LineCount:####} Right: {textBoxRight.LineCount:####}\n";
            textBoxInfo.Text += "\n";
            textBoxInfo.Text += $"Language example:\n{ExampleLanguage}\n";
            textBoxInfo.Text += "\n";


            textBoxInfo.Text += $"Language picked:\n{PickedLanguage}\n";

            textBoxInfo.Text += "\n";
            textBoxInfo.Text += $"{status}";

        }


        public async void SucsessTriggered(string status = "", int delay = 1000)
        {
            if (isSomethingTriggered)
                return;
            isSomethingTriggered = true;
            Status = status;
            tmpBackground = Background.Clone();
            Background = new SolidColorBrush(Color.FromArgb(200, 34, 139, 34));
            await Task.Delay(delay);
            Background = tmpBackground.Clone();
            Status = "";
            isSomethingTriggered = false;
        }
        public async void WarningTriggered(string status = "", int delay = 300)
        {
            if (isSomethingTriggered)
                return;
            isSomethingTriggered = true;
            Status = status;
            tmpBackground = Background.Clone();
            Background = new SolidColorBrush(Color.FromArgb(200, 255, 140, 0));
            await Task.Delay(delay);
            Background = tmpBackground.Clone();
            Status = "";
            isSomethingTriggered = false;
        }

        public void AddStringToLeft(string value)
        {
            textBoxLeft.Text += $"{value}\n";
        }

        public string ReadStringFromText(ref string text)
        {
            var mass = text.Split(new char[] { '\n' }, 2);
            if (mass.Count() > 1)
                text = mass[1];
            return mass[0];
        }




        private void ButtonChooseFileClick(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                if (openFileDialog.ShowDialog() == true)
                {


                    if (openFileDialog.Multiselect == true)
                    {
                        WarningTriggered("", 700);
                        MessageBox.Show("Multiselect is not supported. Please choose ONE file");
                        return;
                    }

                    isLoagingXML = true;


                    textBoxLeft.Text = "";

                    string xmlFileName;
                    string latestLang = ""; //zh_Hans_CN en_US ko_KR ja_JP ru_RU
                    string innerLang = "";
                    string biggerLang = "";
                    int countElementsInBiggerLang = 0;

                    List<XmlElement> willBeAddedElements = new List<XmlElement>();


                    xmlFileName = openFileDialog.FileName;

                    XmlDocument xDoc = new XmlDocument();
                    xDoc.Load(xmlFileName);

                    XmlElement root = xDoc.DocumentElement;

                    foreach (var locText in root.ChildNodes)
                    {
                        if ((locText as XmlElement).Name == "LocalizedText")
                        {
                            DateTime now = DateTime.Now;
                            string filename = $"text {now.Year}, {now.Month} {now.Day}, {now.Hour}.{now.Minute}.{now.Second}.{DateTime.Now.Millisecond}.txt";

                            int countElementsInLatestLang = 0;
                            foreach (var row in (locText as XmlElement).ChildNodes)
                            {
                                if (row is XmlElement)
                                    if ((row as XmlElement).Name == "Row")
                                    {
                                        if (latestLang != (row as XmlElement).Attributes.GetNamedItem("Language").Value)
                                        {
                                            countElementsInLatestLang = 0;
                                            latestLang = (row as XmlElement).Attributes.GetNamedItem("Language").Value;
                                            AddStringToLeft($"\tДля языка {latestLang}:");
                                        }

                                        if ((row as XmlElement).Attributes.GetNamedItem("Text") != null)
                                        {
                                            AddStringToLeft((row as XmlElement).Attributes.GetNamedItem("Text").Value.Trim());
                                        }
                                        else
                                        {
                                            foreach (var textNode in (row as XmlElement).ChildNodes)
                                            {
                                                if (textNode is XmlElement)
                                                    if ((textNode as XmlElement).Name == "Text")
                                                    {
                                                        AddStringToLeft((textNode as XmlElement).InnerText.Trim());
                                                    }
                                            }
                                        }

                                        countElementsInLatestLang++;

                                        if (countElementsInLatestLang > countElementsInBiggerLang)
                                        {
                                            countElementsInBiggerLang = countElementsInLatestLang;
                                            biggerLang = latestLang;
                                        }
                                    }
                            }




                        }
                    }
                    choosedFilePath = openFileDialog.InitialDirectory;
                    ExampleLanguage = biggerLang;
                    ChoosedFileName = xmlFileName;
                }
                else
                {
                    return;
                }


                RefreshInfo();
                SucsessTriggered("Import complete");
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
            finally
            {
                isLoagingXML = false;
            }
        }
        private void ButtonReplaceClick(object sender, RoutedEventArgs e)
        {
            //try
            //{
            if (ChoosedFileName == "" || ExampleLanguage == "")
            {
                return;
            }


            LanguagePickerWindow languagePickerWindow = new(this);
            var dr = languagePickerWindow.ShowDialog();
            if (dr == null)
                return;
            if (!dr.Value)
                return;



            string xmlFileName = ChoosedFileName;
            string text = textBoxRight.Text;

            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(xmlFileName);

            XmlElement root = xDoc.DocumentElement;

            foreach (var locText in root.ChildNodes)
            {
                if ((locText as XmlElement).Name == "LocalizedText")
                {
                    foreach (var row in (locText as XmlElement).ChildNodes)
                    {
                        if (row is XmlElement)
                        {
                            if ((row as XmlElement).Name == "Row")
                            {
                                if (ExampleLanguage == (row as XmlElement).Attributes.GetNamedItem("Language").Value)
                                {
                                    var tmpElement = (row as XmlElement);
                                    //Console.Write($"{tmpElement.Attributes.GetNamedItem("Text").Value} -> ");

                                    tmpElement.Attributes.GetNamedItem("Language").Value = PickedLanguage;


                                    bool isFoundTextNode = false;
                                    foreach (var textNode in tmpElement.ChildNodes)
                                    {
                                        if (textNode is XmlElement)
                                            if ((textNode as XmlElement).Name == "Text")
                                            {
                                                (textNode as XmlElement).InnerText = ReadStringFromText(ref text).Trim();
                                                isFoundTextNode = true;
                                            }
                                    }
                                    if (!isFoundTextNode)
                                        tmpElement.Attributes.GetNamedItem("Text").Value = ReadStringFromText(ref text).Trim();




                                    //willBeAddedElements.Add((XmlElement)tmpElement);
                                }
                            }
                        }
                    }
                }
            }

            //foreach (var n in willBeAddedElements)
            //    (locText as XmlElement).AppendChild(n);

            string outerFileName = xmlFileName.Remove(xmlFileName.Length - 4, 4);
            outerFileName += " to " + PickedLanguage + ".xml";
            xDoc.Save(outerFileName);
            SucsessTriggered($"Saved as\n{outerFileName.Split('\\').Last()}", 1500);

            //}
            //catch (Exception ee)
            //{
            //    MessageBox.Show(ee.Message);
            //}
        }
        private void ButtonAddClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ChoosedFileName == "" || ExampleLanguage == "")
                {
                    return;
                }

                LanguagePickerWindow languagePickerWindow = new(this);
                var dr = languagePickerWindow.ShowDialog();
                if (dr == null)
                    return;
                if (!dr.Value)
                    return;

                List<XmlElement> willBeAddedElements = new List<XmlElement>();
                string xmlFileName = ChoosedFileName;
                string text = textBoxRight.Text;

                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(xmlFileName);

                XmlElement root = xDoc.DocumentElement;

                foreach (var locText in root.ChildNodes)
                {
                    if ((locText as XmlElement).Name == "LocalizedText")
                    {
                        foreach (var row in (locText as XmlElement).ChildNodes)
                        {
                            if (row is XmlElement)
                            {
                                if ((row as XmlElement).Name == "Row")
                                {
                                    if (ExampleLanguage == (row as XmlElement).Attributes.GetNamedItem("Language").Value)
                                    {
                                        var tmpElement = (row as XmlElement).Clone();

                                        tmpElement.Attributes.GetNamedItem("Language").Value = PickedLanguage;


                                        bool isFoundTextNode = false;
                                        foreach (var textNode in tmpElement.ChildNodes)
                                        {
                                            if (textNode is XmlElement)
                                                if ((textNode as XmlElement).Name == "Text")
                                                {
                                                    (textNode as XmlElement).InnerText = ReadStringFromText(ref text).Trim();
                                                    isFoundTextNode = true;
                                                }
                                        }
                                        if (!isFoundTextNode)
                                            tmpElement.Attributes.GetNamedItem("Text").Value = ReadStringFromText(ref text).Trim();




                                        willBeAddedElements.Add((XmlElement)tmpElement);
                                    }
                                }
                            }
                        }
                        foreach (var n in willBeAddedElements)
                            (locText as XmlElement).AppendChild(n);



                        xDoc.Save(xmlFileName);
                        SucsessTriggered($"Saved as\n{xmlFileName.Split('\\').Last()}", 1500);
                    }
                }



            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void textBoxLeft_TextChanged(object sender, TextChangedEventArgs e)
        {



            if (!isLoagingXML)
                RefreshInfo();
        }

        private void textBoxRight_TextChanged(object sender, TextChangedEventArgs e)
        {

            if (!isLoagingXML)
                RefreshInfo();
        }
    }
}
