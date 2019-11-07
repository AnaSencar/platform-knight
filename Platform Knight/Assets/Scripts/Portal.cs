using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    enum PortalDestinationLink
    {
        A, B, C, D
    }

    [SerializeField] private string sceneToLoad;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private PortalDestinationLink portalDestinationLink;
    [SerializeField] private float timeToWaitForFader;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == GameConstants.PLAYER_TAG)
        {
            StartCoroutine(SwitchScene());
        }
    }

    private IEnumerator SwitchScene()
    {
        DontDestroyOnLoad(gameObject);
        GameObject player = GameObject.FindWithTag(GameConstants.PLAYER_TAG);
        FaderSystem fader = FindObjectOfType<FaderSystem>();
        EnableOrDisablePlayerMovementAndAttack(player, false);
        yield return fader.FadeOut();
        yield return SceneManager.LoadSceneAsync(sceneToLoad);
        FindObjectOfType<CameraSetup>().SetPlayerAndBackground();
        Portal portalOnWhichToSpawn = GetCorrespondingPortal();
        UpdatePlayerLocation(portalOnWhichToSpawn, player);
        yield return new WaitForSeconds(timeToWaitForFader);
        yield return fader.FadeIn();
        EnableOrDisablePlayerMovementAndAttack(player, true);
        Destroy(gameObject);
    }

    private Portal GetCorrespondingPortal()
    {
        foreach(Portal portal in FindObjectsOfType<Portal>())
        {
            if (portal == this)
            {
                continue;
            }
            if (portalDestinationLink == portal.portalDestinationLink)
            {
                return portal;
            }
        }
        return null;
    }

    private void UpdatePlayerLocation(Portal portalOnWhichToSpawn, GameObject player)
    {
        player.transform.position = portalOnWhichToSpawn.spawnPoint.transform.position;
    }

    private void EnableOrDisablePlayerMovementAndAttack(GameObject player, bool shouldEnable)
    {
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        player.GetComponent<Animator>().SetBool(GameConstants.ISWALKING_ANIM_PAR, false);
        player.GetComponent<PlayerMovement>().enabled = shouldEnable;
        player.GetComponent<PlayerAttack>().enabled = shouldEnable;
    }

}
