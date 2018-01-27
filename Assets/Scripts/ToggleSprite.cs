using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ToggleSprite : MonoBehaviour {
    [SerializeField] private Sprite onSprite;
    [SerializeField] private Sprite offSprite;

    [SerializeField] private bool isOn = true;

    private Image image;

    public bool IsOn {
        get { return isOn; }
        set { isOn = value; UpdateValue(); }
    }

    private void Awake() {
        image = GetComponent<Image>();
    }

    private void Start() {
        UpdateValue();
    }

    private void UpdateValue() {
        image.sprite = isOn ? onSprite : offSprite;
    }
}
