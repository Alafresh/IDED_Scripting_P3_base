using System;
using UnityEngine;
public class RefactoredGameController : GameControllerBase
{
    public event Action OnGameOver;
    public event Action OnArrowShot;
    public override PlayerControllerBase PlayerController => RefactoredPlayerController.Instance;

    public static RefactoredGameController Instance { get; private set; }

    protected override void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        base.Awake();
    }
    public override void ProcessShot(Vector3 aimPosition)
    {
        base.ProcessShot(aimPosition);

        OnArrowShot?.Invoke();

        if (Arrows <= 0)
        {
            OnGameOver?.Invoke();
        }
    }
}