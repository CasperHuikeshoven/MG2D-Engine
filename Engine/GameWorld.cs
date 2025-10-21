using System;
using Microsoft.Xna.Framework;

namespace Engine
{
    public class GameWorld : GameObjectList
    {
        protected Tile[,] tiles;

        public GameWorld(string filename)
        {
            tiles = new Tile[20,12];
            ReadWorld(filename);
        }

        public virtual void ReadWorld(string filename)
        {

        }

        public bool HasTileCollision(int x, int y, Rectangle rectangle)
        {
            if(x < 0 || x >= tiles.GetLength(0) || y < 0 || y >= tiles.GetLength(1))
                return false;
            
            return tiles[x,y].HasCollision && rectangle.Intersects(tiles[x,y].BoundingBoxForCollisions);
        }
    }
}


