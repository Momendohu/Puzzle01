using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody))]
public class Ball : MonoBehaviour {
    [SerializeField]
    private Rigidbody _rigidbody = null;

    private Vector3 _direction = new Vector3 (5, 5, 0);

    private bool _isCollided = false;

    void Start () { }

    void Update () {
        Move ();
    }

    void FixedUpdate () {
        _isCollided = false;
    }

    void OnCollisionEnter (Collision col) {
        AudioManager.Instance.PlaySE ("se");
        
        if (_isCollided) {
            return;
        }
        _isCollided = true;

        var dir = Vector3.zero;
        foreach (ContactPoint contact in col.contacts) {
            dir += (contact.point - this._rigidbody.position);
        }

        _direction = new Vector3 (
            dir.x == 0 ? _direction.x : _direction.x * (-1),
            dir.y == 0 ? _direction.y : _direction.y * (-1),
            0
        );

        if (col.gameObject.tag == "Block") {
            col.gameObject?.GetComponent<Block> ().ReceiveDamage ();
        }
    }

    private void Move () {
        _rigidbody.position += _direction * Time.fixedDeltaTime;
    }
}