using UnityEngine;
using System.Collections;

public class Click : MonoBehaviour
{

    float thrust = FuchiUtils.thrust;
    int counter = FuchiUtils.counter;
    //private float rot = 0.0f;
	float x0 = FuchiUtils.x0;
	float x1 = FuchiUtils.x1;
	float y0 = FuchiUtils.y0;
	float y1 = FuchiUtils.y1;
	Fase fase = FuchiUtils.Fase;
    void Update()
	{
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider != null)
            {
                counter++;
                if (counter == 10)
                {
					Ganar();
                    Debug.Log("Victoria");
                }
                float x = Random.Range(x0, x1);
                float y = Random.Range(y0, y1);
                hit.collider.attachedRigidbody.AddForce(new Vector2(x, y).normalized * thrust, ForceMode2D.Impulse);
                hit.collider.attachedRigidbody.angularVelocity = Random.Range(-350.5f, 350.0f);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Abajo")
        {
            this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
            this.gameObject.GetComponent<Rigidbody2D>().angularVelocity = 0.0f;
			Perder();
            Debug.Log("Fin");
        }
    }
	
	private void Ganar()
    {
        switch (fase)
        {
            case Fase.FASE1:
                ManejadorFase1.AumentarMicrojuegosJugados();
                ManejadorFase1.RevisarFinFase();
                break;
            case Fase.FASE2:
                //llamar manejador de fase 2
                break;
            case Fase.FASE3:
                //llamar manejador de fase 3
                break;
        }
    }
	
	private void Perder()
    {
        //timerJuego.Stop();
        switch (fase)
        {
            case Fase.FASE1:
                ManejadorFase1.PerderVida();
                ManejadorFase1.AumentarMicrojuegosJugados();
                ManejadorFase1.RevisarFinFase();
                break;
            case Fase.FASE2:
                //llamar manejador de fase 2
                break;
            case Fase.FASE3:
                //llamar manejador de fase 3
                break;
        }
        
    }
}