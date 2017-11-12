using System.Linq;
using System.Windows;
using TEdit.Geometry.Primitives;
using TEditXNA.Terraria;
using TEditXna.ViewModel;

namespace TEditXna.Editor.Plugins
{
    public class RemoveAllLavaPlugin : BasePlugin
    {
        public RemoveAllLavaPlugin(WorldViewModel worldViewModel)
            : base(worldViewModel)
        {
            Name = "Remove All Lava";
        }

        public override void Execute()
        {
            if (_wvm.CurrentWorld == null)
                return;

            if (MessageBox.Show("Are you sure you wish to remove all lava from this world?", "Delete Lava?",
                        MessageBoxButton.OKCancel, MessageBoxImage.Question) != MessageBoxResult.OK)
                return;

            for (int x = 0; x < _wvm.CurrentWorld.TilesWide; x++)
            {
                for (int y = 0; y < _wvm.CurrentWorld.TilesHigh; y++)
                {
                    // Check if a tile is a block of pot
                    if (_wvm.CurrentWorld.Tiles[x, y].LiquidType == LiquidType.Lava)
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
