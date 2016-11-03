using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StageMaker
{
    public partial class ImageCutterForm : Form
    {
        private Bitmap source;
        public int x { get; private set; }
        public int y { get; private set; }
        public int width { get; private set; }
        public int height { get; private set; }
        public string type { get; private set; }
        public string imagePath { get; private set; }

        public ImageCutterForm()
        {
            InitializeComponent();
            this.numericUpDown1.ValueChanged += new EventHandler(crop);
            this.numericUpDown2.ValueChanged += new EventHandler(crop);
            this.numericUpDown3.ValueChanged += new EventHandler(crop);
            this.numericUpDown4.ValueChanged += new EventHandler(crop);
        }

        private void initializeForms()
        {
            numericUpDown1.Value = numericUpDown1.Minimum;
            numericUpDown2.Value = numericUpDown2.Minimum;
            textBox1.Text = String.Empty;
            if (source != null)
            {
                numericUpDown1.Maximum = source.Width;
                numericUpDown2.Maximum = source.Height;
                numericUpDown3.Maximum = source.Width;
                numericUpDown4.Maximum = source.Height;
                numericUpDown3.Value = source.Width;
                numericUpDown4.Value = source.Height;
                this.pictureBox1.Image = new Bitmap(source);
            }
        }

        private void crop(object sender, EventArgs e)
        {
            if(source != null)
            {
                int x = (int)numericUpDown1.Value;
                int y = (int)numericUpDown2.Value;
                int width = (int)numericUpDown3.Value;
                int height = (int)numericUpDown4.Value;
                Rectangle section = new Rectangle(x, y, width, height);
                Bitmap croppedBitmap = CropImage(new Bitmap(source), section);
                this.pictureBox1.Image = croppedBitmap;
            }
        }

        public Bitmap CropImage(Bitmap source, Rectangle section)
        {
            Bitmap bmp = new Bitmap(section.Width, section.Height);
            Graphics g = Graphics.FromImage(bmp);
            g.DrawImage(source, 0, 0, section, GraphicsUnit.Pixel);
            return bmp;
        }

        private void button1_Click(object sender, EventArgs e) //set image
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "png files (*.png)|*.png|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            DialogResult r = openFileDialog1.ShowDialog();
            if(r == DialogResult.OK)
            {
                source = new Bitmap(openFileDialog1.FileName);
                imagePath = openFileDialog1.FileName;
                initializeForms();
            }
        }

        private void button3_Click(object sender, EventArgs e) //reset values
        {
            initializeForms();
        }

        private void button2_Click(object sender, EventArgs e) //add new enemy type
        {
            type = textBox1.Text;
            if(type == null || type == String.Empty)
            {
                MessageBox.Show("Le nom du type d'ennemi n'a pas de valeur.", "Erreur");
            }
            else if(imagePath == null)
            {
                MessageBox.Show("L'image n'a pas été choisie", "Erreur");
            }
            else
            {
                x = (int)numericUpDown1.Value;
                y = (int)numericUpDown2.Value;
                width = (int)numericUpDown3.Value;
                height = (int)numericUpDown4.Value;
                DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
