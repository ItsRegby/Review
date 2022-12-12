using System;

namespace EndProject.core
{
    public class Bot
    {
        private GameField gameField;
        private Cell[,] cells;
        private Position position;
        private bool isBotTurn = true;
        

        public Bot(GameField gameField)
        {
            this.gameField = gameField;
            this.cells = gameField.cells;
            this.position = gameField.position;
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

                Position turn = FindOptimalTurn();

                if (turn.Equals(new Position(0, 0)))
                {
                    turn = GetRandomTurn();
                }
                cells[turn.x, turn.y].PerformClick();

            }
            else
            {
                isBotTurn = true;
            }
            
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
        public Position FindOptimalTurn() 
        {   
            Position position = gameField.position;            
            Position turn;
            Position lastSaveTurn = new Position(0, 0);
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
                    turn = new Position(i, position.y);                   
                    if(!GameField.HasNextMove(gameField, turn))
                    {                        
                        return turn;                        
                    }
                    if (IsSaveMove(turn))
                    {
                        lastSaveTurn = (Position)turn.Clone();
                    }
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
                    turn = new Position(position.x, j);
                    if (!GameField.HasNextMove(gameField, turn))
                    {
                        return turn;
                    }
                    if (IsSaveMove(turn))
                    {
                        lastSaveTurn = (Position)turn.Clone();
                    }
                }
            }            
            return lastSaveTurn;
        }
        private bool IsSaveMove(Position position)        
        {
            for (int i = position.x + 1; i < gameField.width; i++)
            {
                Position currentPosition = new Position(i, position.y);
                if (cells[i, position.y].getStatus().Equals(CellStatus.MINE))
                {
                    break;
                }
                if (!GameField.HasNextMove(gameField, currentPosition))
                {                    
                    return false;
                }
            }
            for (int j = position.y + 1; j < gameField.height; j++)
            {
                Position currentPosition = new Position(position.x, j);               
                if (cells[position.x, j].getStatus().Equals(CellStatus.MINE))
                {
                    break;
                }
                if(!GameField.HasNextMove(gameField, currentPosition))
                {                    
                    return false;
                }
            }            
            return true;
        }
    }
    
}
