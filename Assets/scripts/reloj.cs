using System;
using UnityEngine;

public class reloj : MonoBehaviour
{
    [Header("Manecillas del Reloj")]
    public Transform manecillaHoras;
    public Transform manecillaMinutos;
    public Transform manecillaSegundos;

    [Header("Configuración")]
    public bool usarHoraReal = true;
    public int horaManual = 12;
    public int minutoManual = 0;

    void Update()
    {
        DateTime tiempoActual;

        if (usarHoraReal)
        {
            // Opción A: Usar hora real del sistema
            tiempoActual = DateTime.Now;
        }
        else
        {
            // Opción B: Usar hora manual del mundo VR
            tiempoActual = new DateTime(2024, 1, 1, horaManual, minutoManual, 0);
            // Incrementar segundos manualmente
            tiempoActual = tiempoActual.AddSeconds(Time.time);
        }

        // Calcular ángulos de rotación
        float segundos = tiempoActual.Second;
        float minutos = tiempoActual.Minute;
        float horas = tiempoActual.Hour % 12; // Formato 12 horas

        // Rotación suave de las manecillas
        float anguloSegundos = segundos * 6f; // 360° / 60 = 6° por segundo
        float anguloMinutos = (minutos * 6f) + (segundos * 0.1f); // Movimiento suave
        float anguloHoras = (horas * 30f) + (minutos * 0.5f); // 360° / 12 = 30° por hora

        // Aplicar rotaciones (eje Z para reloj 2D en pared)
        if (manecillaSegundos != null)
            manecillaSegundos.localRotation = Quaternion.Euler(0, 0, -anguloSegundos);

        if (manecillaMinutos != null)
            manecillaMinutos.localRotation = Quaternion.Euler(0, 0, -anguloMinutos);

        if (manecillaHoras != null)
            manecillaHoras.localRotation = Quaternion.Euler(0, 0, -anguloHoras);
    }
}