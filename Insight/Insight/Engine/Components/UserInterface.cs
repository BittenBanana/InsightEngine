using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insight.Engine.Components
{
    public class UserInterface
    {
        private SpriteBatch spriteBatch;
        private Dictionary<string, Sprite>  sprites;
        private Dictionary<string, FontText> texts;
        private ContentManager content;
        private GameObject gameObject;

        private struct Sprite
        {
            public Texture2D spriteTexture;
            public Vector2 position;
            public Color color;
            public float opacity;
        }
        
        private struct FontText
        {
            public SpriteFont spriteFont;
            public string text;
            public Vector2 position;
            public Color color;
            public float opacity;
        }

        public UserInterface(GameObject gameObject, GraphicsDevice graphics, ContentManager content)
        {
            sprites = new Dictionary<string, Sprite>();
            texts = new Dictionary<string, FontText>();
            spriteBatch = new SpriteBatch(graphics);
            this.content = content;
            this.gameObject = gameObject;
        }

        public void AddSprite(string path, string name, Vector2 position, Color color, float opacity)
        {
            Sprite sprite = new Sprite();
            Texture2D texture = content.Load<Texture2D>(path);
            sprite.spriteTexture = texture;
            sprite.position = position;
            sprite.opacity = opacity;
            sprite.color = color;
            sprites.Add(name, sprite);
        }

        public void AddText(string path, string name, string text, Vector2 position, Color color, float opacity)
        {
            FontText font = new FontText();
            SpriteFont spriteFont = content.Load<SpriteFont>(path);
            font.spriteFont = spriteFont;
            font.position = position;
            font.opacity = opacity;
            font.color = color;
            font.text = text;
            texts.Add(name, font);
        }

        public void ChangeSpriteOpacity(string spriteName, float opacity)
        {
            if(sprites[spriteName].opacity <= 1)
            {
                Sprite sprite = sprites[spriteName];
                sprite.opacity = opacity;
                sprites[spriteName] = sprite;
            }
        }

        public void ChangeText(string textName, string text)
        {
            FontText font = texts[textName];
            font.text = text;
            texts[textName] = font;
        }

        public void ChangeTextOpacity(string textName, float opacity)
        {
            if (texts[textName].opacity <= 1)
            {
                FontText text = texts[textName];
                text.opacity = opacity;
                texts[textName] = text;
            }
        }

        public void ChangeSpritePosition(string spriteName, float posX, float posY)
        {
            if (sprites[spriteName].opacity <= 1)
            {
                Sprite sprite = sprites[spriteName];
                sprite.position = new Vector2(posX, posY);
                sprites[spriteName] = sprite;
            }
        }

        public void Draw()
        {
            spriteBatch.Begin(SpriteSortMode.Texture, BlendState.AlphaBlend);

            foreach (KeyValuePair<string, Sprite> pair in sprites)
            {
                spriteBatch.Draw(pair.Value.spriteTexture, pair.Value.position, null, pair.Value.color * pair.Value.opacity, 0f, Vector2.Zero, 1.0f, SpriteEffects.None, 0f);
            }

            foreach (KeyValuePair<string, FontText> pair in texts)
            {
                spriteBatch.DrawString(pair.Value.spriteFont, pair.Value.text, pair.Value.position, pair.Value.color * pair.Value.opacity);
            }

                     

            spriteBatch.End();
        }

    }
}
