using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionsUI : MonoBehaviour
{
    public GameObject instructions;
    private bool isShowing = false;
    // Start is called before the first frame update
    void Start()
    {
        //instructions = GetComponent<InstructionsUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            isShowing = !isShowing;
            instructions.SetActive(isShowing);
        }
    }
}
