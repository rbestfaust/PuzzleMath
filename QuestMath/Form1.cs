using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace QuestMath
{
    public partial class Form1 : Form
    {
        public int valueMax;
        public int valueMin;
        public  Boolean multiplication = true;
        public static int count = 0;
        public int commonCount;
        public string countText = $"Сегодня ты решил : {count.ToString()}";
        string path = @"C:\Users\Roman\Desktop\QuestMath\commonCount.txt";
        string path2 = @"C:\Users\Roman\Desktop\QuestMath\";

        string Print (int a , int b, bool multiplication)
        {
            
            string text = ($" {b.ToString()}  +  {a.ToString()}   =  ");
            string text2 = ($" {b.ToString()} -  {a.ToString()}   =  ");

            return multiplication ? label7.Text= text : label7.Text = text2;
            
        }

        

         void Level(int lvl)
        {

            if (progressBar1.Value == 100)
            {
                MessageBox.Show( $"Вы решили уже {count.ToString()} примеров!\n " +
                    "Этого достаточно для ребёнка!\n" +
                    "Но если не устали , продолжайте!!!", "Умничка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                progressBar1.Value = 0;
            }

            Random random = new Random();
            
            (int, int) value = (0, 0);
            int min, max;
            button2.Enabled = true;
            switch (lvl)
            {
                case 1:
                    value = (random.Next(0, 8), random.Next(9, 50));
                    min = value.Item1;
                    max = value.Item2;
                    valueMax = value.Item2;
                    valueMin = value.Item1;
                    Print(min,max, multiplication);
                    break;
                case 2:
                    value = (random.Next(15, 50), random.Next(51, 150));
                    min = value.Item1;
                    max = value.Item2;
                    valueMax = value.Item2;
                    valueMin = value.Item1;
                    Print(min, max, multiplication);
                    break;


                case 3:

                    value = (random.Next(20, 90), random.Next(91, 300));
                    min = value.Item1;
                    max = value.Item2;
                    valueMax = value.Item2;
                    valueMin = value.Item1;
                    Print(min, max, multiplication);
                    break;

                case 4:

                    value = (random.Next(75, 195), random.Next(200, 500));
                    min = value.Item1;
                    max = value.Item2;
                    valueMax = value.Item2;
                    valueMin = value.Item1;
                    Print(min, max, multiplication);
                    break;



            }
        }

        public Form1()
        {
            InitializeComponent();
            this.ActiveControl = textBox1;
            textBox1.Focus();

           
        }

       async public void AnimText (int text)
        {
            char[] Text1 = label1.Text.ToCharArray();
            char[] Text3 = label3.Text.ToCharArray();
            char[] Text2 = label2.Text.ToCharArray();

            switch (text)
            {
                case 1:

                    label1.Text = "";
                    await Task.Delay(50);
                    foreach (var item in Text1)
                    {
                        label1.Text += item;
                        await Task.Delay(20);
                    }
                    break;

                case 3:

                    label3.Text = "";
                    await Task.Delay(50);
                    foreach (var item in Text3)
                    {
                        label3.Text += item;
                        await Task.Delay(20);
                    }
                    break;

                case 2:

                    label2.Text = "";
                    await Task.Delay(50);
                    foreach (var item in Text2)
                    {
                        label2.Text += item;
                        await Task.Delay(20);
                    }
                    break;

            }

            
        }


        
            
       async private void Form1_Load(object sender, EventArgs e)
        {


            if (File.Exists(path))
            {
                using (StreamReader readCount = File.OpenText(path))
                {

                    commonCount = Convert.ToInt32(readCount.ReadLine());
                }
                label8.Text =  $"Решено за все время : {commonCount.ToString()}"; 
            }
            else
            {
                DirectoryInfo createDir = new DirectoryInfo(path2);
                
                createDir.Create();
                

                using (StreamWriter createCount = File.CreateText(path))
                {
                    createCount.WriteLine("0");
                }
                label8.Text = $"Решено за все время : {commonCount.ToString()}";
            }


            label1.Text = "Давай давай учиться)))";
            label2.Text = "В это окошко нужно вводить ответы >>>";
            button1.Text = "Дальше";
            label4.Text = "";
            label5.Text = "";
            button2.Enabled = false;
            label6.Text = countText;
            
            label7.Text = "";
            progressBar1.Value = 0;

            if (commonCount < 5)
            {
                await Task.Delay(1000);

                AnimText(1);

                await Task.Delay(3000);

                AnimText(3);

                await Task.Delay(3000);

                AnimText(2);
            }
            

        }

        

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                checkBox2.Enabled = false;
                checkBox3.Enabled = false;
                checkBox4.Enabled = false;
                Level(1);
                label2.Text = "";

                button2.Enabled = true;
                button1.Enabled = false;
            }
            else
            {
                checkBox2.Enabled = true;
                checkBox3.Enabled = true;
                button2.Enabled = false;
                checkBox4.Enabled = true;
            }
            
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                checkBox1.Enabled = false;
                checkBox3.Enabled = false;
                checkBox4.Enabled = false;
                Level(2);
                label2.Text = "";

                button2.Enabled = true;
                button1.Enabled = false;
            }
            else
            {
                checkBox1.Enabled = true;
                checkBox3.Enabled = true;
                button2.Enabled = false;
                checkBox4.Enabled = true;
            }
            
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                checkBox2.Enabled = false;
                checkBox1.Enabled = false;
                checkBox4.Enabled = false;
                Level(3);
                label2.Text = "";

                button2.Enabled = true;
                button1.Enabled = false;
            }
            else
            {
                checkBox2.Enabled = true;
                checkBox1.Enabled = true;
                button2.Enabled = false;
                checkBox4.Enabled = true;
            }
            
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
            {
                checkBox2.Enabled = false;
                checkBox1.Enabled = false;
                checkBox3.Enabled = false;
                Level(4);
                label2.Text = "";

                button2.Enabled = true;
                button1.Enabled = false;
            }
            else
            {
                checkBox2.Enabled = true;
                checkBox1.Enabled = true;
                checkBox3.Enabled = true;
                button2.Enabled = false;
            }
        }

     async  private void button1_Click(object sender, EventArgs e)
        {
            button1.Text = "Дальше";

            if (checkBox1.Checked == true)
            {
                Level(1);
                textBox1.Text = "";
                button1.Enabled = false;
            }
            else if (checkBox3.Checked == true)
            {
                Level(3);
                textBox1.Text = "";
                button1.Enabled = false;
            }

            else if (checkBox2.Checked == true)
            {
                Level(2);
                textBox1.Text = "";
                button1.Enabled = false;
            }
            else if (checkBox4.Checked == true)
            {
                Level(4);
                textBox1.Text = "";
                button1.Enabled = false;
            }

            else
                label4.Text = "Вы не выбрали уровень сложности!!!";
            await Task.Delay(800);
            label4.Text =  "";
        }

        

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            label1.Text = " Удачи Козявка)))";
            label2.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int result=0 ;
            try { result = Convert.ToInt32(textBox1.Text); }
            catch {
                MessageBox.Show("Вы что-то ввели не то. \nВозможные варианты \n\n " +
             "\t - пробел ;\n" +
             "\t - буквы ;\n" +
             "\t - а может просто нечего не ввели.\n\n" +
             "Вводить нужно только правильный ответ , \nцифрами без букв и пробелов :))",
             "Ну как так то ???" ,MessageBoxButtons.OK , MessageBoxIcon.Information );
                textBox1.Text = "";
                textBox1.Focus();
            }
            
            

            if (multiplication)
            {
                if (valueMax + valueMin == result)
                {
                    button1.Enabled = true;
                    label5.Text = "Верно";
                    count++;

                    using (StreamWriter addToCommonCount = File.CreateText(path))
                    {
                        addToCommonCount.WriteLine(commonCount + count);
                        label8.Text = $"Решено за все время: {(commonCount + count).ToString()}"; 
                    }

                    countText = $"Сегодня ты решил : {count.ToString()}";
                    label6.Text = countText;
                    button2.Enabled = false;
                    multiplication = count % 2 == 0 ? true : false;

                    if (progressBar1.Value != 100)
                        progressBar1.Value += 10;
                }
                else
                {
                    button1.Enabled = false;
                    label5.Text = "Ошибка";
                    textBox1.Text = "";
                    textBox1.Focus();
                }
            }
            else
            {
                if (valueMax - valueMin == result)
                {
                    button1.Enabled = true;
                    label5.Text = "Верно";
                    count++;

                    using (StreamWriter addToCommonCount = File.CreateText(path))
                    {
                        addToCommonCount.WriteLine(commonCount + count);
                        label8.Text = $"Решено за все время: {(commonCount + count).ToString()}";
                    }


                    if (progressBar1.Value != 100)
                        progressBar1.Value += 10;

                    countText = $"Сегодня ты решил : {count.ToString()}";
                    label6.Text = countText;
                    button2.Enabled = false;
                    multiplication = count % 2 == 0 ? true : false;

                }
                else
                {
                    button1.Enabled = false;
                    label5.Text = "Ошибка";
                    textBox1.Text = "";
                    textBox1.Focus();
                }
            }

             
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

         void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Enter)
            {

                button2.PerformClick();
               
                button1.Focus();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        
    }
}
