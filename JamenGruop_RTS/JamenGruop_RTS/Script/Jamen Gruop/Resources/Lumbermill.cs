using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JamenGruop_RTS
{
	class Lumbermill : GameObject
	{
        private int resourceValue = 20;

        private readonly object lockCapacity = new object();

        public Lumbermill(Vector2 pos)
        {
            sprite = SpriteContainer.sprite["LumberMilk"];

            Transform.Position = pos;
            Transform.Scale = new Vector2(2, 2);
        }

        public void GatherResource(Worker worker)
        {
            lock (lockCapacity)
            {
                Thread.Sleep(1500);

                worker.WorkerResourceValue += resourceValue;
                worker.WorkerHasDeliveredResource = false;

                worker.WorkerState = EWorkerStates.MovingToTarget;

                worker.Sprite = SpriteContainer.sprite["WLumber"];
            }
        }
    }
}
