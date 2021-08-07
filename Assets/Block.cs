using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Block : MonoBehaviour {
    [SerializeField]
    private TextMeshPro _textMeshPro = null;

    private int _life = 10;

    void Start () {
        UpdateUI ();
    }

    public void ReceiveDamage () {
        _life--;
        if (_life <= 0) {
            Destroy (this.gameObject);
            return;
        }

        UpdateUI ();
    }

    private void UpdateUI () {
        _textMeshPro.text = string.Format ("{0}", _life);
    }
}