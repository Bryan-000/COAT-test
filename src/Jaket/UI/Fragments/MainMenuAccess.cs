namespace Jaket.UI.Fragments;

using UnityEngine;
using UnityEngine.UI;

using Jaket.Net;
using Jaket.UI.Dialogs;
using Coat.UI.Dialogs;

/// <summary> Access to the mod functions through the main menu. </summary>
public class MainMenuAccess : CanvasSingleton<MainMenuAccess>
{
    /// <summary> Table containing the access buttons. </summary>
    private Transform table;
    private Button lobbies;
    private Button gamemodes;
    /// <summary> Main menu table. </summary>
    private GameObject menu;

    private void Start()
    {
        GetComponent<CanvasScaler>().screenMatchMode = CanvasScaler.ScreenMatchMode.Expand;

        table = UIB.Rect("Access Table", transform, new(0f, -364f, 720f, 40f));
        table.gameObject.AddComponent<HudOpenEffect>();

        UIB.Button("#lobby-tab.join", table, new(-182f, 0f, 356f, 40f), clicked: LobbyController.JoinByCode).targetGraphic.color = new(1f, .1f, .9f);
        UIB.Button("#lobby-tab.list", table, new(182f, 0f, 356f, 40f), clicked: LobbyList.Instance.Toggle).targetGraphic.color = new(1f, .4f, .8f);


        lobbies = UIB.Button("COAT LOBBIES", transform, new(-432f, -270f, 110f, 110f), clicked: LobbyListCoat.Instance.Toggle);
        gamemodes = UIB.Button("GAME MODES", transform, new(-432f, -150f, 110f, 110f), clicked: LobbyGameList.Instance.Toggle);
        lobbies.targetGraphic.color = new(0f, .5f, 1f);
        gamemodes.targetGraphic.color = new(0f, .5f, 1f);
    }

    private void Update() {
        table.gameObject.SetActive(menu.activeSelf);
        lobbies.gameObject.SetActive(menu.activeSelf);
        gamemodes.gameObject.SetActive(menu.activeSelf);
    }

    /// <summary> Toggles visibility of the access table. </summary>
    public void Toggle()
    {
        gameObject.SetActive(Shown = Scene == "Main Menu");
        if (Shown) (menu = ObjFind("Main Menu (1)")).transform.Find("Panel").transform.localPosition = new(0f, -292f, 0f);
    }
}
