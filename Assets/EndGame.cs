using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EndGame : MonoBehaviour
{
    [SerializeField] private Matrix _matrix;
    [SerializeField] private Pockets _pockets;

    public static UnityEvent OnEndGameWinEvent = new UnityEvent();
    public static UnityEvent OnEndGameLoseEvent = new UnityEvent();

    private void OnEnable()
    {
        Matrix.OnFilledMatrixCellsCountIsZeroEvent.AddListener(CheckResults);
        Matrix.OnPlayerSendBlockNotOnCenterEvent.AddListener(CheckResults);
        //Pockets.OnFilledPocketCellsIsZeroEvent.AddListener(CheckResults);
    }
    public void CheckResults()
    {
        CheckWin();
        CheckLose();
    }
    private void CheckWin()
    {
        if (_matrix.FilledCellsCount == 0)
        {
            OnEndGameWinEvent.Invoke();
        }
    }
    private void CheckLose()
    {
        if (_matrix.FilledCellsCount != 0)
        {
            OnEndGameLoseEvent.Invoke();
        }
    }
}
