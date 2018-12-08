//Biến dùng để lưu chuỗi
char buffer[64] = {};
//Chiều dài chuỗi
int stlen;
void setup()
{
	//Mở cổng serial
	Serial.begin(9600);
}

void loop()
{
	//Nếu có tín hiệu vào từ Serial
	if (Serial.available()>0) {
		//Đọc tín hiệu đó vào buffer
		stlen = Serial.available();
		Serial.readBytes(buffer, stlen);
		//Xuất ra Serial ngược lại
		for (int i = 1; i<stlen + 1; i++) Serial.print(buffer[stlen - i]);
		//Xuống hàng
		Serial.println("");
		//Nghỉ mệt
		delay(500);
	}
	else {
		//Chưa có gì hết
		Serial.println("Chua co gi!");
		//Nghỉ mệt
		delay(5000);
	}

}