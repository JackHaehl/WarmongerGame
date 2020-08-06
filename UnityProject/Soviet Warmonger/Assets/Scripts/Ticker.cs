using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Ticker : MonoBehaviour {

    public TickerItem tickerItemPrefab;
    [Range(1f, 10f)]
    public float itemDuration = 3.0f;
    public string[] fillerItems;

    float width;
    float pixelsPerSecond;
    TickerItem currentItem;

    // Start is called before the first frame update
    void Start()
    {
        width = GetComponent<RectTransform>().rect.width;
        pixelsPerSecond = width / itemDuration;
        AddTickerItem(fillerItems[0]);
    }

    // Update is called once per frame
    void Update()
    {
        UnityEngine.Debug.Log(currentItem.GetXPosition);
        UnityEngine.Debug.Log(currentItem.GetXPosition - currentItem.GetWidth);
        if (currentItem.GetXPosition <= currentItem.GetXPosition - currentItem.GetWidth)
        {
            AddTickerItem(fillerItems[Random.Range(0, fillerItems.Length)]);
        }
    }

    void AddTickerItem(string message)
    {
        currentItem = Instantiate(tickerItemPrefab, transform);
        currentItem.Initialize(width, pixelsPerSecond, message);
    }
}
