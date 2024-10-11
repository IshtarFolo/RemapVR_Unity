using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Points : MonoBehaviour
{
    // VARIABLES
    public float pointage = 0; // Le pointage
    public List<GameObject> dechets = new List<GameObject>(); // Liste des dechets

    public TextMeshProUGUI lesPoints;

    public AudioClip dechetFin;
    public AudioClip citrouilleFin;

    void Start()
    {
        dechets.AddRange(GameObject.FindGameObjectsWithTag("dechet1"));
        dechets.AddRange(GameObject.FindGameObjectsWithTag("dechet2"));
        dechets.AddRange(GameObject.FindGameObjectsWithTag("dechet3"));
        //Tag pour la citrouille qui enlèvera des points
        dechets.AddRange(GameObject.FindGameObjectsWithTag("citrouille"));
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
            GetComponent<AudioSource>().PlayOneShot(dechetFin, 1f);
            Destroy(infoTrigger.gameObject);
            Debug.Log("Trigger entered by: " + infoTrigger.gameObject.name); // Debug log
        }

        //Jeter la citrouille enlevera des points
        else if (infoTrigger.gameObject.CompareTag("citrouille"))
        {
            pointage--;
            GetComponent<AudioSource>().PlayOneShot(citrouilleFin, 1f);
            Destroy(infoTrigger.gameObject);
        }
    }

    private void Update()
    {
        if (lesPoints != null)
        {
            lesPoints.text = "Ramasse les déchets !\r\nNe jette pas les citrouilles, ou tu seras le prochain sacrifice !\r\n\r\n" + pointage.ToString() + "points";
        }
    }
}