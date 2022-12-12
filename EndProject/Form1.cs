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
        private int mineCount = 25;
            
        
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

        private void EasyMenuItem_Click(object sender, EventArgs e)
        {
            height = 10;
            width = 15;
            mineCount = 25;
            RemoveCells(gameField);
            Init();
        }

        private void NormalMenuItem_Click(object sender, EventArgs e)
        {
            height = 15;
            width = 20;
            mineCount = 30;
            RemoveCells(gameField);
            Init();
        }

        private void HardMenuItem_Click(object sender, EventArgs e)
        {
            height = 15;
            width = 25;
            mineCount = 35;
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
