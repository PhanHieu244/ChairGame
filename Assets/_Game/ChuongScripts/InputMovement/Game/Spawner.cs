using System;
using System.Collections.Generic;
using ChuongCustom;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GameInputMovement.Game
{
    public class Spawner : Singleton<Spawner>, IMovementInputListener
    {
        [SerializeField] private Transform container;
        [SerializeField] private List<Chair> chairPrefabs;
        [SerializeField] private MovementContainer movementContainer;

        private Chair _chair;

        private void Start()
        {
            Spawn();
        }

        public void MouseDownAction(Vector3 worldPointInput)
        {
            
        }

        public void MouseUpAction(Vector3 worldPointInput)
        {
            Drop();
            DelaySpawn();
        }

        public void MouseDragAction(Vector3 worldPointInput)
        {
            
        }

        private void DelaySpawn()
        {
            DOVirtual.DelayedCall(1.2f, Spawn);
        }

        private void Spawn()
        {
            var ran = Random.Range(0, chairPrefabs.Count);
            _chair = Instantiate(chairPrefabs[ran], container);
            _chair.transform.localPosition = Vector3.zero;
        }

        private void Drop()
        {
            _chair.transform.SetParent(null);
            _chair.Drop();
        }

        public void Rotate()
        {
            _chair?.transform.Rotate(new Vector3(0f, 0f, 45f));
        }
    }
}