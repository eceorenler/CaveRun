using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

class Player
{
    private Texture2D texture;
    private Vector2 position;
    private int width;
    private int height;

    private float velocity;
    private float gravity;
    private float jumpStrength;
    private float groundY;
    private bool isOnGround;

    private KeyboardState  previousKeyboard;

    //Constructor with Parameters

    public Player(Texture2D texture, Vector2 startPosition, float groundY)
    {
        this.texture = texture;
        this.position = startPosition;
        this.groundY = groundY;

        width = 80;
        height = 110;
        velocity = 0;
        gravity = 0.5f;
        jumpStrength = -12f;
        isOnGround = true;
    }
    
    public void Update()
    {
        KeyboardState keyboard = Keyboard.GetState();

        //jump

        if ((keyboard.IsKeyDown(Keys.Space) && previousKeyboard.IsKeyUp(Keys.Space)) ||
            (keyboard.IsKeyDown(Keys.W) && previousKeyboard.IsKeyUp(Keys.W)) ||
            (keyboard.IsKeyDown(Keys.Up) && previousKeyboard.IsKeyUp(Keys.Up)))
        {
            if (isOnGround)
            {
                Jump();
            }
        }
        //gravity

        velocity += gravity; 
        position.Y += velocity;

        previousKeyboard = keyboard;

        //ground check

        if (position.Y + height > groundY)
        {
            position.Y = groundY - height;
            velocity = 0;
            isOnGround = true;
        }
    }

    public void Jump()
    {
        velocity = jumpStrength;
        isOnGround = false;
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(texture, GetBounds(), Color.Orange);
    }

    public Rectangle GetBounds() //collider
    {
        return new Rectangle((int)position.X, (int)position.Y, width, height);
    }

}