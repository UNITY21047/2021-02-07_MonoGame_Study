using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace pt_1
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D box;
        private Vector2 box_position;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            box_position = new Vector2(100f);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            box = Content.Load<Texture2D>("box");
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }
            
            // TODO: Add your update logic here
            #region Keyboard
            // Allows the game to exit
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                this.Exit();
            }

            // Update the image positions with AWSD
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                box_position.X--;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                box_position.X++;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                box_position.Y--;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                box_position.Y++;
            }
            #endregion

            #region Mouse
            // Poll mouse state
            MouseState mouse_state = Mouse.GetState();
            // If left mouse button is pressed
            if (mouse_state.LeftButton == ButtonState.Pressed)
            {
                box_position = new Vector2(mouse_state.X, mouse_state.Y);
            }
            #endregion

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.FromNonPremultiplied(187, 68, 48, 100));

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _spriteBatch.Draw(box, box_position, Color.White);
            _spriteBatch.End();
            
            base.Draw(gameTime);
        }
    }
}
