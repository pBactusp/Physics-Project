/*
 Name:		Sketch1.ino
 Created:	21-Nov-18 3:20:49 PM
 Author:	User
*/



bool GettingData = false;
byte commandNum;
byte arg1;
byte arg2;
byte arg3;
byte arg4;

float Sensor1Data = 0;

int InputPin = 7;


void setup()
{
	pinMode(InputPin, INPUT);
	Serial.begin(9600);
}

void loop()
{
	if (Serial.available() == 5)
	{
		ReadCommand();

		switch (commandNum)
		{
		case 0:
			Serial.print("boi");
			break;

		case 1:
			GettingData = true;
			SendData();
			break;

		case 2:
			GettingData = false;
			break;

		}
	}

	SendData();
}


void ReadCommand()
{
	commandNum = Serial.read();
	delay(1);
	arg1 = Serial.read();
	delay(1);
	arg2 = Serial.read();
	delay(1);
	arg3 = Serial.read();
	delay(1);
	arg4 = Serial.read();
}

void SendData()
{
	while (GettingData)
	{
		Serial.print(digitalRead(InputPin));
		commandNum = Serial.read();

		if (commandNum == 1)
		{
			GettingData = false;
		}
		delay(10);
	}
}
