using System.Linq;
using System.Windows;
using TEdit.Geometry.Primitives;
using TEditXNA.Terraria;
using TEditXna.ViewModel;
using System.Collections.Generic;

namespace TEditXna.Editor.Plugins
{
    public class RemoveAllCorruption : BasePlugin
    {

        List<Tile> ebonstone = new List<Tile>();

        public RemoveAllCorruption(WorldViewModel worldViewModel)
            : base(worldViewModel)
        {
            Name = "Remove All Corruption";
        }

        public override void Execute()
        {
            if (_wvm.CurrentWorld == null)
                return;

            if (MessageBox.Show("Are you sure you wish to remove the corruption blocks from this world?", "Delete Corruption",
                        MessageBoxButton.OKCancel, MessageBoxImage.Question) != MessageBoxResult.OK)
                return;


            for (int x = 0; x < _wvm.CurrentWorld.TilesWide; x++)
            {
                for (int y = 0; y < _wvm.CurrentWorld.TilesHigh; y++)
                {
                    // Check if a tile is a block of ebonstone
                    if (_wvm.CurrentWorld.Tiles[x, y].Type == 25)
                    {
                            _wvm.UndoManager.SaveTile(x, y);
                            _wvm.CurrentWorld.Tiles[x, y].Type = 1;
                            _wvm.UpdateRenderPixel(x, y);
                    }

                    if (_wvm.CurrentWorld.Tiles[x, y].Type == 163)
                    {
                        _wvm.UndoManager.SaveTile(x, y);
                        _wvm.CurrentWorld.Tiles[x, y].Type = 161;
                        _wvm.UpdateRenderPixel(x, y);
                    }

                    if (_wvm.CurrentWorld.Tiles[x, y].Type == 24)
                    {
                        _wvm.UndoManager.SaveTile(x, y);
                        _wvm.CurrentWorld.Tiles[x, y].Type = 0;
                        _wvm.CurrentWorld.Tiles[x, y].IsActive = false;
                        _wvm.UpdateRenderPixel(x, y);
                    }

                    if (_wvm.CurrentWorld.Tiles[x, y].Type == 23)
                    {
                        _wvm.UndoManager.SaveTile(x, y);
                        _wvm.CurrentWorld.Tiles[x, y].Type = 2;
                        _wvm.UpdateRenderPixel(x, y);
                    }

                    if (_wvm.CurrentWorld.Tiles[x, y].Type == 112)
                    {
                        _wvm.UndoManager.SaveTile(x, y);
                        _wvm.CurrentWorld.Tiles[x, y].Type = 53;
                        _wvm.UpdateRenderPixel(x, y);
                    }

                    if (_wvm.CurrentWorld.Tiles[x, y].Type == 398)
                    {
                        _wvm.UndoManager.SaveTile(x, y);
                        _wvm.CurrentWorld.Tiles[x, y].Type = 397;
                        _wvm.UpdateRenderPixel(x, y);
                    }

                    if (_wvm.CurrentWorld.Tiles[x, y].Type == 400)
                    {
                        _wvm.UndoManager.SaveTile(x, y);
                        _wvm.CurrentWorld.Tiles[x, y].Type = 396;
                        _wvm.UpdateRenderPixel(x, y);
                    }

                    if (_wvm.CurrentWorld.Tiles[x, y].Type == 32)
                    {
                        _wvm.UndoManager.SaveTile(x, y);
                        _wvm.CurrentWorld.Tiles[x, y].Type = 0;
                        _wvm.CurrentWorld.Tiles[x, y].IsActive = false;
                        _wvm.UpdateRenderPixel(x, y);
                    }

                    if (_wvm.CurrentWorld.Tiles[x, y].Wall == (byte)3)
                    {
                        _wvm.UndoManager.SaveTile(x, y);
                        _wvm.CurrentWorld.Tiles[x, y].Wall = (byte)1;
                        _wvm.UpdateRenderPixel(x, y);
                    }

                }
                }

                _wvm.UndoManager.SaveUndo();

            }
        }
    }
