using System;

namespace BlackJackGame
{
    public class Frame : GuiObject
    {
        private string boarder;

        public Frame(int x, int y, int h, int w, string boarder) : base(x, y, h, w)
        {
            this.boarder = boarder;
        }

        public void Render()
        {
            for (int i = 0; i < height; i++)
            {
                Console.SetCursorPosition(x, y+i);
                for (int j = 0; j < width; j++)
                {
                    if (i == 0 || i == (height - 1) || j == 0 || (j == width - 1))
                    {
                        Console.Write(boarder);
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
            Console.SetCursorPosition(0,0);
        }
    }
}