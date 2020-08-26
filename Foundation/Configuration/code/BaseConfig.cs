using System;

namespace SearchFight.Foundation.Configuration
{
    public abstract class BaseConfig<T> where T : BaseConfig<T>
    {
        private static readonly Lazy<T> Instance =
            new Lazy<T>(
                () => Activator.CreateInstance(typeof(T), true) as T);

        public static T Current => Instance.Value;
    }
}
