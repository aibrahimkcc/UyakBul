using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using CsvHelper;
using System.Globalization;

namespace UyakBul
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public class Person
        {

            public string Column1 { get; set; }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            listBox4.Items.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            listBox4.Items.Clear();
            string filePath = @"TDK.csv";
            StreamReader reader = new StreamReader(filePath);

            // harfler içinde var mı?
            using (var csv = new CsvHelper.CsvReader(reader, new CsvHelper.Configuration.CsvConfiguration(CultureInfo.InvariantCulture)))
            {
                var records = csv.GetRecords<Person>().ToList();

                // Filter records based on textBox1.Text
                var filteredRecords = records.Where(k => k.Column1.Contains(textBox1.Text)).ToList();

                // Add filtered records to listBox5
                foreach (var record in filteredRecords)
                {
                    listBox2.Items.Add(record.Column1); // Assuming you're interested in adding the name
                }

                // Filter records based on textBox1.Text
                var filteredRecordsEndsWith = records.Where(k => k.Column1.EndsWith(textBox1.Text)).ToList();

                // Add filtered records to listBox5
                foreach (var record in filteredRecordsEndsWith)
                {
                    listBox1.Items.Add(record.Column1); // Assuming you're interested in adding the name
                }
            }
            // Aranan harflerin içinde bulunduğu kelimelerden oluşan bir array oluşturur.
            int itemCount = listBox2.Items.Count;
            string[] itemsArray = new string[itemCount];
            for (int i = 0; i < itemCount; i++)
            {
                itemsArray[i] = listBox2.Items[i].ToString();


            }
            //aranan sıralı harflarin kelimenin hangi son harfine denk geleceği bilgisini alır.
            int iindex = Convert.ToInt16(textBox2.Text);
            foreach (string item in itemsArray)
            {
                int kelimenLength = (item.Length);//Aranılan kelime uzunluğu
                int uyaklength = (textBox1.Text.Length);//aranılan harflerin uzunluğu
                if (uyaklength + iindex > kelimenLength)
                {
                    continue;
                }
                // eğer aranılan harflerin tamamını bulursa x'in değeri aranılan harf sayısı kadar olacaktır ki bu doğrulama sayesinde bulunan kelime listeye yazdırılır.
                int x = 0;
                for (int j = 0; j < uyaklength; j++)
                {
 
                    //ilk seferinde aranılan harflerin sonuncusun değerini döndürür.
                    //ilk seferinde son harfin olması istenilen indexdeki harfi döndürür.
                    // harf sayısınca bu işlem devam eder.
                    //Ali Keçecinin ilk algoritması!
                    if (textBox1.Text[(uyaklength - 1 - j)] == item[kelimenLength - 1 - iindex - j])
                    {
                        x++;
                    }
                }
                
                if (x == uyaklength)
                {
                    listBox3.Items.Add(item);
                }




            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "listBox1")
            {
                foreach (var item in listBox1.Items)
                {
                    // Convert item to a string (or appropriate type)
                    string itemText = item.ToString();
                    if (itemText.Length == Convert.ToInt16(textBox3.Text))
                    {
                        listBox4.Items.Add(itemText);
                    }

                }
            }
            if (comboBox1.Text == "listBox2")
            {
                foreach (var item in listBox2.Items)
                {
                    // Convert item to a string (or appropriate type)
                    string itemText = item.ToString();
                    if (itemText.Length == Convert.ToInt16(textBox3.Text))
                    {
                        listBox4.Items.Add(itemText);
                    }

                }
            }
            if (comboBox1.Text == "listBox3")
            {
                foreach (var item in listBox3.Items)
                {
                    // Convert item to a string (or appropriate type)
                    string itemText = item.ToString();
                    if (itemText.Length == Convert.ToInt16(textBox3.Text))
                    {
                        listBox4.Items.Add(itemText);
                    }

                }
            }

        }
    }
}
