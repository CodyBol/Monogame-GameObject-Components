﻿using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using System;
using Engine.Misc;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

namespace Engine
{
    public class AssetLoader
    {
        private Dictionary<string, Sprite> _sprites;
        private Dictionary<string, SpriteFont> _fonts;
        private Dictionary<string, Song> _songs;
        private Dictionary<string, SoundEffect> _soundEffects;
        private ContentManager _content;

        /**
         * creates the AssetLoader with the needed information
         */
        public AssetLoader(ContentManager Content) 
        {
            _content = Content;
            clearFullLoader();
        }

        /**
         * clears the AssetLoader
         */
        public void clearFullLoader()
        {
            clearSpriteLoader();
            clearFontLoader();
        }

        /**
         * clears the AssetLoader
         */
        public void clearSpriteLoader() {
            _sprites = new Dictionary<string, Sprite>();
        }

        /**
         * clears the AssetLoader
         */
        public void clearFontLoader()
        {
            _fonts = new Dictionary<string, SpriteFont>();
        }

        /**
         * clears the AssetLoader
         */
        public void ClearsongLoader()
        {
            _songs = new Dictionary<string, Song>();
        }

        /**
         * clears the AssetLoader
         */
        public void ClearSoundEffectLoader()
        {
            _soundEffects = new Dictionary<string, SoundEffect>();
        }

        /**
         * adds multiple fonts to the AssetLoader
         */
        public void addFontsToLoader(List<string> fontNames)
        {
            foreach (string fontName in fontNames)
            {
                addFontToLoader(fontName);
            }
        }

        /**
         * adds a single font to the AssetLoader
         */
        public void addFontToLoader(string fontName)
        {
            _fonts.Add(fontName, _content.Load<SpriteFont>("fonts/" + fontName));
        }

        /**
        * get a single font
        */
        public SpriteFont getFont(string fontName)
        {
            if (_fonts.ContainsKey(fontName))
            {
                return _fonts[fontName];
            }

            throw new Exception("The requested sprite [" + fontName + "] is not loaded in the AssetLoader");
        }

        /**
         * adds multiple sprites to the AssetLoader
         */
        public void addSpritesToLoader(List<string> spriteNames) {
            foreach (string spriteName in spriteNames)
            {
                addSpriteToLoader(spriteName);
            }
        }

        /**
         * adds a single sprite to the AssetLoader
         */
        public void addSpriteToLoader(string spriteName)
        {
            Sprite sprite = new Sprite(_content.Load<Texture2D>(spriteName));
            
            _sprites.Add(spriteName, sprite);
        }

        /**
         * adds a single sprite to the AssetLoader
         */
        public void AddSpriteSheetToLoader(string spriteName, Rectangle singleDimensions, Vector2 offset, SpriteSheetType type = SpriteSheetType.SpriteSheet)
        {
            SpriteSheet sheet = new SpriteSheet(_content.Load<Texture2D>(spriteName), singleDimensions, offset, type);
            
            _sprites.Add(spriteName, sheet);
        }

        /**
         * get a single sprite
         */
        public Sprite getSprite(string spriteName) 
        {
            if (_sprites.ContainsKey(spriteName))
            {
                return _sprites[spriteName];
            }

            throw new Exception("The requested sprite [" + spriteName + "] is not loaded in the AssetLoader");
        }

        /**
         * get a single sprite
         */
        public SpriteSheet getSpriteSheet(string spriteName) 
        {
            if (_sprites.ContainsKey(spriteName))
            {
                return _sprites[spriteName] as SpriteSheet;
            }

            throw new Exception("The requested sprite [" + spriteName + "] is not loaded in the AssetLoader");
        }
        
        /**
         * adds multiple songs to the AssetLoader
         */
        public void addSongToLoader(List<string> songNames)
        {
            foreach (string songName in songNames)
            {
                addSongToLoader(songName);
            }
        }

        /**
         * adds a single song to the AssetLoader
         */
        public void addSongToLoader(string songName)
        {
            _songs.Add(songName, _content.Load<Song>("songs/" + songName));
        }

        /**
        * get a single song
        */
        public Song getSong(string songName)
        {
            if (_songs.ContainsKey(songName))
            {
                return _songs[songName];
            }

            throw new Exception("The requested sprite [" + songName + "] is not loaded in the AssetLoader");
        }
        
        /**
         * adds multiple sound effect to the AssetLoader
         */
        public void addSoundEffectToLoader(List<string> soundNames)
        {
            foreach (string soundName in soundNames)
            {
                addSoundEffectToLoader(soundName);
            }
        }

        /**
         * adds a single song to the AssetLoader
         */
        public void addSoundEffectToLoader(string soundName)
        {
            _soundEffects.Add(soundName, _content.Load<SoundEffect>("sound_effects/" + soundName));
        }

        /**
        * get a single song
        */
        public SoundEffect getSoundEffect(string soundName)
        {
            if (_soundEffects.ContainsKey(soundName))
            {
                return _soundEffects[soundName];
            }

            throw new Exception("The requested sprite [" + soundName + "] is not loaded in the AssetLoader");
        }
    }
}
