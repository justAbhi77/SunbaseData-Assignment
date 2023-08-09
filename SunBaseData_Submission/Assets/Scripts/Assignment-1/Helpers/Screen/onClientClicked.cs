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
            if (SetupUi.obj.data.ContainsKey(clientid))
                ClientInfoScreen.Instance.showClientInfo(SetupUi.obj.data[clientid].name, SetupUi.obj.data[clientid].points, SetupUi.obj.data[clientid].address);
            else
                ClientInfoScreen.Instance.showClientInfo();
        }
        catch
        {
            print("N/A");
        }
    }
}
