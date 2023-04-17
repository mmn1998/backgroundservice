using System;
using System.Collections.Generic;
using System.Text;

namespace TestBackgroundService
{
    public class Singleton<T>
    {
        #region Singleton

        private static readonly Lazy<T> Lazy =
            new Lazy<T>(Activator.CreateInstance<T>);

        public static T Instance => Lazy.Value;

        #endregion
    }
}
