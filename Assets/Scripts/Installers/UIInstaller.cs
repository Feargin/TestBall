using NaughtyAttributes;
using TMPro;
using Zenject;

namespace Installers
{
    internal sealed class UIInstaller : MonoInstaller
    {
        [Foldout("For developers only!")] public TMP_Text ScoreText;
    
        public override void InstallBindings()
        {
            Container.BindInstance(ScoreText);
        }
    }
}