﻿using UnityEngine;
using UnityEngine.EventSystems;

namespace LD54.Managers
{
    public class DeleteKeyManager : MonoBehaviour
    {
        private void Update()
        {
            if (!Input.GetKeyDown(KeyCode.Delete)) return;
            if (EventSystem.current.currentSelectedGameObject == null) return;
            if (EventSystem.current.currentSelectedGameObject.CompareTag("Essential")) return;
            
            EventManager.FileDeleted();
            Destroy(EventSystem.current.currentSelectedGameObject);
        }
    }
}