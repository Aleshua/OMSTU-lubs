namespace SpaceBattle.Lib;

public class QueueAdapter : IReceiver
{
    Queue<ICommand> queue;

    public QueueAdapter(Queue<ICommand> queue) => this.queue = queue;

    public ICommand Receive()
    {
        return queue.Dequeue();
    }

    public bool IsEmpty()
    {
        return queue.Count() == 0;
    }
}
