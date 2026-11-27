using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

class Obstacle
{
    private Texture2D texture;
    private Vector2 position;
    private int width;
    private int height;
    private float speed;
    private bool isFlying;

    public Obstacle(Texture2D texture, float startX, float groundY, bool isFlying)
    {
        this.texture = texture;
        this.isFlying = isFlying;
        speed = 5f;

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

    public void Update()
    {
        position.X -= speed;

        //temp test
        if (position.X + width < 0)
        {
            position.X = 1000;
        }
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

    
    
}