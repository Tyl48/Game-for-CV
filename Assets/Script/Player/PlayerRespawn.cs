using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerRespawn : MonoBehaviour
{
    [SerializeField] private AudioClip checkpoint;
    private Transform currentCheckpoint;
    private Health playerHealth;
    private UIManager uiManager;
    

    private void Awake()
    {
        playerHealth = GetComponent<Health>();
        uiManager = FindObjectOfType<UIManager>();
    }

    public void RespawnCheck()
    {
        //check if check point available
        if (currentCheckpoint == null)
        {
            // Show game over screen
            uiManager.gameOver();
            return;
        }

        transform.position = currentCheckpoint.position;
        playerHealth.Respawn();

        // move to camera to checkpoint room
        Camera.main.GetComponent<CameraController>().MoveToNewRoom(currentCheckpoint.parent);
    }

    //public void RespawnCheck()
    //{
    //    if (currentCheckpoint == null)
    //    {
    //        uiManager.GameOver();
    //        return;
    //    }

    //    playerHealth.Respawn(); //Restore player health and reset animation
    //    transform.position = currentCheckpoint.position; //Move player to checkpoint location

    //    //Move the camera to the checkpoint's room
    //    Camera.main.GetComponent<CameraController>().MoveToNewRoom(currentCheckpoint.parent);
    //}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Checkpoint")
        {
            currentCheckpoint = collision.transform;
            SoundManager.instance.PlaySound(checkpoint);
            collision.GetComponent<Collider2D>().enabled = false;
            collision.GetComponent<Animator>().SetTrigger("appear");
        }
    }
}
