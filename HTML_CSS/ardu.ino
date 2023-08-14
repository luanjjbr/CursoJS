const int butPin1 = 6;
const int butPin2 = 7;
const int potPin = A0;

void setup() {
  Serial.begin(9600);
  pinMode(butPin1, INPUT);
  pinMode(butPin2, INPUT);
  digitalWrite(butPin1, HIGH);
  digitalWrite(butPin2, HIGH);
}

void loop() {
  int potValue = analogRead(potPin);

  if ((digitalRead(butPin1) == LOW) && (digitalRead(butPin2) == LOW)) {
    Serial.write('0');  // Differentiating button press from potentiometer data
    delay(100);  // Adjust delay as needed
  } else if (digitalRead(butPin1) == LOW) {
    Serial.write('1');
    delay(100);
  } else if (digitalRead(butPin2) == LOW) {
    Serial.write('2');
    delay(100);
  }
  
  Serial.print("P");
  Serial.println(potValue);
  delay(100);
}
