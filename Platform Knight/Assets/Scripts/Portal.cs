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
        FaderSystem fader = FindObjectOfType<FaderSystem>();
        yield return fader.FadeOut();
        yield return SceneManager.LoadSceneAsync(sceneToLoad);
        Portal portalOnWhichToSpawn = GetCorrespondingPortal();
        UpdatePlayerLocation(portalOnWhichToSpawn);
        yield return new WaitForSeconds(timeToWaitForFader);
        yield return fader.FadeIn();
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

    private void UpdatePlayerLocation(Portal portalOnWhichToSpawn)
    {
        GameObject player = GameObject.FindWithTag(GameConstants.PLAYER_TAG);
        player.transform.position = portalOnWhichToSpawn.spawnPoint.transform.position;
    }

}
