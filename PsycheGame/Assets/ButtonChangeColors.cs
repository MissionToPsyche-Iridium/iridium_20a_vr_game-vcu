using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonChangeColors : MonoBehaviour {
    public MeshRenderer buttonRenderer;
    public Material redMaterial;
    public Material greenMaterial;

    public void SetToGreen() {
        buttonRenderer.material = greenMaterial;
    }

    public void SetToRed(){
        buttonRenderer.material = redMaterial;
    }
}
