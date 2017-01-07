using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using JJ.Framework.Presentation.WinForms.Helpers;
using JJ.Framework.Presentation.WinForms.EventArg;
using JJ.Framework.Exceptions;

namespace JJ.Framework.Presentation.WinForms.Controls
{
    public partial class FilePathControl : UserControl
    {
        // TODO: Tooltip only works when TextBoxEnabled = true;

        public event EventHandler<FilePathEventArgs> Browsed;

        public FilePathControl()
        {
            _graphics = CreateGraphics();

            InitializeComponent();

            // HACK: To be able to see the file name for long file paths do not fit on screen, we make the text right aligned.
            // But TextAlign = HorizontalAlignment.Right does not work. It will only right align it if the text fits on screen!
            // Thank you WinForms.
            // The only reason I do this, is because the alternative, showing the full path as a tooltip,
            // does not work if the control is disabled!
            // Thank you WinForms.
            textBox.RightToLeft = RightToLeft.Yes;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            RequestPositionControls();
        }

        // Fields

        private FileDialog _fileDialog;
        private Graphics _graphics;

        // Properties

        public override string Text
        {
            get { return FilePath; }
            set { FilePath = value; }
        }

        public string LabelText
        {
            get { return label.Text; }
            set
            {
                if (label.Text == value) return;
                label.Text = value;
                RequestPositionControls();
            }
        }

        public string FilePath
        {
            get { return textBox.Text; }
            set { textBox.Text = value; }
        }

        private FileBrowseModeEnum _browseMode;
        public FileBrowseModeEnum BrowseMode
        {
            get { return _browseMode; }
            set { SetBrowseMode(value); }
        }

        private int _spacing;

        [DefaultValue(4)]
        public int Spacing
        {
            get { return _spacing; }
            set
            {
                if (_spacing == value) return;
                _spacing = value;
                RequestPositionControls();
            }
        }

        [DefaultValue(true)]
        public bool TextBoxEnabled
        {
            get { return textBox.Enabled; }
            set { textBox.Enabled = value; }
        }

        // Applying

        private void SetBrowseMode(FileBrowseModeEnum value)
        {
            switch (value)
            {
                case FileBrowseModeEnum.Open:
                    _fileDialog = new OpenFileDialog();
                    break;

                case FileBrowseModeEnum.Save:
                    _fileDialog = new SaveFileDialog();
                    break;

                default:
                    throw new InvalidValueException(value);
            }

            _browseMode = value;
        }

        // Gui

        private void RequestPositionControls()
        {
            if (timerPositionControls == null) return;

            timerPositionControls.Enabled = true;
        }

        private void timerPositionControls_Tick(object sender, EventArgs e)
        {
            PositionControls();
        }

        private void PositionControls()
        {
            try
            {
                SuspendLayout();

                timerPositionControls.Enabled = false;

                // TODO: Label and TextBox text does not line up.
                // TODO:
                // I chose not to use label auto-sizing, because WinForms often does not do a good job positioning (see comment above),
                // so I decided to take matters into my own hands. But The measure text solution here also gave me all sorts of trouble.
                // Perhaps it would have been a better plan to use WinForms in a standard way and build solutions to its problems
                // on top of this.

                int y = 0;
                int x = 0;
                int height = textBox.Height; // We cannot size a TextBox's height, so we're stuck with it.

                // label
                if (!String.IsNullOrEmpty(label.Text))
                {
                    float textWidth = ControlHelper.MeasureStringWithFontScaling(_graphics, label).Width;
                    int labelWidth = (int)Math.Ceiling(textWidth);
                    labelWidth += 2; // MeasureText and Label.Width do not seem to want to work together...
                    label.Location = new Point(x, y);
                    label.Size = new Size(labelWidth, height);

                    x += label.Width + _spacing;
                }

                // textBox
                textBox.Location = new Point(x, y);
                int textBoxWidth =  Width - x - buttonBrowse.Width - _spacing;
                if (textBoxWidth < 1) textBoxWidth = 1;
                textBox.Width = textBoxWidth;

                x += textBox.Width + _spacing;

                // buttonBrowse
                buttonBrowse.Location = new Point(x, y);
                buttonBrowse.Height = height;
            }
            finally
            {
                ResumeLayout();
            }
        }

        // Events

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            _fileDialog.FileName = textBox.Text;

            if (_fileDialog.ShowDialog() == DialogResult.OK)
            {
                textBox.Text = _fileDialog.FileName;

                if (Browsed != null)
                {
                    var e2 = new FilePathEventArgs(textBox.Text);
                    Browsed(this, e2);
                }
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            RequestPositionControls();
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            toolTip.SetToolTip(textBox, textBox.Text);
        }
    }
}
