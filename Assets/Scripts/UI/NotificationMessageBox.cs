using System;
using System.Collections;
using TMPro;
using UnityEngine;

namespace UI
{
    public class NotificationMessageBox : MonoBehaviour
    {
        [SerializeField] private NotificationEventChannel channel;
        [SerializeField] private TMP_Text textField;


        private void OnEnable()
        {
            channel.OnInvoke += ChangeNotification;
        }

        private void OnDisable()
        {
            channel.OnInvoke -= ChangeNotification;
        }

        private void ChangeNotification(string text)
        {
            textField.text = text;
            StartCoroutine(DeleteTextAfter(5f));
        }

        private IEnumerator DeleteTextAfter(float seconds)
        {
            yield return new WaitForSeconds(seconds);
            textField.text = "";
        }
    }
}