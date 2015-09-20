namespace GenericMemento
{
    using System;
    using System.Reflection;
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;

    using GenericMemento.Cloneables;

    public class Saver<T> : IStateSaver<T>
    {
        private IMemory<T> memory;

        public Saver()
        {
            this.memory = new Memory<T>();
        }

        public bool HasStates
        {
            get
            {
                return !this.memory.IsEmpty;
            }
        }

        public void SaveState(T obj)
        {
            this.memory.PushItem(this.DeepClone(obj));
        }

        public T GetState()
        {
            return this.memory.GetItem();
        }

        private T DeepClone(T obj)
        {
            T result = default(T);

            // this isn't pretty on purpose, i've adressed it in the strategy project
            if (obj as IDeepClonable<T> != null)
            {
                result = (obj as IDeepClonable<T>).DeepClone();
            }
            else if (obj as ICloneable != null)
            {
                result = (T)(obj as ICloneable).Clone();
            }
            else if (typeof(T).IsSerializable)
            {
                using (var ms = new MemoryStream())
                {
                    var formatter = new BinaryFormatter();
                    formatter.Serialize(ms, obj);
                    ms.Position = 0;

                    result = (T)formatter.Deserialize(ms);
                }
            }
            else
            {
                var copy = Activator.CreateInstance<T>();

                var piList = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

                foreach (var pi in piList)
                {
                    if (pi.GetValue(copy, null) != pi.GetValue(obj, null))
                    {
                        pi.SetValue(copy, pi.GetValue(obj, null), null);
                    }

                }
            }

            return result;
        }
    }
}