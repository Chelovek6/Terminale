using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terminale
{
    internal class Terminal
    {
        private List<string> lines;
        private int cursorX;
        private int cursorY;
        public Terminal()
        {
            lines = new List<string> { "" };
            cursorX = 0;
            cursorY = 0;
        }
        public void ProcessInput(string input)
        {
            foreach (char c in input)
            {
                switch (c)
                {
                    case 'L':
                        MoveCursorLeft();
                        break;
                    case 'R':
                        MoveCursorRight();
                        break;
                    case 'U':
                        MoveCursorUp();
                        break;
                    case 'D':
                        MoveCursorDown();
                        break;
                    case 'B':
                        MoveCursorToBeginningOfLine();
                        break;
                    case 'E':
                        MoveCursorToEndOfLine();
                        break;
                    case 'N':
                        InsertNewLine();
                        break;
                    default:
                        InsertCharacter(c);
                        break;
                }
            }
        }
        public void InsertCharacter(char c)
        {
            lines[cursorY] = lines[cursorY].Insert(cursorX, c.ToString());
            cursorX++;
        }
        public void MoveCursorLeft()
        {
            if (cursorX > 0)
            {
                cursorX--;
            }
        }
        public void MoveCursorRight()
        {
            if (cursorX < lines[cursorY].Length)
            {
                cursorX++;
            }
        }
        public void MoveCursorUp()
        {
            if (cursorY > 0)
            {
                cursorY--;
                if (cursorX > lines[cursorY].Length)
                {
                    cursorX = lines[cursorY].Length;
                }
            }
        }
        public void MoveCursorDown()
        {
            if (cursorY < lines.Count - 1)
            {
                cursorY++;
                if (cursorX > lines[cursorY].Length)
                {
                    cursorX = lines[cursorY].Length;
                }
            }
        }
        public void MoveCursorToBeginningOfLine()
        {
            cursorX = 0;
        }
        public void MoveCursorToEndOfLine()
        {
            cursorX = lines[cursorY].Length;
        }
        public void InsertNewLine()
        {
            string currentLine = lines[cursorY];
            string newLine = currentLine.Substring(cursorX);
            lines[cursorY] = currentLine.Substring(0, cursorX);
            lines.Insert(cursorY + 1, newLine);
            cursorY++;
            cursorX = 0;
        }
        public void PrintResult()
        {
            foreach (string line in lines)
            {
                if (!string.IsNullOrEmpty(line)) // Игнорируем пустые строки
                {
                    Console.WriteLine(line);
                }
            }
        }
    }
}
