using UnityEngine;
using Zenject;

public class EnemyDetectControllerInstaller : MonoInstaller
{
    [SerializeField] private EnemyDetectController enemyDetectController;
    public override void InstallBindings()
    {
        Container.Bind<EnemyDetectController>().FromInstance(enemyDetectController).AsSingle();
    }
}