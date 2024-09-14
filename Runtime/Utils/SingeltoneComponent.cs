using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EMA.Utils
{
    public class SingletonComponent<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T _instance;

        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<T>();

                    if (_instance == null)
                    {
                        Debug.LogError($"Singleton {typeof(T)} was not found!");

                    }
                }

                return _instance;
            }
        }

        private void OnEnable()
        {
            var curObjectScripts = FindObjectsOfType<T>();

            if (curObjectScripts.Length > 1)
            {
                Debug.LogWarning($"Singleton {typeof(T)} should be the only instance!");

                Destroy(gameObject);
                return;
            }
        }
    }
}