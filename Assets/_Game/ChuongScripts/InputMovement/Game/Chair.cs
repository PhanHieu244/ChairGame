using System;
using System.Collections;
using _Game;
using ChuongCustom;
using DG.Tweening;
using UnityEngine;

public class Chair : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private Collider2D _collider2D;

    private bool isStanding;

    private void Start()
    {
        _collider2D.enabled = false;
    }

    public void Drop()
    {
        _collider2D.enabled = true;
        _rigidbody2D.isKinematic = false;
        _rigidbody2D.constraints = RigidbodyConstraints2D.None;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (!col.collider.CompareTag("stand")) return;
        isStanding = true;
        StopAllCoroutines();
        StartCoroutine(IEDoCheck());
    }

    private IEnumerator IEDoCheck()
    {
        var _time = 0f;
        int count = 0;
        while (_time <= 5f && isStanding)
        {
            yield return null;
            _time += Time.deltaTime;
            if(_rigidbody2D.velocity.magnitude > 0.01f || _rigidbody2D.angularVelocity > 0.4f) continue;
            count++;
            if (count <= 3)
            {
                yield return null;
                continue;
            }
            transform.localScale = Vector3.one;
            yield return null;
            StayStanding();
            yield return null;
            Ruler.Instance.StartRuler();
            yield break;
        }
    }

    private void StayStanding()
    {
        transform.SetParent(Standing.Instance.transform);
        _rigidbody2D.isKinematic = true;
        _rigidbody2D.constraints = RigidbodyConstraints2D.FreezeAll;
        gameObject.tag = "stand";
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (!other.collider.CompareTag("stand")) return;
        isStanding = false;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("lose"))
        {
            InGameManager.Instance.BeforeLose();
            Destroy(gameObject);
            return;
        }
    }
}
