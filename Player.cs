using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

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

    private bool isRolling;
    private int rollHeight;

    //constructor with parameters

    public Player(Texture2D texture, Vector2 startPosition, float groundY)
    {
        this.texture = texture;
        this.position = startPosition;
        this.groundY = groundY;

        width = 80;
        height = 110;
        velocity = 0;
        gravity = 0.5f;
        jumpStrength = -14f;
        isOnGround = true;

        isRolling = false;
        rollHeight = 55;
    }
    
    public void Update(GameTime gameTime, InputManager input)
    {
        //jump
        if (input.IsJumpPressed() && isOnGround && !isRolling)
        {
            Jump();
        }

        //roll
        if (input.IsRollHeld() && isOnGround)
        {
            isRolling = true;
        }
        else
        {
            isRolling = false;
        }
        
        //gravity
        velocity += gravity; 
        position.Y += velocity;


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
        if (isRolling)
        {
            return new Rectangle((int)position.X, (int)position.Y + (height - rollHeight), width, rollHeight); // only upper bound needs to get down
        }

        return new Rectangle((int)position.X, (int)position.Y, width, height);
    }

}