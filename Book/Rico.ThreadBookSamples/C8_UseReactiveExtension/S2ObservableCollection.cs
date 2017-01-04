using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rico.ThreadBookSamples.C8_UseReactiveExtension
{
    class S2ObservableCollection
    {
        static void ExcuteMain()
        {
            foreach (int i in EnumerableEventSequence())
            {
                Console.Write(i);
            }
            Console.WriteLine();
            Console.WriteLine("IEnumerable");

            IObservable<int> o = EnumerableEventSequence().ToObservable();
            using (IDisposable subscription = o.Subscribe(Console.Write))
            {
                Console.WriteLine();
                Console.WriteLine("IObservable");
            }

            o = EnumerableEventSequence().ToObservable().SubscribeOn(TaskPoolScheduler.Default);
            using (IDisposable subscription = o.Subscribe(Console.Write))
            {
                Console.WriteLine();
                Console.WriteLine("IObservable async");
                Console.ReadLine();
            }
        }

        static IEnumerable<int> EnumerableEventSequence()
        {
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(TimeSpan.FromSeconds(0.5));
                yield return i;
            }
        }
    }
}
