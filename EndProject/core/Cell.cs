using System;
using System.Windows.Forms;

namespace EndProject.core
{
    public class Cell : Button
    {
        public int x;
        public int y;
        public GameField gameField;
        public CellStatus status = CellStatus.EMPTY;        

        public Cell(int x, int y, GameField gameField)  
        {
            this.x = x;
            this.y = y;
            this.gameField = gameField;
        }

        public int[] ExtractArrayIndexes()
        {
            return new int[]{ x, y};
        }
        public void InitCellStatus(int status)
        {
            if(status == 1)
            {
                this.status = CellStatus.MINE;
            }            
            else
            {
                this.status = CellStatus.EMPTY;
            }
            UpdateImage();
        }

        private void UpdateImage()
        {
            base.Image = status.getImage();
            
        }

        public void setStatus(CellStatus status)
        {
            this.status = status;
            UpdateImage();
        }
        public CellStatus getStatus()
        {
            return status;
        }
        public override string ToString() { return $"Status: {status}, X: {x}, Y: {y}]"; }

    }
}
