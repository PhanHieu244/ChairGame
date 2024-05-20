using System.Collections;
using ChuongCustom;
using UnityEngine;

namespace _Game
{
    public class Ruler : Singleton<Ruler>
    {
        [SerializeField] private Transform startPoint;
        [SerializeField] private Transform endPoint;

        private bool isMove;
        private bool isUpdate;

        private void OnEnable()
        {
            transform.position = startPoint.position;
        }

        public void StartRuler()
        {
            isUpdate = true;
        }
        
        public void UpdateScore()
        {
            var score = (int) ((transform.position.y - startPoint.position.y) * 10 );
            ScoreManager.Score = score;
        }

        public void OnTriggerStay2D(Collider2D other)
        {
            if (isMove || !isUpdate) return;
            if (!other.CompareTag("stand")) return;
            StartCoroutine(Move());
            isMove = true;
        }

        public IEnumerator Move()
        {
            while (enabled)
            {
                if (transform.position.y <= endPoint.position.y)
                {
                    transform.position += new Vector3(0f, 0.02f);
                    yield return null;
                }
                else
                {
                    Standing.Instance.transform.position -= new Vector3(0f, 0.02f);
                    yield return null;
                }
            }
            
        }

        public void OnTriggerExit2D(Collider2D other)
        {
            if (!other.CompareTag("stand")) return;
            StopAllCoroutines();
            isMove = false;
            UpdateScore();
            isUpdate = false;
        }
    }
}  