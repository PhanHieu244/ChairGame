using System;
using ChuongCustom;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace GameInputMovement
{
    public class InputMovement : SerializedMonoBehaviour
    {
        [OdinSerialize, NonSerialized] private IMovementContainer _movementContainer;
        [OdinSerialize, NonSerialized] private IMovementInputListener _listener;

        private Camera _camera;
        
        private void Awake()
        {
            _camera = Camera.main;
        }

        private Vector3 GetMovePos()
        {
            var worldPos = _camera.ScreenToWorldPoint(Input.mousePosition);
            worldPos.z = 0;
            return worldPos;
        }

        public void OnMouseDown()
        {
            if (InGameManager.Instance.isLose) return;
            
            var movePos = GetMovePos();
            _movementContainer.Move(movePos);
            Debug.Log(movePos);
            _listener.MouseDownAction(movePos);
        }

        public void OnMouseUp()
        {
            if (InGameManager.Instance.isLose) return;
            var movePos = GetMovePos();
            _movementContainer.Move(movePos);
            _listener.MouseUpAction(movePos);
            _movementContainer.Revert();
        }

        public void OnMouseDrag()
        {
            if (InGameManager.Instance.isLose) return;
            var movePos = GetMovePos();
            _movementContainer.Move(movePos);
            _listener.MouseDragAction(movePos);
        }
    }
}