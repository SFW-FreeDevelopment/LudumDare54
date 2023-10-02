using System;
using LD54.Abstractions;
using TMPro;
using UnityEngine;

namespace LD54.Objects
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class SystemTime : MonoBehaviour
    {
        private TextMeshProUGUI _textMesh;

        private void Awake() => _textMesh = GetComponent<TextMeshProUGUI>();

        private void Start() =>
            StartCoroutine(CoroutineTemplate.FireAndDelayLoopRoutine(1, () =>
            {
                _textMesh.text = DateTime.Now.ToString("hh:mm tt");
            }));
    }
}