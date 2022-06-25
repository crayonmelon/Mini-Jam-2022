using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack : MonoBehaviour
{
    float knockBackDuration = .5f;
    [SerializeField] float knockBackForce = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Sword"))
        {
            StopAllCoroutines();
            StartCoroutine(knockBack());
        }
    }
    IEnumerator knockBack()
    {
        Vector3 dir = (this.transform.position - GameObject.FindGameObjectWithTag("Player").transform.position).normalized;
        Vector3 newPos = (transform.position + dir.With(y:0) * knockBackForce);

        float timeElapsed = 0;

        while (timeElapsed < knockBackDuration)
        {
            transform.position = Vector3.Lerp(transform.position, newPos, timeElapsed / knockBackDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
    }
}
