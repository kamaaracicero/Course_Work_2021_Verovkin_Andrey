using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreasureGameLib;

namespace VerovkinGameEngine.ElementMovement
{
    public class ObjectMover
    {
        public void MovePlayerX(float distance, ref float[] coords, GameObject player)
        {
            for (int index = 0; index < 12; index += 3)
            {
                coords[index] += distance;
            }
            player.position.X = coords[0];
            player.position.Y = coords[1];
        }

        public void MovePlayerY(float distance, ref float[] coords, GameObject player)
        {
            for (int index = 1; index < 12; index += 3)
            {
                coords[index] += distance;
            }
            player.position.X = coords[0];
            player.position.Y = coords[1];
        }

        public void MovePlayerViewBox(ref float[] coords, Player player)
        {
            float[] newViewBoxCoords = player.MoveViewBlock();

            for (int index = 12; index < coords.Length; index++)
            {
                coords[index] = newViewBoxCoords[index - 12];
            }
        }

        public void MovePlayerZ(float distance, ref float[] coords)
        {
            for (int index = 2; index < coords.Length; index += 3)
            {
                coords[index] += distance;
            }
        }
    }
}
