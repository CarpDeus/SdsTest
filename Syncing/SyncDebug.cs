using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DeveloperSample.Syncing
{
    public class SyncDebug
    {
        private static bool _isBusyUpdating = false;

        public List<string> InitializeList(IEnumerable<string> items)
        {
            var bag = new ConcurrentBag<string>();
            foreach (var i in items)
            {
                var r = Task.Run(() => i).GetAwaiter().GetResult();
                bag.Add(r);
            }
            return bag.ToList();
        }


        public Dictionary<int, string> InitializeDictionary(Func<int, string> getItem)
        {
            var itemsToInitialize = Enumerable.Range(0, 100).ToList();

            var concurrentDictionary = new ConcurrentDictionary<int, string>();
            var threads = Enumerable.Range(0, 3)
                .Select(i => new Thread(() =>
                {
                    foreach (var item in itemsToInitialize)
                    {  while(_isBusyUpdating)
                        {
                            Thread.Sleep(10);
                        }
                         _isBusyUpdating = true;
                        if(!concurrentDictionary.ContainsKey(item))
                        {
                            concurrentDictionary.AddOrUpdate(item, getItem, (_, s) => s);
                        }
                        _isBusyUpdating = false;
                    }
                }))
                .ToList();

            foreach (var thread in threads)
            {
                thread.Start();
            }
            foreach (var thread in threads)
            {
                thread.Join();
            }

            return concurrentDictionary.ToDictionary(kv => kv.Key, kv => kv.Value);
        }
    }
}