﻿using System.Linq;
using System.Windows;
using TEdit.Geometry.Primitives;
using TEditXNA.Terraria;
using TEditXna.ViewModel;
using System.Collections.Generic;

namespace TEditXna.Editor.Plugins
{
    public class RemoveAllAltars : BasePlugin
    {

        List<Tile> ebonstone = new List<Tile>();

        public RemoveAllAltars(WorldViewModel worldViewModel)
            : base(worldViewModel)
        {
            Name = "Remove All Altars";
        }

        public override void Execute()
        {
            if (_wvm.CurrentWorld == null)
                return;

            if (MessageBox.Show("Are you sure you wish to remove the altars from this world? This will not count as smashing them.", "Delete Altars",
                        MessageBoxButton.OKCancel, MessageBoxImage.Question) != MessageBoxResult.OK)
                return;


            for (int x = 0; x < _wvm.CurrentWorld.TilesWide; x++)
            {
                for (int y = 0; y < _wvm.CurrentWorld.TilesHigh; y++)
                {
                    // Check if a tile is a block of altar
                    if (_wvm.CurrentWorld.Tiles[x, y].Type == 26)
                    {
                        _wvm.UndoManager.SaveTile(x, y);
                        _wvm.CurrentWorld.Tiles[x, y].Type = 0;
                        _wvm.CurrentWorld.Tiles[x, y].IsActive = false;
                        _wvm.UpdateRenderPixel(x, y);
                    }
                    
                }
            }

            _wvm.UndoManager.SaveUndo();

        }
    }
}
