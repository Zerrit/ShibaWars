using UnityEngine;

public class GameBootstrap : MonoBehaviour
{
    public Side playerSide;

    [SerializeField] private BattleCommunicator _battleCommunicator;
    [SerializeField] private BattleUI _battleUI;
    [SerializeField] private MiniMap _miniMap;

    [SerializeField] private PlayerTower _leftPlayer;
    [SerializeField] private Ai_Tower _rightPlayer;
    [SerializeField] private Mine[] mines;
    private void Awake()
    {
        _ = new EventsManager();
        _battleCommunicator.Initialize();
        _miniMap.Initialize(10);
        _battleUI.Initialize(_leftPlayer._workerParameters, _leftPlayer._units, _leftPlayer._abilities);
        _leftPlayer.Initialize();
        _rightPlayer.Initialize();

        foreach (Mine mine in mines) mine.Initialize(playerSide);
    }
}
