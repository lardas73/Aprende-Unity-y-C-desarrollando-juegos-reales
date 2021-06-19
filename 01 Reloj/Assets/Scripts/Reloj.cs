using System;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Reloj : MonoBehaviour {

    // Referencia al Transform de la aguja de horas
    [SerializeField] private Transform horas;

    // Referencia al Transform de la aguja de minutos
    [SerializeField] private Transform minutos;

    // Referencia al Transform de la aguja de segundos
    [SerializeField] private Transform segundos;

    // Sonidos de la aguja de segundos
    [SerializeField] private AudioClip[] sonidosSegundero;

    // Indicador de cuál fue el último tic (1 o 2) que se reprodujo
    private int ultimoTic = 2;

    // Grados que gira cada aguja al moverse una posición
    private float gradosPorHora = 30f;
    private float gradosPorMinuto = 6f;
    private float gradosPorSegundo = 6f;

    //private AudioSource _audioSource;

    private void Start()
    {
        this.ActualizarReloj();
        //_audioSource = this.GetComponent<AudioSource>();
    }

    private void Update()
    {
        this.ActualizarReloj();
    }

    private void ActualizarReloj()
    {
        // Obtengo la hora actual del sistema
        DateTime horaActual = DateTime.Now;

        // Si hace falta, emito el sonido de la aguja de segundos
        this.ReproducirSonidoDeReloj(horaActual);

        // Roto las agujas según la hora actual
        RotarAgujas(horaActual);
    }

    private void RotarAgujas(DateTime horaActual)
    {
        this.horas.localRotation = Quaternion.Euler(0f, horaActual.Hour * this.gradosPorHora, 0f);
        this.minutos.localRotation = Quaternion.Euler(0f, horaActual.Minute * this.gradosPorMinuto, 0f);
        this.segundos.localRotation = Quaternion.Euler(0f, horaActual.Second * this.gradosPorSegundo, 0f);
    }

    private void ReproducirSonidoDeReloj(DateTime horaActual)
    {
        if (this.segundos.localRotation != Quaternion.Euler(0f, horaActual.Second * this.gradosPorSegundo, 0f))
        {
            // Alterno el sonido a reproducir, entre los 2 sonidos de tic
            if (this.ultimoTic == 1)
            {
                this.GetComponent<AudioSource>().PlayOneShot(this.sonidosSegundero[1]);
                this.ultimoTic = 2;
            }
            else
            {
                this.GetComponent<AudioSource>().PlayOneShot(this.sonidosSegundero[0]);
                this.ultimoTic = 1;
            }
        }
    }
}