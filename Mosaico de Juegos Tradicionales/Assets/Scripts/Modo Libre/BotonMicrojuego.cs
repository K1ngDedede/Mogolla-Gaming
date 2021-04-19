using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class BotonMicrojuego : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    NombreMicrojuego nombreMicrojuego;
    void Update()
    {
        
    }
  
    public void OnPointerEnter(PointerEventData eventData)
    {
        MenuModoLibre.ActualizarTitulo(ConfigUtils.BuscarMicrojuego(nombreMicrojuego).nombre);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        MenuModoLibre.ActualizarTitulo("Seleccione un juego");
    }

    public void CargarEscenaInformativa()
    {
        ConfigUtils.MicrojuegoActual = ConfigUtils.BuscarMicrojuego(nombreMicrojuego);
        SceneManager.LoadScene("detalleMicrojuego");
    }
}
