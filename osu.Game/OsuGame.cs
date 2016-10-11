﻿//Copyright (c) 2007-2016 ppy Pty Ltd <contact@ppy.sh>.
//Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using osu.Game.Configuration;
using osu.Game.GameModes.Menu;
using OpenTK;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Sprites;
using osu.Framework.OS;
using osu.Game.Graphics.Background;
using osu.Game.GameModes.Play;
using osu.Game.Graphics.Containers;
using osu.Game.Overlays;

namespace osu.Game
{
    public class OsuGame : OsuGameBase
    {
        public Toolbar Toolbar;

        public override void SetHost(BasicGameHost host)
        {
            base.SetHost(host);

            host.Size = new Vector2(Config.Get<int>(OsuConfig.Width), Config.Get<int>(OsuConfig.Height));
        }

        public override void Load()
        {
            base.Load();

            ShowPerformanceOverlay = true;

            Add(new Drawable[] {
                new ParallaxContainer
                {
                    Children = new [] {
                        new Background()
                    }
                },
                new MainMenu(),
                Toolbar = new Toolbar(),
            });
        }

        public override bool Invalidate(Invalidation invalidation = Invalidation.All, Drawable source = null, bool shallPropagate = true)
        {
            if (!base.Invalidate(invalidation, source, shallPropagate)) return false;

            if (Parent != null)
            {
                Config.Set(OsuConfig.Width, Size.X);
                Config.Set(OsuConfig.Height, Size.Y);
            }
            return true;
        }
    }
}
