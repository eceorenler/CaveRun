using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

class GameplayScreen
{
    private Texture2D pixel;
    private float groundY;

    private Player player;
    private ObstacleSpawner obstacleSpawner;
    private bool isGameOver;

    public GameplayScreen(Texture2D pixel, float groundY)
    {
        this.pixel = pixel;
        this.groundY = groundY;

        Reset();
    }

    public void Reset()
    {
        player = new Player(pixel, new Vector2(120, groundY - 110), groundY);
        obstacleSpawner = new ObstacleSpawner(pixel, groundY);
        
        isGameOver = false;

    }

    public void Update(GameTime gameTime, InputManager input)
    {
        if (!isGameOver)
        {
            player.Update(gameTime, input);
            obstacleSpawner.Update(gameTime);

            if (obstacleSpawner.CheckCollision(player.GetBounds()))
            {
                isGameOver = true;
            }
        }
    }

    public bool IsGameOver()
    {
        return isGameOver;
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(pixel, new Rectangle(0, (int)groundY,800,600-(int)groundY), Color.Brown);
        player.Draw(spriteBatch);
        obstacleSpawner.Draw(spriteBatch);
    }
}
