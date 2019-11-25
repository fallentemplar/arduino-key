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
    SerialInput = Serial.readString();
    
    if(SerialInput=="D959C03BF6CC65498B0C023E7C734144"){
      digitalWrite(LEDPin, HIGH);
      Serial.println("Y");
    }
    else if(SerialInput=="karlaseguridad123"){
      digitalWrite(LEDPin, HIGH);
      Serial.println("Y");
    }else{
    
      Serial.println("N");
    }
  }
}
