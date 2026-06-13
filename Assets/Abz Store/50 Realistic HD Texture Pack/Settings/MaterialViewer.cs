using UnityEngine;
using TMPro;

public class MaterialViewer : MonoBehaviour
{
    [Header("Objects")]
    public GameObject sphere;
    public GameObject cube;

    [Header("Materials")]
    public Material[] materials;

    [Header("UI")]
    public TMP_Text materialNameText;

    private int currentMaterialIndex = 0;
    private bool showingSphere = true;

    private Renderer sphereRenderer;
    private Renderer cubeRenderer;

    private void Start()
    {
        sphereRenderer = sphere.GetComponent<Renderer>();
        cubeRenderer = cube.GetComponent<Renderer>();

        ShowSphere();
        ApplyMaterial();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            NextMaterial();
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            PreviousMaterial();
        }
    }

    public void ToggleShape()
    {
        showingSphere = !showingSphere;

        if (showingSphere)
            ShowSphere();
        else
            ShowCube();

        ApplyMaterial();
    }

    private void ShowSphere()
    {
        sphere.SetActive(true);
        cube.SetActive(false);
    }

    private void ShowCube()
    {
        sphere.SetActive(false);
        cube.SetActive(true);
    }

    public void NextMaterial()
    {
        if (materials.Length == 0) return;

        currentMaterialIndex++;

        if (currentMaterialIndex >= materials.Length)
            currentMaterialIndex = 0;

        ApplyMaterial();
    }

    public void PreviousMaterial()
    {
        if (materials.Length == 0) return;

        currentMaterialIndex--;

        if (currentMaterialIndex < 0)
            currentMaterialIndex = materials.Length - 1;

        ApplyMaterial();
    }

    private void ApplyMaterial()
    {
        if (materials.Length == 0) return;

        Material currentMaterial = materials[currentMaterialIndex];

        sphereRenderer.material = currentMaterial;
        cubeRenderer.material = currentMaterial;

        if (materialNameText != null)
        {
            materialNameText.text = currentMaterial.name.Replace(" (Instance)", "");
        }
    }
}