using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex05.Logic
{
    public enum eTurnResult
    {
        Player1Win = 1,
        Player2Win = 2,
        Draw = 3,
        None = 4
    }

    public class Game
    {
        private readonly Player r_Player1;
        private readonly Player r_Player2;
        private readonly GameBoard r_GameBoard;
        private readonly bool r_IsAhgainstComputer;
        private eCurrentPlayer m_CurrentPlayer = eCurrentPlayer.Player1;

        public Game(int i_BoardLength, bool i_TwoPlayersMode, CellSignsWrapper.eCellSigns i_Player1Sign)
        {
            r_Player1 = new Player(i_Player1Sign, true);
            CellSignsWrapper.eCellSigns player2Sign = CellSignsWrapper.eCellSigns.SignedCellX;
            r_Player2 = new Player(player2Sign, i_TwoPlayersMode);
            r_GameBoard = new GameBoard(i_BoardLength);
            r_IsAhgainstComputer = i_TwoPlayersMode;
        }

        public event Action<eTurnResult> m_GameEnded;

        public event Action m_InvalidMove;

        private enum eCurrentPlayer
        {
            Player1 = 1,
            Player2 = 2,
        }

        public Player Player1
        {
            get { return r_Player1; }
        }

        public Player Player2
        {
            get { return r_Player2; }
        }

        public GameCell[,] BoardCell
        {
            get { return r_GameBoard.Board; }
        }

        public GameBoard Board
        {
            get { return r_GameBoard; }
        }

        public void EmptyBoard()
        {
            r_GameBoard.InitializeBoard();
        }

        ////Entery point from UI to LOGIC
        public void MakeMoveLogic(GameCell i_CellFromUI)
        {
            playATurn(i_CellFromUI);
        }

        private void playATurn(GameCell i_FilledCell)
        {
            bool gameEnded = false;
            int row = i_FilledCell.Row;
            int col = i_FilledCell.Col;

            if (!ValidateMove(i_FilledCell))
            {
                doOnInValidMove();
                return;
            }

            if (m_CurrentPlayer == eCurrentPlayer.Player1)
            {
                r_GameBoard.MarkCell(row, col, r_Player1.Sign);
                gameEnded = CheckForFinalResult(i_FilledCell);
                m_CurrentPlayer = eCurrentPlayer.Player2;
            }
            else
            {
                r_GameBoard.MarkCell(row, col, r_Player2.Sign);
                CheckForFinalResult(i_FilledCell);
                m_CurrentPlayer = eCurrentPlayer.Player1;
            }

            if (r_IsAhgainstComputer && !gameEnded)
            {
                MakeComputerMove();
            }
            
            if (gameEnded)
            {
                m_CurrentPlayer = eCurrentPlayer.Player1;
            }
        }

        private void MakeComputerMove()
        {
            GameCell computerChosenCell = new GameCell();
            ComputerAI.BestMove(r_GameBoard, computerChosenCell);
            int row = computerChosenCell.Row;
            int col = computerChosenCell.Col;
            r_GameBoard.MarkCell(row, col, r_Player2.Sign);
            CheckForFinalResult(computerChosenCell);
            m_CurrentPlayer = eCurrentPlayer.Player1;
        }

        private bool ValidateMove(GameCell i_NextCell)
        {
            bool isValidMove = true;
            if (i_NextCell.CellContent != CellSignsWrapper.eCellSigns.EmptySignedCell)
            {
                isValidMove = false;
            }

            return isValidMove;
        }

        private bool CheckForFinalResult(GameCell i_FilledCell)
        {
            bool gameEnded = false;
            eTurnResult resultOfTurn = eTurnResult.None;
            bool result = r_GameBoard.CheckForFullLine(i_FilledCell);

            if (result)
            {
                if (i_FilledCell.CellContent == CellSignsWrapper.eCellSigns.SignedCellX)
                {
                    resultOfTurn = eTurnResult.Player1Win;
                    Player1.Points++;
                }
                else
                {
                    resultOfTurn = eTurnResult.Player2Win;
                    Player2.Points++;
                }
            }
            else
            {
                result = r_GameBoard.CheckIfBoardFull();
                if (result)
                {
                    resultOfTurn = eTurnResult.Draw;
                }
            }

            if (resultOfTurn != eTurnResult.None)
            {
                gameEnded = true;
                doOnFinalResult(resultOfTurn);
            }

            return gameEnded;
        }

        private void doOnFinalResult(eTurnResult i_FinalRes)
        {
            m_GameEnded.Invoke(i_FinalRes);
        }

        private void doOnInValidMove()
        {
            m_InvalidMove.Invoke();
        }
    }
}
