using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mail;
using UnityEngine;
using StarterAssets;

public class FakeWallScript : MonoBehaviour
{
    public GameObject wall;
    public GameObject triggerWall;
    public GameObject fakeWall;
    public float fadeSpeed, fadeAmount, fadewait;
    Renderer renderer;
    private Material material;
    public bool StonekeyUse = false;
    public GameObject StoneKeyUI;
    

    private void Start()
    {
        material = wall.GetComponent<Renderer>().material;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent<ThirdPersonController>(out var controller))
        {
            return;
        }
        else
        {
            StartCoroutine(DestroyFakeWall());
        }
    }
    IEnumerator DestroyFakeWall()
    {
        Debug.Log("debut");
        Color currentColor = material.color;
        Color smoothColor = new Color(currentColor.r, currentColor.g, currentColor.b, Mathf.Lerp(currentColor.a, fadeAmount, fadeSpeed));
        material.color = smoothColor;
        yield return new WaitForSeconds(fadewait);
        if (currentColor.a <= 0.2f)
        {
            Destroy(fakeWall);
            if (StonekeyUse)
            {
                StartCoroutine(StoneKeyShow());
            }
            
        }
        else
        {
            Debug.Log(currentColor.a);
            StartCoroutine(DestroyFakeWall());
        }
    }

    private IEnumerator StoneKeyShow()
    {
        StoneKeyUI.SetActive(true);
        yield return new WaitForSeconds(2);
        StoneKeyUI.SetActive(false);
        Destroy(triggerWall);
    }






}
