using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CaveRun;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    private Texture2D pixel;
    private Player player;
    private float groundY = 480;

    private ObstacleSpawner obstacleSpawner;
    private bool isGameOver;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);

        _graphics.PreferredBackBufferWidth = 800;
        _graphics.PreferredBackBufferHeight = 600;

        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        pixel = new Texture2D(GraphicsDevice, 1, 1); //for prototype
        pixel.SetData(new Color[] { Color.White });

        player = new Player(pixel, new Vector2(120, groundY - 110), groundY);

        obstacleSpawner = new ObstacleSpawner(pixel, groundY);

        isGameOver = false;


    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();
    
        if (!isGameOver)
        {
            player.Update(gameTime);
            obstacleSpawner.Update(gameTime);

            //stop game if collision
            if (obstacleSpawner.CheckCollision(player.GetBounds()))
            {
                isGameOver = true;
            }

        }

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        if (isGameOver)
        {
            GraphicsDevice.Clear(Color.DarkRed);
        }
        else
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
        }

        // TODO: Add your drawing code here

        _spriteBatch.Begin();
        
        _spriteBatch.Draw(pixel, new Rectangle(0, (int)groundY, 800, 600 - (int)groundY), Color.Brown);
        player.Draw(_spriteBatch);

        obstacleSpawner.Draw(_spriteBatch);
        
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
