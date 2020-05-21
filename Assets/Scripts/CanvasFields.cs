using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasFields : MonoBehaviour
{
    [SerializeField]
    private UnityEngine.UI.Text goldText;
    [SerializeField]
    private UnityEngine.UI.Text farmscountText;

    public UnityEngine.UI.Text FarmsCountText => farmscountText;

    
    public UnityEngine.UI.Text GoldText => goldText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
