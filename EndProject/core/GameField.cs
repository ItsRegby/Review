using System;
using System.Drawing;
using System.Windows.Forms;

namespace EndProject.core
{
    public class GameField : ICloneable
    {
        private const int menuHeight = 24;
        public int height;
        public int width;
        public int cellSize;
        public int mineCount;
        public Position position = new Position(0, 0);
        public int[,] rawCells;
        public Cell[,] cells;
        public bool isPlayeble = true;
        public Bot bot;
        public bool isBotTurn = true;
        public EventHandler cellHandler = (o, e) =>
        {

            Cell cell = (Cell)o;

            GameField gameField = cell.gameField;
            gameField.PaintAllVisitedCells(cell);

            cell.setStatus(CellStatus.PLAYER);

            gameField.position.IndexesFromArray(cell.ExtractArrayIndexes());
            gameField.DeleteAllEventHandlers();
            gameField.AddEventHandlers();

            if (!cell.gameField.HasNextMove() && gameField.bot.getBotTurn())
            {
                MessageBox.Show("You win", "Message");
            }
            else if (!cell.gameField.HasNextMove() && !gameField.bot.getBotTurn())
            {
                MessageBox.Show("You lose", "Message");

            }

            gameField.bot.TryToMakeTurn();
        };

        public GameField(int height, int width, int cellSize, int mineCount)
        {
            this.height = height;
            this.width = width;
            this.cellSize = cellSize;
            this.mineCount = mineCount;
            rawCells = GetRawCells();
            cells = new Cell[rawCells.GetLength(0), rawCells.GetLength(1)];
            InitCells();
            bot = new Bot(this);
        }

        private GameField(int height, int width, int cellSize, int mineCount, Position position, int[,] rawCells, Cell[,] cells, bool isPlayeble, Bot bot, bool isBotTurn) : this(height, width, cellSize, mineCount)
        {
            this.position = position;
            this.rawCells = rawCells;
            this.cells = cells;
            this.isPlayeble = isPlayeble;
            this.bot = bot;
            this.isBotTurn = isBotTurn;
        }

        public int[,] GetRawCells()
        {
            int[,] mapCreate = new int[width, height];
            Random random = new Random();
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (random.Next(0, 101) < mineCount)
                    {
                        mapCreate[x, y] = 1;
                    }
                    else { mapCreate[x, y] = 0; }
                }
            }
            for (int x = 0; x < 2; x++)
            {
                for (int y = 0; y < 2; y++)
                {
                    mapCreate[x, y] = 0;
                }
            }
            return mapCreate;
        }
        public Cell[,] getCells()
        {
            return cells;
        }
        public void InitCells()
        {
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    Cell cell = new Cell(i, j, this);
                    cell.InitCellStatus(rawCells[i, j]);
                    cell.Location = new Point(i * cellSize, j * cellSize + menuHeight);
                    cell.Size = new Size(cellSize, cellSize);
                    cells[i, j] = cell;
                }
            }
            cells[0, 0].setStatus(CellStatus.PLAYER);
            AddEventHandlers();
        }

        public void AddEventHandlers()
        {
            for(int i = position.x; i < width; i++)
            {
                if (cells[i, position.y].getStatus().Equals(CellStatus.PLAYER))
                {
                    continue;
                }
                if(cells[i, position.y].getStatus().Equals(CellStatus.MINE))
                {
                    break;
                }
                cells[i, position.y].Click += cellHandler;
            }
            for (int j = position.y; j < height; j++)
            {
                if (cells[position.x, j].getStatus().Equals(CellStatus.PLAYER))
                {
                    continue;
                }
                if (cells[position.x, j].getStatus().Equals(CellStatus.MINE))
                {
                    break;
                }
                cells[position.x, j].Click += cellHandler;
            }
        }
        public void DeleteAllEventHandlers()
        {
            foreach(Cell cell in cells)
            {
                cell.Click -= cellHandler;
            }            
        }

        public void PaintAllVisitedCells(Cell currentCell)
        {
            for (int i = position.x; i < currentCell.x; i++)
            {
                cells[i, position.y].setStatus(CellStatus.VISITED);
            }
            for (int j = position.y; j < currentCell.y; j++)
            {
                cells[position.x, j].setStatus(CellStatus.VISITED);
            }
        }

        public bool HasNextMove()
        {
            int nextXIndex = position.x + 1;
            int nextYIndex = position.y + 1;
            if ((nextXIndex >= width || cells[nextXIndex, position.y].getStatus().Equals(CellStatus.MINE))
                && (nextYIndex >= height || cells[position.x, nextYIndex].getStatus().Equals(CellStatus.MINE)))
            {
                isPlayeble = false;
            }
            return isPlayeble;
        }

        public static bool HasNextMove(GameField gameField, Position position)
        {
            bool isPlayeble = true;
            int nextXIndex = position.x + 1;
            int nextYIndex = position.y + 1;

            if ((nextXIndex >= gameField.width || gameField.cells[nextXIndex, position.y].getStatus().Equals(CellStatus.MINE))
                && (nextYIndex >= gameField.height || gameField.cells[position.x, nextYIndex].getStatus().Equals(CellStatus.MINE)))
            {
                isPlayeble = false;
            }

            return isPlayeble;
        }

        public object Clone()
        {
            return new GameField(height, width, cellSize, mineCount, (Position)position.Clone(), rawCells, (Cell[,])cells.Clone(), isPlayeble, bot, isBotTurn);
        }
    }
}
