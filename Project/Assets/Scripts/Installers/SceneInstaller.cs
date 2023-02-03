using UnityEngine;
using Zenject;

public class SceneInstaller : MonoInstaller 
{ 
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Transform startPosition;
    [SerializeField] private GameObject pistolPrefab;

    public override void InstallBindings()
    {
        PlayerData player = Container.InstantiatePrefabForComponent<PlayerData>(playerPrefab, startPosition);
        Container.Bind<PlayerData>().FromInstance(player).AsSingle();


        PistolController pistol = Container.InstantiatePrefabForComponent<PistolController>(pistolPrefab, startPosition);
        
    }
}

