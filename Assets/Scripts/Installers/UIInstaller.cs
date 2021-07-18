using NaughtyAttributes;
using UnityEngine;
using TMPro;
using Zenject;

public class UIInstaller : MonoInstaller
{
    [Foldout("For developers only!")] public TMP_Text ScoreText;
    
    public override void InstallBindings()
    {
        Container.BindInstance(ScoreText).WhenInjectedInto<ScoreZone>();
    }
}