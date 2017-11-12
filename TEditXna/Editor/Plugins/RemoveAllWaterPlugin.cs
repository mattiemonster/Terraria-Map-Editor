using System.Linq;
using System.Windows;
using TEdit.Geometry.Primitives;
using TEditXNA.Terraria;
using TEditXna.ViewModel;

namespace TEditXna.Editor.Plugins
{
    public class RemoveAllWaterPlugin : BasePlugin
    {
        public RemoveAllWaterPlugin(WorldViewModel worldViewModel)
            : base(worldViewModel)
        {
            Name = "Remove All Water";
        }

        public override void Execute()
        {
            if (_wvm.CurrentWorld == null)
                return;

            if (MessageBox.Show("Are you sure you wish to remove all water from this world?", "Delete Water?",
                        MessageBoxButton.OKCancel, MessageBoxImage.Question) != MessageBoxResult.OK)
                return;

            for (int x = 0; x < _wvm.CurrentWorld.TilesWide; x++)
            {
                for (int y = 0; y < _wvm.CurrentWorld.TilesHigh; y++)
                {
                    // Check if a tile is a block of pot
                    if (_wvm.CurrentWorld.Tiles[x, y].LiquidType == LiquidType.Water)
                    {
                        _wvm.UndoManager.SaveTile(x, y);
                        _wvm.CurrentWorld.Tiles[x, y].LiquidType = LiquidType.None;
                        _wvm.CurrentWorld.Tiles[x, y].LiquidAmount = (byte)0;
                        _wvm.UpdateRenderPixel(x, y);
                    }
                }
            }

            _wvm.UndoManager.SaveUndo();

        }
    }
}
