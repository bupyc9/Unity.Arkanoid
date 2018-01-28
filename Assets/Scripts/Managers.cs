using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(AudioManager))]
public class Managers : MonoBehaviour {
    public static AudioManager Audio { get; private set; }

    private List<IGameManager> startSequence;

    private void Awake() {
        Audio = GetComponent<AudioManager>();

        startSequence = new List<IGameManager>() { Audio };
        StartCoroutine(StartupManagers());
    }

    private IEnumerator StartupManagers() {
        foreach(IGameManager manager in startSequence) {
            manager.Startup();
        }

        yield return null;

        var numModels = startSequence.Count;
        var numReady = 0;

        while(numReady < numModels) {
            var lastReady = numReady;
            numReady = 0;

            foreach(IGameManager manager in startSequence) {
                if(manager.status == ManagerStatus.Started) {
                    numReady++;
                }
            }

            if(numReady > lastReady) {
                Debug.Log($"Progress: {numReady} / {numModels}");
            }

            yield return null;         
        }

        Debug.Log("All managers started up");
    }
}
