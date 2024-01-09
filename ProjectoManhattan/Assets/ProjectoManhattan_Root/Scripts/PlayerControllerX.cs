using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    //Variables de referencia
    Rigidbody2D playerRb;
    Animator anim;
    float horizontalInput;

    [Header("Movement & Jump")]
    public float speed;
    public float jumpForce;
    bool isFacingRight = true;

    [SerializeField] bool isGrounded;
    [SerializeField] GameObject groundCheck;//Un objeto que detecta el suelo
    [SerializeField] LayerMask groundLayer; //Sirve para decirle al personaje cuál es la capa suelo
    [SerializeField] float groundCheckRadius = 0.1f; //Define el radio de 


    // Start is called before the first frame update

    private void Awake() //Va antes de start
    {
        playerRb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        groundCheck = GameObject.Find("GroundCheck");//Encuentra el object que hemos creado como hijo de Player
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.transform.position, groundCheckRadius, groundLayer); ;  //Physics2D dibuja figuras geometricas invisibles
        //isGrounded va a ser verdadero     //Desde dónde?                   ,Radio?           , qué capa va a detectar? 
        anim.SetBool("Jump", !isGrounded);
        Movement(); // LAS FÍSICAS DEBERÍAN IR EN EL FIXED UPDATE
        Jump();
        if (horizontalInput > 0) //Si 
        {
            if (!isFacingRight)
            {
                Flip();
            }
        }
        if (horizontalInput < 0)
        {
            if (isFacingRight)

            {
                Flip();
            }
        }

    }

    void Movement()
    {
        //Referenciar el INPUT
        horizontalInput = Input.GetAxis("Horizontal"); // Rellenamos la variable del input horizontal
        playerRb.velocity = new Vector2(horizontalInput * speed, playerRb.velocity.y); //El valor Y representa el valor que tenga la posY del player en cada momento, no queremos modificarla
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse); //Definimos el tipo de fuerza (Impulse para salto) después de definir que el salto es moverse en vertical * jumpforce
        };
    }

    void Flip()
    {
        Vector3 currentScale = transform.localScale; //Esta variable es igual a nuestra escala actual
        currentScale.x *= -1; //Invierte el X de currentScale
        transform.localScale = currentScale;
        isFacingRight = !isFacingRight; //Invierte el valor del booleano isFacingRight
    }

}
