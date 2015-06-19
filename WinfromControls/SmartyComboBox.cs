using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WinfromControls
{
    public delegate bool CheckComboboxItem(string info);
    
    public partial class SmartyComboBox<T> : UserControl
    {
        public CheckComboboxItem Validator;
        public List<T> BoundEntities { get; set; }
        public BindingSource BindingSource { get; set; }

        public SmartyComboBox()
        {
            BindingSource = new BindingSource();
            BoundEntities = new List<T>();
            InitializeComponent();

            ComboBox.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
        }


        public void SetValidator(CheckComboboxItem val)
        {
            Validator = val;
        }

        public ComboBox ComboBox {
            get { return comboBox; }}

        public void LoadData(List<T> collection)
        {
            BindingSource.DataSource = collection;
            comboBox.DataSource = BindingSource.DataSource;
            comboBox.DisplayMember = "Name";
            comboBox.ValueMember = "Name";
        }


        private void ComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {

            if (Validator == null) return;

            if (Validator.Invoke(SelectedItem.ToString()))
            {
                toolTip1.Show("bad select!", ComboBox);
                pictureBox.Image = Properties.Resources.Close_2_icon16;
            }
            else
            {
                pictureBox.Image = Properties.Resources.Actions_dialog_ok_apply_icon_16;
                toolTip1.Hide(comboBox);
            }

        }


        public T SelectedItem { get { return (T)comboBox.SelectedItem; } }

    }
}
