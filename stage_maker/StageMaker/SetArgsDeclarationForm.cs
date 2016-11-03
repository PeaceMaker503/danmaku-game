using StageMaker.utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static StageMaker.spell_maker.models.Value;

namespace StageMaker
{
    public partial class SetArgsDeclarationForm : Form
    {
        private readonly int MARGIN = 12;
        private readonly int OFFSET_SPACE_TEXBOX_Y = 2;
        private readonly int SPACE_LINES = 30;
        public string[] args { get; private set; }
        private List<TextBox> textboxes;

        private void validate(object sender, EventArgs e)
        {
            args = new string[textboxes.Count];
            int i = 0;
            foreach(TextBox t in textboxes)
            {
                args[i] = t.Text;
                i++;
            }

            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cancel(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        public SetArgsDeclarationForm(Dictionary<string, Types> args)
        {
            InitializeComponent();
            textboxes = new List<TextBox>(); ;
            List<Label> labels = new List<Label>();
            Button buttonValidate = new Button();
            buttonValidate.AutoSize = true;
            buttonValidate.Name = "Validate";
            buttonValidate.Text = "Validate";
            buttonValidate.Visible = true;

            Button buttonCancel = new Button();
            buttonCancel.AutoSize = true;
            buttonCancel.Name = "Cancel";
            buttonCancel.Text = "Cancel";
            buttonCancel.Visible = true;

            buttonValidate.Click += new EventHandler(validate);
            buttonCancel.Click += new EventHandler(cancel);

            int maxWidth = 0;
            int i = 0;
            foreach(string key in args.Keys)
            {
                var label = new Label();
                label.AutoSize = true;
                label.Name = key;
                label.Text = key + ": (" + StringHelper.TypesEnumToString(args[key]) + ")";
                label.Location = new Point(MARGIN, MARGIN + OFFSET_SPACE_TEXBOX_Y + (SPACE_LINES * i));
                label.Visible = true;

                var txt = new TextBox();
                txt.Name = key;
                txt.Text = String.Empty;
                txt.Location = new Point(12 + label.PreferredWidth, MARGIN + (SPACE_LINES * i));
                txt.Visible = true;

                maxWidth = Math.Max(maxWidth, label.PreferredWidth);
                textboxes.Add(txt);
                labels.Add(label);
                i++;
            }

            buttonValidate.Location = new Point(MARGIN + maxWidth, MARGIN + labels.Count * SPACE_LINES);
            buttonCancel.Location = new Point(buttonValidate.Location.X + buttonValidate.PreferredSize.Width + MARGIN, MARGIN + labels.Count * SPACE_LINES);

            int j = 0;
            foreach (Label l in labels)
            {
                l.Location = new Point(l.Location.X + maxWidth - l.PreferredWidth, l.Location.Y);
                textboxes[j].Location = new Point(MARGIN + maxWidth, textboxes[j].Location.Y);
                textboxes[j].Width = buttonValidate.PreferredSize.Width + buttonCancel.PreferredSize.Width + MARGIN;
                this.Controls.Add(l);
                this.Controls.Add(textboxes[j]);
                j++;
            }

            this.Controls.Add(buttonValidate);
            this.Controls.Add(buttonCancel);

            this.Width = 4 * MARGIN + maxWidth + textboxes[0].Width;
            this.Height = 4 * MARGIN + (labels.Count + 1) * (SPACE_LINES);
        }
    }
}
