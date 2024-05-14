using UnityEngine;
using System.Collections;

public class SpawnUnits : MonoBehaviour
{
    public GameObject[] units;
      public int[] unitManpowerCosts;
    private int selectedUnitIndex = 0;
    private Coroutine increaseManpowerCoroutine;

    int manpower = 250;


    private void Start()
    {
        StartCoroutine(IncreaseManpowerOverTime());
    }


    public void SelectUnit(int index)
    {
        selectedUnitIndex = index;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (manpower >= unitManpowerCosts[selectedUnitIndex]) 
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    Instantiate(units[selectedUnitIndex], hit.point + Vector3.up * 2, Quaternion.identity);
                    manpower -= unitManpowerCosts[selectedUnitIndex]; 
                    Debug.Log("Manpower remaining: " + manpower);
                }
            }
            else
            {
                Debug.Log("Not enough manpower to spawn this unit.");
            }
        }
        if (manpower < 1000 && increaseManpowerCoroutine == null)
        {
            increaseManpowerCoroutine = StartCoroutine(IncreaseManpowerOverTime());
        }
    }

     private IEnumerator IncreaseManpowerOverTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(3); 

            if (manpower >= 1000)
            {
                increaseManpowerCoroutine = null;
                yield break;
            }

            manpower += 10; 
            Debug.Log("Manpower increased: " + manpower);
        }
    }
}