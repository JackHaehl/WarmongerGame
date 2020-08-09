using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconBehaviour : MonoBehaviour
{
    private float limit = 1.3f;
    private float totalTime = 0;
    // Start is called before the first frame update
    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (totalTime < limit)
        {
            gameObject.GetComponent<Image>().color = new Color32(255,255,255,(byte)(255*(limit-totalTime)/limit));
            totalTime += Time.deltaTime;
            gameObject.transform.position += new Vector3(0, 0.015f * (limit - totalTime) * (limit - totalTime), 0);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    
}
