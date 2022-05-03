using UnityEngine;
using SyunichTool;


public class GameManager : SingletonMonovehavior<GameManager>
{
    protected override bool IsDestroyOnLoad{ get => true; }
    public bool CanTouch { get; set; }

    [SerializeField] private GameClearEffect gameClearEffect;

    protected override void Awake()
    {
        CanTouch = true;
    }

    public void GameClear()
    {
        CanTouch = false;
        StartCoroutine(gameClearEffect.GameClearUIMoving());
    }
}
