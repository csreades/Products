/******************************************************************************************
	Title:		    		LP50 Standard printing script
	Author:		    	GJ Pixdro BV
	Date:		      	05 March 2008
	Description:	This script performs a default printing job on the LP50 inkjet printer. Also print
						simulation is handled
	Version:      		$Revision: 40 $
*******************************************************************************************/

public void Initialize()
{


}

public void Execute()
{

    string serial_port = Parameters.GetValue("HeadAssy.COMPORT");
    SerialPort port = new SerialPort(serial_port, 1000000);
	bool success = false;
	while(!success){
                try {
                    port.Open ();
                    success = true;
                } catch (Exception otherProblem) {
                    Logger.Log ("Other exception: " + otherProblem);
                }
	}
    string messageToSend = "r";
    messageToSend += "\r\n";
    port.Write(messageToSend);
    Logger.Log(messageToSend);
    Thread.Sleep(50);
    //Check for any data on the port
    string s = port.ReadExisting();
    int drop_count = 0;
    while(s.Length < 1){
    s = port.ReadExisting();
    drop_count++;
    Thread.Sleep(1);
    if(drop_count > 1000){
        break;
    }
    }
    Logger.Log("RX " + s);
    port.Close();
	
	
	port.Open();
    messageToSend = "U 1";
    messageToSend += "\r\n";
    port.Write(messageToSend);
    Logger.Log(messageToSend);
    Thread.Sleep(50);
    //Check for any data on the port
    s = port.ReadExisting();
    drop_count = 0;
    while(s.Length < 1){
    s = port.ReadExisting();
    drop_count++;
    Thread.Sleep(1);
    if(drop_count > 1000){
        break;
    }
    }
    Logger.Log("RX " + s);
    port.Close();
	
	
	
}