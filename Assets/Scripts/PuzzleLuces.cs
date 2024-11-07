using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleLuces : MonoBehaviour
{
    public List<Toggle> toggles;
    public Sprite spriteApagado;
    public Sprite spriteEncendido;
    public Button[] botones;
    public GameObject canvasPuzzle;
    public GameObject imagenConCollider;

    private BoxCollider2D boxCollider;

    void Start()
    {
        boxCollider = imagenConCollider.GetComponent<BoxCollider2D>();

        foreach (var toggle in toggles)
        {
            Image imagenToggle = toggle.transform.Find("Background").GetComponent<Image>();
            if (imagenToggle != null)
            {
                imagenToggle.sprite = spriteApagado;
            }
            else
            {
                Debug.LogError("No se encontró el componente Image en el objeto Background del toggle: " + toggle.name);
            }
        }

        for (int i = 0; i < botones.Length; i++)
        {
            int index = i;
            botones[index].onClick.AddListener(() => ActivarToggles(GetTogglesForButton(index)));
        }

        canvasPuzzle.SetActive(false);
    }

    private int[] GetTogglesForButton(int buttonIndex)
    {
        switch (buttonIndex)
        {
            case 0: return new int[] { 0, 1, 2 };
            case 1: return new int[] { 3, 4, 5 };
            case 2: return new int[] { 6, 7, 8 };
            case 3: return new int[] { 9, 10, 11 };
            case 4: return new int[] { 12, 13, 14 };
            default: return new int[0];
        }
    }

    void ActivarToggles(int[] indicesToggles)
    {
        foreach (int index in indicesToggles)
        {
            if (index >= 0 && index < toggles.Count)
            {
                Toggle toggle = toggles[index];
                toggle.isOn = !toggle.isOn;

                Image imagenToggle = toggle.transform.Find("Background").GetComponent<Image>();
                if (imagenToggle != null)
                {
                    imagenToggle.sprite = toggle.isOn ? spriteEncendido : spriteApagado;
                }
            }
        }

        ComprobarPuzzleResuelto();
    }

    void ComprobarPuzzleResuelto()
    {
        bool puzzleResuelto = true;
        foreach (Toggle toggle in toggles)
        {
            if (!toggle.isOn)
            {
                puzzleResuelto = false;
                break;
            }
        }

        if (puzzleResuelto)
        {
            Debug.Log("Puzzle resuelto");
        }
    }

    void Update()
    {
        // Detectar clic izquierdo del ratón
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (boxCollider != null && boxCollider.OverlapPoint(mousePos))
            {
                // Abrir el canvas al tocar la imagen
                canvasPuzzle.SetActive(true);
            }
        }
    }

    public void SalirCanvas()
    {
        canvasPuzzle.SetActive(false);
    }
}
