using System;
using UnityEngine;

namespace UI
{
    [CreateAssetMenu(fileName = "NotificationChannel", menuName = "ScriptableObjects/NotificationChannel")]
    public class NotificationEventChannel : ScriptableObject
    {
        public event Action<string> OnInvoke;

        public void Invoke(string message)
        {
            OnInvoke?.Invoke(message);
        }
    }
}