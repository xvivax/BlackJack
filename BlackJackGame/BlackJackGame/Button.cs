using System;

namespace BlackJackGame
{
    public class Button : GuiObject
    {
        private bool isActive = false;
        private string activeBoarderSign = "#";
        private string inactiveBoarderSign = "-";
        private string text;

        private Frame inactiveFrame;
        private Frame activeFrame;

        public Button(int x, int y, string text) : base(x, y, 5, text.Length + 4)
        {
            this.text = text;
            activeFrame = new Frame(x, y, height, width, activeBoarderSign);
            inactiveFrame = new Frame(x, y, height, width, inactiveBoarderSign);
        }

        public void SetActive()
        {
            isActive = true;
        }

        public void SetNotActive()
        {
            isActive = false;
        }

        public bool GetIsActive()
        {
            return isActive;
        }

        public void ShowText()
        {
            Console.SetCursorPosition(x + 2, y + 2);
            Console.WriteLine(text);
            Console.SetCursorPosition(0, 0);
        }

        public void Render()
        {
            if (isActive)
            {
                activeFrame.Render();
            }
            else
            {
                inactiveFrame.Render();
            }
            ShowText();
        }
    }
}