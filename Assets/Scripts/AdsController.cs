using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Monetization;


public class AdsController : MonoBehaviour
{
    private string storedId = "3534768";
    private static string videoId = "video";

    private void Start()
    {
        Monetization.Initialize(storedId, true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            VideAd();
        }
    }

    private static void VideAd()
    {
        if (Monetization.IsReady(videoId))
        {
            ShowAdPlacementContent ad = null;
            ad = Monetization.GetPlacementContent(videoId) as ShowAdPlacementContent;

            if ( ad != null )
            {
                ad.Show();
            }
        }
        else
        {
            Debug.Log("AD Not Ready!");
        }
    }
}
