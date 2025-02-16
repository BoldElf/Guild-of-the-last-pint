using UnityEngine;
using Zenject;

public class ShowProofControllerOnSceneInstaller : MonoInstaller
{
    [SerializeField] private ShowProofControllerOnScene showProofControllerOnScene;
    public override void InstallBindings()
    {
        Container.Bind<ShowProofControllerOnScene>().FromInstance(showProofControllerOnScene).AsSingle();
    }
}