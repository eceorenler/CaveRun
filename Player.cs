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
        //gravity

        previousKeyboard = keyboard;
    }

    public void Jump()
    {
        
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