using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamier : MonoBehaviour
{
    RectTransform myRectTransform;
    bool flip = false;
    

    // Start is called before the first frame update
    void Start()
    {
        myRectTransform = this.GetComponent<RectTransform>();
        //myRectTransform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (myRectTransform.localPosition.x > 0 && !flip || myRectTransform.localPosition.x < 0 && flip  ){
            this.transform.localScale = Vector3.Scale(this.transform.localScale, (new Vector3(-1f, 1f,1f)));
            flip = !flip;
        }
    }
}
