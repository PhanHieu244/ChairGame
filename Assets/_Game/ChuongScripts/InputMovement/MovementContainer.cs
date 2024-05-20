using System;
using UnityEngine;

namespace GameInputMovement
{
    public class MovementContainer : MonoBehaviour, IMovementContainer
    {
        [SerializeField] private Transform startPoint;
        [SerializeField] private Transform limitPoint;

        public event Action OnRevert;
        
        public void Move(Vector3 movePos)
        {
            var y = limitPoint.position.y;
            if (movePos.y < y) movePos.y = y; 
            transform.position = movePos;
        }

        public void Revert()
        {
            transform.position = startPoint.position;
            OnRevert?.Invoke();
        }
    }

    public interface IMovementContainer
    {
        void Move(Vector3 movePos);
        void Revert();
    }
}