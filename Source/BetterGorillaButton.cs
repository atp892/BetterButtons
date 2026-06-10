using GorillaExtensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
public class BetterGorillaButton : MonoBehaviour
{
    public float Delay = 0.3f;
    private float time = 0f;
    public TextMeshPro text;
    public Vector3 offset;
    public Color OnButtonPressColor;
    public Color IdleColor;
    public virtual void Awake() 
    { 
        if (text == null)
        {
            GameObject textObject = new GameObject();
            textObject.transform.parent = transform;
            textObject.transform.localPosition = offset;
            textObject.transform.localEulerAngles = transform.forward;
            text = textObject.AddComponent<TextMeshPro>();
        }
    }
    public virtual void OnButtonPress()
    {
        StartCoroutine(Color());
    }
    public virtual IEnumerator Color()
    {
        gameObject.GetComponent<MeshRenderer>().material.color = OnButtonPressColor;
        yield return new WaitForSeconds(Delay);
        gameObject.GetComponent<MeshRenderer>().material.color = IdleColor;
    }
    public void OnTriggerEnter(Collider other)
    {
        if (time > Time.time && other == GorillaTagger.Instance.rightHandTriggerCollider || other == GorillaTagger.Instance.leftHandTriggerCollider)
        {
            time = Time.time + Delay;
            OnButtonPress();
            if (GorillaTagger.Instance.rightHandTriggerCollider == other) GorillaTagger.Instance.offlineVRRig.PlayHandTapLocal(67, false, 0.2f);
            else GorillaTagger.Instance.offlineVRRig.PlayHandTapLocal(67, true, 0.2f);
        }
    }
}

