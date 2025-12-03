using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.IO;

namespace animation_lesson
{
    enum Screen
    {
        Intro,
        TribbleYard, 
        Outro

    }
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Rectangle window;

        Screen screen;

        SoundEffect gameOver;

        SpriteFont introText, outroText;

        MouseState mouseState;

        Texture2D introTexture, outroTexture;

        Rectangle tribbleOrangeRect, tribbleGreyRect, tribbleCreamRect, tribbleBrownRect;

        Texture2D tribbleOrangeTexture, tribbleGreyTexture, tribbleCreamTexture, tribbleBrownTexture;

        Vector2 tribbleOrangeSpeed, tribbleGreySpeed, tribbleCreamSpeed, tribbleBrownSpeed;

        Color backColor;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            window = new Rectangle(0, 0, 800, 600);
            _graphics.PreferredBackBufferWidth = window.Width;
            _graphics.PreferredBackBufferHeight = window.Height;
            _graphics.ApplyChanges();

            screen = Screen.Intro;
            //screen = Screen.Outro;

            tribbleOrangeRect = new Rectangle(275, 75, 100, 100);
            tribbleOrangeSpeed = new Vector2(2, 1);
            tribbleBrownRect = new Rectangle(500, 10, 100, 100);
            tribbleBrownSpeed = new Vector2(2, 1);
            tribbleGreyRect = new Rectangle(300, 300, 100, 100);
            tribbleGreySpeed = new Vector2(2, 1);
            tribbleCreamRect = new Rectangle(500, 500, 100, 100);
            tribbleCreamSpeed = new Vector2(0, 3);

            backColor = Color.LightPink;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            tribbleOrangeTexture = Content.Load<Texture2D>("tribbleOrange");
            tribbleBrownTexture = Content.Load<Texture2D>("tribbleBrown");
            tribbleGreyTexture = Content.Load<Texture2D>("tribbleGrey");
            tribbleCreamTexture = Content.Load<Texture2D>("tribbleCream");
            introTexture = Content.Load<Texture2D>("tribble_intro");
            introText = Content.Load<SpriteFont>("introText");
            outroTexture = Content.Load<Texture2D>("tribble_Outro");
            outroText = Content.Load<SpriteFont>("outro");

            gameOver = Content.Load<SoundEffect>("gameOver");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            mouseState = Mouse.GetState();


            if (screen == Screen.Intro)
            {
                if (mouseState.LeftButton == ButtonState.Pressed)
                    screen = Screen.TribbleYard;
            }
            else if (screen == Screen.TribbleYard)
            {

                

                tribbleOrangeRect.X += (int)tribbleOrangeSpeed.X;
                tribbleOrangeRect.Y += (int)tribbleOrangeSpeed.Y;
                if (tribbleOrangeRect.Right > window.Width || tribbleOrangeRect.Left < 0)
                {
                    tribbleOrangeSpeed.X *= -1;
                    backColor = Color.LightPink;
                }
                if (tribbleOrangeRect.Top < 0 || tribbleOrangeRect.Bottom > window.Height)
                {
                    tribbleOrangeSpeed.Y *= -1;
                    backColor = Color.LightPink;
                }

                tribbleBrownRect.X += (int)tribbleBrownSpeed.X;
                tribbleBrownRect.Y += (int)tribbleBrownSpeed.Y;
                if (tribbleBrownRect.Right > window.Width || tribbleBrownRect.Left < 0)
                {
                    tribbleBrownSpeed.X *= -1;
                    backColor = Color.Pink;
                }
                if (tribbleBrownRect.Top < 0 || tribbleBrownRect.Bottom > window.Height)
                {
                    tribbleBrownSpeed.Y *= -1;
                    backColor = Color.Pink;
                }

                tribbleCreamRect.X += (int)tribbleCreamSpeed.X;
                tribbleCreamRect.Y += (int)tribbleCreamSpeed.Y;
                if (tribbleCreamRect.Right > window.Width || tribbleCreamRect.Left < 0)
                {
                    tribbleCreamSpeed.X *= -1;
                    backColor = Color.Purple;

                }
                if (tribbleCreamRect.Top < 0 || tribbleCreamRect.Bottom > window.Height)
                {
                    tribbleCreamSpeed.Y *= -1;
                    backColor = Color.Purple;

                }

                tribbleGreyRect.X += (int)tribbleGreySpeed.X;
                tribbleGreyRect.Y += (int)tribbleGreySpeed.Y;
                if (tribbleGreyRect.Right > window.Width || tribbleGreyRect.Left < 0)
                {
                    tribbleGreySpeed.X *= -1;
                    backColor = Color.LightSkyBlue;
                }
                if (tribbleGreyRect.Top < 0 || tribbleGreyRect.Bottom > window.Height)
                {
                    tribbleGreySpeed.Y *= -1;
                    backColor = Color.LightSkyBlue;
                }

                if (mouseState.RightButton == ButtonState.Pressed)
                {
                    screen = Screen.Outro;
                    gameOver.Play();
                }
            }
            else if (screen == Screen.Outro)
            {
              
            }


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(backColor);


            // TODO: Add your drawing code here

            _spriteBatch.Begin();

            if (screen== Screen.Intro)
            {
                _spriteBatch.Draw(introTexture, window, Color.White);
                _spriteBatch.DrawString(introText, "To start, Left Click", new Vector2(300, 400), Color.White);
            }
            else if (screen == Screen.Outro)
            {
                _spriteBatch.Draw(outroTexture, window, Color.White);
                _spriteBatch.DrawString(outroText, "Game over, Press esc to leave game", new Vector2(200, 400), Color.White);
            }
            else if (screen== Screen.TribbleYard)
            {
                _spriteBatch.Draw(tribbleOrangeTexture, tribbleOrangeRect, Color.White);
                _spriteBatch.Draw(tribbleGreyTexture, tribbleGreyRect, Color.White);
                _spriteBatch.Draw(tribbleCreamTexture, tribbleCreamRect, Color.White);
                _spriteBatch.Draw(tribbleBrownTexture, tribbleBrownRect, Color.White);
            }

                _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
