using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class salto : MonoBehaviour
{
    public float pulo;
    public float velocidade;
    public int lives;
    public int rings;
    public Text TextLives;
    public Text TextRings;
    
    public bool contador_pulo;


    
    // Start is called before the first frame update
    void Start()
    {
        TextLives.text = lives.ToString();
        TextRings.text = rings.ToString();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
        if(Input.GetKeyDown(KeyCode.Space) && !contador_pulo ){ //Comparação se apertou espaço e personagem não está no ar
        GetComponent<Rigidbody2D>().AddForce(new Vector2(0,pulo));
        GetComponent<AudioSource>().Play();//Quando pula, da um play no som
        }
      
        float movimento = Input.GetAxis("Horizontal"); 
        GetComponent<Rigidbody2D>().velocity = new Vector2(movimento*velocidade,GetComponent<Rigidbody2D>().velocity.y);
        //Debug.Log(movimento);
        if(movimento < 0){
            GetComponent<SpriteRenderer>().flipX = true;
        }else{
            GetComponent<SpriteRenderer>().flipX = false;
            
        }
        if(movimento < 0 || movimento > 0){
            GetComponent<Animator>().SetBool("walking",true);
        }else{
            GetComponent<Animator>().SetBool("walking",false);
        }
    }

    //funçao chamada sempre que o objeto "player" colide com um objeto.
    void OnCollisionEnter2D(Collision2D collision2D) {
        
        Debug.Log("colidiu com "+collision2D.gameObject.tag);
        //CÓDIGO PARA PERDER VIDA AO TOCAR EM UM MOSNTRO
        //if(collision2D.gameObject.CompareTag("monstro")){
        //    lives = lives - 1;
        //    TextLives.text = lives.ToString();
        //}
        //CÓDIGO PARA GANHAR MOEDAS QUANDO TOCAR NA MOEDA
        //if(collision2D.gameObject.CompareTag("anel")){
        //    rings++;
        //    TextRings.text = rings.ToString();
        //}
        //CÓDIGO PARA PULO
        if(collision2D.gameObject.CompareTag("plataforma")){
            
            GetComponent<salto>().contador_pulo = false; 
       
        }
        //FIM CODIGO PARA PULO

    }
    
    //função chamada sempre que o objeto "player" para de colidir com um objeto
    void OnCollisionExit2D(Collision2D collision2D) {
        Debug.Log("Parou de colidir com "+collision2D.gameObject.tag);
        //não dar pulo infinito
        //CÓDIGO PARA NÃO DAR PULO
        if(collision2D.gameObject.CompareTag("plataforma")){
        
            GetComponent<salto>().contador_pulo = true;
        }
        //FIM CODIGO PARA NAO DAR PULO
        
    }
}
