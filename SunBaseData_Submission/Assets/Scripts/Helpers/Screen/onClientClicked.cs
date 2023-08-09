using UnityEngine;
using TMPro;

public class onClientClicked : MonoBehaviour
{
    public void ClientClicked(TextMeshProUGUI id)
    {
        int intid = int.Parse(id.text) - 1;
        int clientid = SetupUi.obj.clients[intid].id;
        try
        {
            print(SetupUi.obj.data[clientid].name + " " + SetupUi.obj.data[clientid].points + " " + SetupUi.obj.data[clientid].address);
            ClientInfoScreen.Instance.showClientInfo(SetupUi.obj.data[clientid].name, SetupUi.obj.data[clientid].points, SetupUi.obj.data[clientid].address);
        }
        catch {
            print("N/A");
        }
    }
}
