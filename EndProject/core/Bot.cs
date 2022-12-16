using System;
using System.IO;
using System.Linq.Expressions;
using System.Drawing;
using System.Text;

namespace EndProject.core
{
    public class Bot
    {
        private GameField gameField;
        private Cell[,] cells;
        private Position position;
        private bool isBotTurn = true;
        private CellStatus[,] boardStatuses;

        public Bot(GameField gameField)
        {
            this.gameField = gameField;
            this.cells = gameField.cells;
            this.position = gameField.position;
            Initialize();
        }
        private void Initialize()
        {
            int w = cells.GetLength(0);
            int h = cells.GetLength(1);
            boardStatuses = new CellStatus[w, h];

            for (int i = w - 1; i >= 0; i--)
            {
                for (int j = h - 1; j >= 0; j--)
                {
                    if (cells[i, j].status.Equals(CellStatus.MINE))
                    {
                        boardStatuses[i, j] = CellStatus.MINE;
                    }
                    else
                    {
                        boardStatuses[i, j] = CellStatus.DEFAULT;
                    }
                }
            }

            for (int j = h - 1; j >= 0; j--)
            {
                for (int i = w - 1; i >= 0; i--)
                {
                    boardStatuses[i, j] = CheckCellStatus(i, j);

                }
            }
            String file = "result " + DateTime.Now.TimeOfDay.ToString().Replace(':', ' ') + ".txt";

            StringBuilder sb = new StringBuilder();

            for (int j = 0; j < h; j++)
            {
                for (int i = 0; i < w; i++)
                {
                    sb.Append(boardStatuses[i, j].Name() + " ");
                    /*if (!boardStatuses[i, j].Equals(CellStatus.MINE))
                    {
                        cells[i, j].Font = new Font("Consolos", 18);
                        cells[i, j].Text = boardStatuses[i, j].Name();
                    }*/
                }
                sb.Append('\n');
            }

            File.WriteAllText(file, sb.ToString());
        }
        private CellStatus CheckCellStatus(int x, int y)
        {
            CellStatus result = CellStatus.L;

            if (boardStatuses[x, y].Equals(CellStatus.MINE))
            {
                return CellStatus.MINE;
            }

            for (int i = x + 1; i < boardStatuses.GetLength(0); i++)
            {
                if (boardStatuses[i, y].Equals(CellStatus.MINE))
                {
                    break;
                }
                if (boardStatuses[i, y].Equals(CellStatus.L))
                {
                    return CellStatus.W;
                }
            }
            for (int j = y + 1; j < boardStatuses.GetLength(1); j++)
            {
                if (boardStatuses[x, j].Equals(CellStatus.MINE))
                {
                    break;
                }
                if (boardStatuses[x, j].Equals(CellStatus.L))
                {
                    return CellStatus.W;
                }
            }

            return result;
        }

        public void setPosition(Position position)
        {
            this.position = position;
        }

        public Position getPosition()
        {
            return this.position;
        }

        public Cell[,] getCells()
        {
            return cells;
        }

        public void setCells(Cell[,] cell)
        {
            this.cells = cell;
        }
        public bool getBotTurn()
        {
            return isBotTurn;
        }

        public void TryToMakeTurn()
        {
            if (isBotTurn)
            {
                isBotTurn = false;
                Position turn = FindBestMove();
                cells[turn.x, turn.y].PerformClick();
            }
            else
            {
                isBotTurn = true;
            }
        }
        public Position FindBestMove()
        {
            Position position = gameField.position;
            int x = position.x;
            int y = position.y;
            int w = boardStatuses.GetLength(0);
            int h = boardStatuses.GetLength(1);

            for (int i = x + 1; i < w; i++)
            {
                if (boardStatuses[i, y].Equals(CellStatus.MINE))
                {
                    break;
                }
                if (boardStatuses[i, y].Equals(CellStatus.L))
                {
                    return new Position(i, y);
                }
            }

            for (int j = y + 1; j < h; j++)
            {
                if (boardStatuses[x, j].Equals(CellStatus.MINE))
                {
                    break;
                }
                if (boardStatuses[x, j].Equals(CellStatus.L))
                {
                    return new Position(x, j);
                }
            }

            return GetRandomTurn();
        }   
        public Position GetRandomTurn()
        {
            for (int i = position.x; i < gameField.width; i++)
            {
                if (cells[i, position.y].getStatus().Equals(CellStatus.PLAYER))
                {
                    continue;
                }
                if (cells[i, position.y].getStatus().Equals(CellStatus.MINE))
                {
                    break;
                }
                if (cells[i, position.y].getStatus().Equals(CellStatus.EMPTY))
                {
                    return new Position(i, position.y);
                }
            }
            for (int j = position.y; j < gameField.height; j++)
            {
                if (cells[position.x, j].getStatus().Equals(CellStatus.PLAYER))
                {
                    continue;
                }
                if (cells[position.x, j].getStatus().Equals(CellStatus.MINE))
                {
                    break;
                }
                if (cells[position.x, j].getStatus().Equals(CellStatus.EMPTY))
                {
                    return new Position(position.x, j);
                }
            }
            return new Position(0, 0);
        }
    }
    
}
