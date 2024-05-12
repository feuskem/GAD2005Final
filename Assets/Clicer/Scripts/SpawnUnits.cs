using UnityEngine;

public class SpawnUnits : MonoBehaviour
{
    public GameObject[] units;
    private int selectedUnitIndex = 0;

    public void SelectUnit(int index)
    {
        selectedUnitIndex = index;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Instantiate(units[selectedUnitIndex], hit.point + Vector3.up * 2, Quaternion.identity);
            }
        }
    }
}