using System;
using System.Drawing;

namespace EndProject.core
{
    public class CellStatus
    {
        private string filePath;

        
        private const string minePath = "images\\mine.png";
        private const string playerPath = "images\\player.png";
        private const string emptyPath = "images\\empty.png";
        private const string visitedPath = "images\\visited.png";

        private CellStatus(string filePath)
        {
            this.filePath = filePath;
        }

        public static CellStatus MINE = new CellStatus(minePath);
        public static CellStatus PLAYER = new CellStatus(playerPath);
        public static CellStatus EMPTY = new CellStatus(emptyPath);
        public static CellStatus VISITED = new CellStatus(visitedPath);

        public String getPath()
        {
            return filePath;
        }

        public Image getImage()
        {
            return Image.FromFile(getPath());
        }
    }
}
