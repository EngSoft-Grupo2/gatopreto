using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProjetoGatoPreto;

public class infoFlip : MonoBehaviour {

    private int fps = 60;
    private float degreePerSec = 180f;
    private const float FLIP_LIMIT_DEGREE = 180f;
    private const float FLIP_DEGREE = 90f;

    private bool isFaceUp, isFlipping, isImageFlipped = false;

    private float waitTime;

	// Use this for initialization
	void Start () {
        waitTime = 1.0f / fps;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClick()
    {
        if (isFlipping)
        {
            return;
        }
        StartCoroutine( flip() );
    }

    IEnumerator flip()
    {
        isFlipping = true;
        isImageFlipped = false;

        bool done = false;
        while (!done)
        {
            float degree = degreePerSec * Time.deltaTime;
            if (isFaceUp)
            {
                degree = -degree;
            }

            transform.Rotate(new Vector3(0, degree, 0));

            if (!isImageFlipped)
            {
                if (!isFaceUp && FLIP_DEGREE < transform.eulerAngles.y)
                {
                    isImageFlipped = true;
                    transform.GetChild(0).SetSiblingIndex(1);
                }
                else if (isFaceUp && FLIP_DEGREE > transform.eulerAngles.y)
                {
                    isImageFlipped = true;
                    transform.GetChild(0).SetSiblingIndex(1);
                }
            }
            

            if (FLIP_LIMIT_DEGREE < transform.eulerAngles.y)
            {
                done = true;
            }
            yield return new WaitForSeconds(waitTime);
        }

        isFaceUp = !isFaceUp;
        isFlipping = false;
    }
}
