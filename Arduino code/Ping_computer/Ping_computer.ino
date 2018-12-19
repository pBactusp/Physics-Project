
bool GettingData = false;
byte commandNum;
byte arg1;
byte arg2;
byte arg3;
byte arg4;

const int trigPin = 23;
const int echoPin = 22;

void setup()
{
  pinMode(trigPin, OUTPUT); // Sets the trigPin as an Output
  pinMode(echoPin, INPUT); // Sets the echoPin as an Input
  
  Serial.begin(9600);
}

void loop() 
{
  while(Serial.available() != 5){delay(1);}
  
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
  
  delay(10);
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
  float duration;
  
  for (int i = 2; i > 0 && GettingData; i--)
  {
    digitalWrite(trigPin, LOW);
    digitalWrite(echoPin, LOW);
    delayMicroseconds(2);
    
    // Sets the trigPin on HIGH state for 10 micro seconds
    digitalWrite(trigPin, HIGH);
    delayMicroseconds(10);
    digitalWrite(trigPin, LOW);
    
    // Reads the echoPin, returns the sound wave travel time in microseconds
    duration = pulseIn(echoPin, HIGH);
  }
  
  while (GettingData)
  {
    /*if (digitalRead(InputPin) == HIGH)
    {
      //Serial.print(50, DEC);
      Serial.print(2.031f, 5);
      digitalWrite(LedPin, HIGH);
    }
    else
    {
      Serial.print(0);
      digitalWrite(LedPin, LOW);
    }*/

    // Clears the trigPin
    digitalWrite(trigPin, LOW);
    digitalWrite(echoPin, LOW);
    delayMicroseconds(2);
    
    // Sets the trigPin on HIGH state for 10 micro seconds
    digitalWrite(trigPin, HIGH);
    delayMicroseconds(10);
    digitalWrite(trigPin, LOW);
    
    // Reads the echoPin, returns the sound wave travel time in microseconds
    duration = pulseIn(echoPin, HIGH);
    
    Serial.print(duration*0.017);

    
    while(Serial.available() == 0){delay(1);}
    commandNum = Serial.read();

    if (commandNum == 1)
    {
      GettingData = false;
    }
    delay(10);
  }
}
