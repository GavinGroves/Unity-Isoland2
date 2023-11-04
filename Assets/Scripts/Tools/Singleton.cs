using UnityEngine;

namespace Tools
{
    public class Singleton<T> : MonoBehaviour where T : Singleton<T>
    {
        private static T instance;

        public static T Instance => Singleton<T>.instance;

        protected virtual void Awake()
        {
            if ((Object)Singleton<T>.instance != (Object)null)
                Object.Destroy((Object)this.gameObject);
            else
                Singleton<T>.instance = (T)this;
        }
    }
}