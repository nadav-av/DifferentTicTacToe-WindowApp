using System;

namespace Ex05.Logic
{
    public class Player
    {
        private readonly CellSignsWrapper.eCellSigns r_PlayerBoardSign;
        private bool m_IsHumanPlayer;
        private int m_PlayerVictoryPoints;

        public Player(CellSignsWrapper.eCellSigns i_PlayerSign, bool i_IsHumanPlayer)
        {
            r_PlayerBoardSign = i_PlayerSign;
            m_IsHumanPlayer = i_IsHumanPlayer;
            m_PlayerVictoryPoints = 0;
        }

        public bool IsHuman
        {
            get
            {
                return m_IsHumanPlayer;
            }

            set
            {
                m_IsHumanPlayer = value;
            }
        }

        public CellSignsWrapper.eCellSigns Sign
        {
            get
            {
                return r_PlayerBoardSign;
            }
        }

        public int Points
        {
            get
            {
                return m_PlayerVictoryPoints;
            }

            set
            {
                m_PlayerVictoryPoints = value;
            }
        }

        public bool CheckIfPlayerLost(GameBoard i_GameBoard, GameCell i_LastFilledCell)
        {
            bool didPlayerLost = i_GameBoard.CheckForFullLine(i_LastFilledCell);
            return didPlayerLost;
        }
    }
}
