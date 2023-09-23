using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using N41_HT_Task1;

var queue = new QUEUE<int>();
    
var tasks = new List<Task>()
{
    new(() => queue.Enqueue(5)),
    new(() => queue.Enqueue(21)),
    new(() => queue.Enqueue(64)),
    new(() => queue.Enqueue(21)),
};
    
Parallel.ForEach(tasks, task => task.Start());
await Task.WhenAll(tasks);
    
Console.WriteLine(queue.Dequeue());
Console.WriteLine(queue.Dequeue()); 

namespace N41_HT_Task1
{
}