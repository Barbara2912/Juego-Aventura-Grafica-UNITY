using UnityEngine;
using TMPro; // Importar el espacio de nombres de TextMesh Pro
using UnityEngine.UI;
using System.Collections.Generic; // Para usar List<T>

public class GameManager : MonoBehaviour
{
    public TMP_InputField apodoInputField; // Campo de entrada para el apodo
    public TMP_Dropdown rolDropdown; // Dropdown para seleccionar el rol
    public GameObject canvas; // Canvas de entrada
    public GameObject canvasDatos; // Canvas donde se mostrarán los datos
    public GameObject nota; // Objeto de la nota
    public GameObject puerta; // Objeto de la puerta
    public TextMeshProUGUI apodoText;
    public TextMeshProUGUI rolText;

    void Start()
    {
        // Asegurarse de que el Dropdown tenga las opciones iniciales
        rolDropdown.ClearOptions(); // Limpia las opciones actuales
        rolDropdown.AddOptions(new List<string> { "Elige un rol", "Detective", "Investigador paranormal" });
        rolDropdown.value = 0; // 0 es la opción de "Elige un rol"

        // Asegúrate de que el canvas de datos esté oculto al inicio
        canvasDatos.SetActive(false);
    }

    // Conectar el botón con el GameManager en el apartado OnClick()/ GameManager OnSubmit
    public void OnSubmit() 
{
    // Verifica si el apodo o el rol son válidos
    if (string.IsNullOrEmpty(apodoInputField.text) || rolDropdown.value == 0)
    {
        Debug.Log("Por favor, completa el apodo y selecciona un rol.");
    }
    else
    {
        Debug.Log("Datos guardados: Apodo - " + apodoInputField.text + ", Rol - " + rolDropdown.options[rolDropdown.value].text);
        
        // Almacena los datos en GameData
        GameData.apodo = apodoInputField.text;
        GameData.rol = rolDropdown.options[rolDropdown.value].text;

        DisableRoleSelection(); // Desactiva la opción "Elige un rol"
        HideCanvas(); // Oculta el canvas de entrada
        ShowDatos(); // Muestra el canvas con los datos
    }
}

    private void DisableRoleSelection()
    {
        // Elimina la opción de "Elige un rol" solo si está activa
        if (rolDropdown.options.Count > 0 && rolDropdown.options[0].text == "Elige un rol")
        {
            rolDropdown.options.RemoveAt(0); // Elimina la opción en la posición 0
        }

        // Actualiza el valor del Dropdown a la nueva primera opción
        rolDropdown.value = 0; // Establece el valor al nuevo primer rol (que ahora es el segundo en la lista)

        // Desactiva el Dropdown para que no se pueda seleccionar más
        rolDropdown.interactable = false; // Mantiene el Dropdown interactivo para ver la selección
    }

    private void HideCanvas()
    {
        canvas.SetActive(false);  // Oculta el Canvas
    }

    private void ShowDatos()
    {
        canvasDatos.SetActive(true); // Muestra el canvas con los datos
       

        // Establece los textos con los datos ingresados
        apodoText.text = "Apodo: " + GameData.apodo;
        rolText.text = "Rol: " + GameData.rol;
    }

    public void InteractWithObject(string objectName)
    {
        if (objectName == "nota")
        {
            Debug.Log("Has encontrado una nota.");
            // Aquí puedes añadir animaciones o lógica adicional
        }
        else if (objectName == "puerta")
        {
            Debug.Log("Yendo a la sala de operaciones...");
            // Aquí puedes añadir animaciones o lógica adicional
        }
    }
}





