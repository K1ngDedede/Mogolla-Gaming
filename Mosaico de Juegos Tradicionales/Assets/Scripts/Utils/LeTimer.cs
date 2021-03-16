using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeTimer : MonoBehaviour
{
    
    public BackwardsTimer n;

    public float Duration;

    private Transform circ;

    private IEnumerator cogotinho;
    
    void Start()
    {
        gameObject.AddComponent(typeof(BackwardsTimer));
        n = gameObject.GetComponent<BackwardsTimer>();
        circ = gameObject.transform.GetChild(0);
        n.Duration = Duration;
        cogotinho = Timer();
    }

    public void Run()
    {
        n.Duration = Duration;
        n.Run();
        StartCoroutine(cogotinho);
    }

    public bool Running()
    {
        return n.Running;
    }

    public void Stop()
    {
        n.Stop();
        StopCoroutine(cogotinho);
    }

    public float SecondsRemaining()
    {
        return n.SecondsRemaining;
    }

    public bool Finished()
    {
        return n.Finished;
    }
    
    IEnumerator Timer() {
        float sI = 360/Duration;
        while (true) {
            //fhRender.sprite = fhSprites[sI%2];
            //sI++;
            print(SecondsRemaining()+", "+n.SecondsRemaining);
            yield return new WaitForSeconds(1);
            circ.Rotate(new Vector3(0,0,sI));
        }
    }
}
