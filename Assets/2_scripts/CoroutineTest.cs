using System.Collections;
using UnityEngine;

public class CoroutineTest : MonoBehaviour
{
    float timer;

    private void Start()
    {
        StartCoroutine(TimerCoroutine());
    }

    IEnumerator TimerCoroutine()
    {
        int counter = 0;
        while (true)
        {
            Debug.Log(counter);
            counter++;
            yield return new WaitForSeconds(1);
        }
    }

    private void Update()
    {
        timer = Time.deltaTime;

        if (timer > 1 )
        {
            Debug.Log("1√ .");
            timer = 0;
        }
    }
}
