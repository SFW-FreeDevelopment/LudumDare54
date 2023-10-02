using UnityEngine;

namespace LD54.UI
{
    public class WindowButton : ButtonBase
    {
        [SerializeField] private GameObject _window;

        protected override void OnClick() => _window.SetActive(!_window.activeSelf);
    }
}