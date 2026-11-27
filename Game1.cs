using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CaveRun;

enum GameState
{
    MainMenu,
    CharacterSelect,
    Playing,
    Win,
    GameOver
}
public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    private Texture2D pixel;
    private float groundY = 480;

    private InputManager inputManager;

    private GameplayScreen gameplayScreen;
    private GameState currentState;


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

        inputManager = new InputManager();

        gameplayScreen = new GameplayScreen(pixel, groundY);
        currentState = GameState.Playing; //since there is no main menu, for testing


    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        inputManager.Update();

        if (currentState == GameState.Playing)
        {
            gameplayScreen.Update(gameTime, inputManager);

            if (gameplayScreen.IsGameOver())
            {
                currentState = GameState.GameOver;
            }
        }
        else if (currentState == GameState.GameOver)
        {
            //for testing
            if (inputManager.IsKeyPressed(Keys.R))
            {
                gameplayScreen.Reset();
                currentState = GameState.Playing;
            }
        }

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        if (currentState == GameState.GameOver)
        {
            GraphicsDevice.Clear(Color.DarkRed);
        }
        else
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
        }

        // TODO: Add your drawing code here

        _spriteBatch.Begin();
        
        gameplayScreen.Draw(_spriteBatch);

        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
