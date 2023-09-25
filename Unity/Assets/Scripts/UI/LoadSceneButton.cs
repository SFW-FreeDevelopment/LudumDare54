using Requests;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class LoadSceneButton : ButtonBase
    {
        [SerializeField] private string _sceneName;

        protected override void OnClick()
        {
            _mediator.Publish(new TestCommand("It worked! Eureka!"));
            SceneManager.LoadScene(_sceneName);
        }
    }
}