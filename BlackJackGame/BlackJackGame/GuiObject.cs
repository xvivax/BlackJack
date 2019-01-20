namespace BlackJackGame
{
    public abstract class GuiObject
    {
        protected int x;
        protected int y;
        protected int height;
        protected int width;

        protected GuiObject(int x, int y, int height, int width)
        {
            this.x = x;
            this.y = y;
            this.height = height;
            this.width = width;
        }
    }
}