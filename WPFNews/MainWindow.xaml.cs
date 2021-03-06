﻿using System;
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
using System.Xml;

namespace WPFNews
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

        XmlDocument doc = new XmlDocument();
        WorkWithInformation work = new WorkWithInformation();

        private void btnGet_Click(object sender, RoutedEventArgs e)
        {
            doc.Load("https://habrahabr.ru/rss/interesting/");
            var rootElement = doc.DocumentElement;

            foreach (XmlNode item in rootElement.ChildNodes)
            {
                foreach (XmlNode nodes in item.ChildNodes)
                {
                    if (nodes.Name == "title")
                        labelTitle.Text = nodes.InnerText;

                    else if (nodes.Name == "description")
                        labelDiscription.Text = nodes.InnerText;

                    else if (nodes.Name == "managingEditor")
                        labelManagingEditor.Text = nodes.InnerText;

                    else if (nodes.Name == "generator")
                        labelGenerator.Text = nodes.InnerText;

                    else if (nodes.Name == "pubDate")
                        labelPubDate.Text = nodes.InnerText;
                }
            }
        }

        private void btnFind_Click(object sender, RoutedEventArgs e)
        {
            work.GetInfoToLIst(doc);
            work.WriteInfoToFile();
            MessageBox.Show("There were generated" + work.count.ToString() + "news");
        }
    }
}
