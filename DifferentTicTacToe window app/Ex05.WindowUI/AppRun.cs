using System.Windows.Forms;

namespace Ex05.WindowUI
{
    public partial class DifferentTicTacToeUI : Form
    {
        private readonly GameSettingsForm r_GameSettings;
        private readonly GameBoardForm r_GameBoardForm;

        public DifferentTicTacToeUI()
        {
            r_GameSettings = new GameSettingsForm();
            r_GameSettings.ShowDialog();
            if (r_GameSettings.DialogResult == DialogResult.OK)
            {
                r_GameBoardForm = new GameBoardForm(r_GameSettings);
                r_GameBoardForm.ShowDialog();
            }
        }
    }
}
