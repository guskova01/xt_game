using UnityEngine;
using Zenject;

public class SceneInstaller : MonoInstaller
{

    [SerializeField] private Transform startPosition;
    [SerializeField] private GameObject pistolPrefab;
    [SerializeField] private Transform start;
    [SerializeField] private GameObject playerPrefab;

    public override void InstallBindings()
    {

        PlayerData player = Container.InstantiatePrefabForComponent<PlayerData>(playerPrefab, start.position, Quaternion.identity, null);
        Container.Bind<PlayerData>().FromInstance(player).AsSingle();

        Container.InstantiatePrefab(pistolPrefab, startPosition);



    }
}


