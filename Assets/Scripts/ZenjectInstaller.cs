using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ZenjectInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IStorage>().To<OfflineJSONStorage>().AsSingle();
    }
}
