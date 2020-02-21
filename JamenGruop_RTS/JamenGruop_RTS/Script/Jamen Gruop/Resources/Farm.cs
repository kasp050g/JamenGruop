using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JamenGruop_RTS
{
    class Farm : GameObject
    {
        private int resourceValue = 10;

        private Mutex m = new Mutex();

        public Farm(Vector2 pos)
        {
            sprite = SpriteContainer.sprite["Fram"];

            Transform.Position = pos;
            Transform.Scale = new Vector2(2,2);
        }

        public void GatherResource(Worker worker)
        {
            m.WaitOne();
            Thread.Sleep(1500);

            worker.WorkerResourceValue += resourceValue;
            worker.WorkerHasDeliveredResource = false;

            worker.WorkerState = EWorkerStates.MovingToTarget;

            worker.Sprite = SpriteContainer.sprite["WMineFood"];
            m.ReleaseMutex();
        }
    }
}
