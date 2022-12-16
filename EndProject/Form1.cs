using EndProject.core;
using System;
using System.Windows.Forms;

namespace EndProject
{
    public partial class Form1 : Form
    {
        public int height = 10;
        public int width = 15;
        public const int cellSize = 50;
        public GameField gameField;        
        private const int mineCount = 25;
        public bool CheatMode = false;
            
        
        public Form1()
        {
            InitializeComponent();
            Init();
        }
       
        public void Init()
        {
            gameField = new GameField(height, width, cellSize, mineCount);
            ConfigureMapSize();
            DrawCells(gameField);
        }
        private void ConfigureMapSize()
        {
            this.Width = width * cellSize + width;
            this.Height = height * cellSize + (height + cellSize);
        }
        public void DrawCells(GameField gameField)
        {
            Cell[,] cells = gameField.getCells();
            foreach(Cell cell in cells)
            {
                this.Controls.Add(cell);
            }
        }
        public void RemoveCells(GameField gameField)
        {
            Cell[,] cells = gameField.getCells();
            foreach (Cell cell in cells)
            {
                this.Controls.Remove(cell);
            }
        }

        private void SmallMapMenuItem_Click(object sender, EventArgs e)
        {
            height = 10;
            width = 15;
            RemoveCells(gameField);
            Init();
        }

        private void NormalMapMenuItem_Click(object sender, EventArgs e)
        {
            height = 15;
            width = 20;
            RemoveCells(gameField);
            Init();
        }

        private void BigMapMenuItem_Click(object sender, EventArgs e)
        {
            height = 15;
            width = 30;
            RemoveCells(gameField);
            Init();
        }

        private void QuitMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void RestartMenuItem_Click(object sender, EventArgs e)
        {
            RemoveCells(gameField);
            Init();
        }
    }
}
