using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MudExpander : MonoBehaviour
{
    [SerializeField] private Vector3 speed = Vector3.zero;
    [SerializeField] private float duration;
    

    private void Update()
    {
        
    }

    public void SendPulse()
    {
        StartCoroutine(Pulse());
    }

    IEnumerator Pulse()
    {
        float timer = 0f;
        Vector3 startingScale = this.transform.localScale;

        while (timer < duration)
        {
            timer += Time.deltaTime;
            this.transform.localScale += speed * Time.deltaTime;
            yield return null;
        }

        this.transform.localScale = startingScale;
    }
}
