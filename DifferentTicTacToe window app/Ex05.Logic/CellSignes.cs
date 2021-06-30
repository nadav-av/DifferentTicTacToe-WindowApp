using System;

namespace Ex05.Logic
{
    public class CellSignsWrapper
    {
        public enum eCellSigns
        {
            EmptySignedCell = ' ',
            SignedCellX = 'X',
            SignedCellO = 'O'
        }

        public static string SignToString(eCellSigns value)
        {
            char res = (char)value;
            return res.ToString();
        }
    }
}
