using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TerraNullius
{
    class Placeable : Item
    {
        public Placeable(int id)
            : base(id)
        {

        }

        public Placeable(int id, int width, int height)
            : base(id, width, height)
        {

        }

        public Placeable(int id, int width, int height, int stack)
            : base(id, width, height, stack)
        {

        }

        public Placeable(int id, int width, int height, int stack, bool dropped)
            : base(id, width, height, stack, dropped)
        {

        }

        private void placeItem(int mouseX, int mouseY)
        {
            //Take the X,Y...
            //Find the bounding box
            //Check availabilty
            //Place item
            //Reduce Stack
        }
    }
}
