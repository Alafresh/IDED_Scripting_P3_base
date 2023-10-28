using UnityEngine;

public class RefactoredPlayerController : PlayerControllerBase
{
    public static RefactoredPlayerController Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    protected override void Start()
    {
        ArrowCount = RefactoredGameController.Instance.Arrows;
        base.Start();
    }

    protected override void ProcessShot(Vector3 point)
    {
        // Crear e invocar el comando ShotCommand
        ICommand shotCommand = new ShotCommand(point);
        shotCommand.Execute();
    }
}

public interface ICommand
{
    void Execute();
}

public class ShotCommand : ICommand
{
    private Vector3 aimPosition;

    public ShotCommand(Vector3 aimPosition)
    {
        this.aimPosition = aimPosition;
    }

    public void Execute()
    {
        // Aquí invocamos RefactoredGameController.ProcessShot con el punto de destino
        RefactoredGameController.Instance.ProcessShot(aimPosition);
    }
}
