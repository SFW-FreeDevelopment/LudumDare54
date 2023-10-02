using UnityEngine;

namespace LD54.UI
{
    public class XButton : ButtonBase
    {
        [SerializeField] private GameObject _window;
        
        protected override void OnClick() => _window.SetActive(false);
    }
}