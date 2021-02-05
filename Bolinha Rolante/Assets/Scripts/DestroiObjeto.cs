using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroiObjeto : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("ApagaObjeto", 1.5f);
    }

    // Update is called once per frame
    void ApagaObjeto()
    {
        Destroy(this.gameObject); // destroi ele mesmo
    }
}
