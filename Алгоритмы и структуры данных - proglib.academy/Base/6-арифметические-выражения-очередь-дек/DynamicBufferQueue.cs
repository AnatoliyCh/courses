namespace Base.ArithmeticExpressionsQueueDec;

public static class DynamicBufferQueue
{
    public static readonly string resultYes = "YES";
    public static readonly string resultNo = "NO";
    public static readonly int commandPopFront = 2;
    public static readonly int commandPushBack = 3;

    public static string Execute(int count, string[] commands)
    {
        var queue = new Queue<int>(count);

        foreach (var str in commands)
        {
            string[] splitStr = str.Trim().Split(' ');
            var command = Convert.ToInt32(splitStr[0]);
            var value = Convert.ToInt32(splitStr[1]);
            if (commandPushBack == command)
            {
                queue.Enqueue(value);
            }
            else if (commandPopFront == command && !queue.IsEmpty)
            {
                var deqValue = queue.Dequeue();
                if (deqValue != value)
                {
                    return resultNo;
                }
            }
            else
            {
                // специальная команда для пустой структуры данных
                if (value == -1 && commandPopFront == command)
                {
                    continue;
                }

                return resultNo;
            }
        }

        return resultYes;
    }

    public class Queue<T>
    {
        private T[] buffer;
        private int head; // первый элемент очереди
        private int tail; // последний элемент очереди

        public Queue(int size)
        {
            buffer = new T[size + 1];
            head = tail = 0;
        }

        public bool IsEmpty { get => head == tail; }

        public void Enqueue(T item)
        {
            // увеличение буфера и копирование
            if ((tail + 1) % buffer.Length == head)
            {
                Resize();
            }

            buffer[tail] = item;
            tail = (tail + 1) % buffer.Length;
        }

        public T Dequeue()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("Queue is empty");
            }

            var result = buffer[head];
            head = (head + 1) % buffer.Length;

            return result;
        }

        private void Resize()
        {
            var newBuffer = new T[buffer.Length * 2];
            int newBufferIndex = 0;
            int bufferIndex = head;
            while (bufferIndex != tail)
            {
                newBuffer[newBufferIndex] = buffer[bufferIndex];
                newBufferIndex++;
                bufferIndex = (bufferIndex + 1) % buffer.Length;
            }

            buffer = newBuffer;
            head = 0;
            tail = newBufferIndex;
        }
    }
}
