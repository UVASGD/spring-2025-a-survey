
using System;
using System.Runtime.CompilerServices;
using UdonSharp;
using UnityEngine;
using UnityEngine.UI;
using VRC.SDKBase;
using VRC.Udon;

public class Colliders : UdonSharpBehaviour
{
    public GameObject[] targets;
    public int walkthroughLayer = 17;
    public int defaultLayer = 0;
    
    
    public void Toggle()
    {
        foreach (var target in targets)
        {
            target.layer = target.layer == walkthroughLayer ? defaultLayer : walkthroughLayer;
        } 
    }
}
