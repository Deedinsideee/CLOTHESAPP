using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace CLOTHESAPP
{
    public partial class START : Form
    {
        int i = 0;




        string connectionstring = "Data Source=UBER-MASHINA;Initial Catalog=APPDB;Integrated Security=True";
        public START()
        {
           
            InitializeComponent();
           
        }
        Dictionary<int, string> clothes = new Dictionary<int, string>();
        int idodjdi=0;
        private void button1_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            button2.Visible = false;
            Graphics g = Graphics.FromHwnd(Handle);
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageSize = new Size(200, 200);

            DirectoryInfo dir = new DirectoryInfo(@"C:\img\body");

            foreach (FileInfo file in dir.EnumerateFiles("*.jpg"))
            {
                


                imageList1.Images.Add(Bitmap.FromFile("\\img\\body\\" + file.Name));
               

            }


            int x = 10;
            int y = 10;


            int count = 0;
            for (i = 0; i < imageList1.Images.Count; i++)
            {
                Button button = new Button();


                if (x==10 && y==10 )
                {

                    //кнопка
                    button.Left = x + 65;
                    button.Top = y + 200;
                    button.Text = "нажми  ";

                    this.Controls.Add(button);
                    button.Name = Convert.ToString(i);

                    button.Click += ButtonOnClickbody;
                    //конец кнопки 

                    imageList1.Draw(g, new Point(x, y), i);
                    count += 1;
                    x += 1;

                   
                }

                else if (x < 2000 && count<4)
                {
                    x += 255;
                    //кнопка
                    button.Left = x + 65;
                    button.Top = y + 200;
                    this.Controls.Add(button);
                    button.Text = "нажми  ";
                    button.Name =  Convert.ToString(i);
                    button.Click += ButtonOnClickbody;
                    //конец кнопки 

                    imageList1.Draw(g, new Point(x, y), i);
                    count += 1;

                }
                else
                {
                    count = 0;
                    x = 10;
                    y += 270;

                    //кнопка
                    button.Left = x + 65;
                    button.Top = y + 200;
                    this.Controls.Add(button);
                    button.Text = "нажми  ";
                    button.Name = Convert.ToString(i);
                    button.Click += ButtonOnClickbody;
                    //конец кнопки 
                    imageList1.Draw(g, new Point(x, y), i);
                    count += 1;
                }
            }
        }

        private void ButtonOnClickbody(object sender, EventArgs eventArgs)
        {
            var button = (Button)sender;
            string abc = button.Name;


            int idshnik = Convert.ToInt32(abc);
            int schet = 0;


            DirectoryInfo dir = new DirectoryInfo(@"C:\img\body");
            foreach (FileInfo file in dir.EnumerateFiles("*.jpg"))
            {
                if (schet == idshnik)
                {
                    idodjdi += 1;
                    clothes.Add(idodjdi, file.Name);
                }
                schet += 1;
            }

            MessageBox.Show(clothes[idodjdi]);

            Controls.Clear();
            imageList1.Images.Clear();

            DirectoryInfo dirlegs = new DirectoryInfo(@"C:\img\legs");

            Graphics g = Graphics.FromHwnd(Handle);

            foreach (FileInfo file in dirlegs.EnumerateFiles("*.jpg"))
            {



                imageList1.Images.Add(Bitmap.FromFile("\\img\\legs\\" + file.Name));


            }


            int x = 10;
            int y = 10;


            int count = 0;
            for (i = 0; i < imageList1.Images.Count; i++)
            {
                Button buttonlegs = new Button();


                if (x == 10 && y == 10)
                {

                    //кнопка
                    buttonlegs.Left = x + 65;
                    buttonlegs.Top = y + 200;
                    buttonlegs.Text = "нажми  ";

                    this.Controls.Add(buttonlegs);
                    buttonlegs.Name = Convert.ToString(i);

                    buttonlegs.Click += ButtonOnCliclegs;
                    //конец кнопки 

                    imageList1.Draw(g, new Point(x, y), i);
                    count += 1;
                    x += 1;


                }

                else if (x < 2000 && count < 4)
                {
                    x += 255;
                    //кнопка
                    buttonlegs.Left = x + 65;
                    buttonlegs.Top = y + 200;
                    this.Controls.Add(buttonlegs);
                    buttonlegs.Text = "нажми  ";
                    buttonlegs.Name = Convert.ToString(i);
                    buttonlegs.Click += ButtonOnCliclegs;
                    //конец кнопки 

                    imageList1.Draw(g, new Point(x, y), i);
                    count += 1;

                }
                else
                {
                    count = 0;
                    x = 10;
                    y += 270;

                    //кнопка
                    buttonlegs.Left = x + 65;
                    buttonlegs.Top = y + 200;
                    this.Controls.Add(buttonlegs);
                    buttonlegs.Text = "нажми  ";
                    buttonlegs.Name = Convert.ToString(i);
                    buttonlegs.Click += ButtonOnCliclegs;
                    //конец кнопки 
                    imageList1.Draw(g, new Point(x, y), i);
                    count += 1;
                }
            }


        }

        private void ButtonOnCliclegs(object sender, EventArgs eventArgs)
        {
            var button = (Button)sender;
            string abc = button.Name;


            int idshnik = Convert.ToInt32(abc);
            int schet = 0;


            DirectoryInfo dir = new DirectoryInfo(@"C:\img\legs");
            foreach (FileInfo file in dir.EnumerateFiles("*.jpg"))
            {
                if (schet == idshnik)
                {
                    idodjdi += 1;
                    clothes.Add(idodjdi , file.Name);
                }
                schet += 1;
            }

            MessageBox.Show(clothes[idodjdi ]);

            Controls.Clear();
            imageList1.Images.Clear();

            DirectoryInfo dirshoes = new DirectoryInfo(@"C:\img\shoes");

            Graphics g = Graphics.FromHwnd(Handle);

            foreach (FileInfo file in dirshoes.EnumerateFiles("*.jpg"))
            {



                imageList1.Images.Add(Bitmap.FromFile("\\img\\shoes\\" + file.Name));


            }


            int x = 10;
            int y = 10;


            int count = 0;
            for (i = 0; i < imageList1.Images.Count; i++)
            {
                Button buttonshoes = new Button();


                if (x == 10 && y == 10)
                {

                    //кнопка
                    buttonshoes.Left = x + 65;
                    buttonshoes.Top = y + 200;
                    buttonshoes.Text = "нажми  ";

                    this.Controls.Add(buttonshoes);
                    buttonshoes.Name = Convert.ToString(i);
                    buttonshoes.Click += ButtonOnClicshoes;
                    //конец кнопки 

                    imageList1.Draw(g, new Point(x, y), i);
                    count += 1;
                    x += 1;


                }

                else if (x < 2000 && count < 4)
                {
                    x += 255;
                    //кнопка
                    buttonshoes.Left = x + 65;
                    buttonshoes.Top = y + 200;
                    this.Controls.Add(buttonshoes);
                    buttonshoes.Text = "нажми  ";
                    buttonshoes.Name = Convert.ToString(i);
                    buttonshoes.Click += ButtonOnClicshoes;

                    //конец кнопки 

                    imageList1.Draw(g, new Point(x, y), i);
                    count += 1;

                }
                else
                {
                    count = 0;
                    x = 10;
                    y += 270;

                    //кнопка
                    buttonshoes.Left = x + 65;
                    buttonshoes.Top = y + 200;
                    this.Controls.Add(buttonshoes);
                    buttonshoes.Text = "нажми  ";
                    buttonshoes.Name = Convert.ToString(i);
                    buttonshoes.Click += ButtonOnClicshoes;

                    //конец кнопки 
                    imageList1.Draw(g, new Point(x, y), i);
                    count += 1;
                }
            }


        }

        private void ButtonOnClicshoes(object sender, EventArgs eventArgs)
        {
            var button = (Button)sender;
            string abc = button.Name;


            int idshnik = Convert.ToInt32(abc);
            int schet = 0;


            DirectoryInfo dir = new DirectoryInfo(@"C:\img\shoes");
            foreach (FileInfo file in dir.EnumerateFiles("*.jpg"))
            {
                if (schet == idshnik)
                {
                    idodjdi += 1;
                    clothes.Add(idodjdi, file.Name);
                }
                schet += 1;
            }

            MessageBox.Show(clothes[idodjdi]);


            string s = "";

            foreach (KeyValuePair<int, string> kvp in clothes)
                s += string.Format("Key = {0}, Value = {1}",
                    kvp.Key, kvp.Value) + Environment.NewLine;
                MessageBox.Show(s);

        }

    }
}
