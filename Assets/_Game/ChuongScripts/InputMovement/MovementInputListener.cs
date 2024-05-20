using UnityEngine;

namespace GameInputMovement
{
    public class MovementInputListener : IMovementInputListener
    {
        public void MouseDownAction(Vector3 worldPointInput)
        {
            
        }

        public void MouseUpAction(Vector3 worldPointInput)
        {
            
        }

        public void MouseDragAction(Vector3 worldPointInput)
        {
            
        }
    }

    public interface IMovementInputListener
    {
        void MouseDownAction(Vector3 worldPointInput);
        void MouseUpAction(Vector3 worldPointInput);
        void MouseDragAction(Vector3 worldPointInput);
    }
}