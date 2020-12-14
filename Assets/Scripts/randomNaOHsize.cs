using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomNaOHsize : MonoBehaviour
{
    [SerializeField]
    GameObject NaOH;

    [SerializeField]
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Awake()
    {
        for (int i = 0; i < 50; i++)
        {
            float randomX = Random.Range(475f, 500f);
            float randomY = Random.Range(475f, 500f);
            float randomScale = Random.Range(0.5f, 2f);
            NaOH.transform.localScale = new Vector3(randomScale, randomScale, 0);
            rb = GetComponent<Rigidbody2D>();

            Vector3 newPosition = new Vector3(randomX, randomY, 0f);
            GameObject cloneNaOH = Instantiate(this.gameObject, newPosition, Quaternion.identity);
            cloneNaOH.name = NaOH.name;
            
            
        }
    }
}
