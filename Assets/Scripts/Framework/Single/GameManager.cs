using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class GameManager : GameManagerBase
{
    protected override void InitializeManagerClasses()
    {
        RegisterManagerClass<ResourceManager>();
        RegisterManagerClass<SceneManager>();
        RegisterManagerClass<PlayerManager>();
        RegisterManagerClass<AudioManager>();
    }
}
