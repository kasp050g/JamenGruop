using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JamenGruop_RTS
{
    public class Goldmine
    {
        Semaphore MySemaphore = new Semaphore(0, 3); // 0,3 siger hvor mange der starte der, og hvor mange der kan være inde i minen
        public void TIngeligen()
        {
            for (int i = 1; i < 5; i++) // < 5 er hvor mange der thread der er i alt.
                                        // i < "hvor mange workers der står udenfor", skal finde en måde spillet selv kan se hvor mange der står og venter
            {
                new Thread(Enter).Start(i);
            }
            Thread.Sleep(500); //hvor lang tid der går før minen åbner
            Console.WriteLine("Main Thread Release(3)"); // nu er minen åbnet og workers kan komme ind, kan fjernes
            MySemaphore.Release(3); // hvor mange thread der kan være inde i minen af gangen
            Console.ReadKey();
        }

        void Enter(object id)
        {
            Console.WriteLine(id + " waits outside the mine"); // kan fjernes.
            MySemaphore.WaitOne(); // der er 3 thread der inde i mine, så der kan ikke være flere
            Console.WriteLine(id + " Enters the Mine"); // kan fjernes.
            Thread.Sleep(1000 * (int)id); // hvor lang tid threaden er inde i minen
            Console.WriteLine(id + " Is leaving"); // threaden går ud af mine igen.
            MySemaphore.Release();
        }
    }
}
