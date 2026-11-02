using UnityEngine;

public class GameManager3 : MonoBehaviour
{
    public static GameManager3 Instancia { get; private set; }

    [Header("Paneles UI")]
    [SerializeField] private GameObject panelGameOver;

    void Awake()
    {
        if (Instancia == null)
        {
            Instancia = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        if (panelGameOver != null)
        {
            panelGameOver.SetActive(false);
        }
    }

    public void ActivarGameOver()
    {
        if (panelGameOver != null)
        {
            panelGameOver.SetActive(true);
        }
    }
}