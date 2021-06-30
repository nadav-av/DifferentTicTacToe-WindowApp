using System;
using System.Drawing;
using System.Windows.Forms;

namespace Ex05.WindowUI
{
    public partial class GameSettingsForm : Form
    {
        private bool m_IsAgainstComputer = true;

        public GameSettingsForm()
        {
            InitializeComponent();
        }

        public int RowColSize
        {
            get
            {
                return (int)upDownRows.Value;
            }
        }

        public string Player1Name
        {
            get
            {
                return (string)textBoxPlayer1.Text;
            }
        }

        public bool IsAgainstComputer
        {
            get
            {
                return m_IsAgainstComputer;
            }
        }

        public string Player2Name
        {
            get
            {
                string p2Name;

                if (textBoxPlayer2.Enabled == false)
                {
                    p2Name = "Computer";
                }
                else
                {
                    p2Name = (string)textBoxPlayer2.Text;
                }

                return p2Name;
            }
        }

        public void StartButton_Clicked(object sender, EventArgs e)
        {
            if (isFormFullfilled())
            {
                DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid input.");
            }
        }

        private void checkPlayer2_CheckedChangedOnce(object sender, EventArgs e)
        {
            textBoxPlayer2.Text = string.Empty;
            textBoxPlayer2.BackColor = Color.White;
            textBoxPlayer2.Enabled = true;
            textBoxPlayer2.ForeColor = Color.Black;
            textBoxPlayer2.TextAlign = HorizontalAlignment.Left;
            CheckBox player2Checkbox = sender as CheckBox;
            player2Checkbox.CheckedChanged -= checkPlayer2_CheckedChangedOnce;
            player2Checkbox.CheckedChanged += checkPlayer2_CheckedChangedAgain;
            m_IsAgainstComputer = false;
        }

        private void checkPlayer2_CheckedChangedAgain(object sender, EventArgs e)
        {
            textBoxPlayer2.Text = "[Computer]";
            textBoxPlayer2.BackColor = Color.LightGray;
            textBoxPlayer2.Enabled = false;
            textBoxPlayer2.ForeColor = Color.DarkGray;
            textBoxPlayer2.TextAlign = HorizontalAlignment.Center;
            CheckBox player2Checkbox = sender as CheckBox;
            player2Checkbox.CheckedChanged -= checkPlayer2_CheckedChangedAgain;
            player2Checkbox.CheckedChanged += checkPlayer2_CheckedChangedOnce;
            m_IsAgainstComputer = true;
        }

        private bool isFormFullfilled()
        {
            return textBoxPlayer1.Text != string.Empty && textBoxPlayer2.Text != string.Empty ? true : false;
        }

        private void numOfRows_Changed(object sender, EventArgs e)
        {
            upDownCols.Value = upDownRows.Value;
        }

        private void numOfCols_Changed(object sender, EventArgs e)
        {
            upDownRows.Value = upDownCols.Value;
        }
    }
}
