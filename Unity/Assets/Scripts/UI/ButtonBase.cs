using UnityEngine;
using UnityEngine.UI;
using Zenject;

[RequireComponent(typeof(Button))]
public abstract class ButtonBase : MonoBehaviour
{
    protected Button _button;
    [Inject] protected ITest _test;
    
    protected void Awake()
    {
        _button = GetComponent<Button>();
    }

    protected void Start()
    {
        _button.onClick.AddListener(OnClick);
    }

    protected abstract void OnClick();
}
