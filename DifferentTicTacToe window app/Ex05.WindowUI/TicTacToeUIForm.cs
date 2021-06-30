using System;
using System.Drawing;
using System.Windows.Forms;
using Ex05.Logic;

namespace Ex05.WindowUI
{
    public partial class GameBoardForm : Form
    {
        private readonly Label r_LabelPlayer1 = new Label();
        private readonly Label r_LabelPlayer2 = new Label();
        private readonly GameSettingsForm r_GameSettingsForm;
        private BoardButton[,] r_ButtonGameBoard;
        private Game m_Game;

        public GameBoardForm(GameSettingsForm i_settingsForm)
        {
            this.Text = "Different Tic Tac Toe";
            this.BackColor = Color.SteelBlue;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.AutoSize = true;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            r_GameSettingsForm = i_settingsForm;
            buildTicTacToeBoard();
            m_Game.Board.m_MarkedCellListener += new Action<int, int, CellSignsWrapper.eCellSigns>(markCellInForm);
            m_Game.m_GameEnded += new Action<eTurnResult>(resultMassege);
            m_Game.m_InvalidMove += new Action(invalidMoveChosen);
        }

        private static void buttonDesignHelper(BoardButton i_Button, int i_Left, int i_RowPosition, int i_ColPosition)
        {
            i_Button.Left = i_Left + (i_ColPosition * 62);
            i_Button.Top = 32 + (i_RowPosition * 62);
            i_Button.Size = new System.Drawing.Size(62, 62);
        }

        private void markCellInForm(int i_Row, int i_Col, CellSignsWrapper.eCellSigns i_SignToFill)
        {
            r_ButtonGameBoard[i_Row, i_Col].Text = CellSignsWrapper.SignToString(i_SignToFill);
        }

        private void invalidMoveChosen()
        {
            MessageBox.Show("Invalid Move.");
        }

        private void buildTicTacToeBoard()
        {
            int boardSize = r_GameSettingsForm.RowColSize;
            bool isAgainstComputer = r_GameSettingsForm.IsAgainstComputer;

            m_Game = new Game(
                 boardSize,
                 isAgainstComputer,
                 CellSignsWrapper.eCellSigns.SignedCellO);

            initControls();
        }

        private void initControls()
        {
            int boardLength = r_GameSettingsForm.RowColSize;
            r_ButtonGameBoard = new BoardButton[boardLength, boardLength];
            addButtonsToForm(boardLength);

            r_LabelPlayer1.Font = new Font("Ariel", 11, FontStyle.Bold);

            r_LabelPlayer1.Top = r_ButtonGameBoard[boardLength - 1, 0].Bottom + 30;
            r_LabelPlayer1.Left = (this.Width - r_LabelPlayer1.Width) / 4;

            r_LabelPlayer1.Text = r_GameSettingsForm.Player1Name + ": " + m_Game.Player1.Points.ToString();
            r_LabelPlayer1.AutoSize = true;
            this.Controls.Add(this.r_LabelPlayer1);

            r_LabelPlayer2.Font = new Font("Ariel", 11, FontStyle.Bold);

            r_LabelPlayer2.Top = r_ButtonGameBoard[boardLength - 1, boardLength - 1].Bottom + 30;
            r_LabelPlayer2.Left = (this.Width - r_LabelPlayer2.Width) * 3 / 4;

            r_LabelPlayer2.Text = r_GameSettingsForm.Player2Name + ": " + m_Game.Player2.Points.ToString();
            r_LabelPlayer2.AutoSize = true;
            this.Controls.Add(this.r_LabelPlayer2);
        }

        private void addButtonsToForm(int i_BoardSize)
        {
            for (int i = 0; i < i_BoardSize; i++)
            {
                for (int j = 0; j < i_BoardSize; j++)
                {
                    addButton(i, j);
                }
            }
        }

        private void addButton(int i_RowPosition, int i_ColPosition)
        {
            GameCell cell = m_Game.BoardCell[i_RowPosition, i_ColPosition];
            BoardButton button = new BoardButton(cell);

            if (r_GameSettingsForm.RowColSize > 4)
            {
                buttonDesignHelper(button, 6, i_RowPosition, i_ColPosition);
            }
            else if (r_GameSettingsForm.RowColSize == 3)
            {
                buttonDesignHelper(button, 50, i_RowPosition, i_ColPosition);
            }
            else if (r_GameSettingsForm.RowColSize == 4)
            {
                buttonDesignHelper(button, 19, i_RowPosition, i_ColPosition);
            }

            button.Click += new System.EventHandler(boardButton_clicked);
            button.Enabled = true;
            button.TabStop = false;
            this.Controls.Add(button);
            r_ButtonGameBoard[i_RowPosition, i_ColPosition] = button;
        }

        private void boardButton_clicked(object sender, EventArgs e)
        {
            BoardButton senderBtn = sender as BoardButton;
            m_Game.MakeMoveLogic(senderBtn.Cell); 
        }

        private void resultMassege(eTurnResult i_res)
        {
            if (i_res == eTurnResult.Player1Win)
            {
                string player1Name = r_GameSettingsForm.Player1Name;
                string message = "The winner is " + player1Name + "!";
                string resultType = "A Win!";
                resultMessageHelper(message, resultType);
            }
            else if (i_res == eTurnResult.Player2Win)
            {
                string player2Name = r_GameSettingsForm.Player2Name;
                string message = "The winner is " + player2Name + "!";
                string resultType = "A Win!";
                resultMessageHelper(message, resultType);
            }
            else
            {
                string message = "Tie!";
                string resultType = "A Tie!";
                resultMessageHelper(message, resultType);
            }
        }

        private void resultMessageHelper(string i_Message, string i_ResultType)
        {
            DialogResult dialogResult = MessageBox.Show(
                                                i_Message +
                                                     Environment.NewLine +
                                                     "Would you like to play another round?", 
                                                i_ResultType,
                                                      MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.cleanBoard();
                r_LabelPlayer1.Text = r_GameSettingsForm.Player1Name + ": " + m_Game.Player1.Points.ToString();
                r_LabelPlayer2.Text = r_GameSettingsForm.Player2Name + ": " + m_Game.Player2.Points.ToString();
            }
            else
            {
                this.Close();
            }
        }

        private void cleanBoard()
        {
            m_Game.EmptyBoard();

            for (int i = 0; i < r_GameSettingsForm.RowColSize; i++)
            {
                for (int j = 0; j < r_GameSettingsForm.RowColSize; j++)
                {
                    r_ButtonGameBoard[i, j].Text = CellSignsWrapper.SignToString(CellSignsWrapper.eCellSigns.EmptySignedCell);
                    r_ButtonGameBoard[i, j].Enabled = true;
                    r_ButtonGameBoard[i, j].TabStop = false;
                }
            }
        }
    }
}
