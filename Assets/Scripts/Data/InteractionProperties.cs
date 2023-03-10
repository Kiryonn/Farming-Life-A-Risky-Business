using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Propri�t�s des int�ractions",menuName = "Data/Propri�t�s des int�ractions")]  
public class InteractionProperties : ScriptableObject
{
    [ColorUsage(true,true)]
    public Color taskColor;
    [ColorUsage(true, true)]
    public Color itemColor;
    [ColorUsage(true, true)]
    public Color otherColor;
}
