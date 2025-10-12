# Screen Streamer

## Data Structures

### V1
Array of Pixels

```
class Pixel //(10 bytes)
{
	short X // 2 bytes
	short Y // 2 bytes
	short R // 2 bytes
	short G // 2 bytes
	short B // 2 bytes
}
```

Data send via UDP is array of pixels

### V2
Y value associated with array of pixels

```
class Row
{
	short X // 2 bytes
	Pixel[] Pixels // 5 bytes * number of pixels
}

class Pixel
{
	short X // 2 bytes
	byte R // 1 byte
	byte G // 1 byte
	byte B // 1 byte
}

```

Data send via UDP is single row

### V3
```
class Delta
{
	byte Version // 1 byte
	short Size // 2 bytes total size of frame
	Row[] Rows // 4 bytes * number of rows
}

class Row
{
	short X // 2 bytes
	short PixelCount // 2 bytes
	Pixel[] Pixels // 5 bytes * number of pixels
}

class Pixel
{
	short X // 2 bytes
	byte R // 1 byte
	byte G // 1 byte
	byte B // 1 byte
}
```

Data send via UDP is a single Delta instance