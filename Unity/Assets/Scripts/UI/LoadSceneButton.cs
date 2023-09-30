using UnityEngine;
using UnityEngine.SceneManagement;

namespace LD54.UI
{
    public class LoadSceneButton : ButtonBase
    {
        [SerializeField] private string _sceneName;

        protected override void OnClick() => SceneManager.LoadScene(_sceneName);
    }
}