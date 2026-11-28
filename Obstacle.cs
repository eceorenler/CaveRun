using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

class Obstacle
{
    private Texture2D texture;
    private Vector2 position;
    private int width;
    private int height;
    private bool isFlying;

    public Obstacle(Texture2D texture, float startX, float groundY, bool isFlying)
    {
        this.texture = texture;
        this.isFlying = isFlying;

        if (isFlying)
        {
            width = 60;
            height = 40;
            position = new Vector2(startX, groundY - 80 - height); //obstacle
        }
        else
        {
            width = 40;
            height = 50;
            position = new Vector2(startX, groundY - height);
        }
    }

    public void Update(float speed)
    {
        position.X -= speed;

    }

    public void Draw(SpriteBatch spriteBatch)
    {
        if (isFlying)
        {
            spriteBatch.Draw(texture, GetBounds(), Color.Purple);
        }
        else
        {
            spriteBatch.Draw(texture, GetBounds(), Color.DarkGreen);
        }
    }

    public Rectangle GetBounds()
    {
        return new Rectangle((int)position.X, (int)position.Y, width, height);
    }    

    public bool IsOffScreen()
    {
        return position.X + width < 0;
    }

    
    
}