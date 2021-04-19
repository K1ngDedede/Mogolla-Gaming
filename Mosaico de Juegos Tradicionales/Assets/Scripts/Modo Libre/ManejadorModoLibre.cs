using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class ManejadorModoLibre
{
    public static void Ganar()
    {
        SceneManager.LoadScene("victoriaModoLibre");
    }

    public static void Perder()
    {
        SceneManager.LoadScene("derrotaModoLibre");
    }
}
