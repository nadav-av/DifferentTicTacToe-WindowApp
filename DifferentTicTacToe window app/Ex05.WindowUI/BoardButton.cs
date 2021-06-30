using System.Drawing;
using System.Windows.Forms;
using Ex05.Logic;

namespace Ex05.WindowUI
{
    public class BoardButton : Button
    {
        private readonly GameCell r_CellButton;

        public BoardButton(GameCell i_cell)
        {
            r_CellButton = i_cell;
            r_CellButton.Row = i_cell.Row;
            r_CellButton.Col = i_cell.Col;
            initializeBoardButton();
        }

        public GameCell Cell
        {
            get
            {
                return r_CellButton;
            }
        }

        private void initializeBoardButton()
        {
            this.BackColor = Color.White;
            this.Enabled = true;
        }
    }
}