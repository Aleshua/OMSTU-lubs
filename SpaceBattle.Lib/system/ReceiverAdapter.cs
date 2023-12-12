using System.Collections.Concurrent;

namespace SpaceBattle.Lib {
    public class ReceiverAdapter : IReceiver{
        BlockingCollection<ICommand> queue;

        public ReceiverAdapter(BlockingCollection<ICommand> queue)
        {
            this.queue = queue;
        }
        public bool IsEmpty()
        {
            return queue.Count == 0;
        }
        public ICommand Receive()
        {
            return queue.Take();
        }
    }
}
