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
//Dont need newtonsoft.json.jsonconvert.. just jsosnconvert
using Newtonsoft.Json;

namespace _312576json
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            System.IO.StreamReader sr = new System.IO.StreamReader("json.txt");
            try
            {
                Dictionary<string, string> items = 
                JsonConvert.DeserializeObject<Dictionary<string, string>>(sr.ReadToEnd());
                MessageBox.Show(items["name"] + " lives in " + items["city"]);

                foreach (string s in items.Keys)
                {
                    MessageBox.Show(s + ": " + items[s]);
                }
                items["name"] = "Robert";
                string newVersion = JsonConvert.SerializeObject(items);
                sr.Close();
                System.IO.StreamWriter writer = new System.IO.StreamWriter("json.txt");
                writer.Write(newVersion);
                writer.Flush();
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }
    }
}
