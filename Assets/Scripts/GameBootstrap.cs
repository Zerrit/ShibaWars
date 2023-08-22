using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBootstrap : MonoBehaviour
{
    public static GameBootstrap instance;

    public PlayerSide playerSide;





    private void Awake()
    {
        _ = new EventsManager();
        instance = this;
    }
}
