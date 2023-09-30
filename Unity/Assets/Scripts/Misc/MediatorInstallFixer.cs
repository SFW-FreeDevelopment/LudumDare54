using System;
using UniMediator;
using UnityEditor;
using UnityEngine;
using Zenject;

namespace LD54.Misc
{
    [RequireComponent(typeof(SceneContext))]
    public class MediatorInstallFixer : MonoBehaviour
    {
        [SerializeField] private SceneContext _sceneContext;
        
        private void Awake()
        {
            if (_sceneContext == null)
                _sceneContext = GetComponent<SceneContext>();

            InstallMediator();
        }

        private void Start()
        {
            _sceneContext.Run();
        }

        private static void InstallMediator()
        {
            foreach (var mediator in FindObjectsOfType<MediatorImpl>())
            {
                DestroyImmediate(mediator.gameObject);
            }

            var @object = new GameObject("UniMediator");
            @object.AddComponent<MediatorImpl>();
            @object.AddComponent<Mediator>();

            Undo.RegisterCreatedObjectUndo(@object, "Install Mediator");
        }
    }
}