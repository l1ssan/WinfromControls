using System.Collections.Generic;
using System.Windows.Forms;
using WinfromControls;

namespace Demo
{


    public partial class FormDemo : Form
    {
        private List<Book> books = new List<Book>
        {
            new Book{Author = "Palanic", Name = "Fight Club"},
            new Book{Author ="Salvatore", Name = "Dark Elf"}
        };

        private SmartyComboBox<Book> sCombobox = new SmartyComboBox<Book>();
        public FormDemo()
        {
            InitializeComponent();

            smartyTextBox2.SetDelegate(CheckTextBox);
            sCombobox.LoadData(books);
            sCombobox.SetValidator(CheckComboBox);
            comboPanel.Controls.Add(sCombobox);
            sCombobox.ComboBox.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
        }

        private void ComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            selectedLabel.Text = sCombobox.SelectedItem.Name;
        }
        
        /// <summary>
        /// validate function
        /// </summary>
        /// <param name="str">validating textbox string</param>
        /// <returns></returns>
        private static bool CheckTextBox(string str)
        {
            return str == "hex";
        }

        private static bool CheckComboBox(string str)
        {
            return str=="Dark Elf";
        }
    }
}
