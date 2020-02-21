using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JamenGruop_RTS
{
	class Goldmine : GameObject
	{
        private int resourceValue = 25;

        private int availableResource = 100000;

        private Semaphore capacitySemaphore = new Semaphore(3, 3);

        public Goldmine(Vector2 pos)
        {
            sprite = SpriteContainer.sprite["GoldMine"];

            Transform.Position = pos;
            Transform.Scale = new Vector2(2, 2);
        }

        public void GatherResource(Worker worker)
        {
            if (availableResource > 0)
            {
                capacitySemaphore.WaitOne();
                Thread.Sleep(3000);

                worker.WorkerResourceValue += resourceValue;
                availableResource -= resourceValue;
                worker.WorkerHasDeliveredResource = false;

                worker.WorkerState = EWorkerStates.MovingToTarget;

                worker.Sprite = SpriteContainer.sprite["WMineFood"];
                capacitySemaphore.Release();
            }
        }
    }
}
