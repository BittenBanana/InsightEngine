using Insight.Engine.Components;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insight.Engine.Prefabs.UI
{
    class AmmoInterface
    {
        public AmmoInterface(UserInterface ui, float w, float windowHeight)
        {
            ui.AddSprite("Sprites/GUI/bg", "bg", new Vector2(30, windowHeight - 100), Color.White, 1);
            ui.AddSprite("Sprites/GUI/paraliz_nieaktywny", "oko_na", new Vector2(30, windowHeight - 100), Color.White, 1);
            ui.AddSprite("Sprites/GUI/marker_niekatywny", "marker_na", new Vector2(30, windowHeight - 100), Color.White, 1);
            ui.AddSprite("Sprites/GUI/agresja_nieaktywna", "agresja_na", new Vector2(30, windowHeight - 100), Color.White, 1);

            ui.AddSprite("Sprites/GUI/paraliz_aktywny", "oko_a", new Vector2(30, windowHeight - 100), Color.White, 0);
            ui.AddSprite("Sprites/GUI/marker_atywny", "marker_a", new Vector2(30, windowHeight - 100), Color.White, 0);
            ui.AddSprite("Sprites/GUI/agresja_aktywna", "agresja_a", new Vector2(30, windowHeight - 100), Color.White, 0);
            ui.AddSprite("Sprites/GUI/przeslonka", "przeslonka", new Vector2(30, windowHeight - 100), Color.White, 1);

            ui.AddSprite("Sprites/GUI/ramka_pocisk1", "ammo1", new Vector2(30, windowHeight - 100), Color.White, 0);
            ui.AddSprite("Sprites/GUI/ramka_pocisk2", "ammo2", new Vector2(30, windowHeight - 100), Color.White, 0);
            ui.AddSprite("Sprites/GUI/ramka_pocisk3", "ammo3", new Vector2(30, windowHeight - 100), Color.White, 0);
        }
    }
}
