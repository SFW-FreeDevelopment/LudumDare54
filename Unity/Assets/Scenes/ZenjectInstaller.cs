using UniMediator;
using UnityEngine;
using Zenject;

public class ZenjectInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IMediator>()
            .To<MediatorImpl>()
            .FromComponentInHierarchy()
            .AsSingle();
        Container.Bind<ITest>()
            .To<Test>()
            .AsSingle()
            .NonLazy();
    }
}

public interface ITest
{
    public void Speak();
}

public class Test : ITest
{
    public void Speak()
    {
        Debug.Log("I am a test");
    }
}