using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TerraNullius
{
    class Item
    {
        protected int iID;
        
        protected int iWidth;
        protected int iHeight;

        protected int dWidth;
        protected int dHeight;

        protected int iStack;
        protected int iStackable;
        protected int iMaxStack;

        protected bool iDropped;
        protected bool droppedCollision;

        public Item(int id)
        {
            iID = id;
        }

        public Item(int id, int width, int height)
        {
            iID = id;
            iWidth = width;
            iHeight = height;
        }

        public Item(int id, int width, int height, int stack)
        {
            iID = id;
            iWidth = width;
            iHeight = height;
            iStack = stack;
        }

        public Item(int id, int width, int height, int stack, bool dropped)
        {
            iID = id;
            iWidth = width;
            iHeight = height;
            iStack = stack;
            iDropped = dropped;
        }

        protected void reduceItemStack()
        {

        }

    }
}
