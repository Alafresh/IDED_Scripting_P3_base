using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefactoredUIController : UIControllerBase
{
    protected override GameControllerBase GameController => RefactoredGameController.Instance;

    private void HandleGameOver()
    {
        gameOverGroup?.SetActive(true);
        enabled = false;
    }

    private void Update()
    {
        RefactoredGameController.Instance.OnArrowShot -= UpdateUIOnArrowShot;
        RefactoredGameController.Instance.OnGameOver -= HandleGameOver;
    }

    public void UpdateUIOnArrowShot()
    {
        if (GameController != null)
        {
            if (shotsCountLabel != null)
            {
                shotsCountLabel.text = GameController.RemainingArrows.ToString();
            }

            if (scoreCountLabel != null)
            {
                scoreCountLabel.text = GameController.Score.ToString();
            }

            if (windLabel != null)
            {
                windLabel.text = string.Format("{0:0.00F}", GameController.WindSpeed);
            }
        }
    }

}
