using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupController : MonoBehaviour {
    [SerializeField] private GameObject overlay;

    private void Start() {
        Close();
    }

    public void Close() {
        gameObject.SetActive(false);
        overlay.SetActive(false);
    }

    public void Open() {
        gameObject.SetActive(true);
        overlay.SetActive(true);
    }
}
