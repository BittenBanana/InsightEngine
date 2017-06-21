using Insight.Engine.Components;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insight.Engine.Prefabs.UI
{
    class SightSlider
    {
        private UserInterface ui;
        private float offset = 0;
        private static float sliderWidth = 200.0f;
        public SightSlider(UserInterface ui, float w, float h)
        {
            this.ui = ui;
            ui.AddSprite("Sprites/GUI/SightSlider/pasek", "pasek", new Vector2(30, 30), Color.White, 1);
            ui.AddSprite("Sprites/GUI/SightSlider/wskaznik", "wskaznik", new Vector2(30, 30), Color.White, 1);
        }

        public void SetSightLevel(float lvl)
        {
            offset = 30 + lvl * sliderWidth;

            ui.ChangeSpritePosition("wskaznik", offset , 30);
        }


        
    }
}
