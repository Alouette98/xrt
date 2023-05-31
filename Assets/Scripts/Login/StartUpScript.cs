using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartUpScript : MonoBehaviour
{
    // Start is called before the first frame update
    
    [SerializeField]
    public GameObject logoCanvas;

    [SerializeField] public GameObject welcomeCanvas;
    
    void Start()
    {
        StartUpBehaviour();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void StartUpBehaviour()
    {
        // Debug.LogWarning("--Start up button clicked--");
        StartCoroutine(LogoDisappear());
    }

    IEnumerator LogoDisappear()
    {
        yield return new WaitForSeconds(1.5f);
        logoCanvas.SetActive(false);
        welcomeCanvas.SetActive(true);
    }
}
