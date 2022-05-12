using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invisibility : MonoBehaviour
{
    public GameObject player;

    private SkinnedMeshRenderer rend;

    public Material invisFace;
    public Material invisBody;

    void Start()
    {
        rend = GetComponent<SkinnedMeshRenderer>();
        rend.enabled = true;
    }

    void Update()
    {
        var materials = rend.materials;

        if (Input.GetKeyDown(KeyCode.H))
        {
            materials[0] = invisBody;
            materials[1] = invisFace;
        }
    }
}
