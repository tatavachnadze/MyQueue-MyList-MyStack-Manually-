using G16_20220623;

MyList<string> list = new MyList<string>();
list.Add("1");
list.Add("2");
list.Add("3");
list.Add("4");
    list.Add("5");
list.Add("6");
list.Add("7");
list.Add("8");
list.Add("9");


MyStack<string> stack = new MyStack<string>();
stack.Push("1");
stack.Push("2");
stack.Push("3");
stack.Push("4");
    stack.Push("5");

MyQueue<string> queue = new MyQueue<string>();
queue.Enqueue("1");
queue.Enqueue("2");
queue.Enqueue("3");

queue.Enqueue("4");
queue.Enqueue("5");

list.TrimToSize();
stack.TrimToSize(); 
queue.TrimToSize();
foreach (var item in list)
{
    Console.WriteLine(item);
}
Console.WriteLine();
foreach (var item in stack)
{
    Console.WriteLine(item);
}
Console.WriteLine();
foreach (var item in queue)
{
    Console.WriteLine(item);
}
