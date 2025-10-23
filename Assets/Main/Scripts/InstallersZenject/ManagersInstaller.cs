
using Zenject;
public class ManagersInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<SelectionManager>().FromComponentInHierarchy().AsSingle();
        Container.Bind<MovementManager>().FromComponentInHierarchy().AsSingle(); 
        Container.Bind<RoomManager>().FromComponentInHierarchy().AsSingle();
        Container.Bind<MouseInputHandler>().FromComponentInHierarchy().AsSingle();
        Container.Bind<ShipUIDataView>().FromComponentInHierarchy().AsSingle();
        Container.Bind<ShipVisual>().FromComponentInHierarchy().AsSingle();
    }
}
