using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Points : MonoBehaviour
{
    // VARIABLES
    public float pointage = 0; // Le pointage
    public List<GameObject> dechets = new List<GameObject>(); // Liste des dechets

    public TextMeshProUGUI lesPoints;

    void Start()
    {
        dechets.AddRange(GameObject.FindGameObjectsWithTag("dechet1"));
        dechets.AddRange(GameObject.FindGameObjectsWithTag("dechet2"));
        dechets.AddRange(GameObject.FindGameObjectsWithTag("dechet3"));

        GameObject pointageObject = GameObject.FindGameObjectWithTag("pointage");
        if (pointageObject != null)
        {
            lesPoints = pointageObject.GetComponent<TextMeshProUGUI>();
        }
        else
        {
            Debug.LogError("No GameObject found with tag 'pointage'");
        }

        Debug.Log("Points script started. Collider is trigger: " + GetComponent<Collider>().isTrigger);
    }

    private void OnTriggerEnter(Collider infoTrigger)
    {
        if (infoTrigger.gameObject.CompareTag("dechet1") ||
            infoTrigger.gameObject.CompareTag("dechet2") ||
            infoTrigger.gameObject.CompareTag("dechet3"))
        {
            pointage++;
            Destroy(infoTrigger.gameObject);
            Debug.Log("Trigger entered by: " + infoTrigger.gameObject.name); // Debug log
        }
    }

    private void Update()
    {
        if (lesPoints != null)
        {
            lesPoints.text = pointage.ToString();
        }
    }
}