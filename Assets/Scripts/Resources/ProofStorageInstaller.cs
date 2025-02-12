using UnityEngine;
using Zenject;

public class ProofStorageInstaller : MonoInstaller
{
    
    [SerializeField] private ProofStorage proofStoragePrefab;
    public override void InstallBindings()
    {
        Container.Bind<ProofStorage>().FromInstance(proofStoragePrefab).AsSingle();
    }
    
}