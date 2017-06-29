using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insight
{
    class ContentModels
    {
        private static ContentModels instance;
        public static ContentModels Instance
        {
            get
            {
                if (instance == null)
                    instance = new ContentModels();
                return instance;
            }
        }

        public Model ammo_pc { get; private set; }
        public Model column { get; private set; }
        public Model column_rotated { get; private set; }
        public Model cor_corn_col { get; private set; }
        public Model cor_corn_col_rotated { get; private set; }
        public Model cor_corn_lt { get; private set; }
        public Model cor_corn_lt_rotated { get; private set; }
        public Model cor_corn_rt { get; private set; }
        public Model corner { get; private set; }
        public Model corridor_corner_colliders { get; private set; }
        public Model cor_str_3way_lt_g { get; private set; }
        public Model cor_str_3way_nt_g { get; private set; }
        public Model cor_str_3way_nt_g_rotated { get; private set; }
        public Model cor_str_4way_g { get; private set; }
        public Model cor_str_rt_g { get; private set; }
        public Model cor_str_rt_g_rotated { get; private set; }
        public Model cor_str_rt_g_window { get; private set; }
        public Model door_frame { get; private set; }
        public Model door_l_wing { get; private set; }
        public Model door_r_wing { get; private set; }
        public Model door_wall_5x4 { get; private set; }
        public Model door_wall_5x6 { get; private set; }
        public Model f_3x5 { get; private set; }
        public Model f_3x5_rotated { get; private set; }
        public Model f_5x5 { get; private set; }
        public Model floor5x5 { get; private set; }
        public Model floor_5x5_box { get; private set; }
        public Model floorPlane { get; private set; }
        public Model stairs { get; private set; }
        public Model stairsCollider { get; private set; }
        public Model straight { get; private set; }
        public Model straight_rotated { get; private set; }
        public Model w_3x4 { get; private set; }
        public Model w_3x4_visible { get; private set; }
        public Model w_3x5 { get; private set; }
        public Model w_5x4 { get; private set; }
        public Model w_5x4_visible { get; private set; }
        public Model w_5x5 { get; private set; }
        public Model w_5x5_visible { get; private set; }
        public Model wall { get; private set; }
        public Model wall_5x3_dm_g { get; private set; }
        public Model wall_5x4_dm_g { get; private set; }
        public Model wall5x5withDoor { get; private set; }
        public Model wall_dm_g { get; private set; }
        public Model wall_sdl_g { get; private set; }
        public Model wall_sdm_g { get; private set; }
        public Model wall_sdr_g { get; private set; }

        public Model ball { get; private set; }
        public Model bulletdispenser { get; private set; }
        public Model dispensertrigger { get; private set; }
        public Model triggerbox { get; private set; }

        public Model superBoxHero { get; private set; }
        public Model crate { get; private set; }
        public Model desk2Monitors { get; private set; }
        public Model intercom { get; private set; }
        public Model bigMachine { get; private set; }
        public Model playerRun { get; set; }
        public Model playerIdle { get; set; }
        public Model playerDeath { get; set; }
        public Model playerWalkF { get; set; }
        public Model playerWalkB { get; set; }
        public Model playerWalkL { get; set; }
        public Model playerWalkR { get; set; }
        public Model playerFistFight { get; set; }
        public Model enemyWalkF { get; set; }
        public Model enemyAggresive { get; set; }
        public Model enemyFight { get; set; }
        public Model enemyDeath { get; set; }
        public Model enemyIdle { get; set; }
        public Model enemyParalysis{ get; set; }
        public Model enemyMarker { get; set; }
        public Model enemyShooting { get; set; }
        public Model enemyDancing { get; set; }
        public Model bigMachineCollider { get; set; }
        public Model ceilingBogRoom { get; set; }
        public Model newWall { get; set; }
        public Model newWallSmaller { get; set; }
        public Model straightCollider { get; set; }
        public Model smallRoomCeiling { get; set; }
        public Model lastRoomCeiling { get; set; }
        public Model glassModel { get; set; }
        public Model glassBaseModel { get; set; }
        public Model sleepingDude { get; set; }

        public void LoadContent(ContentManager content)
        {
            playerIdle = content.Load<Model>("Models/pistol_idle");
            playerRun = content.Load<Model>("Models/pistol_run");
            playerDeath = content.Load<Model>("Models/death");
            playerWalkB = content.Load<Model>("Models/pistol_walk_b");
            playerWalkF = content.Load<Model>("Models/pistol_walk_f");
            playerWalkR = content.Load<Model>("Models/pistol_walk_r");
            playerWalkL = content.Load<Model>("Models/pistol_walk_l");
            playerFistFight = content.Load<Model>("Models/fist_fight_A");
            enemyWalkF = content.Load<Model>("Models/Enemy/enemy_walk_f");
            enemyAggresive = content.Load<Model>("Models/Enemy/enemy_aggresive");
            enemyDeath = content.Load<Model>("Models/Enemy/enemy_death");
            enemyFight = content.Load<Model>("Models/Enemy/enemy_fight_fist");
            enemyIdle = content.Load<Model>("Models/Enemy/enemy_idle");
            enemyParalysis = content.Load<Model>("Models/Enemy/enemy_paralysis");
            enemyMarker = content.Load<Model>("Models/Enemy/enemy_marker");
            enemyShooting = content.Load<Model>("Models/Enemy/shooting");
            enemyDancing = content.Load<Model>("Models/Enemy/flair");

            ammo_pc = content.Load<Model>("Models/Konrads/Enviroment/ammo-pc");
            column = content.Load<Model>("Models/Konrads/Enviroment/column");
            column_rotated = content.Load<Model>("Models/Konrads/Enviroment/column-rotated");
            cor_corn_col = content.Load<Model>("Models/Konrads/Enviroment/cor-corn-col");
            cor_corn_col_rotated = content.Load<Model>("Models/Konrads/Enviroment/cor-corn-col-rotated");
            cor_corn_lt = content.Load<Model>("Models/Konrads/Enviroment/cor-corn-lt");
            cor_corn_lt_rotated = content.Load<Model>("Models/Konrads/Enviroment/cor-corn-lt-rotated");
            cor_corn_rt = content.Load<Model>("Models/Konrads/Enviroment/cor-corn-rt");
            corner = content.Load<Model>("Models/Konrads/Enviroment/corner");
            corridor_corner_colliders = content.Load<Model>("Models/Konrads/Enviroment/corridor-corner-colliders");
            cor_str_3way_lt_g = content.Load<Model>("Models/Konrads/Enviroment/cor-str-3way-lt-g");
            cor_str_3way_nt_g = content.Load<Model>("Models/Konrads/Enviroment/cor-str-3way-nt-g");
            cor_str_3way_nt_g_rotated = content.Load<Model>("Models/Konrads/Enviroment/cor-str-3way-nt-g-rotated");
            cor_str_4way_g = content.Load<Model>("Models/Konrads/Enviroment/cor-str-4way-g");
            cor_str_rt_g = content.Load<Model>("Models/Konrads/Enviroment/cor-str-rt-g");
            cor_str_rt_g_rotated = content.Load<Model>("Models/Konrads/Enviroment/cor-str-rt-g-rotated");
            cor_str_rt_g_window = content.Load<Model>("Models/Konrads/Enviroment/cor-str-rt-g-window");
            door_frame = content.Load<Model>("Models/Konrads/Enviroment/Door/frame");
            door_l_wing = content.Load<Model>("Models/Konrads/Enviroment/Door/l-wing");
            door_r_wing = content.Load<Model>("Models/Konrads/Enviroment/Door/r-wing");
            door_wall_5x4 = content.Load<Model>("Models/Konrads/Enviroment/Door/wall-5x4");
            door_wall_5x6 = content.Load<Model>("Models/Konrads/Enviroment/Door/wall-5x6");
            f_3x5 = content.Load<Model>("Models/Konrads/Enviroment/f-3x5");
            f_3x5_rotated = content.Load<Model>("Models/Konrads/Enviroment/f-3x5-rotated");
            f_5x5 = content.Load<Model>("Models/Konrads/Enviroment/f-5x5");
            floor5x5 = content.Load<Model>("Models/Konrads/Enviroment/floor5x5");
            floor_5x5_box = content.Load<Model>("Models/Konrads/Enviroment/floor-5x5-box");
            floorPlane = content.Load<Model>("Models/Konrads/Enviroment/floorPlane");
            stairs = content.Load<Model>("Models/Konrads/Enviroment/stairs");
            stairsCollider = content.Load<Model>("Models/Konrads/Enviroment/stairs-col");
            straight = content.Load<Model>("Models/Konrads/Enviroment/straight");
            straight_rotated = content.Load<Model>("Models/Konrads/Enviroment/straight-rotated");
            w_3x4 = content.Load<Model>("Models/Konrads/Enviroment/w-3x4");
            w_3x4_visible = content.Load<Model>("Models/Konrads/Enviroment/w-3x4-visible");
            w_3x5 = content.Load<Model>("Models/Konrads/Enviroment/w-3x5");
            w_5x4 = content.Load<Model>("Models/Konrads/Enviroment/w-5x4");
            w_5x4_visible = content.Load<Model>("Models/Konrads/Enviroment/w-5x4-visible");
            w_5x5 = content.Load<Model>("Models/Konrads/Enviroment/w-5x5");
            w_5x5_visible = content.Load<Model>("Models/Konrads/Enviroment/w-5x5-visible");
            wall = content.Load<Model>("Models/Konrads/Enviroment/wall");
            wall_5x3_dm_g = content.Load<Model>("Models/Konrads/Enviroment/wall-5x3-dm-g");
            wall_5x4_dm_g = content.Load<Model>("Models/Konrads/Enviroment/wall-5x4-dm-g");
            wall5x5withDoor = content.Load<Model>("Models/Konrads/Enviroment/wall5x5withDoor");
            wall_dm_g = content.Load<Model>("Models/Konrads/Enviroment/wall-dm-g");
            wall_sdl_g = content.Load<Model>("Models/Konrads/Enviroment/wall-sdl-g");
            wall_sdm_g = content.Load<Model>("Models/Konrads/Enviroment/wall-sdm-g");
            wall_sdr_g = content.Load<Model>("Models/Konrads/Enviroment/wall-sdr-g");

            ball = content.Load<Model>("Models/ball");
            bulletdispenser = content.Load<Model>("Models/bulletdispenser");
            dispensertrigger = content.Load<Model>("Models/dispensertrigger");
            triggerbox = content.Load<Model>("Models/triggerbox");
            superBoxHero = content.Load<Model>("Models/Konrads/Character/superBoxHero");
            crate = content.Load<Model>("Models/Konrads/Enviroment/crate");
            desk2Monitors = content.Load<Model>("Models/Konrads/Enviroment/desk-2monitors");
            intercom = content.Load<Model>("Models/Konrads/Enviroment/intercom");
            bigMachine = content.Load<Model>("Models/Konrads/Enviroment/bigMachine_1stRoom");
            bigMachineCollider = content.Load<Model>("Models/Konrads/Enviroment/bigMachine_1stRoom_collider");
            ceilingBogRoom = content.Load<Model>("Models/Konrads/Enviroment/sufit_pokojZMaszyna");
            newWall = content.Load<Model>("Models/Konrads/Enviroment/w-5x5-new");
            newWallSmaller = content.Load<Model>("Models/Konrads/Enviroment/w-3x5-new");
            straightCollider = content.Load<Model>("Models/Konrads/Enviroment/collider-cor-str");
            smallRoomCeiling = content.Load<Model>("Models/Konrads/Enviroment/sufit_malyPokoj");
            lastRoomCeiling = content.Load<Model>("Models/Konrads/Enviroment/sufit_pokojKoncowy");
            glassModel = content.Load<Model>("Models/Konrads/Enviroment/szybaGora");
            glassBaseModel = content.Load<Model>("Models/Konrads/Enviroment/szybaDol");
            sleepingDude = content.Load<Model>("Models/Konrads/Character/ofiara");
        }
    }
}
