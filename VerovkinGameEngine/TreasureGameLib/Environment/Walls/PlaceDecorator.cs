using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreasureGameLib.Environment.Walls
{
    public abstract class PlaceDecorator : Place
    {
        Place place;

        public PlaceDecorator(Place place, OpenTKColor color)
            : base(place.position, place.Width, place.Height, place.Index, color)
        {
            this.place = place;
        }

        public void SetPlaceObject(Place place) => this.place = place;

        public Place GetPlaceObject() => place;
    }
}
