using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JamenGruop_RTS
{
    class Worker : GameObject
    {
        public int WorkerResourceValue = 0;
        public bool WorkerHasDeliveredResource = true;
        public EResources WorkerResource = new EResources();
        public Thread WorkerThread;

        public Player Owner;

        private ETeam workerTeam = new ETeam();
        public EWorkerStates WorkerState = new EWorkerStates();

        private Component targetBuilding;

        private Vector2 velocity = new Vector2();
        private float speed = 400f;

        private bool isAlive = true;
        public bool IsSelected = true;

        private Barracks barracks;
        private Goldmine mine;
        private Lumbermill lumbermill;
        private Farm farm;

        public Worker(Player owner, Vector2 spawnPosition)
        {
            sprite = SpriteContainer.sprite["WIdle"];
            color = Color.White;
            transform.Scale = new Vector2(2, 2);

            WorkerResource = EResources.Gold;

            transform.Position = spawnPosition;

            Owner = owner;
            workerTeam = Owner.PlayerTeam;
            WorkerState = EWorkerStates.MovingToTarget;

            WorkerThread = new Thread(Update);
            WorkerThread.IsBackground = true;
            WorkerThread.Start();
        }

        public override void Update()
        {
            while (isAlive)
            {
                Thread.Sleep(6); // Monogames Update looper approx hvert 6 ms.
                                 // Dette replikere denne egenskab, for tråden.

                HandleInput();

                    switch (WorkerState)
                    {
                        case EWorkerStates.Delivering:
                            velocity = Vector2.Zero;
                            barracks.DeliverResource(this);
                            break;

                        case EWorkerStates.Lumbering:
                            velocity = Vector2.Zero;
                            lumbermill.GatherResource(this);
                            break;

                        case EWorkerStates.GatheringFood:
                            velocity = Vector2.Zero;
                            farm.GatherResource(this);
                            break;

                        case EWorkerStates.Mining:
                            velocity = Vector2.Zero;
                            mine.GatherResource(this);
                            break;

                        case EWorkerStates.MovingToTarget:
                            GotoTarget();
                            break;

                        case EWorkerStates.PlayerControlled:
                            break;
                    }

                    if (targetBuilding != null)
                        MoveTowardsBuilding();

            }


            // Workeren er død, samt med ham dør tråden.
            Thread.CurrentThread.Abort();
        }

        private void GotoTarget()
        {
            if (WorkerHasDeliveredResource)
                FindNearestResource();
            else
                FindNearestBarracks();
        }

        private void FindNearestResource()
        {
            switch (WorkerResource)
            {
                case EResources.Gold:
                    ObtainNearestBuilding(SpriteContainer.sprite["GoldMine"], ref targetBuilding);
                    break;

                case EResources.Wood:
                    ObtainNearestBuilding(SpriteContainer.sprite["LumberMilk"], ref targetBuilding);
                    break;

                case EResources.Food:
                    ObtainNearestBuilding(SpriteContainer.sprite["Fram"], ref targetBuilding);
                    break;
            }
        }

        private void FindNearestBarracks()
        {
            ObtainNearestBuilding(SpriteContainer.sprite["Barracks"], ref targetBuilding);
        }


        private void MoveTowardsBuilding()
        {
            XYDifference(Transform.Position.X,
                         targetBuilding.Transform.Position.X,
                         ref velocity.X);

            XYDifference(Transform.Position.Y,
                         targetBuilding.Transform.Position.Y,
                         ref velocity.Y);

            Vector2.Normalize(velocity);
        }

        private void XYDifference(float xy1, float xy2, ref float velocity)
        {
            if (ApproximatelyEqual(xy1, xy2, 5))
                velocity = 0;

            else if (xy2 < xy1)
                velocity = -1;

            else if (xy2 > xy1)
                velocity = 1;
        }

        private void ObtainNearestBuilding(Texture2D sprite, ref Component nearestBuilding)
        {
            nearestBuilding = LucasScene.GameObjects.ToList()
                    .Where(nBuilding => nBuilding.Sprite == sprite)
                    .Select(nBuilding => new Component(nBuilding.Transform.Position))
                    .OrderBy(nBuilding => Vector2.Distance(nBuilding.Transform.Position, Transform.Position))
                    .First();
        }

        private void HandleInput()
        {
            KeyboardState keyState = Keyboard.GetState();

            if (keyState.IsKeyDown(Keys.F))
                WorkerResource = EResources.Food;
            if (keyState.IsKeyDown(Keys.G))
                WorkerResource = EResources.Gold;
            if (keyState.IsKeyDown(Keys.W))
                WorkerResource = EResources.Wood;
        }

        public void Move()
        {
            Transform.Position += ((velocity * speed) * Time.deltaTime);
        }

        private bool ApproximatelyEqual(float a, float b, float approximatelyEqualThreshold)
        {
            return Math.Abs(a - b) < approximatelyEqualThreshold;
        }

        public override void IsColliding(Component component)
        {
            if (BoundingBox.Intersects(component.BoundingBox))
            {
                OnCollision(component);
            }

            switch (WorkerState)
            {
                case EWorkerStates.PlayerControlled:
                    break;

                default:
                    if (component.Sprite == SpriteContainer.sprite["GoldMine"] &&
                        BoundingBox.Intersects(component.BoundingBox) &&
                        WorkerHasDeliveredResource &&
                        WorkerResourceValue == 0 &&
                        WorkerResource == EResources.Gold)
                    {
                        WorkerState = EWorkerStates.Mining;
                        mine = (Goldmine)component;
                    }
                    else if (component.Sprite == SpriteContainer.sprite["LumberMilk"] &&
                        BoundingBox.Intersects(component.BoundingBox) &&
                        WorkerHasDeliveredResource &&
                        WorkerResourceValue == 0 &&
                        WorkerResource == EResources.Wood)
                    {
                        WorkerState = EWorkerStates.Lumbering;
                        lumbermill = (Lumbermill)component;
                    }
                    else if (component.Sprite == SpriteContainer.sprite["Fram"] &&
                        BoundingBox.Intersects(component.BoundingBox) &&
                        WorkerHasDeliveredResource &&
                        WorkerResourceValue == 0 &&
                        WorkerResource == EResources.Food)
                    {
                        WorkerState = EWorkerStates.GatheringFood;
                        farm = (Farm)component;
                    }
                    else if (component.Sprite == SpriteContainer.sprite["Barracks"] &&
                        BoundingBox.Intersects(component.BoundingBox) &&
                        !WorkerHasDeliveredResource &&
                        WorkerResourceValue > 0)
                    {
                        WorkerState = EWorkerStates.Delivering;
                        barracks = (Barracks)component;
                    }
                    break;
            }
        }
    }
}
