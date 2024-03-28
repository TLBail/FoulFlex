void setup() {
  // put your setup code here, to run once:
  Serial.begin(9600);

pinMode(LED_BUILTIN, OUTPUT);

   digitalWrite(LED_BUILTIN, HIGH);  // turn the LED on (HIGH is the voltage level)
  delay(1000);                      // wait for a second
  digitalWrite(LED_BUILTIN, LOW);   // turn the LED off by making the voltage LOW
  delay(1000); 
}

void loop() {

  if(Serial.available()){
    if(Serial.read() == "1"){
        digitalWrite(LED_BUILTIN, HIGH);  // turn the LED on (HIGH is the voltage level)
        delay(1000);                      // wait for a second
      digitalWrite(LED_BUILTIN, LOW);   // turn the LED off by making the voltage LOW
      delay(1000); 
    }
  }
}
