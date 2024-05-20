
using ChuongCustom;
using GameInputMovement.Game;
using UnityEngine;

public class RotateBut : MonoBehaviour
{
    private void OnMouseDown()
    {
        if (InGameManager.Instance.isLose) return;
        Spawner.Instance.Rotate();
    }
}
