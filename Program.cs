using System.Windows.Forms;
using System.Drawing;
using System;

ApplicationConfiguration.Initialize();

var form = new Form();
form.WindowState = FormWindowState.Maximized; // tamanho da aba
form.FormBorderStyle = FormBorderStyle.None; // deixa full screen

PictureBox pb = new PictureBox(); // componente para colocar imagens
pb.Dock = DockStyle.Fill;
pb.Image = Image.FromFile("jequiti.png");
pb.SizeMode = PictureBoxSizeMode.Zoom;

form.Controls.Add(pb);

var show = false;

var timer = new Timer();
timer.Interval = 200;
timer.Tick += delegate
{

    if(show)
    {
        form.Hide();
        show = false;
    }

    var rand = Random.Shared;
    if (rand.Next(100) < 2)
    {
        form.Show();
        show = true;
    }

};

form.Load += delegate
{
    form.Hide();
    timer.Start();
};

form.KeyDown += (s, e) =>
{
    if (e.KeyCode == Keys.Escape)
        Application.Exit();
};

Application.Run(form);