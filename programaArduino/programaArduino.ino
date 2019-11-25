#define LEDPin 13
String SerialInput;
void setup()
{
  pinMode(LEDPin, OUTPUT);
  // serial communication
  Serial.begin(9600);
}

void loop()
{
  while(Serial.available()){
    //read from serial port
    SerialInput = Serial.readString();
    //verify incomingOption
    if(SerialInput=="alexisseguridad123"){
      digitalWrite(LEDPin, HIGH);
    }
    else if(SerialInput=="karlaseguridad123"){
      digitalWrite(LEDPin, HIGH);
    }
  }
}
