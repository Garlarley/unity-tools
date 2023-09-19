using UnityEngine;

namespace MD
{
    /// <summary>
    /// MDSingleton can create an instance if none exists when requested.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class MDSingleton<T> : MonoBehaviour where T : Component
    {
        private static T instance;
        private static bool createIfNone = false;

        public static T Instance
        {
            get
            {
                if (instance == null && createIfNone)
                {
                    CreateInstance();
                }
                return instance;
            }
            private set => instance = value;
        }

        /// <summary>
        /// Set before call to determine null behavior
        /// </summary>
        public static bool CreateIfNone
        {
            get => createIfNone;
            set => createIfNone = value;
        }

        protected virtual void Awake()
        {
            if (instance != null)
            {
#if UNITY_EDITOR
                Debug.LogWarning($"Instance of {typeof(T)} already exists.");
#endif
                Destroy(gameObject);
                return;
            }

            instance = this as T;
            OnInstanceCreated();
        }

        protected virtual void OnDestroy()
        {
            if (instance == this)
            {
                OnInstanceDestroyed();
                instance = null;
            }
        }

        public static void CreateInstance()
        {
            if (instance == null)
            {
                GameObject singletonObject = new GameObject(typeof(T).ToString());
                instance = singletonObject.AddComponent<T>();
            }
        }

        public static void DestroyInstance()
        {
            if (instance != null)
            {
                Destroy(instance.gameObject);
            }
        }

        protected virtual void OnInstanceCreated()
        {
        }

        protected virtual void OnInstanceDestroyed()
        {
        }
    }
}
