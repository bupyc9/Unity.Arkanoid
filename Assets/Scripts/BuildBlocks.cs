using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BuildBlocks : MonoBehaviour {
    [SerializeField] private int rows;
    [SerializeField] private int cols;
    [SerializeField] private GameObject[] prefabs;
    [SerializeField] private float marginX;
    [SerializeField] private float marginY;

    void Start() {
        var random = new System.Random();
        float x = gameObject.transform.position.x;
        float y = gameObject.transform.position.y;

        var sizes = new List<float>();
        for(var r = 1; r <= rows; r++) {
            sizes.Clear();

            for(var c = 1; c <= cols; c++) {
                var index = random.Next(0, prefabs.Length);

                var block = Instantiate(prefabs[index], new Vector2(x, y), Quaternion.identity) as GameObject;
                block.transform.SetParent(gameObject.transform);

                var renderer = block.GetComponent<Renderer>();
                sizes.Add(renderer.bounds.size.y);

                x += renderer.bounds.size.x + marginX;
            }

            x = gameObject.transform.position.x;
            y -= marginY + sizes.Max();
        }
    }
}
