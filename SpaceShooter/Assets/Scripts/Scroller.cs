using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroller : MonoBehaviour
{

    [SerializeField] float scrollingSpeed = 0f;
    Material myMaterial;
    Vector2 offSet;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        myMaterial = GetComponent<Renderer>().material;
        while (scrollingSpeed <= 0.5f)
        {
            offSet = new Vector2(0, scrollingSpeed);
            scrollingSpeed += 0.01f;
            yield return new WaitForSeconds(5);
        }
    }

    // Update is called once per frame
    void Update()
    {
        myMaterial.mainTextureOffset += offSet * Time.deltaTime;
    }
}


