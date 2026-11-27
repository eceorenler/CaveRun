using Microsoft.Xna.Framework.Input;

class InputManager
{
    private KeyboardState currentKeyboard;
    private KeyboardState previousKeyboard;

    public InputManager()
    {
        currentKeyboard = Keyboard.GetState();
        previousKeyboard = currentKeyboard;
    }

    public void Update()
    {
        previousKeyboard = currentKeyboard;
        currentKeyboard = Keyboard.GetState();
    }

    //for holding the button
    public bool IsKeyDown(Keys key)
    {
        return currentKeyboard.IsKeyDown(key);
    }

    
    public bool IsKeyPressed(Keys key)
    {
        return currentKeyboard.IsKeyDown(key) && previousKeyboard.IsKeyUp(key);
    }

    public bool IsJumpPressed()
    {
        return IsKeyPressed(Keys.Space) || IsKeyPressed(Keys.W) || IsKeyPressed(Keys.Up);
    }

    public bool IsRollHeld()
    {
        return IsKeyDown(Keys.S) || IsKeyDown(Keys.Down);
    }
}