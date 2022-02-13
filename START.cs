using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows;
using Newtonsoft.Json;

namespace CLOTHESAPP
{
    public partial class START : Form
    {
        int i = 0;




        string connectionstring = "Data Source=UBER-MASHINA;Initial Catalog=APPDB;Integrated Security=True";
        public START()
        {

            InitializeComponent();
            try
            {
                loooks = File.ReadLines("dict.txt").Select(line => line.Split('\t')).Where(arr => arr.Length == 2).ToDictionary(arr => arr[0], arr => arr[1]);
            }
            catch
            {

            }


            
            try
            {
                puti = JsonConvert.DeserializeObject<Dictionary<string, DirectoryInfo>>(File.ReadAllText("puti.json"));
            }
            catch
            {

            }
           




        }
        List<string> clothes = new List<string>(16);


        Dictionary<string, DirectoryInfo> puti = new Dictionary<string, DirectoryInfo>();

        Dictionary<string, string> loooks = new Dictionary<string, string>();
        int idodjdi = 0;




        private void button1_Click(object sender, EventArgs e)
        {
            button4.Visible = false;
            button3.Visible = true;
            imageList1.Images.Clear();

            Graphics g = Graphics.FromHwnd(Handle);

            Color col = Color.Pink;
            g.Clear(Color.Pink);
            clothes.Clear();
            button1.Visible = false;
            button2.Visible = false;
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageSize = new Size(256, 256);
            
            
            DirectoryInfo dir = puti["body"];


            foreach (FileInfo file in dir.EnumerateFiles())
            {



                imageList1.Images.Add(Bitmap.FromFile(dir+ "\\" + file.Name));


            }

            int x = 10;
            int y = 10;


            int count = 0;
            for (i = 0; i < imageList1.Images.Count; i++)
            {
                Button button = new Button();


                if (x == 10 && y == 10)
                {

                    //кнопка
                    button.Left = x + 45;
                    button.Top = y + 175;
                    button.Text = "нажми  ";

                    button.Name = Convert.ToString(i);
                    this.Controls.Add(button);
                    button.Click += ButtonOnClickbody;

                    button.Click += yadebil;
                    //конец кнопки 

                    imageList1.Draw(g, new Point(x, y), i);
                    count += 1;
                    x += 1;


                }

                else if (x < 2000 && count < 6)
                {
                    x += 266;
                    //кнопка
                    button.Left = x + 45;
                    button.Top = y + 175;
                    button.Text = "нажми  ";
                    button.Name = Convert.ToString(i);
                    button.Click += yadebil;
                    button.Click += ButtonOnClickbody;
                    this.Controls.Add(button);

                    //конец кнопки 

                    imageList1.Draw(g, new Point(x, y), i);
                    count += 1;

                }
                else
                {
                    count = 0;
                    x = 10;
                    y += 276;

                    //кнопка
                    button.Left = x + 45;
                    button.Top = y + 175;
                    this.Controls.Add(button);
                    button.Text = "нажми  ";
                    button.Name = Convert.ToString(i);
                    button.Click += yadebil;
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


            DirectoryInfo dir = puti["body"];

            foreach (FileInfo file in dir.EnumerateFiles())
            {
                if (schet == idshnik)
                {

                    clothes.Add(file.Name);
                }
                schet += 1;
            }


          
            imageList1.Images.Clear();

            DirectoryInfo dirlegs = puti["legs"];


            Graphics g = Graphics.FromHwnd(Handle);
            Color col = Color.Pink;
            g.Clear(Color.Pink);
            foreach (FileInfo file in dirlegs.EnumerateFiles("*.jpg"))
            {



                imageList1.Images.Add(Bitmap.FromFile(dirlegs+"\\" + file.Name));


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
                    buttonlegs.Click += yadebil;

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
                    buttonlegs.Click += yadebil;
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
                    buttonlegs.Click += yadebil;
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




            DirectoryInfo dir = puti["legs"];
            foreach (FileInfo file in dir.EnumerateFiles("*.jpg"))
            {
                if (schet == idshnik)
                {
                    idodjdi += 1;
                    clothes.Add(file.Name);
                }
                schet += 1;
            }



           
            imageList1.Images.Clear();

            DirectoryInfo dirshoes = puti["shoes"];

            Graphics g = Graphics.FromHwnd(Handle);
            Color col = Color.Pink;
            g.Clear(Color.Pink);
            foreach (FileInfo file in dirshoes.EnumerateFiles("*.jpg"))
            {



                imageList1.Images.Add(Bitmap.FromFile(dirshoes + "\\" + file.Name));


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

                    buttonshoes.Click += yadebil;
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
                    buttonshoes.Click += yadebil;

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
                    buttonshoes.Click += yadebil;

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
            
            DirectoryInfo dir = puti["shoes"];
            foreach (FileInfo file in dir.EnumerateFiles("*.jpg"))
            {
                if (schet == idshnik)
                {
                    idodjdi += 1;
                    clothes.Add(file.Name);
                }
                schet += 1;
            }




           


           
            imageList1.Images.Clear();
            imageList1.ImageSize = new Size(256, 256);
            Graphics g = Graphics.FromHwnd(Handle);

            Color col = Color.Pink;
            g.Clear(Color.Pink);

            string new_name = "";
            foreach (string opa in clothes)
            {
                new_name = new_name + opa;
            }
            new_name = new_name + ".jpg";
           
            DirectoryInfo dirlooks = puti["looks"];
            try
            {
                string per = loooks[new_name];

                imageList1.Images.Add(Bitmap.FromFile(dirlooks + "\\" + per));
                imageList1.Draw(g, new Point(650, 250), 0);

            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("к сожалению такое отсутствует");
            }



        }





        private void button2_Click(object sender, EventArgs e)
        {
            button4.Visible = false;
            button3.Visible = true;
            imageList1.Images.Clear();

            Graphics g = Graphics.FromHwnd(Handle);

            Color col = Color.Pink;
            g.Clear(Color.Pink);
            clothes.Clear();
            button1.Visible = false;
            button2.Visible = false;
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageSize = new Size(200, 200);
            
            DirectoryInfo dir = puti["body"];


            foreach (FileInfo file in dir.EnumerateFiles("*.jpg"))
            {



                imageList1.Images.Add(Bitmap.FromFile(dir + "\\" + file.Name));


            }

            int x = 10;
            int y = 10;


            int count = 0;
            for (i = 0; i < imageList1.Images.Count; i++)
            {
                Button button_vibor_body = new Button();


                if (x == 10 && y == 10)
                {

                    //кнопка
                    button_vibor_body.Left = x + 65;
                    button_vibor_body.Top = y + 200;
                    button_vibor_body.Text = "нажми  ";

                    this.Controls.Add(button_vibor_body);
                    button_vibor_body.Name = Convert.ToString(i);
                    button_vibor_body.Click += yadebil;

                    button_vibor_body.Click += ButtonOnClick_vibor_looks_body;
                    //конец кнопки 

                    imageList1.Draw(g, new Point(x, y), i);
                    count += 1;
                    x += 1;


                }

                else if (x < 2000 && count < 4)
                {
                    x += 255;
                    //кнопка
                    button_vibor_body.Left = x + 65;
                    button_vibor_body.Top = y + 200;
                    this.Controls.Add(button_vibor_body);
                    button_vibor_body.Text = "нажми  ";
                    button_vibor_body.Name = Convert.ToString(i);
                    button_vibor_body.Click += yadebil;

                    button_vibor_body.Click += ButtonOnClick_vibor_looks_body;
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
                    button_vibor_body.Left = x + 65;
                    button_vibor_body.Top = y + 200;
                    this.Controls.Add(button_vibor_body);
                    button_vibor_body.Text = "нажми  ";
                    button_vibor_body.Name = Convert.ToString(i);
                    button_vibor_body.Click += yadebil;

                    button_vibor_body.Click += ButtonOnClick_vibor_looks_body;
                    //конец кнопки 
                    imageList1.Draw(g, new Point(x, y), i);
                    count += 1;
                }
            }



        }

        private void ButtonOnClick_vibor_looks_body(object sender, EventArgs eventArgs)
        {
            var button = (Button)sender;
            string abc = button.Name;


            int idshnik = Convert.ToInt32(abc);
            int schet = 0;


            DirectoryInfo dir = puti["body"];
            foreach (FileInfo file in dir.EnumerateFiles("*.jpg"))
            {
                if (schet == idshnik)
                {

                    clothes.Add(file.Name);
                }
                schet += 1;
            }

            

            imageList1.Images.Clear();

            DirectoryInfo dirlegs = puti["legs"];

            Graphics g = Graphics.FromHwnd(Handle);
            Color col = Color.Pink;
            g.Clear(Color.Pink);

            foreach (FileInfo file in dirlegs.EnumerateFiles("*.jpg"))
            {



                imageList1.Images.Add(Bitmap.FromFile(dirlegs + "\\" + file.Name));


            }


            int x = 10;
            int y = 10;


            int count = 0;
            for (i = 0; i < imageList1.Images.Count; i++)
            {
                Button button_vibor_legs = new Button();


                if (x == 10 && y == 10)
                {

                    //кнопка
                    button_vibor_legs.Left = x + 65;
                    button_vibor_legs.Top = y + 200;
                    button_vibor_legs.Text = "нажми  ";

                    this.Controls.Add(button_vibor_legs);
                    button_vibor_legs.Name = Convert.ToString(i);
                    button_vibor_legs.Click += yadebil;

                    button_vibor_legs.Click += ButtonOnClick_vibor_looks_legs;
                    //конец кнопки 

                    imageList1.Draw(g, new Point(x, y), i);
                    count += 1;
                    x += 1;


                }

                else if (x < 2000 && count < 4)
                {
                    x += 255;
                    //кнопка
                    button_vibor_legs.Left = x + 65;
                    button_vibor_legs.Top = y + 200;
                    this.Controls.Add(button_vibor_legs);
                    button_vibor_legs.Text = "нажми  ";
                    button_vibor_legs.Name = Convert.ToString(i);
                    button_vibor_legs.Click += yadebil;

                    button_vibor_legs.Click += ButtonOnClick_vibor_looks_legs;
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
                    button_vibor_legs.Left = x + 65;
                    button_vibor_legs.Top = y + 200;
                    this.Controls.Add(button_vibor_legs);
                    button_vibor_legs.Text = "нажми  ";
                    button_vibor_legs.Name = Convert.ToString(i);
                    button_vibor_legs.Click += yadebil;

                    button_vibor_legs.Click += ButtonOnClick_vibor_looks_legs;
                    //конец кнопки 
                    imageList1.Draw(g, new Point(x, y), i);
                    count += 1;
                }
            }


        }

        private void ButtonOnClick_vibor_looks_legs(object sender, EventArgs eventArgs)
        {
            var button = (Button)sender;
            string abc = button.Name;


            int idshnik = Convert.ToInt32(abc);
            int schet = 0;


            DirectoryInfo dir = puti["legs"];
            foreach (FileInfo file in dir.EnumerateFiles("*.jpg"))
            {
                if (schet == idshnik)
                {
                    idodjdi += 1;
                    clothes.Add(file.Name);
                }
                schet += 1;
            }

          

            imageList1.Images.Clear();

            DirectoryInfo dirshoes = puti["shoes"];

            Graphics g = Graphics.FromHwnd(Handle);
            Color col = Color.Pink;
            g.Clear(Color.Pink);

            foreach (FileInfo file in dirshoes.EnumerateFiles("*.jpg"))
            {



                imageList1.Images.Add(Bitmap.FromFile(dirshoes + "\\" + file.Name));


            }


            int x = 10;
            int y = 10;


            int count = 0;
            for (i = 0; i < imageList1.Images.Count; i++)
            {
                Button button_vibor_shoes = new Button();


                if (x == 10 && y == 10)
                {

                    //кнопка
                    button_vibor_shoes.Left = x + 65;
                    button_vibor_shoes.Top = y + 200;
                    button_vibor_shoes.Text = "нажми  ";

                    this.Controls.Add(button_vibor_shoes);
                    button_vibor_shoes.Name = Convert.ToString(i);

                    button_vibor_shoes.Click += yadebil;

                    button_vibor_shoes.Click += ButtonOnClick_vibor_looks_shooes;
                    //конец кнопки 

                    imageList1.Draw(g, new Point(x, y), i);
                    count += 1;
                    x += 1;


                }

                else if (x < 2000 && count < 4)
                {
                    x += 255;
                    //кнопка
                    button_vibor_shoes.Left = x + 65;
                    button_vibor_shoes.Top = y + 200;
                    this.Controls.Add(button_vibor_shoes);
                    button_vibor_shoes.Text = "нажми  ";
                    button_vibor_shoes.Name = Convert.ToString(i);
                    button_vibor_shoes.Click += yadebil;

                    button_vibor_shoes.Click += ButtonOnClick_vibor_looks_shooes;

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
                    button_vibor_shoes.Left = x + 65;
                    button_vibor_shoes.Top = y + 200;
                    this.Controls.Add(button_vibor_shoes);
                    button_vibor_shoes.Text = "нажми  ";
                    button_vibor_shoes.Name = Convert.ToString(i);
                    button_vibor_shoes.Click += yadebil;

                    button_vibor_shoes.Click += ButtonOnClick_vibor_looks_shooes;

                    //конец кнопки 
                    imageList1.Draw(g, new Point(x, y), i);
                    count += 1;
                }
            }


        }

        private void ButtonOnClick_vibor_looks_shooes(object sender, EventArgs eventArgs)
        {
            var button = (Button)sender;
            string abc = button.Name;


            int idshnik = Convert.ToInt32(abc);
            int schet = 0;


            DirectoryInfo dir = puti["shoes"];
            foreach (FileInfo file in dir.EnumerateFiles("*.jpg"))
            {
                if (schet == idshnik)
                {
                    idodjdi += 1;
                    clothes.Add(file.Name);
                }
                schet += 1;
            }

            
            DirectoryInfo dirlooks = puti["looks"];
            System.Windows.Forms.MessageBox.Show("теперь укажи что именно то что ты навыбирала");

            Graphics g = Graphics.FromHwnd(Handle);
            Color col = Color.Pink;
            g.Clear(Color.Pink);
            imageList1.Images.Clear();
            foreach (FileInfo file in dirlooks.EnumerateFiles("*.jpg"))
            {



                imageList1.Images.Add(Bitmap.FromFile(dirlooks + "\\" + file.Name));


            }

            int x = 10;
            int y = 10;


            int count = 0;
            for (i = 0; i < imageList1.Images.Count; i++)
            {
                Button button_vibor_looks = new Button();


                if (x == 10 && y == 10)
                {

                    //кнопка
                    button_vibor_looks.Left = x + 65;
                    button_vibor_looks.Top = y + 200;
                    button_vibor_looks.Text = "нажми  ";
                    button_vibor_looks.Click += ButtonOnClick_looks;

                    this.Controls.Add(button_vibor_looks);
                    button_vibor_looks.Name = Convert.ToString(i);

                    //конец кнопки 

                    imageList1.Draw(g, new Point(x, y), i);
                    count += 1;
                    x += 1;


                }

                else if (x < 2000 && count < 4)
                {
                    x += 255;
                    //кнопка
                    button_vibor_looks.Left = x + 65;
                    button_vibor_looks.Top = y + 200;
                    this.Controls.Add(button_vibor_looks);
                    button_vibor_looks.Text = "нажми  ";
                    button_vibor_looks.Name = Convert.ToString(i);
                    button_vibor_looks.Click += ButtonOnClick_looks;

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
                    button_vibor_looks.Left = x + 65;
                    button_vibor_looks.Top = y + 200;
                    this.Controls.Add(button_vibor_looks);
                    button_vibor_looks.Text = "нажми  ";
                    button_vibor_looks.Name = Convert.ToString(i);
                    button_vibor_looks.Click += ButtonOnClick_looks;
                    //конец кнопки 
                    imageList1.Draw(g, new Point(x, y), i);
                    count += 1;
                }
            }

            dir = null;



        }

        private void ButtonOnClick_looks(object sender, EventArgs eventArgs)
        {

            var button = (Button)sender;
            string abc = button.Name;


            int idshnik = Convert.ToInt32(abc);
            int schet = 0;


            DirectoryInfo dir = puti["looks"];
            foreach (FileInfo file in dir.EnumerateFiles("*.jpg"))
            {
                if (schet == idshnik)
                {
                    idodjdi += 1;
                    clothes.Add(file.Name);
                }
                schet += 1;
            }

            string per = clothes[3];
            clothes.Remove(per);
            string new_name = "";
            foreach (string opa in clothes)
            {
                new_name = new_name + opa;
            }
            new_name = new_name + ".jpg";
            try
            {

                loooks.Add(new_name, per);
                using (var writer = new StreamWriter("dict.txt"))
                {
                    foreach (var kvp in loooks)
                    {
                        writer.WriteLine($"{kvp.Key}\t{kvp.Value}");
                    }
                    System.Windows.Forms.MessageBox.Show("запись сделана");
                }
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("к сожалению такое уже записано попробуй заново");

            }
            //Запись

            
            //конец записи



           




        }





        private void yadebil(object sender, EventArgs e)
        {
            int i = 0;
            var salmons = new List<Control>();

            foreach (Control ctrl in this.Controls)
            {

                if (ctrl.Name == Convert.ToString(i))
                {
                    salmons.Add(ctrl);
                    i++;
                    
                }
            }
            foreach (Control ctrl in salmons)
                this.Controls.Remove(ctrl);
           
            

        }



        private void kekw(object sender, EventArgs e)
        {

            clothes.Clear();

            Graphics g = Graphics.FromHwnd(Handle);

            Color col = Color.Pink;
            g.Clear(Color.Pink);
            button1.Visible = true;
            button2.Visible = true;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int i = 0;
            var salmons = new List<Control>();

            foreach (Control ctrl in this.Controls)
            {

                if (ctrl.Name == Convert.ToString(i))
                {
                    salmons.Add(ctrl);
                    i++;

                }
            }
            foreach (Control ctrl in salmons)
                this.Controls.Remove(ctrl);
            salmons.Clear();
            foreach (Control ctrl in this.Controls)
            {

                if (ctrl.Name == "body" || ctrl.Name == "legs" || ctrl.Name == "shoes" || ctrl.Name == "looks")
                {
                    salmons.Add(ctrl);
                    i++;

                }
            }
            foreach (Control ctrl in salmons)
                this.Controls.Remove(ctrl);
            salmons.Clear();
            clothes.Clear();
            button3.Visible = false;
            Graphics g = Graphics.FromHwnd(Handle);

            Color col = Color.Pink;
            g.Clear(Color.Pink);
            button1.Visible = true;
            button2.Visible = true;
            button4.Visible = true;
        }

      

        private void putdofailov(object sender, EventArgs e)
        {
            DialogResult result = fbd.ShowDialog();
            if (result == DialogResult.OK)
            {
                DirectoryInfo dir = new DirectoryInfo(fbd.SelectedPath);

            }

        }

        private void button4_Click(object sender, EventArgs e)
        {   

            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = true;
            button4.Visible = false;
            int x = 277;
            int y = 182;

            //кнопка для бади
            this.Controls.Add(new TextBox() { Name = "body", Location = new Point(x + 80, y - 20), Text = "путь для футболочек", Enabled = false, Width = 110 });
            Button button_put_body = new Button();
            button_put_body.Width = 290;
            button_put_body.Height = 147;
            button_put_body.Left = x; 
            button_put_body.Top = y;
            button_put_body.Text = "нажми  ";
            this.Controls.Add(button_put_body);
            button_put_body.Name = "body";
            button_put_body.Click += put_do_body;

            //конец кнопки под бади

            x =x + 295;

            //кнопка для легс 
            this.Controls.Add(new TextBox() { Name = "legs", Location = new Point(x + 80, y - 20), Text = "путь для штанов", Enabled = false, Width = 110 });
            Button button_put_legs = new Button();
            button_put_legs.Width = 290;
            button_put_legs.Height = 147;
            button_put_legs.Left = x;
            button_put_legs.Top = y ;
            button_put_legs.Text = "нажми  ";
            this.Controls.Add(button_put_legs);
            button_put_legs.Name = "legs";
            button_put_legs.Click += put_do_legs;
            //конец кнопки под лекс

            x =x + 295;

            //кнопка для шус
            this.Controls.Add(new TextBox() { Name = "shoes", Location = new Point(x + 80, y - 20), Text = "путь для ботинок", Enabled = false, Width = 110 });
            Button button_put_shoes = new Button();
            button_put_shoes.Width = 290;
            button_put_shoes.Height = 147;
            button_put_shoes.Left = x ;
            button_put_shoes.Top = y;
            button_put_shoes.Text = "нажми  ";
            this.Controls.Add(button_put_shoes);
            button_put_shoes.Name = "shoes";
            button_put_shoes.Click += put_do_shoes;
            //конец кнопки под шус

            x = x + 295;

            //кнопка для луков
            this.Controls.Add(new TextBox() { Name = "looks", Location = new Point(x + 80, y - 20), Text = "путь для луков", Enabled = false, Width = 110 });
            Button button_put_looks = new Button();
            button_put_looks.Width = 290;
            button_put_looks.Height = 147;
            button_put_looks.Left = x ;
            button_put_looks.Top = y;
            button_put_looks.Text = "нажми  ";
            this.Controls.Add(button_put_looks);
            button_put_looks.Name = "looks";
            button_put_looks.Click += put_do_looks;
            //конец кнопки под луки 
        }

        private void put_do_body(object sender, EventArgs e)
        {
            DialogResult result = fbd.ShowDialog();
            if (result == DialogResult.OK)
            {
                DirectoryInfo dir = new DirectoryInfo(fbd.SelectedPath);
                
                try
                {
                    puti.Add("body", dir);

                    File.WriteAllText("puti.json", JsonConvert.SerializeObject(puti));


                    /*using (var writer = new StreamWriter("puti.txt"))
                    {
                        foreach (var kvp in puti)
                        {
                            writer.WriteLine($"{kvp.Key}\t{kvp.Value}");
                        }
                    }*/
                }
                catch
                {

                    string messageBoxText = "Такой путь уже существует, хочешь указать новый ?";
                    string caption = "Word Processor";
                    MessageBoxButtons button = MessageBoxButtons.YesNo;
                    MessageBoxIcon icon = MessageBoxIcon.Warning;
                    MessageBoxResult resultasd = (MessageBoxResult)System.Windows.Forms.MessageBox.Show(messageBoxText, caption, button, icon);
                    switch (resultasd)
                    {
                        case MessageBoxResult.Yes:
                            puti.Remove("body");
                            puti.Add("body", dir);
                            File.WriteAllText("puti.json", JsonConvert.SerializeObject(puti));
                            break;
                        case MessageBoxResult.No:

                            break;

                    }


                }
            }

        }

        private void put_do_legs(object sender, EventArgs e)
        {
            DialogResult result = fbd.ShowDialog();
            if (result == DialogResult.OK)
            {
                DirectoryInfo dir = new DirectoryInfo(fbd.SelectedPath);
                try
                {
                    puti.Add("legs", dir);
                    File.WriteAllText("puti.json", JsonConvert.SerializeObject(puti));
                }
                catch
                {

                    string messageBoxText = "Такой путь уже существует, хочешь указать новый ?";
                    string caption = "Word Processor";
                    MessageBoxButtons button = MessageBoxButtons.YesNo;
                    MessageBoxIcon icon = MessageBoxIcon.Warning;
                    MessageBoxResult resultasd = (MessageBoxResult)System.Windows.Forms.MessageBox.Show(messageBoxText, caption, button, icon);
                    switch (resultasd)
                    {
                        case MessageBoxResult.Yes:
                            puti.Remove("legs");
                            puti.Add("legs", dir);
                            File.WriteAllText("puti.json", JsonConvert.SerializeObject(puti));
                            break;
                        case MessageBoxResult.No:

                            break;

                    }


                }
            }
        }

        private void put_do_shoes(object sender, EventArgs e)
        {
            DialogResult result = fbd.ShowDialog();
            if (result == DialogResult.OK)
            {
                DirectoryInfo dir = new DirectoryInfo(fbd.SelectedPath);
                try
                {
                    puti.Add("shoes", dir);
                    File.WriteAllText("puti.json", JsonConvert.SerializeObject(puti));
                }
                catch
                {
                    
                    string messageBoxText = "Такой путь уже существует, хочешь указать новый ?";
                    string caption = "Word Processor";
                    MessageBoxButtons button = MessageBoxButtons.YesNo;
                    MessageBoxIcon icon = MessageBoxIcon.Warning;
                    MessageBoxResult resultasd = (MessageBoxResult)System.Windows.Forms.MessageBox.Show(messageBoxText, caption, button, icon);
                    switch (resultasd)
                    {
                        case MessageBoxResult.Yes:
                            puti.Remove("shoes");
                            puti.Add("shoes", dir);
                            File.WriteAllText("puti.json", JsonConvert.SerializeObject(puti));
                            break;
                        case MessageBoxResult.No:
                            
                            break;
                        
                    }


                }
            }
        }

        private void put_do_looks(object sender, EventArgs e)
        {
            DialogResult result = fbd.ShowDialog();
            if (result == DialogResult.OK)
            {
                DirectoryInfo dir = new DirectoryInfo(fbd.SelectedPath);
                try
                {
                    puti.Add("looks", dir);
                    File.WriteAllText("puti.json", JsonConvert.SerializeObject(puti));
                }
                catch
                {

                    string messageBoxText = "Такой путь уже существует, хочешь указать новый ?";
                    string caption = "Word Processor";
                    MessageBoxButtons button = MessageBoxButtons.YesNo;
                    MessageBoxIcon icon = MessageBoxIcon.Warning;
                    MessageBoxResult resultasd = (MessageBoxResult)System.Windows.Forms.MessageBox.Show(messageBoxText, caption, button, icon);
                    switch (resultasd)
                    {
                        case MessageBoxResult.Yes:
                            puti.Remove("looks");
                            puti.Add("looks", dir);
                            File.WriteAllText("puti.json", JsonConvert.SerializeObject(puti));
                            break;
                        case MessageBoxResult.No:

                            break;

                    }


                }
            }
        }

    }
}

        

    





        










