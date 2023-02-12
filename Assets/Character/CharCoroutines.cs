using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharCoroutines : MonoBehaviour
{
    CharStateManager charStateManager;
    private IEnumerator _coroutine;

    private void Start()
    {
        charStateManager = GetComponent<CharStateManager>();
    }

    public IEnumerator WaitForNextAttack()
    {
        _coroutine = GetForNextAttack();

        StartCoroutine(_coroutine);
        yield return new WaitForSecondsRealtime(2);
        StopAllCoroutines();
    }
    public IEnumerator GetForNextAttack()
    {
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        StopAllCoroutines();
    }
    public void StartCustomCoroutine()
    {
        _coroutine = WaitForNextAttack();
        StartCoroutine(_coroutine);
    }
}
