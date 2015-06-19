using System.Windows.Forms;

namespace WinfromControls
{
    public delegate bool SendInfo(string info);
    
    public partial class SmartyTextBox : UserControl
    {
        public SmartyTextBox()
        {


            InitializeComponent();
            textBox.TextChanged += textBox_TextChanged;
           // textBox.Validating += textBox_Validating;

        }

        //private void textBox_Validating(object sender, CancelEventArgs e)
        //{
        //    if (checkString == null) return;

        //    if (checkString.Invoke(textBox.Text))
        //    {
        //        toolTip1.Show("bad language!", textBox);
        //        e.Cancel = true;
        //    }
        //    else
        //    {
        //        toolTip1.Hide(textBox);
        //    }
        //}

        public SendInfo checkString;

        public void SetDelegate(SendInfo setInfo)
        {
            checkString = setInfo;
        }

        private void textBox_TextChanged(object sender, System.EventArgs e)
        {
            if (checkString == null) return;

            if (checkString.Invoke(textBox.Text))
            {
                toolTip1.Show("bad language!", textBox);
                pictureBox.Image = Properties.Resources.Close_2_icon16;
            }
            else
            {
                pictureBox.Image = Properties.Resources.Actions_dialog_ok_apply_icon_16;
                toolTip1.Hide(textBox);
            }
        }
    }
}
