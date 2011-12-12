using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using System.IO;

namespace HostHelper
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

        private void onLoad(object sender, RoutedEventArgs e)
        {
            loadContent();
        }

        void loadContent()
        {
            try
            {
                textBox.Text = loadHostFileContent();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        void saveContent()
        {
            try
            {
                saveHostFileContent(textBox.Text);
                MessageBox.Show("成功");
            }
            catch (System.Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        string loadHostFileContent()
        {
            string hostFilePath = System.IO.Path.Combine(Environment.SystemDirectory, @"drivers\etc\hosts");
            string content = File.ReadAllText(hostFilePath);
            return content;
        }

        void saveHostFileContent(string content)
        {
            string hostFilePath = System.IO.Path.Combine(Environment.SystemDirectory, @"drivers\etc\hosts");
            File.WriteAllText(hostFilePath, content);
        }

        private void loadButton_Click(object sender, RoutedEventArgs e)
        {
            loadContent();
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            saveContent();
        }
    }
}
