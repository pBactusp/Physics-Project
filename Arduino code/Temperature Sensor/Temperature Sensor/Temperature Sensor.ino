/*
 Name:		Temperature_Sensor.ino
 Created:	21-Nov-18 12:49:20 PM
 Author:	User
*/


#include <OneWire.h>

int tSensor = 10;
OneWire ow(tSensor);

byte data[12];
byte addr[8];


void setup()
{
	Serial.begin(9600);
}

void loop()
{
	if (!ow.search(addr)) {
		Serial.println("No more addresses.");
		Serial.println();
		ow.reset_search();
		delay(250);
		return;
	}


}
