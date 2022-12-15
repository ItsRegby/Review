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
        private CellStatus()
        {

        }

        public static CellStatus MINE = new CellStatus(minePath);
        public static CellStatus PLAYER = new CellStatus(playerPath);
        public static CellStatus EMPTY = new CellStatus(emptyPath);
        public static CellStatus VISITED = new CellStatus(visitedPath);
        public static CellStatus W = new CellStatus();
        public static CellStatus L = new CellStatus();
        public static CellStatus DEFAULT = new CellStatus();

        public String getPath()
        {
            return filePath;
        }

        public Image getImage()
        {
            return Image.FromFile(getPath());
        }
        public static string Name(CellStatus status)
        {
            if (status.Equals(MINE))
            {
                return "MINE";
            }
            if (status.Equals(PLAYER))
            {
                return "PLAYER";
            }
            if (status.Equals(EMPTY))
            {
                return "EMPTY";
            }
            if (status.Equals(VISITED))
            {
                return "VISITED";
            }
            if (status.Equals(W))
            {
                return "W";
            }
            if (status.Equals(L))
            {
                return "L";
            }
            return "DEFAULT";
        }
        public string Name()
        {
            if (this.Equals(MINE))
            {
                return "M";
            }
            if (this.Equals(PLAYER))
            {
                return "PLAYER";
            }
            if (this.Equals(EMPTY))
            {
                return "EMPTY";
            }
            if (this.Equals(VISITED))
            {
                return "VISITED";
            }
            if (this.Equals(W))
            {
                return "W";
            }
            if (this.Equals(L))
            {
                return "L";
            }
            return "DEFAULT";
        }
    }
}
